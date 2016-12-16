using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCollection.Models
{
    public class NewGame
    {
        [Required(ErrorMessage = "Title has to be filled!")]
        
        public String GameTitle { get; set; }

        public List<ConsoleSoort> AlleConsoles { get; set; }
        public int Console { get; set; }

        [Required(ErrorMessage = "Condition has to be filled!")]
        [Display(Name="Condition")]
        public String Conditie { get; set; }

      
        public Version Version { get; set; }

        //public Foto Foto { get; set; }

        //public Screenshot Screenshots { get; set; }
    }  
    public enum Version
        {
            Digital,
            Physical
        }

}