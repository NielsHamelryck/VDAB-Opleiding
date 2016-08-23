using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Figuur
    {
        public bool Changed { get; set; }
        public Int32 ID { get; set; }

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

        private Object _versieValueDateTime;

        public Object Versie
        {
            get { return _versieValueDateTime; }
            set { _versieValueDateTime = value; }
        }

        public Figuur(Int32 id,string naamValue, object versieValueDateTime)
        {
            this.ID = id;
            this.Naam = naamValue;
            this.Versie = versieValueDateTime;
            this.Changed = false;
        }

        public Figuur()
        {
            
        }
    }
}
