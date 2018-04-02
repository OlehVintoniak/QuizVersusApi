using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Repositories.Abstract;
using QuizVersus.Core.Repositories.Factory;
using QuizVersus.Core.Repositories.Interfaces;
using QuizVersus.Core.Services.Abstract;
using QuizVersus.Core.Services.Interfaces;
using System;

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
            var category = _categoryRepository.FindById(question.CategoryId);
            if(category == null)
            {
                throw new Exception("Category does not exist");
            }
            return base.Add(question);
        }
    }
}
