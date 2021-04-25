using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelEntities.Entities
{
    public partial class Guest
    {
        public long GuestId { get; set; }

        [Required(ErrorMessage="Enter the First Name")]
        public string GuestFirstName { get; set; }

        [Required(ErrorMessage = "Enter the Last Name")]
        public string GuestLastName { get; set; }

       [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long MobileNumber { get; set; }
    }
}
