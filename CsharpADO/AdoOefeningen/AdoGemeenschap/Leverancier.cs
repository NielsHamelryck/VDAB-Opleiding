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
        public int LevNr { get; set; }

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

        private String postcodeValue;

        public String Postcode
        {
            get { return postcodeValue; }
            set
            {
                postcodeValue = value;
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

        public Object Versie { get; set; }

        public Leverancier(int levnr, string naam, string adres, string postcode,string woonplaats,object versie)
        {
            this.LevNr = levnr;
            this.Naam = naam;
            this.Adres = adres;
            this.Postcode = postcode;
            this.Woonplaats = woonplaats;
            this.Versie = versie;
            Changed = false;
        }

        public Leverancier()
        {
            
        }
    }

}
