using System;

namespace Staybnb.Models
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string AltText { get; set; } = string.Empty;
        public bool IsPrimary { get; set; } = false;
        public DateTime DateUploaded { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}