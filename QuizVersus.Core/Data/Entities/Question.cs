using QuizVersus.Core.Data.Entities.Abstract;
using QuizVersus.Core.Data.Enums;
using System.Collections.Generic;

namespace QuizVersus.Core.Data.Entities
{
    public class Question : Entity<int>
    {
        public string Text { get; set; }
        public Difficult Difficult { get; set; }
        public int CategoryId { get; set; }

        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public CorrectAnswer CorrectAnswer { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Quiz> Quizes { get; set; } = new List<Quiz>();
    }
}
