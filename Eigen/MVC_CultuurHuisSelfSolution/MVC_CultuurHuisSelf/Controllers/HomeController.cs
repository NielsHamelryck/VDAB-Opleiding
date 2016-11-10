using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CultuurHuisSelf.Services;
using MVC_CultuurHuisSelf.Models;

namespace MVC_CultuurHuisSelf.Controllers
{
    public class HomeController : Controller
    {
        private CultuurhuisService service = new CultuurhuisService();
        
        public ActionResult Index(int? id)
        {
            VoorstellingInfo info = new VoorstellingInfo();
            info.Genres = service.GetAllGenres();
            info.Genre = service.GetGenre(id);
            info.Voorstellingen = service.GetAllVoorstellingenPerGenre(id);
            if (Session.Keys.Count > 0)
            {
                ViewBag.winkelMandje = true;
            }
            else
            {
                ViewBag.winkelMandje = false;
            }
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

        public ActionResult Reserveren(int voorstellingsNr)
        {
            Voorstelling gekozenVoorstelling = new Voorstelling();
            gekozenVoorstelling = service.GetGekozenVoorstelling(voorstellingsNr);
            return View(gekozenVoorstelling);
        }
        [HttpPost]
        public ActionResult Reserveer(int id)
        {
            Voorstelling voorstelling = service.GetGekozenVoorstelling(id);
            uint aantalPlaatsen = uint.Parse(Request["aantalPlaatsen"]);
            if (aantalPlaatsen > voorstelling.VrijePlaatsen)
            {
                return RedirectToAction("Reserveer", "Home", new {id = id});
            }
            
                Session[id.ToString()] = aantalPlaatsen;
            

            return RedirectToAction("Mandje", "Home");
        }

        public ActionResult Mandje()
        {
            decimal teBetalen = 0;
            List<MandjeItem> winkelMandje = new List<MandjeItem>();

            foreach (string number in Session)
            {
                int voorstellingnummer;
                if (int.TryParse(number, out voorstellingnummer))
                {
                    Voorstelling voorstelling = service.GetGekozenVoorstelling(voorstellingnummer);
                    if (voorstelling != null)
                    {
                        MandjeItem mandjeItem = new MandjeItem(voorstellingnummer, voorstelling.Datum
                            ,voorstelling.Titel,voorstelling.Uitvoerders,voorstelling.Prijs,
                            Convert.ToInt16(Session[number]));
                        teBetalen += (mandjeItem.Prijs*mandjeItem.Plaatsen);
                        winkelMandje.Add(mandjeItem);
                    }
                }
                
            }
            ViewBag.Mandje = winkelMandje;
            ViewBag.teBetalen = teBetalen;
            return View(winkelMandje);
        }

        [HttpPost]

        public ActionResult Verwijderen()
        {
            foreach (var item in Request.Form.AllKeys)
            {
                if(Session[item] != null) Session.Remove(item);
            }
            return RedirectToAction("Mandje", "Home");
        }

        public ActionResult Bevestiging()
        {
            //zoek klant
            if (Request["zoek"]!=null)
            {
                var naam = Request["naam"];
                var paswoord = Request["paswoord"];

                var klant = service.GetKlant(naam,paswoord);
                if (klant != null)
                {
                    Session["klant"] = klant;
                }
                else
                {
                    ViewBag.errorMessage = "Verkeerd gebruikersnaam of wachtwoord";
                }
                return View();

            }
            //nieuwe klanten
            if (Request["nieuw"] != null)
            {
                return RedirectToAction("Nieuw", "Home");
            }
            // bevestigen van de bestelling via het klantenobject
            if (Request["bevestig"] != null)
            {
                Klant klant = (Klant)Session["Klant"];
                Session.Remove("klant");

                List<MandjeItem> gelukteReserveringen = new List<MandjeItem>();
                List<MandjeItem> mislukteReserveringen = new List<MandjeItem>();

                foreach (string number in Session)
                {
                    Reservatie nieuweReservatie = new Reservatie();
                    nieuweReservatie.VoorstellingsNr = int.Parse(number);
                    nieuweReservatie.Plaatsen = Convert.ToInt16(Session[number]);
                    nieuweReservatie.KlantNr = klant.KlantNr;

                    Voorstelling gekozenVoorstelling = service.GetGekozenVoorstelling(nieuweReservatie.VoorstellingsNr);
                    if (gekozenVoorstelling.VrijePlaatsen >= nieuweReservatie.Plaatsen)
                    {
                        service.BewaarReservatie(nieuweReservatie);
                        gelukteReserveringen.Add(new MandjeItem(gekozenVoorstelling.VoorstellingsNr,gekozenVoorstelling.Datum,
                            gekozenVoorstelling.Titel, gekozenVoorstelling.Uitvoerders,gekozenVoorstelling.Prijs,
                            nieuweReservatie.Plaatsen));
                    } else mislukteReserveringen.Add(new MandjeItem(gekozenVoorstelling.VoorstellingsNr,gekozenVoorstelling.Datum,
                            gekozenVoorstelling.Titel, gekozenVoorstelling.Uitvoerders,gekozenVoorstelling.Prijs,
                            nieuweReservatie.Plaatsen));
                }

                Session.RemoveAll();
                Session["gelukt"] = gelukteReserveringen;
                Session["mislukt"] = mislukteReserveringen;
                return RedirectToAction("Overzicht", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Nieuw()
        {
            NieuweKlant nieuweklant = new NieuweKlant();

            return View(nieuweklant);
        }


        [HttpPost]
        public ActionResult Nieuw(NieuweKlant nieuweKlant)
        {
            if (this.ModelState.IsValid)
            {
                Klant nieuw = new Klant();
                nieuw.Voornaam = nieuweKlant.Voornaam;
                nieuw.Familienaam = nieuweKlant.Familienaam;
                nieuw.Straat = nieuweKlant.Straat;
                nieuw.HuisNr = nieuweKlant.Huisnr;
                nieuw.Postcode = nieuweKlant.Postcode;
                nieuw.Gemeente = nieuweKlant.Gemeente;
                nieuw.GebruikersNaam = nieuweKlant.Gebruikersnaam;
                nieuw.Paswoord = nieuweKlant.Paswoord;
                Session["klant"] = nieuw;
                service.ToevoegenKlant(nieuw);
                return RedirectToAction("Bevestiging", "Home");
            }
            else return View(nieuweKlant);
        }


        public ActionResult Overzicht()
        {
            List<MandjeItem> gelukteReservaties = (List<MandjeItem>) Session["gelukt"];
            List<MandjeItem> mislukteReservaties = (List<MandjeItem>)Session["mislukt"];
            ViewBag.gelukt = gelukteReservaties;
            ViewBag.mislukt = mislukteReservaties;
            Session.Clear();
            return View();
        }
    }
}