using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelDataAccess.Interface;
using TravelEntities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelEntities.CustomEntities;
using System.Data;

namespace TravelDataAccess
{
    public class DataAccess :IDataAccess
    {
        private readonly TravelDbContext _travelDbContext;
        public DataAccess(TravelDbContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public int Registration(SignUp res)
        {
            _travelDbContext.SignUp.Add(res);
            return _travelDbContext.SaveChanges();
        }
        public bool Login(Login login)
        {
            return _travelDbContext.SignUp.Any(x => x.Username == login.UserName && x.Password == login.Password);
        }
        public int AddGuest(Guest guest)
        {
            _travelDbContext.Guest.Add(guest);
            return _travelDbContext.SaveChanges();
        }

        public List<City> GetCities()
        {
            return _travelDbContext.City.ToList(); 
        }

        public List<Hotel> GetHotel()
        {
            return _travelDbContext.Hotel.ToList();
        }

        public List<DisplayHotels> GetHotelList(AvailableHotelSearchViewModel availableHotelSearchViewModel)
        {  
            return (_travelDbContext.DisplayHotels.FromSqlRaw("EXEC [dbo].[GetBooking]'" + availableHotelSearchViewModel.CheckInDate 
                + "','" + availableHotelSearchViewModel.CheckOutDate 
                + "'," + availableHotelSearchViewModel.CityId)).ToList();
        }

        public Hotel GetHotelId(long Id)
        {
            return _travelDbContext.Hotel.FirstOrDefault(x => x.HotelId == Id);
        }

        public long AddBookingList(BookingViewModel bookingViewModel)
        {
            long result = 0;
            SqlParameter resultParameter = new SqlParameter();
            try
            {
                resultParameter.ParameterName = "@RESULT";
                resultParameter.Direction = ParameterDirection.Output;
                resultParameter.SqlDbType = SqlDbType.BigInt;
                _travelDbContext.Database.ExecuteSqlRaw("[dbo].[AddBookingInfo] @HotelId,@CheckIn,@CheckOut,@NoOfPeople,@CityId,@RESULT OUT",
                     new SqlParameter("@HotelId", bookingViewModel.HotelId),
                     new SqlParameter("@CheckIn", bookingViewModel.CheckInDate),
                     new SqlParameter("@CheckOut", bookingViewModel.CheckOutDate),
                     new SqlParameter("@NoOfPeople", bookingViewModel.NoOfPeople),
                     new SqlParameter("@CityId", bookingViewModel.CityId),
                     resultParameter
                     );
                if (Convert.ToInt32(resultParameter.Value) > 0)
                    result = Convert.ToInt32(resultParameter.Value);
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        
    }
}
