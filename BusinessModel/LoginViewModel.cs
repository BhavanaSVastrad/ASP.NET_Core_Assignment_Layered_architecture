using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter the Email!")]

        public string Email { get; set; }



        [Required(ErrorMessage = "Enter the Password")]
        public string Password { get; set; }
    }
}
