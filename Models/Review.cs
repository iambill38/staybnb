using System.ComponentModel.DataAnnotations;

namespace Staybnb.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int PropertyId { get; set; }
        public Property Property { get; set; } = null!;

        public string ReviewerId { get; set; } = string.Empty;
        public User Reviewer { get; set; } = null!;
    }
}