using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelEntities.Entities
{
    public partial class Hotel
    {
        public Hotel()
        {
            Bookings = new HashSet<Booking>();
        }

        public long HotelId { get; set; }
        public string HotelName { get; set; }
        public long CityId { get; set; }
        public string HotelImage { get; set; }

        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile ImageUploader { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
