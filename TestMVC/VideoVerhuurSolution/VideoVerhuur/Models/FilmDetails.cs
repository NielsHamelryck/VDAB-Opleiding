using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoVerhuur.Models
{
    public class FilmDetails
    {
        public Genre Genre { get; set; }
        public List<Film> Films { get; set; }
    }
}