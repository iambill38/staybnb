using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staybnb.Data;
using Staybnb.Models;

namespace Staybnb.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly StaybnbDbContext _context;

        public PropertiesController(StaybnbDbContext context)
        {
            _context = context;
        }

        // GET: Properties (Browse with filters)
        public async Task<IActionResult> Index(string city = null, string propertyType = null)
        {
            // Get all active properties with their images
            var query = _context.Properties
                .Where(p => p.IsActive)
                .Include(p => p.PropertyImages)
                .Include(p => p.Host)
                .AsQueryable();

            // Filter by city if provided
            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(p => p.City.ToLower().Contains(city.ToLower()));
            }

            // Filter by property type if provided
            if (!string.IsNullOrEmpty(propertyType))
            {
                query = query.Where(p => p.PropertyType.ToLower() == propertyType.ToLower());
            }

            var properties = await query.OrderByDescending(p => p.DateCreated).ToListAsync();

            // Get unique cities and property types for filter dropdowns
            ViewBag.Cities = await _context.Properties
                .Where(p => p.IsActive)
                .Select(p => p.City)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            ViewBag.PropertyTypes = await _context.Properties
                .Where(p => p.IsActive)
                .Select(p => p.PropertyType)
                .Distinct()
                .OrderBy(t => t)
                .ToListAsync();

            ViewBag.SelectedCity = city;
            ViewBag.SelectedPropertyType = propertyType;

            return View(properties);
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var property = await _context.Properties
                .Include(p => p.PropertyImages)
                .Include(p => p.Host)
                .Include(p => p.CheckInProcess)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }
    }
}
