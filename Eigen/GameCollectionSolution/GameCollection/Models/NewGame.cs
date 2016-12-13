using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCollection.Models
{
    public class NewGame
    {
        [Required(ErrorMessage = "Titel moet ingevuld zijn")]
        [Display(Name="Titel van het spel")]
        public String GameTitle { get; set; }

        public List<ConsoleSoort> AlleConsoles { get; set; }
        public int Console { get; set; }

        [Required(ErrorMessage = "Conditie moet ingevuld zijn")]
        public String Conditie { get; set; }

        //public Foto Foto { get; set; }

        //public Screenshot Screenshots { get; set; }
    }
}