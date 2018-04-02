using QuizVersus.Core.Data;
using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Repositories;
using QuizVersus.Core.Services.Interfaces;

namespace QuizVersus.Core.Services
{
    public class QuestionService : GenericRepository<Question>, IQuestionService
    {
        public QuestionService(ApplicationDbContext context,
            IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        {
        }
    }
}
