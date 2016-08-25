using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class BierEigenschappen
    {
        public bool Changed { get; set; }

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

        private String brouwerValue;

        public String Brouwer
        {
            get { return brouwerValue; }
            set
            {
                brouwerValue = value;
                Changed = true;
            }
        }
        

        private String soortValue;

        public String Soort
        {
            get { return soortValue; }
            set
            {
                soortValue = value;
                Changed = true;
            }
        }

        private Single? alcoholValue;

        public Single? Alcohol
        {
            get { return alcoholValue; }
            set
            {
                alcoholValue = value;
                Changed = true;
            }
        }

        public Int32 BierNr { get; set; }

        public Object Versie { get; set; }

        public BierEigenschappen(string naamValue, string brouwerValue, string soortValue, Single? alcoholValue, object versie, Int32 biernr)
        {
            this.naamValue = naamValue;
            this.brouwerValue = brouwerValue;
            this.soortValue = soortValue;
            this.alcoholValue = alcoholValue;
            this.Versie = versie;
            this.BierNr = biernr;
            Changed = false;

        }

        public BierEigenschappen()
        {
            
        }
        

        
    }
}
