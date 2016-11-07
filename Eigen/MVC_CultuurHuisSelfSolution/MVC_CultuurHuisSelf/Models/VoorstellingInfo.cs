using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CultuurHuisSelf.Models
{
    public class VoorstellingInfo
    {

        public List<Voorstelling> Voorstellingen { get; set; }
        public List<Genre> Genres { get; set; }

        public Genre Genre { get; set; }

    }
}