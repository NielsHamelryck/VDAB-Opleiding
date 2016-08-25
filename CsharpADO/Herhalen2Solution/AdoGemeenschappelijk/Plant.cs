using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschappelijk
{
    public class Plant
    {
        public bool Changed { get; set; }

        private Int32 plantNrValue;

        public Int32 PlantNr
        {
            get { return plantNrValue; }
            set
            {
                plantNrValue = value;
                
            }
        }

        public String Naam { get; set; }

        private Int32 soortNrValue;

        public Int32 SoortNr
        {
            get { return soortNrValue; }
            set
            {
                soortNrValue = value;
                Changed = true;
            }
        }

        private Int32 levNrValue;

        public Int32 Levnr
        {
            get { return levNrValue; }
            set
            {
                levNrValue = value;
                Changed = true;
            }
        }

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

        private Decimal verkoopPrijsValue;

        public Decimal VerkoopPrijs
        {
            get { return verkoopPrijsValue; }
            set
            {
                verkoopPrijsValue = value;
                Changed = true;
            }
        }

        public Object Versie { get; set; }


        public Plant(int plantNrValue, string naam, int soortNrValue, int levNrValue, string kleurValue, decimal verkoopPrijsValue)
        {
            this.plantNrValue = plantNrValue;
            this.Naam = naam;
            this.soortNrValue = soortNrValue;
            this.levNrValue = levNrValue;
            this.kleurValue = kleurValue;
            this.verkoopPrijsValue = verkoopPrijsValue;
            Changed = false;
        }

        public Plant()
        {
            
        }
    }
}
