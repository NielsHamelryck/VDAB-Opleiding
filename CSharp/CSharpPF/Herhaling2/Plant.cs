using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string PlantenNaam { get; set; }
        public string Kleur { get; set; }
        public decimal Prijs { get; set; }
        public string Soort { get; set; }

        public Plant(int plantid,string plantennaam,string kleur, decimal prijs, string soort)
        {
            this.PlantId = plantid;
            this.PlantenNaam = plantennaam;
            this.Prijs = prijs;
            this.Kleur = kleur;
            this.Soort = soort;
        }
    }
}
