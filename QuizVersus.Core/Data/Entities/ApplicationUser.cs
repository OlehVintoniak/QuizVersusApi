using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QuizVersus.Core.Data.Entities.Abstract;

namespace QuizVersus.Core.Data.Entities
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Quiz> SendedQuizes { get; set; }
        public virtual ICollection<Quiz> ReceivedQuizes { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
