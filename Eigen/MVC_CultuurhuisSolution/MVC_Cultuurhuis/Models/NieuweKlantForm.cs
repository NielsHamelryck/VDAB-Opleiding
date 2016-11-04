﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MVC_Cultuurhuis.Models
{
    public class NieuweKlantForm
    {
        private string gebruikersnaam;


        [Required(ErrorMessage = "Voornaam is verplicht in te vullen!")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Familienaam is verplicht in te vullen!")]
        public string Familienaam { get; set; }

        [Required(ErrorMessage = "Straat is verplicht in te vulllen!")]
        public string Straat { get; set; }
        [Required(ErrorMessage = "Huisnr is verplicht in te vullen!")]
        public string Huisnr { get; set; }
        [Required(ErrorMessage = "Postcode is verplicht in te vullen!")]
        public string Postcode { get; set; }
        [Required(ErrorMessage = "Gemeente is verplicht in te vullen!")]
        public string Gemeente { get; set; }

        [Required(ErrorMessage = "Gebruikersnaam is verplicht!")]
        [Bestaatnogniet(ErrorMessage = "Een klant met deze gebruikersnaam komt al voor in de database. kies een andere naam.")]
        public string Gebruikersnaam {
            get { return this.gebruikersnaam; }
            set { this.gebruikersnaam = value; }
        }
        [Required(ErrorMessage = "Wachtwoord is verplicht in te vullen!")]
        [DataType(DataType.Password)]
        [Display(Name="Wachtwoord")]
        public string Paswoord { get; set; }

        [Required(ErrorMessage = "Wachtwoord moet bevestigd worden!")]
        [DataType(DataType.Password)]
        [Compare("Paswoord",ErrorMessage = "{0} verschilt van {1}. Probeer opnieuw.")]
        [Display(Name = "Wachtwoord bevestigen")]
        public string HerhaalPaswoord { get; set; }
    
}
}