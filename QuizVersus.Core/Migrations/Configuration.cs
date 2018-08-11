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
            var admin = new ApplicationUser
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                FirstName = "System",
                LastName = "Admin"
            };
            var resultAdmin = userManager.Create(admin, password);
            if (resultAdmin.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, userRole.Name);
            }
            // Default Users
            var users = new List<KeyValuePair<string, string>>
            {
                //new KeyValuePair<string, string>("Petro", "Petrenko"),
                //new KeyValuePair<string, string>("Vasyl", "Vasylenko"),
                //new KeyValuePair<string, string>("Ivan", "Ivanenko"),
                //new KeyValuePair<string, string>("Dima", "Dinuch")
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
                    Text = "Столица Великобритании:",
                    Answer1 = "Киев",
                    Answer2 = "Лондон",
                    Answer3 = "Торонто",
                    Answer4 = "Москва",
                    CategoryId = 3,
                    CorrectAnswer = CorrectAnswer.Second,
                    Difficult = Difficult.Easy
                },
                new Question
                {
                    Text = "Когда началась вторая мировая война?",
                    Answer1 = "в 1999 году",
                    Answer2 = "в 1945 году",
                    Answer3 = "в 1633 году",
                    Answer4 = "в 1939 году",
                    CategoryId = 1,
                    CorrectAnswer = CorrectAnswer.Fourth,
                    Difficult = Difficult.Medium
                },
                new Question
                {
                    Text = "Индия была колонией:",
                    Answer1 = "Великобритании",
                    Answer2 = "Франции",
                    Answer3 = "Австралии",
                    Answer4 = "Росии",
                    CategoryId = 1,
                    CorrectAnswer = CorrectAnswer.First,
                    Difficult = Difficult.Medium
                },
                new Question
                {
                    Text = "Могут ли существовать две одинаковые снежинки?",
                    Answer1 = "Нет",
                    Answer2 = "Да",
                    Answer3 = "Да, но только внешне. Атомная структура кристаллов все равно будет различной",
                    Answer4 = "Возможно, в параллельной вселенной",
                    CategoryId = 2,
                    CorrectAnswer = CorrectAnswer.Third,
                    Difficult = Difficult.Medium
                },
                new Question
                {
                    Text = "СНГ было создано:",
                    Answer1 = "в 1990 году",
                    Answer2 = "в 1991 году",
                    Answer3 = "в 2000 году",
                    Answer4 = "в 2018 году",
                    CategoryId = 1,
                    CorrectAnswer = CorrectAnswer.Second,
                    Difficult = Difficult.Easy
                },
                new Question
                {
                    Text = "Самая высокая суточная температура плюс +7° С, самая низкая минус 2°С значит, амплитуда равна:",
                    Answer1 = "5° С",
                    Answer2 = "7° С",
                    Answer3 = "9° С",
                    Answer4 = "-2° С ",
                    CategoryId = 3,
                    CorrectAnswer = CorrectAnswer.Third,
                    Difficult = Difficult.Medium
                },
                new Question
                {
                    Text = "Вода на планете Земля образует:",
                    Answer1 = "Гидросферу",
                    Answer2 = "Атмосферу",
                    Answer3 = "Атлантиду",
                    Answer4 = "Космос",
                    CategoryId = 3,
                    CorrectAnswer = CorrectAnswer.First,
                    Difficult = Difficult.Medium
                },
                new Question
                {
                    Text = "Каждый день Земля становится тяжелее. Почему?",
                    Answer1 = "ядро Земли постепенно увеличивается",
                    Answer2 = "Земля поглощает эфир, которые увеличивает ее массу",
                    Answer3 = "Оседает космическая пыль",
                    Answer4 = "Размножения всего живого на планете",
                    CategoryId = 2,
                    CorrectAnswer = CorrectAnswer.Third,
                    Difficult = Difficult.Hard
                },
                new Question
                {
                    Text = "Акция “Золотой плач” имела место:",
                    Answer1 = "в Китае",
                    Answer2 = "в Эльдорадо",
                    Answer3 = "в Испании",
                    Answer4 = "в Индии",
                    CategoryId = 1,
                    CorrectAnswer = CorrectAnswer.Fourth,
                    Difficult = Difficult.Hard
                },
                new Question
                {
                    Text = "Из чего состоят облака?",
                    Answer1 = "Водяных капель и кристалликов льда",
                    Answer2 = "из концентрированного озона",
                    Answer3 = "из космической пыли",
                    Answer4 = "химический состав установить невозможно. Это - условное явление",
                    CategoryId = 2,
                    CorrectAnswer = CorrectAnswer.First,
                    Difficult = Difficult.Medium
                },
                new Question
                {
                    Text = "Самая длинная и полноводная река мира:",
                    Answer1 = "Янцзи",
                    Answer2 = "Нил",
                    Answer3 = "Амазонка",
                    Answer4 = "Волга",
                    CategoryId = 3,
                    CorrectAnswer = CorrectAnswer.Third,
                    Difficult = Difficult.Easy
                },
                new Question
                {
                    Text = "Что способно преодолеть звуковой барьер?",
                    Answer1 = "Будильник",
                    Answer2 = "Мельница",
                    Answer3 = "Кнут",
                    Answer4 = "Велосипед",
                    CategoryId = 2,
                    CorrectAnswer = CorrectAnswer.Third,
                    Difficult = Difficult.Medium
                },
                new Question
                {
                    Text = "СССР прекратил свое существование:",
                    Answer1 = "в 1991 году",
                    Answer2 = "в 1992 году",
                    Answer3 = "в 2001 году",
                    Answer4 = "в 2012 году",
                    CategoryId = 1,
                    CorrectAnswer = CorrectAnswer.First,
                    Difficult = Difficult.Easy
                },
                new Question
                {
                    Text = "Вблизи черных дыр есть фотонная среда. Что (согласно теории) может увидеть человек, если вдруг окажется там?",
                    Answer1 = "момент Большого взрыва",
                    Answer2 = "себя в десятикратном увеличении",
                    Answer3 = "свою спину",
                    Answer4 = "другое измерение",
                    CategoryId = 2,
                    CorrectAnswer = CorrectAnswer.Third,
                    Difficult = Difficult.Hard
                },
                new Question
                {
                    Text = "Самые высокие горы на Земле:",
                    Answer1 = "Альпы",
                    Answer2 = "Гималаи",
                    Answer3 = "Карпаты",

                    Answer4 = "Апаччи",
                    CategoryId = 3,
                    CorrectAnswer = CorrectAnswer.Third,
                    Difficult = Difficult.Easy
                },
            };
            context.Questions.AddRange(questions);
        }
    }
}
