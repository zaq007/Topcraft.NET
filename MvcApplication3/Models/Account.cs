using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcApplication3.Models.Interfaces;

namespace MvcApplication3.Models
{
    public partial class Account
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "No email!")]
        [Display(Name = "Enter your e-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Wrong format of e-mail adress")]
        public string Email { get; set; }

        [Display(Name = "Enter your password")]
        [Required(ErrorMessage = "No password")]
        [DataType(DataType.Password)]
        [StringLength(256, MinimumLength = 6, ErrorMessage = "Password too short")]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public int Wallet { get; set; }

        [ScaffoldColumn(false)]
        public Role RoleName { get; set; }

        public static bool operator==(Account a, Account b)
        {
            if ((object)a != null && (object)b != null)
                return a.Id == b.Id;
            if ((object)a == null && (object)b == null)
                return true;
            return false;
        }

        public static bool operator!=(Account a, Account b)
        {
            if ((object)a != null && (object)b != null)
                return a.Id != b.Id;
            if ((object)a == null && (object)b == null)
                return false;
            return true;
        }

    }
  
    public enum Role
    {
        Guest,
        Member,
        Admin
    };

    
}