using QuizVersus.Core.Data;
using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Repositories;
using QuizVersus.Core.Services.Interfaces;

namespace QuizVersus.Core.Services
{
    public class CategoryService : GenericRepository<Category>, ICategoryService
    {
        public CategoryService(ApplicationDbContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork) { }

    }
}
