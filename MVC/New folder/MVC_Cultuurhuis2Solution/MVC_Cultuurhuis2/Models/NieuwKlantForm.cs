using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Cultuurhuis2.Models
{
    public class NieuwKlantForm
    {
        [Required(ErrorMessage = "Voornaam is verplicht in te vullen ! ")]
        public String Voornaam { get; set; }

        [Required(ErrorMessage = "Familienaam is verplicht in te vullen!")]
        public String Familienaam { get; set; }
        [Required(ErrorMessage = "Straat is verplicht in te vullen!")]
        public string Straat { get; set; }

        [Required(ErrorMessage = "Huisnr is verplicht in te vullen!")]

        public string Huisnr { get; set; }

        [Required(ErrorMessage = "Postcode is verplicht in te vullen!")]
        
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Gemeente is verplicht in te vullen!")]

        public string Gemeente { get; set; }

        [Required(ErrorMessage = "Gebruikersnaam is verplicht in te vullen!")]
        [BestaatNogNiet(ErrorMessage = "Een klant met deze gebruikersnaam kom al voor in de database. Kies een andere naam.")]
        public string Gebruikersnaam { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht in te vullen!")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Paswoord { get; set; }

        [Compare("Paswoord",ErrorMessage = "Wachtwoord bevestigen verschilt van Wachtwoord. Probeer opnieuw")]
        [DataType(DataType.Password)]
        [Display(Name = "Bevestig wachtwoord")]
        public string BevestigPaswoord { get; set; }

    }
}