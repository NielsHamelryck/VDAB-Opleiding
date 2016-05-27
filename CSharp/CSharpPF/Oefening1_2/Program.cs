using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening1_2
{
    class Program
    {
        const ulong BtwNummer = 213252520UL;
        static void Main(string[] args)
        {
            ulong deeltal = BtwNummer / 100UL;
            int rest = (int)(deeltal % 97UL);
            int controle = 97 - rest;
            Console.WriteLine((int)(BtwNummer % 100) == controle);
        }
    }
}
