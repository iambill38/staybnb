using System;

namespace Staybnb.Models
{
    public class HostApplication
    {
        public int Id { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReviewDate { get; set; }
        public string AdminComments { get; set; } = string.Empty;

        // Foreign Keys
        public string ApplicantId { get; set; } = string.Empty;
        public User Applicant { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }

        // CHANGED: nullable, because no admin has reviewed it yet when it's created
        public string? ReviewedByAdminId { get; set; }
        public User? ReviewedByAdmin { get; set; }
    }
}