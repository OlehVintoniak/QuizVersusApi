using System.Collections.Generic;

namespace QuizVersusApi.Models.Quiz
{
    public class QuizViewModel
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}