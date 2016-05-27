using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening5_2
{
    public class Stookketel : IVervuiler
    {
        private float COnormValue;

        public float CONorm
        {
            get { return COnormValue; }
            set {if(value>0) 
                COnormValue = value; }
        }

        public Stookketel(float COnorm)
        {
            this.CONorm = COnorm;
        }

        public double GeefVervuiling()
        {
            return CONorm*100;
        }
    }
}
