using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class Leg
    {
        Table myTable;
        public Leg()
        {

        }

        public void SetTable(Table table)
        {
            myTable = table;
        }

        public void showData()
        {
            Console.WriteLine("I am a leg");
            myTable.ShowData();
        }
    }
}
