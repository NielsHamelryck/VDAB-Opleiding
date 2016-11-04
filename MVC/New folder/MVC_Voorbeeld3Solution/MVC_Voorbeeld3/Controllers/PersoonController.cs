using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using MVC_Voorbeeld3.Models;
using MVC_Voorbeeld3.Services;

namespace MVC_Voorbeeld3.Controllers
{
    public class PersoonController : Controller
    {
        // GET: Persoon

        private PersoonService PersoonService = new PersoonService();
        public ActionResult Index()
        {
            var personen = PersoonService.GetAll();
            return View(personen);
        }

        [HttpGet]
        public ActionResult VerwijderForm(int id)
        {
            return View(PersoonService.FindByID(id));
        }
        [HttpPost]
        public ActionResult Verwijderen(int id)
        {
            PersoonService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Opslag()
        {
            OpslagForm opslagForm = new OpslagForm();
            opslagForm.Percentage = 10;
            return View(opslagForm);
        }

        [HttpPost]
        public ActionResult Opslag(OpslagForm opslagForm)
        {
            if (this.ModelState.IsValid)
            {
                //geen validatiefouten
                PersoonService.Opslag(opslagForm.VanWedde.Value,
                    opslagForm.TotWedde.Value,
                    opslagForm.Percentage);
                return RedirectToAction("Index");
            }
            else
            {
                //wel validatiefouten
                return View(opslagForm);
            }
        }

        [HttpGet]
        public ActionResult VanTotWedde()
        {
            var form = new VanTotWeddeForm();
            return View(form);
        }
        [HttpGet]
        public ActionResult VanTotWeddeResultaat(VanTotWeddeForm form)
        {
            if (this.ModelState.IsValid)
            {
                form.Personen = PersoonService.VanTotWedde(form.VanWedde.Value, form.TotWedde.Value);
                
            }return View("VanTotWedde",form);
        }

        [HttpGet]
        public ActionResult Toevoegen()
        {
            var persoon = new Persoon();
            persoon.Geslacht = Geslacht.Vrouw; //default waarde
            return View(persoon);
        }

        [HttpPost]
        public ActionResult Toevoegen(Persoon persoon)
        {
            if (this.ModelState.IsValid)
            {
                PersoonService.Add(persoon);
                return Redirect("Index");
            }
            return View(persoon);
        }

    }
}