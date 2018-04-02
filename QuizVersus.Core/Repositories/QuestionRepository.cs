using QuizVersus.Core.Data;
using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Repositories.Abstract;
using QuizVersus.Core.Repositories.Interfaces;

namespace QuizVersus.Core.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
