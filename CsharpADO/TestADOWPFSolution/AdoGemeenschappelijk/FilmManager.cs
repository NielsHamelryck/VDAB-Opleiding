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

        public void ToevoegingenWegschrijven(List<Film> ToegevoegdeFilms)
        {
            var manager = new VideoDBManager();

            using (var conVideos = manager.GetConnection())
            {
                using (var comInsert = conVideos.CreateCommand())
                {
                    comInsert.CommandType=CommandType.Text;
                    comInsert.CommandText =
                        "Insert into Films (Titel,GenreNr,InVoorraad,UitVoorraad,Prijs,TotaalVerhuurd) values (@titel,@genrenr,@invoorraad,@uitvoorraad,@prijs,@totaalverhuurd)";

                    var parTitel = comInsert.CreateParameter();
                    parTitel.ParameterName = "@titel";
                    comInsert.Parameters.Add(parTitel);

                    var parGenreNr = comInsert.CreateParameter();
                    parGenreNr.ParameterName = "@genrenr";
                    comInsert.Parameters.Add(parGenreNr);

                    var parInVoorraad = comInsert.CreateParameter();
                    parInVoorraad.ParameterName = "@invoorraad";
                    comInsert.Parameters.Add(parInVoorraad);

                    var parUitvoorraad = comInsert.CreateParameter();
                    parUitvoorraad.ParameterName = "@uitvoorraad";
                    comInsert.Parameters.Add(parUitvoorraad);

                    var parPrijs = comInsert.CreateParameter();
                    parPrijs.ParameterName = "@prijs";
                    comInsert.Parameters.Add(parPrijs);
                    var parTotaalVerhuurd = comInsert.CreateParameter();
                    parTotaalVerhuurd.ParameterName = "@totaalverhuurd";
                    comInsert.Parameters.Add(parTotaalVerhuurd);

                    conVideos.Open();

                    foreach (Film eenFilm in ToegevoegdeFilms)
                    {
                        parTitel.Value = eenFilm.Titel;
                        parGenreNr.Value = eenFilm.GenreNr;
                        parInVoorraad.Value = eenFilm.InVoorraad;
                        parUitvoorraad.Value = eenFilm.UitVoorraad;
                        parPrijs.Value = eenFilm.Prijs;
                        parTotaalVerhuurd.Value = eenFilm.TotaalVerhuurd;
                        comInsert.ExecuteNonQuery();
                    }
                }
            }
        }

        public void VerwijderingenToevoegen(List<Film> oudeFilms)
        {
            var manager = new VideoDBManager();
            using (var conVideo = manager.GetConnection())
            {
                using (var comDelete = conVideo.CreateCommand())
                {
                    comDelete.CommandType=CommandType.Text;
                    comDelete.CommandText = "Delete From Films where BandNr=@bandnr";

                    var parBandNr = comDelete.CreateParameter();
                    parBandNr.ParameterName = "@bandnr";
                    comDelete.Parameters.Add(parBandNr);

                    conVideo.Open();

                    foreach (var oudefilm in oudeFilms)
                    {
                        parBandNr.Value = oudefilm.BandNr;
                        comDelete.ExecuteNonQuery();
                    }
                }
            }
        }

        public void GewijzigdeFilmsToevoegen(List<Film> gewijzigdeFilms)
        {
            var manager = new VideoDBManager();
            using (var conVideos = manager.GetConnection())
            {
                using (var comUpdate = conVideos.CreateCommand())
                {
                    comUpdate.CommandType=CommandType.Text;
                    comUpdate.CommandText =
                        "Update Films set InVoorraad=@invoorraad, UitVoorraad=@uitvoorraad, TotaalVerhuurd=@totaalverhuurd where BandNr=@bandnr";

                    var parInVoorraad = comUpdate.CreateParameter();
                    parInVoorraad.ParameterName = "@invoorraad";
                    comUpdate.Parameters.Add(parInVoorraad);

                    var parUitVoorraad = comUpdate.CreateParameter();
                    parUitVoorraad.ParameterName = "@uitvoorraad";
                    comUpdate.Parameters.Add(parUitVoorraad);

                    var parTotaalVerhuurd = comUpdate.CreateParameter();
                    parTotaalVerhuurd.ParameterName = "@totaalverhuurd";
                    comUpdate.Parameters.Add(parTotaalVerhuurd);

                    var parBandNr = comUpdate.CreateParameter();
                    parBandNr.ParameterName = "@bandnr";
                    comUpdate.Parameters.Add(parBandNr);
                    conVideos.Open();

                    foreach (var eenfilm in gewijzigdeFilms)
                    {
                        parInVoorraad.Value = eenfilm.InVoorraad;
                        parUitVoorraad.Value = eenfilm.UitVoorraad;
                        parTotaalVerhuurd.Value = eenfilm.TotaalVerhuurd;
                        parBandNr.Value = eenfilm.BandNr;
                        comUpdate.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
