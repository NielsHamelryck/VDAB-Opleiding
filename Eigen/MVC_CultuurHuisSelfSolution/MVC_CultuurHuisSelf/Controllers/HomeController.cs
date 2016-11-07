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

        public ActionResult Reserveer(int voorstellingsNr)
        {
            Voorstelling gekozenVoorstelling = new Voorstelling();
            gekozenVoorstelling = service.GetGekozenVoorstelling(voorstellingsNr);
            return View(gekozenVoorstelling);
        }
        [HttpPost]
        public ActionResult Reservering(int voorstellingsNr)
        {
            Voorstelling voorstelling = service.GetGekozenVoorstelling(voorstellingsNr);
            uint aantalPlaatsen = uint.Parse(Request["aantalPlaatsen"]);
            if (aantalPlaatsen > voorstelling.VrijePlaatsen)
            {
                return RedirectToAction("Reserveer", "Home", new {id = voorstellingsNr});
            }
            else
            {
                Session[voorstellingsNr.ToString()] = aantalPlaatsen;
            }

            return RedirectToAction("Mandje", "Home");
        }

        public ActionResult Mandje()
        {
            decimal teBetalen = 0;
            List<MandjeItem> winkelMandje = new List<MandjeItem>();

            foreach (var number in Session)
            {
                int voorstellingnummer;
                if (Int16.TryParse(number, out voorstellingnummer))
                {
                    Voorstelling voorstelling = service.GetGekozenVoorstelling(voorstellingnummer);
                    if (voorstelling != null)
                    {
                        MandjeItem mandjeItem = new MandjeItem(voorstellingnummer, voorstelling.Datum
                            ,voorstelling.Titel,voorstelling.Uitvoerders,voorstelling.Prijs,
                            Convert.ToInt16(Session[number]));

                    }
                }
            }
        }
    }
}