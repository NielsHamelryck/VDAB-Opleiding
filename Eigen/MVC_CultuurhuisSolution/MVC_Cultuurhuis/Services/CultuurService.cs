using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Cultuurhuis.Models;

namespace MVC_Cultuurhuis.Services
{
    public class CultuurService
    {

        

        public List<Genre> GetAllGenres()
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

        public List<Voorstelling> GetAllVoorstellingenVanGenre(int? id)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var query = from voorstelling in db.Voorstellingen.Include("Genre")
                    where voorstelling.Datum >= DateTime.Today
                          && voorstelling.Genre.GenreNr == id
                    orderby voorstelling.Datum
                    select voorstelling;
                return query.ToList();
            }
        }

        public Voorstelling GetVoorstelling(int? id)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Voorstellingen.Find(id);
            }
        }

        public Klant GetKlant(string naam, string passwoord)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return (from klant in db.Klanten
                        where klant.GebruikersNaam == naam &&
                              klant.Paswoord == passwoord
                        select klant).FirstOrDefault();
            }
        }
        //gebruikersnaam moet uniek zijn
        public bool BestaatKlant(string gebruikersnaam)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var bestaandeKlant = (from klant in db.Klanten
                    where klant.GebruikersNaam == gebruikersnaam
                    select klant).FirstOrDefault();
                return bestaandeKlant !=null;
            }
        }

        public void VoegKlantToe(Klant nieuwKlant)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                db.Klanten.Add(nieuwKlant);
                db.SaveChanges();
            }
        }

        public void BewaarReservatie(Reservatie gelukteReservatie)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var voorstelling = db.Voorstellingen.Find(gelukteReservatie.VoorstellingsNr);
                voorstelling.VrijePlaatsen -= gelukteReservatie.Plaatsen;
                    db.Reservaties.Add(gelukteReservatie);
                    db.SaveChanges();
                

            }
        }
    }
}