using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Cultuurhuis2.Models;

namespace MVC_Cultuurhuis2.Services
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

        public Genre GetGenre(int? id)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Genres.Find(id);
            }
        }

        public List<Voorstelling> GetAllVoorstellingenPerGenre(int? id)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var query = (from voorstelling in db.Voorstellingen.Include("Genre")
                    where voorstelling.Datum >= DateTime.Now && voorstelling.Genre.GenreNr==id
                    orderby voorstelling.Datum
                    select voorstelling).ToList();
                return query;
            }
        }

        public Voorstelling GetVoorStelling(int id)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Voorstellingen.Find(id);
            }
        }

        public Klant GetKlant(string naam, string paswoord)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var query = (from klant in db.Klanten
                    where klant.GebruikersNaam == naam && klant.Paswoord == paswoord
                    select klant).FirstOrDefault();

                return query;
            }
        }

        public bool BestaatKlant(string gebruikersnaam)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var bestaat = (from klant in db.Klanten
                    where klant.GebruikersNaam == gebruikersnaam
                    select klant).FirstOrDefault();

                return bestaat!=null;
            }
        }

        public void VoegKlantToe(Klant nieuweKlant)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                db.Klanten.Add(nieuweKlant);
                db.SaveChanges();
            }
        }

        public void BewaarReservatie(Reservatie nieuweReservatie)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var voorstelling = db.Voorstellingen.Find(nieuweReservatie.VoorstellingsNr);
                
                    voorstelling.VrijePlaatsen -= nieuweReservatie.Plaatsen;
                    db.Reservaties.Add(nieuweReservatie);
                    db.SaveChanges();
                
            }
        }
    }
}