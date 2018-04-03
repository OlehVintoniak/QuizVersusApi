using QuizVersus.Core.Data.Entities;

namespace QuizVersusApi.Models.Quiz
{
    public class QuestionViewModel
    {
        public QuestionViewModel(Question question)
        {
            Id = question.Id;
            Text = question.Text;
            Answer1 = question.Answer1;
            Answer2 = question.Answer2;
            Answer3 = question.Answer3;
            Answer4 = question.Answer4;
            Category = question.Category.Name;
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Category { get; set; }
    }
}