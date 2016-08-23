using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Leverancier
    {
        public bool Changed { get; set; }
        //public Int32 LevNr { get; set; }
        //public String Naam { get; set; }
        //public String Adres { get; set; }

        //public String PostNr { get; set; }
        //public String Woonplaats { get; set; }

        private Int32 levnrValue;

        public Int32 LevNr
        {
            get { return levnrValue; }
            set { levnrValue = value; }
        }

        private String naamValue;

        public String Naam
        {
            get { return naamValue; }
            set
            {
                naamValue = value;
                Changed = true;
            }
        }
        private String adresValue;

        public String Adres
        {
            get { return adresValue; }
            set
            {
                adresValue = value;
                Changed = true;
            }
        }

        private String postNrValue;

        public String PostNr
        {
            get { return postNrValue; }
            set
            {
                postNrValue = value;
                Changed = true;
            }
        }

        private String woonplaatsValue;

        public String Woonplaats
        {
            get { return woonplaatsValue; }
            set
            {
                woonplaatsValue = value;
                Changed = true;
            }
        }
        
        

        public Leverancier(int levNr, string naam, string adres, string postNr, string woonplaats)
        {
            this.LevNr = levNr;
            this.Naam = naam;
            this.Adres = adres;
            this.PostNr = postNr;
            this.Woonplaats = woonplaats;
            this.Changed = false;
        }

        public Leverancier()
        {
            
        }
    }
}
