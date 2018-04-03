using QuizVersus.Core.Data.Entities.Abstract;
using System.Collections.Generic;

namespace QuizVersus.Core.Data.Entities
{
    public class Quiz : Entity<int>
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public int? SenderResult { get; set; }
        public int? ReciverResult { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
