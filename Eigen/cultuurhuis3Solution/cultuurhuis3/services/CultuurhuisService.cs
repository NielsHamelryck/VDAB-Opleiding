using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cultuurhuis3.Models;
   

namespace cultuurhuis3.services
{
    public class CultuurhuisService
    {
        public List<Genre> getAlleGenres()
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Genres.OrderBy(g => g.GenreNaam).ToList();
            }
        }

        public Genre GetGenre(int? id)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Genres.Find(id);
            }
        }

        public List<Voorstelling> AlleVoorstellingenVanGenre(int? id)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var query = (from voorstelling in db.Voorstellingen.Include("Genre")
                    where voorstelling.Datum >= DateTime.Now && voorstelling.Genre.GenreNr == id
                    select voorstelling).ToList();
                return query;
            }
        }

        public Voorstelling GetVoorstelling(int id)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Voorstellingen.Find(id);
            }
        }
    }
}