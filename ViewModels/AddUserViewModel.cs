using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Studio___Spa_Day.ViewModels
{
    public class AddUserViewModel
    {

        [Required(ErrorMessage = "Username is required")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Username must be between 5 & 15 characters")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is required!")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 & 20 characters!")]
        public string Password { get; set; }


        [Required(ErrorMessage = "You must re-enter your password!")]
        public string VerifyPassword { get; set; }


        [EmailAddress]
        public string Email { get; set; }


    }
}
