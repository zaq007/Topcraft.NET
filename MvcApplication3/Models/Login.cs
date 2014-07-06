using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcApplication3.Models.Interfaces;

namespace MvcApplication3.Models
{
    public class Login
    {
        [Required(ErrorMessage = "No email!")]
        [Display(Name = "Enter your e-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Wrong format of e-mail adress")]
        public string Email { get; set; }

        [Display(Name = "Enter your password")]
        [Required(ErrorMessage = "No password")]
        [StringLength(256, MinimumLength = 6, ErrorMessage = "Password too short")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}