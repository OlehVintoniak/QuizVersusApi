using QuizVersus.Core.Data.Entities;

namespace QuizVersusApi.Models.Quiz
{
    public class QuestionViewModel
    {
        public string Text { get; set; }

        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }

        public CategoryViewModel Category { get; set; }
    }
    public class CategoryViewModel
    {
        public string Name { get; set; }
    }

}