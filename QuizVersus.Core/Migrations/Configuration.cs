using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QuizVersus.Core.Data;
using QuizVersus.Core.Data.Consts;
using QuizVersus.Core.Data.Entities;

namespace QuizVersus.Core.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string password = "1z1z1z";

            var adminRole = new IdentityRole { Name = RoleConsts.Admin };
            var userRole = new IdentityRole { Name = RoleConsts.User };

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(adminRole);
                roleManager.Create(userRole);
            }

            // Default Admin
            var admin = new ApplicationUser { Email = "admin@gmail.com", UserName = "admin@gmail.com", FirstName = "Admin", LastName = "Adminuch" };
            var resultAdmin = userManager.Create(admin, password);
            if (resultAdmin.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, userRole.Name);
            }

            // Default User
            var user = new ApplicationUser { Email = "user@gmail.com", UserName = "user@gmail.com", FirstName = "User", LastName = "Userovuch" };
            var resultUser = userManager.Create(user, password);
            if (resultUser.Succeeded)
            {
                userManager.AddToRole(user.Id, userRole.Name);
            }

            base.Seed(context);
        }
    }
}
