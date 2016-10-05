using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschappelijk
{
    public class Genre
    {

        public Int32 GenreNr { get; set; }
        public String GenreNaam { get; set; }

        public Genre(int genreNr, string genreNaam)
        {
            GenreNr = genreNr;
            GenreNaam = genreNaam;
        }
        
    }
}
