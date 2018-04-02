using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Repositories.Abstract;
using QuizVersus.Core.Repositories.Interfaces;
using QuizVersus.Core.Services.Abstract;
using QuizVersus.Core.Services.Interfaces;

namespace QuizVersus.Core.Services
{
    public class CategoryService : EntityService<ICategoryRepository, Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository repository)
            : base(unitOfWork, repository) { }

    }
}
