using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelEntities.Entities
{
    public partial class SignUp
    {
        public long UserId { get; set; }
        [Required(ErrorMessage="Username is Required")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
