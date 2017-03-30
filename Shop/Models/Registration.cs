using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Registration
    {
        public int RegistrationID { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Secondname { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        public string Re_Password { get; set; }
    }
}