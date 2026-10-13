using System;

namespace Staybnb.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public string Action { get; set; } = string.Empty; // Default to empty string
        public string Description { get; set; } = string.Empty;
        public string EntityType { get; set; } = string.Empty;
        public int? EntityId { get; set; } // nullable - may not have an entity ID
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string IpAddress { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;

        // Foreign Key
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } // Navigation to User
    }
}