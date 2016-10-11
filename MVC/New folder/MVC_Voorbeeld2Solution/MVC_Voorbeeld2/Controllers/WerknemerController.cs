using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Voorbeeld2.Models;

namespace MVC_Voorbeeld2.Controllers
{
    public class WerknemerController : Controller
    {
        // GET: Werknemer
        public ActionResult Index()
        {
            
            return View("AndereNaam");
        }

        [NonAction]
        public void GeenAction() { }

        public ActionResult AlleWerknemers()
        {
            var werknemers = new List<Werknemer>();

            werknemers.Add(new Werknemer
            {
                Voornaam = "Steven",
                Wedde = 1000,
                InDienst = DateTime.Today
            });
            werknemers.Add(new Werknemer
            {
                Voornaam = "Prosper",
                Wedde = 2000,
                InDienst = DateTime.Today.AddDays(2)
            });

            return View(werknemers);
        }
    }
}