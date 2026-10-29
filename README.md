# Staybnb

Staybnb is an Airbnb-style accommodation booking platform built as a college project for Programming 742. Guests can browse and book properties, hosts can list and manage them, and admins oversee the platform.

## Tech Stack

- ASP.NET Core MVC (C#)
- Entity Framework Core (Code First with migrations)
- SQL Server (LocalDB)
- ASP.NET Core Identity for authentication and roles
- Bootstrap and Bootstrap Icons

## Features

**Accounts and roles**
- Register, log in and log out with ASP.NET Core Identity
- Four roles: Guest, Host, Admin and SuperAdmin
- Access denied page for restricted areas

**Guests**
- Browse properties and view property details with photos
- Book a stay, with prices shown in South African Rand
- View and track bookings under My Bookings
- Four-step online check-in wizard with document upload
- Message hosts directly from a property page
- Apply to become a host

**Hosts**
- Host dashboard and My Properties page
- Activate or deactivate listings
- Configure check-in rules per property
- Approve or reject booking requests
- Review and verify guest check-in documents

**Admins**
- Admin dashboard
- Review host applications and approve or reject them (approval swaps the user from Guest to Host)
- SuperAdmin can promote users to Admin
- Activity logs for logins, registrations and key actions

**Platform**
- In-app notifications with a bell icon and a read/unread state stored in the database
- Messaging inbox with Inbox, Sent, Read and Compose views
- Seeded roles, users and Cape Town property listings on first run

## Getting Started

### Prerequisites

- Visual Studio 2022 or later with the ASP.NET and web development workload
- .NET SDK matching the version in the project file
- SQL Server LocalDB (installed with Visual Studio)

### Setup

1. Clone the repository:
   ```
   git clone https://github.com/iambill38/staybnb.git
   ```
2. Open the solution in Visual Studio.
3. Check the connection string in `appsettings.json`:
   ```
   Server=(localdb)\MSSQLLocalDB;Database=staybnb_db;Trusted_Connection=True;
   ```
4. Restore packages and run the project (F5).

The database is created and migrated automatically on startup, and the seeders add the default roles and sample properties. No manual database setup is needed.

If you prefer to apply migrations manually, run this in the Package Manager Console:
```
Update-Database
```

## Project Structure

```
Controllers/     Account, Home, Properties, Bookings, HostApplication,
                 Admin, Host, CheckIn, HostCheckIns, Documents, Messages
Models/          Entities such as Property, Booking, Payment, Review,
                 Amenity, WishlistItem, GuestCheckIn, GuestDocument, Message
ViewModels/      Form and display models for the views
Views/           Razor views for each controller
Data/            DbContext, migrations and seeders
wwwroot/         Static files, CSS and property images
```

## Image Credits

Property photos are from Unsplash. Credits to the photographers are listed in the project report.

## Author

Billous
Programming 742, Richfield

## Licence

This project was created for educational purposes.
