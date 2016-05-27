using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling
{
    public class Klant
    {
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }

        public Klant(string voornaam, string familienaam)
        {
            this.Voornaam = voornaam;
            this.Familienaam = familienaam;
        }

        public void Afbeelden()
        {
            Console.WriteLine("voornaam:{0} ",Voornaam);
            Console.WriteLine("achternaam: {0}",Familienaam);
        }
    }
}
