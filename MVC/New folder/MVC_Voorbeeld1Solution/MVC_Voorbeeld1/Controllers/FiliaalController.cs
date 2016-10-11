using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld1.Controllers
{
    public class FiliaalController : Controller
    {
        // GET: Filiaal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show()
        {
            return View();
        }

        public ActionResult Read(int? id)
        {
            //lees in de database het filiaal waarvan de id gelijk is aan de waarde
            //van de parameter id
            return View();
        }
    }
}