using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var entities = new LandenStedenTalenEntities())
            {
                Console.WriteLine("Alle landen");
                Console.WriteLine(new string('-', 11));

                var queryAlleLanden = entities.Landen.OrderBy(land => land.Naam).Select(l => l);
                
                foreach (var land in queryAlleLanden)
                    Console.WriteLine("{0} : {1}", land.LandCode, land.Naam);

                Console.WriteLine();

                Console.WriteLine("Landcode:");
                var landCode = Console.ReadLine();
                Console.WriteLine();
                
                var gekozenLand = entities.Landen.Find(landCode);
                if ( gekozenLand == null)
                {
                    Console.WriteLine("Land niet gevonden");
                }
                else
                {
                    Console.WriteLine("Steden van het land met Landcode : {0}", gekozenLand.LandCode);
                    Console.WriteLine(new string('-', 38));
                    foreach (var stad in gekozenLand.Steden) 
                        Console.WriteLine("{0}", stad.Naam);
                    Console.WriteLine();
                   
                    Console.WriteLine("In {0} spreekt men de volgende talen: ", gekozenLand.Naam);
                    Console.WriteLine();
                    foreach (var taal in gekozenLand.Talen)
                    {
                        Console.WriteLine("\t{0}", taal.Naam);
                    }
                    Console.WriteLine();
                    Console.WriteLine("stad:");
                    var nieuweStad = Console.ReadLine();

                    if (nieuweStad == string.Empty)
                    {
                        Console.WriteLine("geen nieuwe stad toegevoegd");
                    }
                    else
                    {
                        gekozenLand.Steden.Add(new Stad()
                        {
                            Naam = nieuweStad
                        });
                        Console.WriteLine("{0} toegevoegd aan het land {1}",nieuweStad,gekozenLand.Naam);
                        entities.SaveChanges(); 
                    }
                    
                }
            }
        }








    }


}

