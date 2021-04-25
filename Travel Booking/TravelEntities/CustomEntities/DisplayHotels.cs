using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravelEntities.CustomEntities
{
    public class DisplayHotels
    {
        [Key]
        public long HotelId { get; set; }
        public string HotelName { get; set; }

        public string HotelImage { get; set; }
    }
}
