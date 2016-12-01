using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cultuurhuis3.Models
{
    public class NieuweKlant
    {
        [Required(ErrorMessage = "Het veld Voornaam is verplicht in te vullen!")]
        public string Voornaam { get; set; }
        [Required(ErrorMessage = "Het veld Familienaam is verplicht in te vullen!")]
        public string Familienaam { get; set; }
        [Required(ErrorMessage = "Het veld Straat is verplicht in te vullen!")]
        public string Straat { get; set; }
        [Required(ErrorMessage = "Het veld Huisnr is verplicht in te vullen!")]
        public string Huisnr { get; set; }
        [Required(ErrorMessage = "Het veld Postcode is verplicht in te vullen!")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Het veld Gemeente is verplicht in te vullen!")]
        public string Gemeente { get; set; }

        [Required(ErrorMessage = "Het veld Gebruikersnaam is verplicht in te vullen!")]
        [KlantBestaatNiet(
            ErrorMessage = "Een klant met deze gebruikersnaam komt al voor in de database. Kies een andere naam")]
        public string Gebruiksnaam
        {
            get ;
        set; 
        }

        [Required(ErrorMessage = "Het veld Wachtwoord is verplicht in te vullen!")]
        [DataType(DataType.Password)]
        [Display(Name="Wachtwoord")]
        public string Paswoord { get; set; }

        [Required(ErrorMessage = "Het veld Wachtwoord bevestigen is verplicht in te vullen!")]
        [Display(Name="Wachtwoord bevestigen")]
        [DataType(DataType.Password)]
        [Compare("Paswoord",ErrorMessage = "Wachtwoord bevestigen verschilt van Wachtwoord. Probeer opnieuw!")]
        public string HerhaalPaswoord { get; set; }

       
    }
}