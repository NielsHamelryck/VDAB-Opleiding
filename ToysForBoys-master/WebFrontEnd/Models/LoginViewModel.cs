using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFrontEnd.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Naam is een verplicht veld")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Postcode is een verplicht veld")]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}