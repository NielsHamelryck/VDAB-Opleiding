using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef het jaar in waar je wilt van kijken of het een schrikkeljaar is");
            int jaar = int.Parse(Console.ReadLine());
            if (jaar % 4 == 0)
            {
                if (jaar % 100 == 0 && jaar % 400 != 0)
                {
                    Console.WriteLine("het is geen schrikkeljaar");
                }
                else Console.WriteLine("het is een schrikkeljaar");
            }
            else Console.WriteLine("is geen schrikkeljaar");

        }
    }
}
