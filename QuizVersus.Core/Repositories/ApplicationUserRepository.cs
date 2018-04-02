using QuizVersus.Core.Data;
using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Repositories.Abstract;
using QuizVersus.Core.Repositories.Interfaces;
using System.Linq;

namespace QuizVersus.Core.Repositories
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext context)
            : base(context) { }

        public string GetRandomReceiversId(string senderId)
        {
            var ids = GetAll()
                .Where(u => u.Id != senderId)
                .Select(u => u.Id)
                .ToArray();
            var receiverIndex = new System.Random().Next(0, ids.Length);
            return ids[receiverIndex];
        }
    }
}
