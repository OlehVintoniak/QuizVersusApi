using QuizVersus.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace QuizVersus.Core.Data.Configurations
{
    public class CategotyConfiguration : EntityTypeConfiguration<Category>
    {
        public CategotyConfiguration()
        {
            HasKey(c => c.Id);
        }
    }
}
