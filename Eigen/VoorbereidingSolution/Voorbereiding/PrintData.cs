using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Voorbereiding
{
    public class PrintData
    {
        protected int integer;
        public void Print(int i)
        {
            integer = i;
            Console.WriteLine("{0} is een integer", i);
        }

        public void Print(bool boolean)
        {
            Console.WriteLine("{0} is een boolean", boolean);
        }

        public void Print(string woord)
        {
            Console.WriteLine("'{0}' is een string", woord);
        }

        public virtual void Stress()
        {
            Console.WriteLine("Allot of stress");
        }
    }
}
