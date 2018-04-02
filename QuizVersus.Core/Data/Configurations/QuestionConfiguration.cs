using QuizVersus.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace QuizVersus.Core.Data.Configurations
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            HasKey(q => q.Id);

            HasRequired(q => q.Category)
                .WithMany(c => c.Questions)
                .HasForeignKey(q => q.CategoryId)
                .WillCascadeOnDelete(false);

            HasMany(q => q.Quizes)
                .WithMany(q => q.Questions);
        }
    }
}
