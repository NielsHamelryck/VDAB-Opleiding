using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Soort
    {
        public int SoortNr { get; set; }
        public string SoortNaam { get; set; }

        public Soort(String soortNaam, int soortNr)
        {
            this.SoortNr = soortNr;
            this.SoortNaam = soortNaam;
        }

        public override string ToString()
        {
            return SoortNaam;
        }
    }
}
