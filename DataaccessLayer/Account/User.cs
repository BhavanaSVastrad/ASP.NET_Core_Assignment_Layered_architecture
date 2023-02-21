using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataaccessLayer.Account
{
    public class User
    {
        [Key]

        public int Id { get; set; }
        [Required(ErrorMessage ="Enter the User Name!")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Enter the Email!")]

        public string Email { get; set; }

        [Required(ErrorMessage ="Enter the Mobile Number!")]
        public long Mobile { get; set; }

        [Required (ErrorMessage ="Enter the Password")]
        public string Password { get; set; }

       
    }
}
