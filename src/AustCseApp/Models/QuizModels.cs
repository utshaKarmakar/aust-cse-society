using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AustCseApp.Models
{
    public class QuizStartVm
    {
        [Required] public string Topic { get; set; } = "";       // e.g., "Python loops" or "LLM basics"
        [Required] public string Difficulty { get; set; } = "easy"; // easy | medium | hard
        [Range(1, 20)] public int Count { get; set; } = 5;
    }

    // What GPT returns (strict JSON)
    public class QuizPayload
    {
        public string topic { get; set; } = "";
        public string difficulty { get; set; } = "";
        public List<QuizQ> questions { get; set; } = new();
    }

    public class QuizQ
    {
        public int id { get; set; }
        public string type { get; set; } = "mcq";        // mcq or truefalse or short
        public string stem { get; set; } = "";
        public List<string> options { get; set; } = new(); // for mcq
        public int correctIndex { get; set; }             // 0-based
        public string explanation { get; set; } = "";
    }

    public class QuizSubmission
    {
        public List<int> answers { get; set; } = new(); // length = #questions; -1 for blank
    }

    public class QuizResultVm
    {
        public QuizPayload Quiz { get; set; } = new();
        public List<int> Answers { get; set; } = new();
        public int Score { get; set; }
    }
}
