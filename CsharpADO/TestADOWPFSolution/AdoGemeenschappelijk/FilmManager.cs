using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschappelijk
{
    public class FilmManager
    {

        public ObservableCollection<Film> GetFilms()
        {
            ObservableCollection<Film> films = new ObservableCollection<Film>();
            var manager = new VideoDBManager();

            using (var conFilms = manager.GetConnection())
            {
                using (var comGetFilms = conFilms.CreateCommand())
                {
                    comGetFilms.CommandType = CommandType.Text;
                    comGetFilms.CommandText = "select * from films order by Titel";

                    conFilms.Open();
                    try
                    {
                        using (var rdrFilms = comGetFilms.ExecuteReader())
                        {
                            Int32 BandNrpos = rdrFilms.GetOrdinal("BandNr");
                            Int32 TitelPos = rdrFilms.GetOrdinal("Titel");
                            Int32 GenreNrPos = rdrFilms.GetOrdinal("GenreNr");
                            Int32 InVoorRaadPos = rdrFilms.GetOrdinal("InVoorraad");
                            Int32 UitVoorraadPos = rdrFilms.GetOrdinal("UitVoorraad");
                            Int32 PrijsPos = rdrFilms.GetOrdinal("Prijs");
                            Int32 TotaalVerhuurPos = rdrFilms.GetOrdinal("TotaalVerhuurd");

                            while (rdrFilms.Read())
                            {

                                films.Add(new Film(rdrFilms.GetInt32(BandNrpos),
                                    rdrFilms.GetString(TitelPos),
                                    rdrFilms.GetInt32(GenreNrPos),
                                    rdrFilms.GetInt32(InVoorRaadPos),
                                    rdrFilms.GetInt32(UitVoorraadPos),
                                    rdrFilms.GetDecimal(PrijsPos),
                                    rdrFilms.GetInt32(TotaalVerhuurPos)));
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
            }


            return films;
        }

        public List<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();
            var manager= new VideoDBManager();
            using (var conVideo = manager.GetConnection())
            {
                using (var comGetGenre = conVideo.CreateCommand())
                {
                    comGetGenre.CommandType = CommandType.Text;
                    comGetGenre.CommandText = "select GenreNr, Genre from genres order by Genre";

                    conVideo.Open();
                    using (var rdrGenre = comGetGenre.ExecuteReader())
                    {
                        Int32 genreNrPos = rdrGenre.GetOrdinal("GenreNr");
                        Int32 genreNaamPos = rdrGenre.GetOrdinal("Genre");

                        while (rdrGenre.Read())
                        {
                            genres.Add(new Genre(rdrGenre.GetInt32(genreNrPos),rdrGenre.GetString(genreNaamPos)));
                        }
                    }
                }
            }
            return genres;
        }

        
    }
}
