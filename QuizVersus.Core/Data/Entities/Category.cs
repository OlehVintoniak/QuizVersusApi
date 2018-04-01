using System.Collections.Generic;
using QuizVersus.Core.Data.Entities.Abstract;

namespace QuizVersus.Core.Data.Entities
{
    public class Category : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public Category()
        {
            Questions = new List<Question>();
        }
    }
}
