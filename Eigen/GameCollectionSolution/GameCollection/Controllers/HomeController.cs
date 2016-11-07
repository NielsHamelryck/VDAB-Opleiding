using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCollection.Models;
using GameCollection.Services;

namespace GameCollection.Controllers
{
    public class HomeController : Controller
    {
        private GameCollectionService service = new GameCollectionService();
        public ActionResult Index(int? id,int? consoleId)
        {
            GameInfo gameInfo = new GameInfo();
            gameInfo.Games = service.GetGamesPerConsole(id);
            gameInfo.ConsoleSoorten = service.GetAllConsolesFromPlatform(id).ToList();
            gameInfo.ConsoleSoort = service.GetConsole(consoleId);
            gameInfo.Platformen = service.GetAllPlatformen();
            
             
            return View(gameInfo);
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
    }
}