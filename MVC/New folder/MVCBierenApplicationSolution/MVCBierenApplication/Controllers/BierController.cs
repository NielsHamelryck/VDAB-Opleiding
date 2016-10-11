using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBierenApplication.Models;

namespace MVCBierenApplication.Controllers
{
    public class BierController : Controller
    {
        // GET: Bier
        public ActionResult Index()
        {
            var bieren= new List<Bier>();

            bieren.Add(new Bier
            {
                Naam = "Aardsmonnik",
                Alcohol = 8,
                ID = 5

            });
            bieren .Add(new Bier
            {
                Naam = "Gouden Carolus Classic",
                Alcohol = 7.5f,
                ID = 17
            });
            bieren.Add(new Bier
            {
                Naam="Duvel",
                Alcohol = 9,
                ID = 38
                
            });
            bieren.Add(new Bier
            {
                Naam = "Jupiler NA",
                Alcohol = 0.0f,
                ID = 105

            });
            return View(bieren);
        }
    }
}