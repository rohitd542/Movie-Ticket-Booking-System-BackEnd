using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaveUrShowUsingCFA.models
{
    public class Registration
    {
        [Key]
        public int userid { get; set; }
        [Required(ErrorMessage = "username is required")]
        [MaxLength(30)]
        [MinLength(5)]
        public string username { get; set; }
        [Required(ErrorMessage = "email is required")]
        [MaxLength(30)]
        [MinLength(5)]
        public string email { get; set; }
        [Required(ErrorMessage = "password is required")]
        [MaxLength(30)]
        [MinLength(5)]
        public string password { get; set; }
        [Required(ErrorMessage = "confirmpassword is requied")]
        [Compare("password", ErrorMessage = "password and confirmation password must match")]
        public string confirmpassword { get; set; }
        public string usertype { get; set; }
    }
}
