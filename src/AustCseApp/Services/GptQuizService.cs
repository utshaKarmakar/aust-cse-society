using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AustCseApp.Models;
using Microsoft.Extensions.Configuration;

namespace AustCseApp.Services
{
    public class GptQuizService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public GptQuizService(IConfiguration config, IHttpClientFactory factory)
        {
            _http = factory.CreateClient();
            _http.Timeout = TimeSpan.FromSeconds(60);

            // ✅ Unified API key loading and validation
            _apiKey = (config["OpenAI:ApiKey"]
                      ?? Environment.GetEnvironmentVariable("OPENAI_API_KEY")
                      ?? "").Trim();

            if (string.IsNullOrWhiteSpace(_apiKey) || !_apiKey.StartsWith("sk-"))
                throw new Exception("Missing or invalid OpenAI API key.");
        }

        public async Task<QuizPayload> GenerateQuizAsync(string topic, string difficulty, int count)
        {
            var system = @"You are a careful examiner for CSE students.
Return ONLY JSON that matches the provided schema.
Questions must be factual, testable, and unambiguous.
Prefer MCQs with 4 options. Include concise explanations.";

            var user = $@"Make a quiz.
topic: {topic}
difficulty: {difficulty}
count: {count}

Return strictly valid JSON in this schema:
{{
  ""topic"": ""string"",
  ""difficulty"": ""string"",
  ""questions"": [
    {{
      ""id"": 1,
      ""type"": ""mcq"",
      ""stem"": ""Which statement about ...?"",
      ""options"": [""opt A"", ""opt B"", ""opt C"", ""opt D""],
      ""correctIndex"": 2,
      ""explanation"": ""1–2 sentence why.""
    }}
  ]
}}";

            // --- Chat Completions API (JSON mode) ---
            var payload = new
            {
                model = "gpt-4o-mini", // ✅ stable model
                messages = new object[]
                {
                    new { role = "system", content = system },
                    new { role = "user",   content = user   }
                },
                response_format = new { type = "json_object" },
                temperature = 0.2
            };

            // ✅ Request with validated API key
            var req = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            req.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
            req.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            var res = await _http.SendAsync(req);
            var body = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new InvalidOperationException($"OpenAI error {(int)res.StatusCode}: {body}");

            // ✅ Parse: choices[0].message.content contains the JSON object string
            using var doc = JsonDocument.Parse(body);
            var choices = doc.RootElement.GetProperty("choices");
            if (choices.GetArrayLength() == 0)
                throw new InvalidOperationException("OpenAI returned no choices.");

            var content = choices[0].GetProperty("message").GetProperty("content").GetString() ?? "{}";

            var quiz = JsonSerializer.Deserialize<QuizPayload>(
                content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return quiz ?? new QuizPayload();
        }
    }
}
