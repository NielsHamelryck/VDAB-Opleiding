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

        public string Conditie { get; set; }


    }
}