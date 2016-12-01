using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoVerhuur.Models;
using VideoVerhuur.Services;


namespace VideoVerhuur.Controllers
{
    
    public class HomeController : Controller
    {
        private VideoVerhuurService service = new VideoVerhuurService();

        public ActionResult Index(int? id)
        {
            Session["Sessie"] = id;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Inloggen()
        {
            int postcode;
            var naam = Request["naam"].ToUpper();
            int.TryParse(Request["postcode"], out postcode);
            
                
            

            var klant = service.FindKlant(naam, postcode);
            if (klant != null)
            {
                Session["klant"] = klant;

            }


            return RedirectToAction("Index", "Home", new {id = 1});
        }

        public ActionResult Uitloggen()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Verhuuringen()
        {
            var genres = service.GetGenres();
            return View(genres);
        }

        public ActionResult Detail(int id)
        {
            var filmDetails = new FilmDetails();
            filmDetails.Genre = service.GetGenre(id);
            filmDetails.Films = service.GetAlleFilmsPerGenre(id);
            return View(filmDetails);
        }


        public ActionResult Huren(int id)
        {
            var film = service.GetFilm(id);
            MandjeItem mandjeItem = new MandjeItem();
            mandjeItem.BandNr = id;
            mandjeItem.Prijs = film.Prijs;
            mandjeItem.Titel = film.Titel;
            if (film.InVoorraad > 0)
            {
                Session[id.ToString()] = mandjeItem;
            }
            else
            {
                return RedirectToAction("Verhuuringen", "Home", new {id = film.GenreNr});
            }
            return RedirectToAction("Mandje", "Home");
        }

        public ActionResult Mandje()
        {
            if (Session["klant"] != null)
            {
                List<MandjeItem> mandje = new List<MandjeItem>();

                foreach (string nummer in Session)
                {
                    int bandnr;
                    if (int.TryParse(nummer, out bandnr))
                    {
                        MandjeItem mandjeItem = (MandjeItem) Session[nummer];
                        mandje.Add(mandjeItem);
                    }
                }
                return View(mandje);
            }
            else return RedirectToAction("Index", "Home");
        }

        public ActionResult Verwijder(int id)
        {
            Film film = service.GetFilm(id);

            return View(film);
        }

        public ActionResult VerwijderUitMandje(int id)
        {
            if (Session[id.ToString()] != null)
            {
                Session.Remove(id.ToString());
            }
            return RedirectToAction("Mandje", "Home");
        }
        [HttpPost]
        public ActionResult Afrekenen()
        {
            decimal totaal=0;
            var klant = (Klant)Session["klant"];
            Session.Remove("klant");
            Session.Remove("sessie");
            List<MandjeItem> mandje = new List<MandjeItem>();

            foreach (string nummer in Session)
            {
                MandjeItem item = (MandjeItem)Session[nummer];
                Verhuuring verhuring = new Verhuuring();
                verhuring.BandNr = int.Parse(nummer);
                verhuring.KlantNr = klant.KlantNr;
                verhuring.VerhuurDatum=DateTime.Now;

                service.BewaarVerhuring(verhuring);
                totaal += item.Prijs;
                mandje.Add(item);
            }
            AfrekeningDetails details = new AfrekeningDetails();
            details.Klant = klant;
            details.Winkelmandje = mandje;
            
            Session.RemoveAll();
            ViewBag.totaal = totaal;
            ViewBag.afrekening = details;
            return View();
        }
    }
}