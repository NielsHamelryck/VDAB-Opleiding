using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefeningen2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Voer het totale aankoopbedrag in van afgelopen jaar");
            float aankoopBedrag = float.Parse(Console.ReadLine());
            string bon;
            if (aankoopBedrag >0 && aankoopBedrag <= 25)
                
                Console.WriteLine("De klant kreeg een kortingsbon van {0}", aankoopBedrag * 0.01f);
            else if (aankoopBedrag > 25 && aankoopBedrag <= 50)
               
                Console.WriteLine("De klant kreeg een kortingsbon van {0}", aankoopBedrag *0.02f);
            else if (aankoopBedrag > 50 && aankoopBedrag <= 100)
               
                Console.WriteLine("De klant kreeg een kortingsbon van {0}", aankoopBedrag *0.03f);
            else if (aankoopBedrag > 100)
                
                Console.WriteLine("De klant kreeg een kortingsbon van {0}", aankoopBedrag *= 0.05f);
            else Console.WriteLine("De klant heeft vorig jaar niet voldoende aangekocht om recht te hebben op een kortingbon");

            
        }
    }
}
