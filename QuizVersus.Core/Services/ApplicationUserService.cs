using QuizVersus.Core.Data;
using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Repositories;
using QuizVersus.Core.Services.Interfaces;

namespace QuizVersus.Core.Services
{
    public class ApplicationUserService : GenericRepository<ApplicationUser>, IApplicationUserService
    {
        public ApplicationUserService(ApplicationDbContext context)
            : base(context) { }
        
    }
}
