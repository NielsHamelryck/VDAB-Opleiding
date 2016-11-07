using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCollection.Models;

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

        public List<Game> GetGamesPerConsole(int? id)
        {
           
                using (var db = new GameCollectionDBContainer())
                {
                    var query = (from game in db.GameSet.Include("ConsoleSoort")
                        where game.ConsoleSoort.Id == id
                        orderby game.Title
                        select game).ToList();
                    return query;
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
    }
}