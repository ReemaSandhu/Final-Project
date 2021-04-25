using System;
using System.Collections.Generic;
using System.Text;
using TravelEntities.CustomEntities;
using TravelEntities.Entities;

namespace TravelBusinessLayer.Interface
{
    public interface ITravelComponent
    {
        List<City> GetCities();
        //List<Hotel> GetHotels();
        //long InsertValues(SearchHotels search);
        List<DisplayHotels> GetHotelList(AvailableHotelSearchViewModel availableHotelSearchViewModel);

        int AddGuest(Guest guest);
        //int AddBookingDetails(Booking booking);
        List<Hotel> GetHotel();
        Hotel GetHotelId(long Id);
        long AddBookingList(BookingViewModel bookingViewModel);
        int Registration(SignUp res);
        bool Login(Login login);
    }
}
