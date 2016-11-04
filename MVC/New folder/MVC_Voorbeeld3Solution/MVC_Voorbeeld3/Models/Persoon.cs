using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MVC_Voorbeeld3.Models
{
    public class Persoon
    {
        public int ID { get; set; }
        
        public string Voornaam { get; set; }
        [StringLength(255, ErrorMessage = "Max. {1} tekens voor {0}")]
        public string Familienaam { get; set; }
        public int Score { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:#,##0.00}",ApplyFormatInEditMode = true)]
        public decimal Wedde { get; set; }
        [StringLength(20,MinimumLength = 8,ErrorMessage = "Min. {2} en max {1} voor het {0}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Min. {2} en max {1} voor het {0}")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "{1} verschilt met {0}")]
        public string HerhaalPassword { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}",ApplyFormatInEditMode = true)]
        [CustomValidations.Verleden(ErrorMessage = "Geboortedatum moet in het verleden liggen")]
        public DateTime Geboren { get; set; }

        public bool Gehuwd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Opmerkingen { get; set; }
        public Geslacht Geslacht { get; set; }
    }
}