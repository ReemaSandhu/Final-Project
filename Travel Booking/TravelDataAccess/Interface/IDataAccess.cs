using System;
using System.Collections.Generic;
using System.Text;
using TravelEntities.CustomEntities;
using TravelEntities.Entities;

namespace TravelDataAccess.Interface
{
    public interface IDataAccess
    {
         List<City> GetCities();

        //List<Hotel> GetHotels();

        //long InsertValues(SearchHotels search);
        List<DisplayHotels> GetHotelList(AvailableHotelSearchViewModel availableHotelSearchViewModel);
        int Registration(SignUp res);
        bool Login(Login login);
        int AddGuest(Guest guest);
        //int AddBookingDetails(Booking booking);
        long AddBookingList(BookingViewModel bookingViewModel);
        List<Hotel> GetHotel();
        Hotel GetHotelId(long Id);
    }
}
