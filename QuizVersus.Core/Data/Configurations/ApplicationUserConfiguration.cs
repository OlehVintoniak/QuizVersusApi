using System.Data.Entity.ModelConfiguration;
using QuizVersus.Core.Data.Entities;

namespace QuizVersus.Core.Data.Configurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            HasKey(u => u.Id);
        }
    }
}
