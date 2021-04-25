using System;
using System.Collections.Generic;



namespace TravelEntities.Entities
{
    public partial class City
    {
        public City()
        {
            Bookings = new HashSet<Booking>();
            Hotels = new HashSet<Hotel>();
        }

        public long CityId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
