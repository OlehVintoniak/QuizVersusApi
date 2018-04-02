using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Exceptions;
using QuizVersus.Core.Repositories.Abstract;
using QuizVersus.Core.Repositories.Factory;
using QuizVersus.Core.Repositories.Interfaces;
using QuizVersus.Core.Services.Abstract;
using QuizVersus.Core.Services.Interfaces;

namespace QuizVersus.Core.Services
{
    public class QuestionService : EntityService<IQuestionRepository, Question>, IQuestionService
    {
        private readonly ICategoryRepository _categoryRepository;
        public QuestionService(IUnitOfWork unitOfWork, IRepositoryManager manager)
            : base(unitOfWork, manager.Questions)
        {
            _categoryRepository = manager.Categories;
        }


        public override Question Add(Question question)
        {
            ValidateQuestion(question);
            return base.Add(question);
        }

        public override void Update(Question question)
        {
            ValidateQuestion(question);
            base.Update(question);
        }

        private void ValidateQuestion(Question question)
        {
            var category = _categoryRepository.FindById(question.CategoryId);
            if (category == null)
            {
                throw new CoreException("Category does not exist");
            }
        }
    }
}
