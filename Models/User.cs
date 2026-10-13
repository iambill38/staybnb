using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Staybnb.Models
{
    public class User : IdentityUser
    {
        // Custom properties
        public string FullName { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public string CurrentRole { get; set; } = "Guest"; // Default role for new users

        // Navigation Properties (relationships to other tables)
        public ICollection<Property> Properties { get; set; } = new List<Property>();
        public ICollection<HostApplication> HostApplications { get; set; } = new List<HostApplication>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();
    }
}