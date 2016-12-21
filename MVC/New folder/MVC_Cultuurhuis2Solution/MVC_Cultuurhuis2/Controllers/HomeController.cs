using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Win32;
using MVC_Cultuurhuis2.Models;
using MVC_Cultuurhuis2.Services;

namespace MVC_Cultuurhuis2.Controllers
{
    public class HomeController : Controller
    {
        private CultuurhuisService service = new CultuurhuisService();
        public ActionResult Index(int? gekozenGenre = null)
        {
           
            if (Session.Keys.Count != 0)
            {
                ViewBag.winkelmandje = true;
            }
            else ViewBag.winkelmandje = false;
            return View(gekozenGenre);
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

        public ActionResult Reserveren(int id)
        {
            Voorstelling gekozenVoorstelling = service.GetVoorStelling(id);
            return View(gekozenVoorstelling);
        }

        [HttpPost]
        public ActionResult Reserveer(int id)
        {
            uint aantalPlaatsen = uint.Parse(Request["aantalPlaatsen"]);
            var gekozenVoorstelling = service.GetVoorStelling(id);
            if (aantalPlaatsen > gekozenVoorstelling.VrijePlaatsen)
            {
                return RedirectToAction("Reserveer", "Home", new {id = id});
            }
            
                Session[id.ToString()] = aantalPlaatsen;
            return RedirectToAction("Mandje", "Home");

        }

        public ActionResult Mandje()
        {
            decimal teBetalen = 0;
            List<MandjeItem> mandjeItems = new List<MandjeItem>();

            foreach (string nummer in Session)
            {
                int voorstellingsNr ;
                if (int.TryParse(nummer, out voorstellingsNr))
                {
                    Voorstelling voorstelling = service.GetVoorStelling(voorstellingsNr);
                    if (voorstelling != null)
                    {
                        MandjeItem mandjeItem = new MandjeItem
                        (
                            voorstellingsNr,
                            voorstelling.Datum, voorstelling.Titel,
                            voorstelling.Uitvoerders, 
                            voorstelling.Prijs, Convert.ToInt16(Session[nummer])
                        );

                        teBetalen += (mandjeItem.Plaatsen*mandjeItem.Prijs);

                        mandjeItems.Add(mandjeItem);
                    }
                }
            }
            ViewBag.teBetalen = teBetalen;
            return View(mandjeItems);
        }

        [HttpPost]
        public ActionResult Verwijderen()
        {
            foreach (var item in Request.Form.AllKeys)
            {
                if (Session[item] != null)
                {
                    Session.Remove(item);
                }
            }
            return RedirectToAction("Mandje", "Home");
        }

        public ActionResult Bevestiging()
        {
            //klant zoeken
            if (Request["zoek"] != null)
            {
                string naam = Request["naam"];
                string paswoord = Request["paswoord"];
                Klant klant = service.GetKlant(naam, paswoord);
                if (klant != null)
                {
                    Session["klant"] = klant;
                }
                else
                {
                    ViewBag.errorMessage = "Verkeerde gebruikersnaam of wachtwoord";
                }

            }
            //nieuwe klant maken
            if (Request["nieuw"] != null)
            {
                return RedirectToAction("Nieuw", "Home");
            }
            // bestelling bevestigen
            if (Request["bevestig"] != null)
            {
                //verwerking klantgegevens via Session["klant"]
                var klant = (Klant) Session["klant"];
                Session.Remove("klant");

                List<MandjeItem> gelukteReserveringen = new List<MandjeItem>();
                List<MandjeItem> mislukteReserveringen = new List<MandjeItem>();

                foreach (string nummer in Session)
                {
                    Reservatie nieuweReservatie = new Reservatie(); 
                     nieuweReservatie.VoorstellingsNr=int.Parse(nummer);
                    nieuweReservatie.Plaatsen = Convert.ToInt16(Session[nummer]);
                    nieuweReservatie.KlantNr = klant.KlantNr;

                    Voorstelling voorstelling = service.GetVoorStelling(nieuweReservatie.VoorstellingsNr);
                    if (voorstelling.VrijePlaatsen >= nieuweReservatie.Plaatsen)
                    {
                        service.BewaarReservatie(nieuweReservatie);
                        gelukteReserveringen.Add(new MandjeItem(voorstelling.VoorstellingsNr,
                            voorstelling.Datum, voorstelling.Titel, voorstelling.Uitvoerders,
                            voorstelling.Prijs, nieuweReservatie.Plaatsen));
                    }
                    else
                    {
                        mislukteReserveringen.Add(new MandjeItem(voorstelling.VoorstellingsNr,
                            voorstelling.Datum, voorstelling.Titel, voorstelling.Uitvoerders,
                            voorstelling.Prijs, nieuweReservatie.Plaatsen));
                    }
                }
                Session.RemoveAll();
                Session["Gelukt"] = gelukteReserveringen;
                Session["mislukt"] = mislukteReserveringen;
                return RedirectToAction("Overzicht", "Home");


            }
            return View();
        }
        [HttpGet]
        public ActionResult Nieuw()
        {
            var nieuwForm = new NieuwKlantForm();
            return View(nieuwForm);
        }
        [HttpPost]
        public ActionResult Nieuw(NieuwKlantForm form)
        {
            if (this.ModelState.IsValid)
            {
                Klant nieuweKlant = new Klant();
                nieuweKlant.Voornaam = form.Voornaam;
                nieuweKlant.Familienaam = form.Familienaam;
                nieuweKlant.Straat = form.Straat;
                nieuweKlant.HuisNr = form.Huisnr;
                nieuweKlant.Postcode = form.Postcode;
                nieuweKlant.Gemeente = form.Gemeente;
                nieuweKlant.GebruikersNaam = form.Gebruikersnaam;
                nieuweKlant.Paswoord = form.Paswoord;
                Session["klant"] = nieuweKlant;
                service.VoegKlantToe(nieuweKlant);
                return RedirectToAction("Bevestiging", "Home");
            }
            else
                return View(form);
        }

        public ActionResult Overzicht()
        {
            List<MandjeItem> gelukteReserveringen = (List<MandjeItem>) Session["gelukt"];
            List<MandjeItem> mislukteReserveringen = (List<MandjeItem>) Session["mislukt"];

            ViewBag.gelukt = gelukteReserveringen;
            ViewBag.mislukt = mislukteReserveringen;
            return View();
        }

        public PartialViewResult GenreLijst(int? gekozenGenre)
        {
            ViewBag.GekozenGenre = gekozenGenre;
            return PartialView(service.GetAllGenres());
        }

        public PartialViewResult GetVoorstellingenVanGenre(int? gekozengenre)
        {
            List<Voorstelling> voorstellingen = service.GetAllVoorstellingenPerGenre(gekozengenre);
            return PartialView(voorstellingen);
        }
    }
}