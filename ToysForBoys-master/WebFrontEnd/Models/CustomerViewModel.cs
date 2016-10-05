using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebFrontEnd.Validation;

namespace WebFrontEnd.Models
{
    public class CustomerViewModel
    {

        public int id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Street and number")]
        public string streetAndNumber { get; set; }
        [Required]
        [Display(Name = "City")]
        public string city { get; set; }
        [Required]
        [Display(Name = "Province")]
        public string state { get; set; }
        [Required]
        [Display(Name = "Postal code")]
        public string postalCode { get; set; }
        [Required]
        [Display(Name = "Country")]
        public int countryId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Email(ErrorMessage = "This is not a valid email address.")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string newPassword { get; set; }

        public CustomerViewModel()
        {

        }
        public CustomerViewModel(Customer cust)
        {
            this.id = cust.id;
            this.name = cust.name;
            this.streetAndNumber = cust.streetAndNumber;
            this.city = cust.city;
            this.state = cust.state;
            this.postalCode = cust.postalCode;
            this.countryId = cust.countryId;
            this.email = cust.email;
            this.password = cust.password;
        }
    }
}