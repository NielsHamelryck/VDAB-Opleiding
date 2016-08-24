using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschappelijk
{
    public class Soort
    {
        private Int32 soortnrValue;

        public Int32 SoortNr
        {
            get { return soortnrValue; }
            set { soortnrValue = value; }
        }

        private String soortValue;

        public String Naam
        {
            get { return soortValue; }
            set { soortValue = value; }
        }

        public Soort(int soortnrValue, string soortValue)
        {
            this.soortnrValue = soortnrValue;
            this.soortValue = soortValue;
        }
    }
}
