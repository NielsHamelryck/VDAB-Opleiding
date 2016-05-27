using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    class Program
    {
        const ulong BtwNummer=213252520UL;
        static void Main(string[] args)
        {
            ulong deeltal = BtwNummer % 100UL;
            int rest = deeltal % 97;
            int controle = 97 - rest;
            Console.WriteLine(97 == controle);
        }
    }
}
