using QuizVersus.Core.Data;
using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Repositories.Abstract;
using QuizVersus.Core.Repositories.Interfaces;

namespace QuizVersus.Core.Repositories
{
    public class QuizRepository : GenericRepository<Quiz>, IQuizRepository
    {
        public QuizRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
