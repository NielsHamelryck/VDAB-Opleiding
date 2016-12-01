using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cultuurhuis3.Models;
using cultuurhuis3.services;

namespace cultuurhuis3.Controllers
{
    public class HomeController : Controller
    {
        private CultuurhuisService service = new CultuurhuisService();
        public ActionResult Index(int? id)
        {
            VoorstellingsInfo info = new VoorstellingsInfo();
            info.Genre = service.GetGenre(id);
            info.Genres = service.getAlleGenres();
            info.Voorstellingen = service.AlleVoorstellingenVanGenre(id);
            if (Session.Keys.Count > 0)
            {
                ViewBag.mandje = true;
            }
            else ViewBag.mandje = false;
            return View(info);
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

        public ActionResult Reserveer(int id)
        {
            Voorstelling geselecteerdeVoorstelling = service.GetVoorstelling(id);
            
            return View(geselecteerdeVoorstelling);
        }
        [HttpPost]
        public ActionResult Reserveren(int id)
        {
            uint aantalPlaatsen = uint.Parse(Request["aantalPlaatsen"]);
            Voorstelling gekozenVoorstelling = service.GetVoorstelling(id);
            if (gekozenVoorstelling.VrijePlaatsen >= aantalPlaatsen)
            {
                Session[gekozenVoorstelling.VoorstellingsNr.ToString()] = aantalPlaatsen;
                return RedirectToAction("Mandje", "Home");
            }
            return RedirectToAction("Reserveer","Home", new {id = id});
        }

        public ActionResult Mandje()
        {
            decimal teBetalen = 0;
            List<MandjeItem> Winkelmandje = new List<MandjeItem>();

            foreach (string nummer in Session)
            {
                int voorstellingsnummer;
                if (int.TryParse(nummer, out voorstellingsnummer))
                {
                    Voorstelling voorstelling = service.GetVoorstelling(voorstellingsnummer);
                    if (voorstelling != null)
                    {
                        MandjeItem mandjeItem =
                            new MandjeItem(voorstellingsnummer, voorstelling.Datum, voorstelling.Titel,
                                voorstelling.Uitvoerders,
                                voorstelling.Prijs, Convert.ToInt16(Session[nummer]));
                        Winkelmandje.Add(mandjeItem);
                        teBetalen += (mandjeItem.Prijs*mandjeItem.Plaatsen);
                    }
                    
                }
            }ViewBag.teBetalen = teBetalen;
                    return View(Winkelmandje);
        }

        [HttpPost]
        public ActionResult Verwijderen()
        {
            
                foreach (var item in Request.Form.AllKeys)
                {
                    if(Session[item]!=null) Session.Remove(item);
                }

            return RedirectToAction("Mandje", "Home");
        }

        public ActionResult Bevestig()
        {
            //als je op de knop zoek me op gedrukt hebt
            if (Request["zoek"] != null)
            {
                var naam = Request["naam"];
                var paswoord = Request["paswoord"];

                Klant klant = service.GetKlant(naam, paswoord);
                if (klant != null)
                    Session["klant"] = klant;
                else ViewBag.errorMessage = "Verkeerde gebruikersnaam of wachtwoord";
                return View();

            }
            //als je op de knop ik ben nieuw gedrukt heb
            if (Request["nieuw"] != null)
            {

                return RedirectToAction("Nieuw", "Home");
            }
            //als je op de knop bevestigen gedrukt hebt
            if (Request["bevestig"] != null)
            {
                var klant = (Klant) Session["Klant"];
                Session.Remove("klant");
                var geluktereservering = new List<MandjeItem>();
                var mislukteReservering = new List<MandjeItem>();

                foreach (string number in Session)
                {
                    var nieuweReservatie = new Reservatie();
                    nieuweReservatie.VoorstellingsNr = int.Parse(number);
                    nieuweReservatie.Plaatsen = Convert.ToInt16(Session[number]);
                    nieuweReservatie.KlantNr = klant.KlantNr;
                    Voorstelling voorstelling = service.GetVoorstelling(nieuweReservatie.VoorstellingsNr);

                    if (nieuweReservatie.Plaatsen < voorstelling.VrijePlaatsen)
                    {
                        service.BewaarReservatie(nieuweReservatie);
                        geluktereservering.Add(new MandjeItem(voorstelling.VoorstellingsNr, voorstelling.Datum,
                            voorstelling.Titel, voorstelling.Uitvoerders, voorstelling.Prijs, nieuweReservatie.Plaatsen));
                    }
                    else
                    {
                        mislukteReservering.Add(new MandjeItem(voorstelling.VoorstellingsNr, voorstelling.Datum,
                            voorstelling.Titel, voorstelling.Uitvoerders, voorstelling.Prijs, nieuweReservatie.Plaatsen));
                    }
                }
                Session.RemoveAll();
                Session["gelukt"] = geluktereservering;
                Session["mislukt"] = mislukteReservering;
                return RedirectToAction("Overzicht", "Home");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Nieuw()
        {
            var nieuwForm = new NieuweKlant();
            return View(nieuwForm);
        }

        [HttpPost]

        public ActionResult Nieuw(NieuweKlant nieuweKlant)
        {
            if (this.ModelState.IsValid)
            {
                Klant klant = new Klant();
                klant.Voornaam = nieuweKlant.Voornaam;
                klant.Familienaam = nieuweKlant.Familienaam;
                klant.Straat = nieuweKlant.Straat;
                klant.HuisNr = nieuweKlant.Huisnr;
                klant.Postcode = nieuweKlant.Postcode;
                klant.Gemeente = nieuweKlant.Gemeente;
                klant.GebruikersNaam = nieuweKlant.Gebruiksnaam;
                klant.Paswoord = nieuweKlant.Paswoord;
                Session["klant"] = klant;
                service.VoegKlantToe(klant);
                return RedirectToAction("Bevestig", "Home");
            }
            else
            {
                return View(nieuweKlant);
            }
        }

        public ActionResult Overzicht()
        {
            List<MandjeItem> gelukteReservaties = (List < MandjeItem > )Session["gelukt"];
            List<MandjeItem> mislukteReservaties = (List<MandjeItem>)Session["mislukt"];

            ViewBag.gelukt = gelukteReservaties;
            ViewBag.mislukt = mislukteReservaties;
            Session.Clear();
            return View();
        }
    }
}