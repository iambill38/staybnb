using Staybnb.Data;
using Staybnb.Models;

namespace Staybnb.Seeds
{
    public class PropertySeeder
    {
        public static async Task SeedPropertiesAsync(StaybnbDbContext context)
        {
            // Check if properties already exist
            if (context.Properties.Any())
            {
                return;
            }

            // Get a host user (SuperAdmin will host these for demo)
            var host = context.Users.FirstOrDefault(u => u.Email == "superadmin@staybnb.com");
            if (host == null)
            {
                return;
            }

            var properties = new List<Property>
            {
                new Property
                {
                    Title = "Cozy 2-Bedroom Apartment in Downtown",
                    Description = "Beautiful modern apartment in the heart of the city. Perfect for couples or small families. Walking distance to restaurants, shops, and public transport. Fully equipped kitchen, comfortable beds, and a stunning city view from the balcony.",
                    Address = "123 Main Street",
                    City = "Amsterdam",
                    PropertyType = "Apartment",
                    PricePerNight = 85m,
                    MaxGuests = 4,
                    HostId = host.Id,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow
                },
                new Property
                {
                    Title = "Spacious House with Garden",
                    Description = "Lovely 3-bedroom house with a large garden. Great for families or groups. Features a fully equipped kitchen, living room with fireplace, and a patio. Parking available on-site.",
                    Address = "456 Oak Avenue",
                    City = "Amsterdam",
                    PropertyType = "House",
                    PricePerNight = 120m,
                    MaxGuests = 6,
                    HostId = host.Id,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow
                },
                new Property
                {
                    Title = "Luxury Villa with Pool",
                    Description = "Stunning luxury villa with a private pool, hot tub, and panoramic views. Perfect for a special getaway. 4 bedrooms, 3 bathrooms, state-of-the-art kitchen, and a spacious living area.",
                    Address = "789 Hill Drive",
                    City = "Barcelona",
                    PropertyType = "Villa",
                    PricePerNight = 250m,
                    MaxGuests = 8,
                    HostId = host.Id,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow
                },
                new Property
                {
                    Title = "Studio Apartment Near Beach",
                    Description = "Charming studio apartment just a 5-minute walk from the beach. Perfect for a romantic getaway or solo traveler. Modern amenities, beach access, and a balcony with sea views.",
                    Address = "321 Beach Road",
                    City = "Barcelona",
                    PropertyType = "Apartment",
                    PricePerNight = 75m,
                    MaxGuests = 2,
                    HostId = host.Id,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow
                },
                new Property
                {
                    Title = "Charming Cottage in Countryside",
                    Description = "Peaceful cottage surrounded by nature. Ideal for a relaxing retreat. Features a fireplace, garden, and easy access to hiking trails. Fully equipped with modern amenities.",
                    Address = "654 Forest Lane",
                    City = "Paris",
                    PropertyType = "House",
                    PricePerNight = 95m,
                    MaxGuests = 4,
                    HostId = host.Id,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow
                }
            };

            context.Properties.AddRange(properties);
            await context.SaveChangesAsync();

            // Add PropertyImages for each property
            var imagesToAdd = new List<PropertyImage>();

            foreach (var property in properties)
            {
                // CHANGED: working image source, a different photo per property
                imagesToAdd.Add(new PropertyImage
                {
                    PropertyId = property.Id,
                    ImageUrl = $"https://picsum.photos/seed/staybnb-{property.Id}-a/800/600",
                    AltText = property.Title,
                    IsPrimary = true,
                    DateUploaded = DateTime.UtcNow
                });

                // Add a second image for each property
                imagesToAdd.Add(new PropertyImage
                {
                    PropertyId = property.Id,
                    ImageUrl = $"https://picsum.photos/seed/staybnb-{property.Id}-b/800/600",
                    AltText = property.City,
                    IsPrimary = false,
                    DateUploaded = DateTime.UtcNow
                });
            }

            context.PropertyImages.AddRange(imagesToAdd);
            await context.SaveChangesAsync();

            // Add CheckInProcess for each property
            var checkInProcesses = new List<CheckInProcess>();

            foreach (var property in properties)
            {
                checkInProcesses.Add(new CheckInProcess
                {
                    PropertyId = property.Id,
                    RequiredDocuments = "Passport or ID Card",
                    HouseRules = "No smoking indoors. Quiet hours after 10 PM. Respect neighbors' privacy.",
                    CheckInInstructions = "Key available at reception. Check-in after 3 PM.",
                    EarliestCheckInTime = new TimeSpan(15, 0, 0),
                    LatestCheckOutTime = new TimeSpan(11, 0, 0),
                    RequiresGuestVerification = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                });
            }

            context.CheckInProcesses.AddRange(checkInProcesses);
            await context.SaveChangesAsync();
        }
    }
}