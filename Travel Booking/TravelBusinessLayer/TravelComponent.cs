using System;
using System.Collections.Generic;
using System.Text;
using TravelBusinessLayer.Interface;
using TravelDataAccess.Interface;
using TravelEntities.CustomEntities;
using TravelEntities.Entities;

namespace TravelBusinessLayer
{
    public class TravelComponent : ITravelComponent
    {
        private readonly IDataAccess _data;

        public TravelComponent(IDataAccess data)
        {
            _data = data;
        }

        public long AddBookingList(BookingViewModel bookingViewModel)
        {
            return _data.AddBookingList(bookingViewModel);
        }

        //public int AddBookingDetails(Booking booking)
        //{
        //    return _data.AddBookingDetails(booking);
        //}

        public int AddGuest(Guest guest)
        {
            return _data.AddGuest(guest);
        }

        

        public List<City> GetCities()
        {
            return _data.GetCities();
        }

        public List<Hotel> GetHotel()
        {
            return _data.GetHotel();
        }

        public Hotel GetHotelId(long Id)
        {
            return _data.GetHotelId(Id);
        }

        public List<DisplayHotels> GetHotelList(AvailableHotelSearchViewModel availableHotelSearchViewModel)
        {
            return _data.GetHotelList(availableHotelSearchViewModel);
        }

        public bool Login(Login login)
        {
            return _data.Login(login);
        }

        public int Registration(SignUp res)
        {
            return _data.Registration(res);
        }

        //public List<Hotel> GetHotels()
        //{
        //    return _data.GetHotels();
        //}

        //public long InsertValues(SearchHotels search)
        //{
        //    return _data.InsertValues(search);
        //}
    }
}
