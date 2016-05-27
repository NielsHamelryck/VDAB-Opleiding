using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening5_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Rekening r1 = new Rekening(063154756360,new DateTime(1899,5,1),3000);
            r1.Storten(200);
            r1.Afbeelden(); 

        }
    }
}
