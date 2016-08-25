using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Plant
    {
        public Boolean Changed { get; set; }
        public Int32 PlantNr { get; set; }
        public String Naam { get; set; }
        public Int32 SoortNr { get; set; }
        public Int32 LevNr { get; set; }
        //public String Kleur { get; set; }
        //public Decimal VerkoopPrijs { get; set; }

        private String kleurValue;

        public String Kleur
        {
            get { return kleurValue; }
            set
            {
                kleurValue = value;
                Changed = true;
            }
        }

        private Decimal verkoopPrijsValueDecimal;

        public Decimal VerkoopPrijs
        {
            get { return verkoopPrijsValueDecimal; }
            set
            {
                verkoopPrijsValueDecimal = value;
                Changed = true;
            }
        }
        

        public Plant(int plantNr, string naam, int soortNr, int levNr, string kleur, decimal verkoopPrijs)
        {
            PlantNr = plantNr;
            Naam = naam;
            SoortNr = soortNr;
            LevNr = levNr;
            Kleur = kleur;
            VerkoopPrijs = verkoopPrijs;
            Changed = false;
        }

        public Plant()
        {
            
        }
    }
}
