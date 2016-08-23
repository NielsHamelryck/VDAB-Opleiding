using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Plant
    {
        public String PlantNaam { get; set; }
        public Int32 PlantNr { get; set; }
        
        public Int32 LevNr { get; set; }

        public bool Changed { get; set; }

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

        private Decimal prijsValue;

        public Decimal VerkoopPrijs
        {
            get { return prijsValue; }
            set
            {
                prijsValue = value;
                Changed = true;
            }
        }

        public Plant(String plantNaam,Int32 plantNr,Int32 levNr, String kleur, decimal verkoopPrijs)
        {
            this.PlantNaam = plantNaam;
            this.PlantNr = plantNr;
            this.LevNr = levNr;
            this.Kleur = kleur;
            this.VerkoopPrijs = verkoopPrijs;
            Changed = false;

        }

        public Plant()
        {
            
        }

        
    }
}
