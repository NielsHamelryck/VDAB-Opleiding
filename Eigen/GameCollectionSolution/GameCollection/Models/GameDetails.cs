using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCollection.Models
{
    public class GameDetails
    {
        public int Game_Id { get; set; }
        public String Title { get; set; }
        [Display(Name = "Console")]
        public String ConsoleNaam { get; set; }
        [Display(Name="Condition")]
        public string Conditie { get; set; }

        [Display(Name="Type:")]
        public string Version { get; set; }

    }
}