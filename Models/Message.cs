using System;

namespace Staybnb.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime SentDate { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
        public DateTime? ReadDate { get; set; }

        // Foreign Keys
        public string SenderId { get; set; } = string.Empty;
        public User Sender { get; set; }

        public string RecipientId { get; set; } = string.Empty;
        public User Recipient { get; set; }
    }
}
