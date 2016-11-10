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

        public Voorstelling GetGekozenVoorstelling(int? voorstellingsNr)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Voorstellingen.Find(voorstellingsNr);
            }
        }

        public bool BestaatKlant(string gebruikersnaam)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var bestaandeklant = (from klant in db.Klanten
                    where klant.GebruikersNaam == gebruikersnaam
                    select klant).FirstOrDefault();

                return bestaandeklant != null;
            }
        }

        public Klant GetKlant(string naam, string paswoord)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                Klant gevondenklant = (from klant in db.Klanten
                    where klant.GebruikersNaam == naam && klant.Paswoord == paswoord
                    select klant).FirstOrDefault();
                
                    return gevondenklant;
                
            }
        }

        public void ToevoegenKlant(Klant nieuw)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                db.Klanten.Add(nieuw);
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