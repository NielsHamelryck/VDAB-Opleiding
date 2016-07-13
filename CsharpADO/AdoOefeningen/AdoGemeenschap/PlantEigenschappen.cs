using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class PlantEigenschappen
    {
        
        public String Naam { get; set; }
        public String Soort { get; set; }

        public String Leverancier { get; set; }

        public String Kleur { get; set; }

        public Decimal VerkoopPrijs { get; set; }

        public PlantEigenschappen(String plantnaam,String soortnaam, String leveranciernaam,String kleur
                                    , Decimal verkoopPrijs)
        {
            this.Naam = plantnaam;
            this.Soort = soortnaam;
            this.Leverancier = leveranciernaam;
            this.Kleur = kleur;
            this.VerkoopPrijs = verkoopPrijs;
        }
    }
}
