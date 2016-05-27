using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class Artiest
    {
        public String Naam { get; set; }

        public Geslacht Geslacht { get; set; }

        public Artiest()
        {
            this.Naam = "Onbekend";
            this.Geslacht = Geslacht.Male;
        }
        public Artiest(string naam, Geslacht geslacht)
        {
            this.Naam = naam;
            this.Geslacht = geslacht;

        }
        public override string ToString()
        {
            return "Artiest:" + Naam + " Geslacht: " + Geslacht;
        } 
    }
}
