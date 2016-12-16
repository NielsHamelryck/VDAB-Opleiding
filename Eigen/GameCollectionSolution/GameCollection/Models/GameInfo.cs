using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameCollection.Models
{
    public class GameInfo
    {
        public List<GameDetails> Games { get; set; }

        public List<ConsoleSoort> ConsoleSoorten { get; set; }

        public ConsoleSoort ConsoleSoort { get; set; }

        public List<Platform> Platformen { get; set; }

        public int TotalGames { get; set; }
    }
}