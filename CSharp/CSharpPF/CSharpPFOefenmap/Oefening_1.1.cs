using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    class Program
    {
        const double GemLichTemp = 37;
        static void Main(string[] args)
        {
            double celciusInFarh;
            celciusInFarh= (GemLichTemp * (9 / 5)) + 32;
            Console.WriteLine("{0} Celcius omgezet in Farhenheit",GemLichTemp,celciusInFarh); 
            


        }
    }
}
