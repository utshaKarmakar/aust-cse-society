using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AustCseApp.Models;
using AustCseApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AustCseApp.Controllers
{
    [Route("Quiz")]
    public class QuizController : Controller
    {
        private readonly GptQuizService _gpt;

        public QuizController(GptQuizService gpt) { _gpt = gpt; }

        [HttpGet("")]
        public IActionResult Index() => View(new QuizStartVm());

        [HttpPost("start")]
        public async Task<IActionResult> Start(QuizStartVm vm)
        {
            if (!ModelState.IsValid) return View("Index", vm);

            // (Optional) add moderation of 'Topic' here using OpenAI Moderation API. :contentReference[oaicite:4]{index=4}

            var quiz = await _gpt.GenerateQuizAsync(vm.Topic, vm.Difficulty, vm.Count);

            // store in session
            HttpContext.Session.Set("quiz", JsonSerializer.SerializeToUtf8Bytes(quiz));

            return View("Take", quiz);
        }

        [HttpPost("submit")]
        public IActionResult Submit([FromForm] QuizSubmission sub)
        {
            if (!HttpContext.Session.TryGetValue("quiz", out var bytes))
                return RedirectToAction("Index");

            var quiz = JsonSerializer.Deserialize<QuizPayload>(bytes)!;
            var score = quiz.questions
                            .Select((q, i) => (q, i))
                            .Count(t => t.i < sub.answers.Count && sub.answers[t.i] == t.q.correctIndex);

            var result = new QuizResultVm { Quiz = quiz, Answers = sub.answers, Score = score };
            return View("Result", result);
        }
    }
}
