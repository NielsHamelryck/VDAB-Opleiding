using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Herhaling2
{
    class Program
    {

        static void Main(string[] args)
        {

            string woord = "lepel";

            for(int teller=0;teller<woord.Length;teller++)
            {
                Console.WriteLine("{0},{0}",(char)woord[teller],(char)woord[(woord.Length-1)-teller]);
            }           


        }


       
    }
}