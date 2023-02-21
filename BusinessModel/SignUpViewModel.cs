using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessModel
{
    public class SignUpViewModel

    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the User Name!")]


        public string Username { get; set; }

        [Required(ErrorMessage = "Enter the Email!")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter the Mobile Number!")]
        [RegularExpression("^(\\d{3}[- ]?){2}\\d{4}$", ErrorMessage = "Enter the valid Mobile number")]
        public long? Mobile { get; set; }

        [Required(ErrorMessage = "Enter the Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter the Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Password does not match with the given Password ")]
        public string ConfirmPassword { get; set; }
    }
}
