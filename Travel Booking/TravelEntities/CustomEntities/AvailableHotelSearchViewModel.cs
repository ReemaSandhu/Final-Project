using System;
using System.Collections.Generic;
using System.Text;

namespace TravelEntities.CustomEntities
{
    public class AvailableHotelSearchViewModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public long CityId { get; set; }
        public int NoOfPeople { get; set; }
    }
}
