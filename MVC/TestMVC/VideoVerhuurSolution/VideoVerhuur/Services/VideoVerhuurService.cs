using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoVerhuur.Models;

namespace VideoVerhuur.Services
{
    public class VideoVerhuurService
    {
        public Klant FindKlant(string naam, int postcode)
        {
            using (var db = new VideoVerhuurEntities())
            {
                var query = (from klant in db.Klanten
                    where klant.Naam == naam && klant.PostCode == postcode
                    select klant).FirstOrDefault();
                return query;
            }
        }

        public List<Genre> GetGenres()
        {
            using (var db = new VideoVerhuurEntities())
            {
                return db.Genres.OrderBy(g => g.GenreNaam).ToList();
            }
        }

        public List<Film> GetAlleFilmsPerGenre(int id)
        {
            using (var db = new VideoVerhuurEntities())
            {
                var query = (from film in db.Films.Include("Genre")
                    where film.Genre.GenreNr == id
                    select film).ToList();
                return query;
            }
        }

        public Genre GetGenre(int id)
        {
            using (var db = new VideoVerhuurEntities())
            {
                return db.Genres.Find(id);
            }
        }

        public Film GetFilm(int id)
        {
            using (var db = new VideoVerhuurEntities())
            {
                return db.Films.Find(id);
            }
        }

        public void BewaarVerhuring(Verhuuring verhuring)
        {
            using (var db = new VideoVerhuurEntities())
            {
                var film = db.Films.Find(verhuring.BandNr);
                film.InVoorraad -= 1;
                film.UitVoorraad += 1;
                db.Verhuur.Add(verhuring);
                db.SaveChanges();
            }
        }
    }
}