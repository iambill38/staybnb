namespace Staybnb.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;

        public int PropertyId { get; set; }
        public Property Property { get; set; } = null!;
    }
}