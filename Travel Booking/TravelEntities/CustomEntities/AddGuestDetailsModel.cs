using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravelEntities.CustomEntities
{
    public class AddGuestDetailsModel
    {
        [Key]
        public long GuestId { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
        public string Email { get; set; }
        public long MobileNumber { get; set; }
        public long BookingId { get; set; }

    }
}
