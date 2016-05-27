using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string Plantennaam { get; set; }
        public string Kleur { get; set; }
        public decimal Prijs { get; set; }
        public string Soort { get; set; }

        public Plant(int plantId, string plantnaam, string kleur, decimal prijs, string soort)
        {
            this.PlantId = plantId;
            this.Plantennaam = plantnaam;
            this.Kleur = kleur;
            this.Prijs = prijs;
            this.Soort = soort;
        }
    }
}
