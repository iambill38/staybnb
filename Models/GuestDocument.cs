using System;

namespace Staybnb.Models
{
    public class GuestDocument
    {
        public int Id { get; set; }
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentUrl { get; set; } = string.Empty;
        public string VerificationStatus { get; set; } = "Pending";
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
        public DateTime? VerificationDate { get; set; }
        public string HostComments { get; set; } = string.Empty;

        // Foreign Keys
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        public string UploadedByUserId { get; set; } = string.Empty;
        public User UploadedByUser { get; set; }

        public string VerifiedByHostId { get; set; } = string.Empty;
        public User VerifiedByHost { get; set; }
    }
}