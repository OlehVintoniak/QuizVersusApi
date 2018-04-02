using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QuizVersus.Core.Data;
using QuizVersus.Core.Data.Consts;
using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Data.Enums;

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
            SeedUsers(context);
            SeedCategories(context);
            SeedQuestions(context);

            base.Seed(context);
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Any()) return;

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string password = "1z1z1z";

            var adminRole = new IdentityRole { Name = Role.Admin };
            var userRole = new IdentityRole { Name = Role.User };

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(adminRole);
                roleManager.Create(userRole);
            }

            // Default Admin
            var admin = new ApplicationUser { Email = "admin@gmail.com", UserName = "admin@gmail.com", FirstName = "Oleg", LastName = "Vintoniak" };
            var resultAdmin = userManager.Create(admin, password);
            if (resultAdmin.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, userRole.Name);
            }

            // Default Users
            var users = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Petro", "Petrenko"),
                new KeyValuePair<string, string>("Vasyl", "Vasylenko"),
                new KeyValuePair<string, string>("Ivan", "Ivanenko"),
                new KeyValuePair<string, string>("Dima", "Dinuch")
            };

            foreach (var user in users)
            {
                var applicationUser = new ApplicationUser
                {
                    Email = $"{user.Key}@gmail.com",
                    UserName = $"{user.Key}@gmail.com",
                    FirstName = user.Key,
                    LastName = user.Value
                };
                var resultUser = userManager.Create(applicationUser, password);
                if (resultUser.Succeeded)
                {
                    userManager.AddToRole(applicationUser.Id, userRole.Name);
                }
            }
        }

        private void SeedCategories(ApplicationDbContext context)
        {
            if (context.Categories.Any()) return;

            var categories = new List<string>
            {
                "History","Science","Geography"
            };
            foreach (var category in categories)
            {
                var c = new Category
                {
                    Name = category
                };
                context.Categories.Add(c);
            }
        }

        private void SeedQuestions(ApplicationDbContext context)
        {
            if (context.Questions.Any()) return;

            var questions = new List<Question>
            {
                new Question
                {
                    Text = "Capital of Great Britian?",
                    Answer1 = "Kyiv",
                    Answer2 = "London",
                    Answer3 = "Toronto",
                    Answer4 = "Moscow",
                    CategoryId = 3,
                    CorrectAnswer = CorrectAnswer.Second,
                    Difficult = Difficult.Easy
                },
                new Question
                {
                    Text = "When GWW II was started?",
                    Answer1 = "1999",
                    Answer2 = "1945",
                    Answer3 = "1633",
                    Answer4 = "1939",
                    CategoryId = 2,
                    CorrectAnswer = CorrectAnswer.Fourth,
                    Difficult = Difficult.Medium
                }
            };
            context.Questions.AddRange(questions);
        }
    }
}
