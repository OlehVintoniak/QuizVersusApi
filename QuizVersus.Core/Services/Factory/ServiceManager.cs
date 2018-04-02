using QuizVersus.Core.Data;
using QuizVersus.Core.Repositories.Abstract;
using QuizVersus.Core.Repositories.Factory;
using QuizVersus.Core.Services.Interfaces;

namespace QuizVersus.Core.Services.Factory
{
    public class ServiceManager : IServiceManager
    {
        private IRepositoryManager _repositoryManager;
        private IUnitOfWork _unitOfWork;

        #region PrivateFields

        private IApplicationUserService _applicationUserService;
        private ICategoryService _categoryService;
        private IQuestionService _questionService;

        #endregion

        public ServiceManager()
        {
            var dbContext = ApplicationDbContext.Create();
            Init(new UnitOfWork(dbContext), new RepositoryManager(dbContext));
        }

        public ServiceManager(IUnitOfWork unitOfWork, IRepositoryManager repositoryManager)
        {
            Init(unitOfWork, repositoryManager);
        }

        private void Init(IUnitOfWork unitOfWork, IRepositoryManager repositoryManager)
        {
            _unitOfWork = unitOfWork;
            _repositoryManager = repositoryManager;
        }

        #region Public Preperties

        public IApplicationUserService ApplicationUserService
            => _applicationUserService ?? (_applicationUserService = new ApplicationUserService(_unitOfWork, _repositoryManager.ApplicationUsers));

        public ICategoryService CategoryService
            => _categoryService ?? (_categoryService = new CategoryService(_unitOfWork, _repositoryManager.Categories));

        public IQuestionService QuestionService
            => _questionService ?? (_questionService = new QuestionService(_unitOfWork, _repositoryManager.Questions));

        #endregion
    }
}
