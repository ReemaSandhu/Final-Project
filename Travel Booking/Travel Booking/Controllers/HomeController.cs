using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Travel_Booking.Models;
using TravelBusinessLayer.Interface;
using TravelEntities.CustomEntities;
using TravelEntities.Entities;

namespace Travel_Booking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITravelComponent _travelComponent;

        public HomeController(ILogger<HomeController> logger, ITravelComponent travelComponent)
        {
            _logger = logger;
            _travelComponent = travelComponent;
        }

        public IActionResult Index()
        {

            
            ViewBag.Cities = _travelComponent.GetCities();
            CombinedModel combinedModel = new CombinedModel();
            return View(combinedModel);
        }
        [HttpPost]
        public IActionResult TravelBook(AvailableHotelSearchViewModel availableHotelSearchViewModel)
        {
            
            var hotelList = _travelComponent.GetHotelList(availableHotelSearchViewModel);

            
            return View("_HotelListPartial", hotelList);

        }
        [HttpPost]
        public IActionResult AddNewGuest(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _travelComponent.AddGuest(guest);
                return View("SuccessBooking");
            }
            else
            {
                return View("HotelBooking");
            }
        }
        public IActionResult BookNow()
        {

            return View();
        }
        public IActionResult About()
        {

            return View();
        }
        public IActionResult Tours()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        
        public IActionResult HotelBooking(BookingViewModel bookingViewModel)
        {
            
                _travelComponent.AddBookingList(bookingViewModel);
            
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
