using System.ComponentModel.DataAnnotations.Schema;

namespace Staybnb.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Paid, Refunded
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
    }
}