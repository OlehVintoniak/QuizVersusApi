using QuizVersus.Core.Data;
using QuizVersus.Core.Repositories.Interfaces;

namespace QuizVersus.Core.Repositories.Factory
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;

        #region PrivateFields

        private IApplicationUserRepository _applicationUserRepository;
        private ICategoryRepository _categoryRepository;
        private IQuestionRepository _questionRepository;
        private IQuizRepository _quizRepository;

        #endregion

        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Public Preperties

        public IApplicationUserRepository ApplicationUsers
            => _applicationUserRepository ?? (_applicationUserRepository = new ApplicationUserRepository(_context));

        public ICategoryRepository Categories
            => _categoryRepository ?? (_categoryRepository = new CategoryRepository(_context));

        public IQuestionRepository Questions
            => _questionRepository ?? (_questionRepository = new QuestionRepository(_context));

        public IQuizRepository Quizes
            => _quizRepository ?? (_quizRepository = new QuizRepository(_context));

        #endregion
    }
}
