using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string Plantennaam { get; set; }
        public string Kleur { get; set; }

        public decimal Prijs { get; set; }

        public string Soort { get; set; }

        public override string ToString()
        {
            return "PlantenNaam: " + Plantennaam +
                " Kleur: " + Kleur + " Prijs: " + Prijs + " Soort: " + Soort;
        }
    }
}
