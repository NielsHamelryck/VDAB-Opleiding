using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Soort
    {
        public Int32 SoortNr { get; set; }

        public String Naam { get; set; }

        public Soort(int soortNr, string naam)
        {
            SoortNr = soortNr;
            Naam = naam;
        }
    }
}
