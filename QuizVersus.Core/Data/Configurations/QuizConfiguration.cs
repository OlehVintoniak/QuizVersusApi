using QuizVersus.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace QuizVersus.Core.Data.Configurations
{
    public class QuizConfiguration : EntityTypeConfiguration<Quiz>
    {
        public QuizConfiguration()
        {
            HasKey(q => q.Id);

            HasMany(q => q.Questions)
                .WithMany(q => q.Quizes);

            HasRequired(q => q.Sender)
                .WithMany(s => s.SendedQuizes)
                .HasForeignKey(q => q.SenderId)
                .WillCascadeOnDelete(false);

            HasRequired(q => q.Receiver)
                .WithMany(r => r.ReceivedQuizes)
                .HasForeignKey(q => q.ReceiverId)
                .WillCascadeOnDelete(false);
        }
    }
}
