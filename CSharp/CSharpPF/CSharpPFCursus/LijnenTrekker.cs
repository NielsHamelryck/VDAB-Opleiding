using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    class LijnenTrekker
    {

        public void TrekLijn(int lengte, char teken = '~')
        {
            for (int teller = 0; teller < lengte; teller++)
                Console.Write(teken);
            Console.WriteLine();
        }
        
       
    }
}
