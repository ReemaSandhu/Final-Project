using System;
using System.Collections.Generic;
using System.Text;
using TravelEntities.Entities;

namespace TravelEntities.CustomEntities
{
    public class GetBookingDetail
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public long CityId { get; set; }
        public long HotelId { get; set; }
    }
}
