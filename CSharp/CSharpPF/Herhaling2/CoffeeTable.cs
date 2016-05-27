using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class CoffeeTable : Table
    {
        public CoffeeTable(decimal breedte,decimal hoogte):base(breedte,hoogte)
        {

        }
        public override void ShowData()
        {
            Console.WriteLine("Koffietafel");
            base.ShowData();
        }
    }
}
