using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening3_2_priem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tik een getal om te kijken of het een priemgetal is");
            int getal = 0;
            int delers = 0;
             getal = Convert.ToInt32(Console.ReadLine());
             if (getal > 0)
             {
                 for (int teller = 2; teller <= getal - 1; teller++)

                     if (getal % teller == 0)
                     {
                         Console.WriteLine("Getal is deelbaar door {0} ", teller);
                         delers++;
                     }

                 if (delers > 0)
                     Console.WriteLine("Het getal {0} is geen priemgetal", getal);
                 else
                     Console.WriteLine("Het getal {0} is een priemgetal", getal);
             }
             else Console.WriteLine("Verkeerde invoer");
        }
    }
}
