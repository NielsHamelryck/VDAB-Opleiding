using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddHerhaling
{
    public class Veiling
    {

        private decimal bedrag;
        private decimal hoogstebod;
        
        
        public void DoeBod(decimal bedrag)
        {
            hoogstebod = Math.Max(hoogstebod, bedrag);
        }
        public decimal getHoogsteBod
        {
            get { return hoogstebod; }
        }
    }
}
