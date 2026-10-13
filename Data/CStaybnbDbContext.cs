using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Staybnb.Models;

namespace Staybnb.Data
{
    public class StaybnbDbContext : IdentityDbContext<User>
    {
        public StaybnbDbContext(DbContextOptions<StaybnbDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<HostApplication> HostApplications { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CheckInProcess> CheckInProcesses { get; set; }
        public DbSet<GuestDocument> GuestDocuments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        // NEW
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Property -> PropertyImage (1-to-many)
            modelBuilder.Entity<PropertyImage>()
                .HasOne(pi => pi.Property)
                .WithMany(p => p.PropertyImages)
                .HasForeignKey(pi => pi.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Property -> CheckInProcess (1-to-1)
            modelBuilder.Entity<CheckInProcess>()
                .HasOne(cp => cp.Property)
                .WithOne(p => p.CheckInProcess)
                .HasForeignKey<CheckInProcess>(cp => cp.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Property -> Booking (1-to-many)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Property)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> Property (1-to-many) - Host has many properties
            modelBuilder.Entity<Property>()
                .HasOne(p => p.Host)
                .WithMany(u => u.Properties)
                .HasForeignKey(p => p.HostId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> HostApplication (1-to-many) - Applicant has many applications
            modelBuilder.Entity<HostApplication>()
                .HasOne(ha => ha.Applicant)
                .WithMany(u => u.HostApplications)
                .HasForeignKey(ha => ha.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade);

            // User (Admin) -> HostApplication (1-to-many) - Admin reviews applications
            modelBuilder.Entity<HostApplication>()
                .HasOne(ha => ha.ReviewedByAdmin)
                .WithMany()
                .HasForeignKey(ha => ha.ReviewedByAdminId)
                .OnDelete(DeleteBehavior.Restrict);

            // Property -> HostApplication (1-to-many)
            modelBuilder.Entity<HostApplication>()
                .HasOne(ha => ha.Property)
                .WithMany()
                .HasForeignKey(ha => ha.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> Booking (1-to-many) - Guest makes many bookings
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Guest)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.GuestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Booking -> GuestDocument (1-to-1)
            modelBuilder.Entity<GuestDocument>()
                .HasOne(gd => gd.Booking)
                .WithOne(b => b.GuestDocument)
                .HasForeignKey<GuestDocument>(gd => gd.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> GuestDocument (1-to-many) - Guest uploads document
            modelBuilder.Entity<GuestDocument>()
                .HasOne(gd => gd.UploadedByUser)
                .WithMany()
                .HasForeignKey(gd => gd.UploadedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User (Host) -> GuestDocument (1-to-many) - Host verifies documents
            modelBuilder.Entity<GuestDocument>()
                .HasOne(gd => gd.VerifiedByHost)
                .WithMany()
                .HasForeignKey(gd => gd.VerifiedByHostId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> Message (1-to-many) - Sender
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> Message (1-to-many) - Recipient
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Recipient)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> Notification (1-to-many)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> ActivityLog (1-to-many)
            modelBuilder.Entity<ActivityLog>()
                .HasOne(al => al.User)
                .WithMany(u => u.ActivityLogs)
                .HasForeignKey(al => al.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- NEW ----------

            // Booking -> Payment (1-to-1)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(p => p.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Property -> Review (1-to-many)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Property)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> Review (1-to-many)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany()
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Property <-> Amenity (many-to-many, EF creates the join table)
            modelBuilder.Entity<Property>()
                .HasMany(p => p.Amenities)
                .WithMany(a => a.Properties);

            // User -> WishlistItem (1-to-many)
            modelBuilder.Entity<WishlistItem>()
                .HasOne(w => w.User)
                .WithMany()
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Property -> WishlistItem (1-to-many)
            modelBuilder.Entity<WishlistItem>()
                .HasOne(w => w.Property)
                .WithMany()
                .HasForeignKey(w => w.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            // A user can wishlist a property only once
            modelBuilder.Entity<WishlistItem>()
                .HasIndex(w => new { w.UserId, w.PropertyId })
                .IsUnique();
        }
    }
}