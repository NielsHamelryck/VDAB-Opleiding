using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbereiding
{
    public class printView : PrintData
    {

        public override void Stress()
        {
            Console.WriteLine("No stress");
        }

        public void AndereInt(int i)
        {
            Console.WriteLine(integer);
        }
    }
}
