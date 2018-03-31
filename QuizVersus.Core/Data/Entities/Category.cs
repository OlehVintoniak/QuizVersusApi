using QuizVersus.Core.Data.Entities.Abstract;

namespace QuizVersus.Core.Data.Entities
{
    public class Category : Entity<int>
    {
        public string Name { get; set; }
    }
}
