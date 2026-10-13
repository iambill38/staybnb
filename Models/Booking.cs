using System;

namespace Staybnb.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal PricePerNight { get; set; }
        public decimal CleaningFee { get; set; } = 50;
        public decimal ServiceFee { get; set; } = 25;
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public string HostApprovalComments { get; set; } = string.Empty;

        // Foreign Keys
        public string GuestId { get; set; } = string.Empty;
        public User Guest { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }

        // Navigation Properties
        public GuestDocument GuestDocument { get; set; }
        public Payment? Payment { get; set; }
    }
}