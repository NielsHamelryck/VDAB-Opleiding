using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Bier
    {

        public Int32 BierNr { get; set; }
        public String Naam { get; set; }
        public Int32 BrouwerNr { get; set; }
        public Int32 SoortNr { get; set; }
        private Single? alcoholValue;

        public Single? Alcohol
        {
            get { return alcoholValue; }
            set
            {
                
                alcoholValue = value;
                
            }
        }
        

        public Bier(int bierNr, string naam, int brouwerNr, int soortNr, Single? alcohol)
        {
            BierNr = bierNr;
            Naam = naam;
            BrouwerNr = brouwerNr;
            SoortNr = soortNr;
            Alcohol = alcohol;
        }

        public Bier()
        {
            
        }
    }

   
}
