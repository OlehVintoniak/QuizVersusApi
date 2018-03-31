using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using QuizVersus.Core.Data.Configurations;
using QuizVersus.Core.Data.Entities;

namespace QuizVersus.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new CategotyConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
