using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelEntities.CustomEntities;

namespace TravelEntities.Entities
{
    public partial class Booking
    {
        public long BookingId { get; set; }
        public long HotelId { get; set; }
        //[Required]
        //[CheckDateRangeAttribute]
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        //[Required(ErrorMessage = "Select No Of People")]
        public long NoOfPeople { get; set; }

        //[Required(ErrorMessage = "Select City")]
        public long CityId { get; set; }

        public virtual City City { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
