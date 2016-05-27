using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class Table
    {
        public decimal BreedteTablet { get; set; }
        public decimal HoogteTablet { get; set; }
        public Table(decimal breedte, decimal hoogte)
        {
            this.BreedteTablet = breedte;
            this.HoogteTablet = hoogte;
        }
        protected Leg myLeg;
        public void addLeg(Leg L)
        {
            myLeg = L;
            myLeg.SetTable(this);

        }
        public virtual void ShowData()
        {
            
            Console.WriteLine("Breedte = "+BreedteTablet);
            Console.WriteLine("Hoogte = " + HoogteTablet);
        }
    }
}
