using System;

namespace Staybnb.Models
{
    public class CheckInProcess
    {
        public int Id { get; set; }
        public string RequiredDocuments { get; set; } = string.Empty;
        public string HouseRules { get; set; } = string.Empty;
        public string CheckInInstructions { get; set; } = string.Empty;
        public TimeSpan EarliestCheckInTime { get; set; } = new TimeSpan(15, 0, 0);
        public TimeSpan LatestCheckOutTime { get; set; } = new TimeSpan(11, 0, 0);
        public bool RequiresGuestVerification { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}