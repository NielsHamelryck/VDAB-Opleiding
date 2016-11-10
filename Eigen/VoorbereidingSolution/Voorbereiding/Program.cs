using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbereiding
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape rShape = new Rectangle(3,5);
            Rectangle r = new Rectangle(5,2);
            Triangle t = new Triangle(5,2);
            double c = rShape.area();
            Console.WriteLine(c);
            Console.WriteLine();
           double a = r.area();
            Console.WriteLine("rectangle = {0}",a);
           double b=  t.area();
            PrintData p = new PrintData();

            p.Stress();
            
            Console.WriteLine("traingle = {0}", b);
        }
    }
}
