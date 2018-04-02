using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Repositories.Abstract;
using QuizVersus.Core.Repositories.Interfaces;
using QuizVersus.Core.Services.Abstract;
using QuizVersus.Core.Services.Interfaces;

namespace QuizVersus.Core.Services
{
    public class ApplicationUserService : EntityService<IApplicationUserRepository, ApplicationUser>, IApplicationUserService
    {
        public ApplicationUserService(IUnitOfWork unitOfWork, IApplicationUserRepository repository)
            : base(unitOfWork, repository) { }
        
    }
}
