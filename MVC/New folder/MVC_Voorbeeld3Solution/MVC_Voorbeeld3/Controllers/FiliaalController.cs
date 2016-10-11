﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Voorbeeld3.Models;
using MVC_Voorbeeld3.Services;

namespace MVC_Voorbeeld3.Controllers
{
    
    public class FiliaalController : Controller
    {
        // GET: Filiaal
        private FiliaalService filiaalService= new FiliaalService();
        private HoofdzetelService hoofdzetelService = new HoofdzetelService();
        public ActionResult Index()
        {
            var hoofdZetel = hoofdzetelService.Read();
            ViewBag.hoofdzetel = hoofdZetel;
            var filialen = filiaalService.FindAll();
            return View(filialen);
        }

        public ActionResult Verwijderen(int id)
        {
            var filiaal = filiaalService.Read(id);
            return View(filiaal);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var filiaal = filiaalService.Read(id);
            this.TempData["filiaal"] = filiaal;
            filiaalService.Delete(id);
            return Redirect("~/Filiaal/Verwijderd");
        }

        public ActionResult Verwijderd()
        {
            var filiaal = (Filiaal) this.TempData["filiaal"];
            return View(filiaal);

        }
    }
}