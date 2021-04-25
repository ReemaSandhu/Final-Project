using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TravelEntities.Entities;

namespace TravelEntities.CustomEntities
{
    public class SearchHotels
    {
        [Key]
        public long BookingId { get; set; }

        //[Required]
        //[CheckDateRangeAttribute]
        public DateTime Date { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        //[Required(ErrorMessage ="Select No Of People")]
        public long NoOfPeople { get; set; }

        //[Required(ErrorMessage = "- Select City -")]
        public long CityId { get; set; }



    }
}
