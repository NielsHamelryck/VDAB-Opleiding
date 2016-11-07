using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_CultuurHuisSelf.Models;

namespace MVC_CultuurHuisSelf.Services
{
    public class CultuurhuisService
    {

        public List<Genre> GetAllGenres()
        {

            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Genres.OrderBy(g=>g.GenreNaam).ToList();
            }
            
        }

        public List<Voorstelling> GetAllVoorstellingenPerGenre(int? id)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return (from voorstelling in db.Voorstellingen.Include("Genre")
                    where voorstelling.Datum >= DateTime.Now && voorstelling.Genre.GenreNr == id
                    select voorstelling).ToList();
            }
        }

        public Genre GetGenre(int? id)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Genres.Find(id);
            }
        }

        public Voorstelling GetGekozenVoorstelling(int voorstellingsNr)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Voorstellingen.Find(voorstellingsNr);
            }
        }
    }
}