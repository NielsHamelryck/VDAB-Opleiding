using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Voer een reeks getallen in :");
            int invoer, kleinste, grootste, teller, totaal;
            totaal = 0;
            teller = 0;
            grootste = 0;
            kleinste = 0;
            double gem = 0d;
            do
            {
                do
                {
                    invoer = Convert.ToInt32(Console.ReadLine());
                    if (invoer < 0 && invoer != -1)
                        Console.WriteLine("getal moet positief zijn");
                }
                while (invoer < 0 && invoer != -1);

                if (invoer != -1)
                {
                    grootste = Math.Max(invoer, grootste);
                    if (kleinste != 0)
                        kleinste = Math.Min(invoer, kleinste);
                    else kleinste = invoer;
                    totaal += invoer;
                    teller++;
                }
            }
            while (invoer != -1);
            if (totaal != 0)
            {
                gem = (double)totaal / teller;
                Console.WriteLine("kleinste waarde is {0}", kleinste);
                Console.WriteLine("Grootste waarde is {0}", grootste);
                Console.WriteLine("gemiddelde waarde is {0}", gem);
            }
            else Console.WriteLine("er zijn geen waarden ingevoerd");
        }
    }
}
