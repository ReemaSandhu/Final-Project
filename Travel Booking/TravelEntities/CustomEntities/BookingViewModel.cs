using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravelEntities.CustomEntities
{
    public class BookingViewModel
    {
        [Key]
        public long BookingId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public long CityId { get; set; }
        public int NoOfPeople { get; set; }
        public long HotelId { get; set; }
    }
}
