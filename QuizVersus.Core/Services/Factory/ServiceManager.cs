using QuizVersus.Core.Data;
using QuizVersus.Core.Services.Interfaces;

namespace QuizVersus.Core.Services.Factory
{
    public class ServiceManager :  IServiceManager
    {
        private readonly ApplicationDbContext _context;

        #region PrivateFields

        private IApplicationUserService _applicationUserService;

        #endregion

        public ServiceManager(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Public Preperties

        public IApplicationUserService ApplicationUsers
            => _applicationUserService ?? (_applicationUserService = new ApplicationUserService(_context));

        #endregion
    }
}
