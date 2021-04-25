using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelEntities.Entities;

namespace Travel_Booking.Controllers
{
    public class HotelsController : Controller
    {
        private readonly TravelDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HotelsController(TravelDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            var travelDbContext = _context.Hotel.Include(h => h.City);
            return View(await travelDbContext.ToListAsync());
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel
                .Include(h => h.City)
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityName");
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelId,HotelName,CityId,ImageUploader")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(hotel.ImageUploader.FileName);
                string extension = Path.GetExtension(hotel.ImageUploader.FileName);
                hotel.HotelImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Images/" + fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await hotel.ImageUploader.CopyToAsync(filestream);
                }
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityName", hotel.CityId);
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityName", hotel.CityId);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("HotelId,HotelName,CityId,HotelImage")] Hotel hotel)
        {
            if (id != hotel.HotelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.HotelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityName", hotel.CityId);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel
                .Include(h => h.City)
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(long id)
        {
            return _context.Hotel.Any(e => e.HotelId == id);
        }
    }
}
