using System;

namespace Staybnb.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsRead { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReadDate { get; set; }
        public string RelatedLink { get; set; } = string.Empty;

        // Foreign Key
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }
    }
}