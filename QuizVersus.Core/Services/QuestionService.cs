using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Repositories.Abstract;
using QuizVersus.Core.Repositories.Interfaces;
using QuizVersus.Core.Services.Abstract;
using QuizVersus.Core.Services.Interfaces;

namespace QuizVersus.Core.Services
{
    public class QuestionService : EntityService<IQuestionRepository, Question>, IQuestionService
    {
        public QuestionService(IUnitOfWork unitOfWork, IQuestionRepository repository)
            : base(unitOfWork, repository) { }
    }
}
