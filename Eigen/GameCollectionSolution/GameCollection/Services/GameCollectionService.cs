using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using GameCollection.Models;
//using GameCollection = GameCollection.Models.GameCollection;

namespace GameCollection.Services
{
    public class GameCollectionService
    {

        public List<Game> GetAllGamesMetConsoleNaam()
        {
            using (var db = new GameCollectionDBContainer())
            {
                var query = (from game in db.GameSet.Include("ConsoleSoort")
                             orderby game.Title
                             select game).ToList();
                return query;
            }
        }

        public List<ConsoleSoort> GetAllConsolesFromPlatform(int? platformId)
        {
            using (var db = new GameCollectionDBContainer())
            {
                var query = from console in db.ConsoleSoortSet.Include("Platform")
                    where console.Platform.Id == platformId
                    orderby console.ConsoleName
                    select console;
                return query.ToList() ;
            }
        }


        public List<ConsoleSoort> GetAllConsoles()
        {
            using (var db = new GameCollectionDBContainer())
            {
                var query = from console in db.ConsoleSoortSet
                            orderby console.ConsoleName
                            select console;
                return query.ToList();
            }
        }


        public List<GameDetails> GetGamesPerConsole(int? id,int? collectionId)
        {
            List<GameDetails> games = new List<GameDetails>();
           
                using (var db = new GameCollectionDBContainer())
                {
                    var query = (from game in db.GameSet.Include("ConsoleSoort")
                        where game.ConsoleSoort_Id == id 
                        orderby game.Title
                        select game).ToList();
                    foreach (var game in query)
                    {
                        foreach (var gamecollection in game.GameCollectionUIs)
                        {
                            if (gamecollection.Collection_id == collectionId)
                            {
                                var gameD = new GameDetails();
                                gameD.Title = game.Title;
                                gameD.ConsoleNaam = game.ConsoleSoort.ConsoleName;
                                gameD.Conditie = gamecollection.Condition;
                                games.Add(gameD);
                            }
                        }
                    }
                    return games;
                }
            
        }

        public ConsoleSoort GetConsole(int? id)
        {
            using (var db = new GameCollectionDBContainer())
            {
                return db.ConsoleSoortSet.Find(id);
            }
        }

        public List<Platform> GetAllPlatformen()
        {
            using (var db = new GameCollectionDBContainer())
            {
                return db.PlatformSet.OrderBy(p=>p.PlatformName).ToList();
            }
        }

        public User GetUser(string naam, string paswoord)
        {
            using (var db = new GameCollectionDBContainer())
            {
                var query = (from user in db.UserSet
                    where user.UserName == naam & user.Password == paswoord
                    select user).FirstOrDefault();
               
                return query;

            }
        }

        public ConsoleSoort getConsoleId(string id)
        {
            var consoleId = int.Parse(id);
            using (var db = new GameCollectionDBContainer())
            {
                var query = (from console in db.ConsoleSoortSet.Include("Platform")
                    where console.Id == consoleId
                    select console).FirstOrDefault();
                return query;
            }
        }

        public void VoegGameToe(Game nieuw)
        {
            using (var db = new GameCollectionDBContainer())
            {
                
                db.GameSet.Add(nieuw);
                db.SaveChanges();
            }
        }

        public Boolean BestaatGame(NewGame nieuw)
        {
            using (var db = new GameCollectionDBContainer())
            {
                var query = (from game in db.GameSet
                    where game.Title == nieuw.GameTitle && game.ConsoleSoort_Id==nieuw.Console
                    select game).FirstOrDefault();
                if (query != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Collection GetCollectionFromUser(User user)
        {
            using (var db = new GameCollectionDBContainer())
            {
                var query = (from collection in db.CollectionSet.Include("User")
                    where collection.User.Id == user.Id
                    select collection).FirstOrDefault();
                return query;
            }
        }

        public Game GetGameDetails(String gameId)
        {
            using (var db = new GameCollectionDBContainer())
            {
                var query = (from game in db.GameSet
                             where game.Title == gameId
                             select game).FirstOrDefault();
                return query;
            }
        }

        public Game getNewlyAddedGame(Game nieuweGame)
        {
            using (var db = new GameCollectionDBContainer())
            {
                var query = (from game in db.GameSet
                             where game.Title == nieuweGame.Title && game.ConsoleSoort_Id==nieuweGame.ConsoleSoort_Id
                             select game).FirstOrDefault();
                return query;
            }
        }

        public List<GameDetails> GetAllGamesFromSearch(string gameNaam,int userId)
        {
            using (var db = new GameCollectionDBContainer())
            {
                List<GameDetails> gevondenGamesVanUser = new List<GameDetails>();
                var query = (from game in db.GameSet.Include("ConsoleSoort")
                    where game.Title.Contains(gameNaam)
                    orderby game.Title
                    select game).ToList();
                foreach (var game in query)
                {
                    foreach (var collection in game.GameCollectionUIs)
                    {
                        if (collection.Collection_id == userId)
                        {
                            var gameD = new GameDetails();
                            gameD.Title = game.Title;
                            gameD.ConsoleNaam = game.ConsoleSoort.ConsoleName;
                            gameD.Conditie = collection.Condition;
                            gevondenGamesVanUser.Add(gameD);
                        }
                    }
                }
                return gevondenGamesVanUser;
            }
        }

        public void AddGameToCollection(GameCollectionUI gc)
        {
            using (var db = new GameCollectionDBContainer())
            {

                db.GameCollectionUIs.Add(gc);
                db.SaveChanges();
            }
        }

        public bool BestaatGameInCollection(Game nieuw, int userId)
        {
            using (var db = new GameCollectionDBContainer())
            {
                var query = (from gamecollection in db.GameCollectionUIs.Include("CollectionSet")
                    where gamecollection.Games_Id == nieuw.Id && gamecollection.CollectionSet.User_Id==userId
                    select gamecollection).FirstOrDefault();

                if (query != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public GameCollectionUI GetGameCollection(User user)
        {
            using (var db = new GameCollectionDBContainer())
            {
               
                var query = (from gc in db.GameCollectionUIs.Include("CollectionSet")
                    where gc.CollectionSet.User_Id == user.Id
                    select gc).FirstOrDefault();


                return query;
            }
        }
    }
}