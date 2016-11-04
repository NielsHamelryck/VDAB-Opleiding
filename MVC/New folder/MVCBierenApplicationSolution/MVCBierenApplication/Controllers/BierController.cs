using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBierenApplication.Models;
using MVCBierenApplication.Services;


namespace MVCBierenApplication.Controllers
{
    
    public class BierController : Controller
    {

        // GET: Bier
        private BierService BierService = new BierService();

        public ActionResult Index()
        {
            var bieren = BierService.FindAll();
            return View(bieren);
        }

        public ActionResult Verwijderen(int id)
        {
            var bier = BierService.Read(id);
            return View(bier);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var bier = BierService.Read(id);
            this.TempData["bier"] = bier;
            BierService.Delete(id);
            return RedirectToAction("Verwijderd","Bier");
        }

        public ActionResult Verwijderd()
        {
            var bieren = (Bier) this.TempData["bier"];
            return View(bieren);
        }

        [HttpGet]
        public ActionResult Toevoegen()
        {
            var bier =new Bier();
            return View(bier);
        }

        [HttpPost]
        public ActionResult Toevoegen(Bier b)
        {
            if (this.ModelState.IsValid)
            {
                BierService.Add(b);
                return Redirect("Index");
            }
            return View(b);
        }
    }
}