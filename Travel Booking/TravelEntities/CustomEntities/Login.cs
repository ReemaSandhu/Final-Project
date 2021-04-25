using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravelEntities.CustomEntities
{
    public class Login
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage ="Username is Required")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
