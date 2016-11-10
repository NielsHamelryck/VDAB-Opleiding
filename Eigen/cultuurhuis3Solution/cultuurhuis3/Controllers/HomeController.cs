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
    }
}