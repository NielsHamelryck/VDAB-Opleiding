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
        {   Collection col = new Collection();
            User user = (User) Session["user"];
            if (user != null) { col = service.GetCollectionFromUser(user);}
            
            

            GameInfo gameInfo = new GameInfo();
            gameInfo.Games = service.GetGamesPerConsole(consoleId,col.Id);
            gameInfo.ConsoleSoorten = service.GetAllConsolesFromPlatform(id).ToList();
            gameInfo.ConsoleSoort = service.GetConsole(consoleId);
            gameInfo.TotalGames = service.GetTotalAmountOfGamesOfUser(user);
            gameInfo.Platformen = service.GetAllPlatformen();
            if (id != null)
            {
                 foreach (var gp in gameInfo.Platformen)
            {
                if (id == gp.Id)
                {
                    ViewBag.gekozenplatform = gp.PlatformName;
                }
            }
             
            }
           
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
        [AuthorizationFilter]
        public ActionResult addNewGame()
        {
            
                NewGame form = new NewGame();
                form.AlleConsoles = service.GetAllConsoles();
            if (TempData["duplicaat"] != null)
            {
                ViewBag.errorMessage = TempData["duplicaat"].ToString();
            }
                return View(form);
            
           
        }
        [HttpPost]
        public ActionResult addNewGame(NewGame form)
        {
            
            var user = (User)Session["user"];
            if (user != null)
            {
                Collection collection = service.GetCollectionFromUser(user);
                TempData.Remove("duplicaat");
                if (ViewData.ModelState.IsValid)
                {

                    Game nieuw = new Game();
                    if (!service.BestaatGame(form))
                    {
                        nieuw.Title = form.GameTitle;
                        nieuw.ConsoleSoort_Id = form.Console;
                        service.VoegGameToe(nieuw);
                        nieuw = service.getNewlyAddedGame(nieuw);
                        
                        GameCollectionUI gc = new GameCollectionUI();

                        gc.Games_Id = nieuw.Id;
                        gc.Collection_id = collection.Id;
                        gc.Condition = form.Conditie;
                        gc.Version = form.Version.ToString();

                        service.AddGameToCollection(gc);
                    }
                    else
                    {
                        nieuw.Title = form.GameTitle;
                        nieuw.ConsoleSoort_Id = form.Console;
                        nieuw = service.getNewlyAddedGame(nieuw);
                        //aanpassingen gebaseerd op de versie van een spel
                        var gameGevondenInCollection = service.BestaatGameInCollection(nieuw, user.Id);
                        if (gameGevondenInCollection==null)
                        {
                            GameCollectionUI gc_new = new GameCollectionUI();

                            gc_new.Games_Id = nieuw.Id;
                            gc_new.Collection_id = collection.Id;
                            gc_new.Condition = form.Conditie;
                            gc_new.Version = form.Version.ToString();
                            service.AddGameToCollection(gc_new);
                        }
                        else
                        {

                            if (gameGevondenInCollection.Version != form.Version.ToString())
                            {
                                GameCollectionUI gc_new = new GameCollectionUI();

                                gc_new.Games_Id = nieuw.Id;
                                gc_new.Collection_id = collection.Id;
                                gc_new.Condition = form.Conditie;
                                gc_new.Version = form.Version.ToString();
                                service.AddGameToCollection(gc_new);
                               
                            }
                            else
                            {
                                TempData["duplicaat"] = "Je hebt deze game al in je collectie";
                                return RedirectToAction("addNewGame", "Home");
                            }
                            
                        }
                        //////HIER GEEINDIGT gedachtegang over error als je al iets wil toevoegen dat al bestaat in je collectie

                    }
                    Session["toegevoegd"] = nieuw;
                    
                    return RedirectToAction("Details", "Home");

                }
                else
                {

                    form.AlleConsoles = service.GetAllConsoles();
                    return View(form);
                }

            }
            else
            {
                return RedirectToAction("Index","Home");
            }
            //Collection collection = service.GetCollectionFromUser(user);
            //TempData.Remove("duplicaat");
            //if (ViewData.ModelState.IsValid)
            //{
                
            //    Game nieuw = new Game();
            //    if (!service.BestaatGame(form))
            //    {

            //        nieuw.Title = form.GameTitle;
            //        //ConsoleSoort console = (service.getConsoleId(Request.Form["myDropdown"]));
            //        nieuw.ConsoleSoort_Id = form.Console;
                   
            //        //nieuw.Condition = form.Conditie;

                    
            //        service.VoegGameToe(nieuw);
            //        nieuw = service.getNewlyAddedGame(nieuw);
            //       // Collection collection = service.GetCollectionFromUser(user);

            //        GameCollectionUI gc = new GameCollectionUI();

            //        gc.Games_Id = nieuw.Id;
            //        gc.Collection_id = collection.Id;
            //        gc.Condition = form.Conditie;

                   
            //       service.AddGameToCollection(gc);
            //    }
            //    else
            //    {
            //        nieuw.Title = form.GameTitle;
            //        nieuw.ConsoleSoort_Id = form.Console;
            //        nieuw = service.getNewlyAddedGame(nieuw);
            //        if (!service.BestaatGameInCollection(nieuw,user.Id))
            //        {
            //            GameCollectionUI gc_new = new GameCollectionUI();

            //            gc_new.Games_Id = nieuw.Id;
            //            gc_new.Collection_id = collection.Id;
            //            gc_new.Condition = form.Conditie;
            //            service.AddGameToCollection(gc_new);
            //        }
            //        else
            //        {
            //             TempData["duplicaat"]= "Je hebt deze game al in je collectie";
            //             return RedirectToAction("addNewGame","Home");
            //        }
            //        //////HIER GEEINDIGT gedachtegang over error als je al iets wil toevoegen dat al bestaat in je collectie
                   
            //    } 
            //    Session["toegevoegd"] = nieuw;
            //    return RedirectToAction("Details", "Home");

            //}
            //else
            //{
                
            //    form.AlleConsoles = service.GetAllConsoles();
            //    return View(form);
            //}
           
        }

        public ActionResult Login()
        {
            var usernaam = Request["usernaam"];
            var paswoord = Request["passwoord"];

            User user = service.GetUser(usernaam, paswoord);
            if (user != null)
            {
                Session.Remove("failed");
                Session["user"] = user;
            }
            else
            {
                Session["failed"]= "Gebruiker niet terug gevonden probeer opnieuw!";
            }
            
            return RedirectToAction("Index","Home");
        }
        [AuthorizationFilter]
        public ActionResult Details(string title,string console,string version)
        {
            Game game = new Game();
            if (Session["toegevoegd"] != null)
            {
                game = (Game)Session["toegevoegd"];
                var gc = service.GetGameCollection((User) Session["user"]);
                version = gc.Version;
            }
            else
            {
                game = service.GetGameDetails(title,console);
            }

            GameDetails details = MaakGameDetails(game);
            details.Version = version;
            //details.Title = game.Title;
            //ConsoleSoort console =service.GetConsole(game.ConsoleSoort_Id);
            //details.ConsoleNaam = console.ConsoleName;
            //details.Conditie = game.Condition;
            //Session.Remove("toegevoegd");
            return View(details);
        }

        [AuthorizationFilter]
        public ActionResult ZoekGame()
        {
            var zoek = Request["zoekbox"];
            var user = (User)Session["user"];
            List<GameDetails> gevondenGames = new List<GameDetails>();
            if (Request["zoekbox"] != null && Request["zoekbox"] != "") 
            gevondenGames = service.GetAllGamesFromSearch(zoek,user.Id);
            
            
                
            
            return View(gevondenGames);

        }

        public GameDetails MaakGameDetails(Game game)
        {
            User user = (User)Session["user"];
            GameCollectionUI gc = service.GetGameCollection(user);
            GameDetails details = new GameDetails();
            details.Title = game.Title;
            ConsoleSoort console = service.GetConsole(game.ConsoleSoort_Id);
            details.ConsoleNaam = console.ConsoleName;
            details.Conditie = gc.Condition;
            details.Version = gc.Version;
            if(Session["toegevoegd"]!=null)
            Session.Remove("toegevoegd");
            return details;
        }
    }
}