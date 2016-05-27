using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TddHerhaling
{
    public class ISBN
    {
        private long isbn;
        private long MaxWaardeNummer = 9999999999999L;
        private long minWaardeNummer = 1000000000000L;
         
        public ISBN(long nummer)
        {
            
            if (nummer < minWaardeNummer || nummer > MaxWaardeNummer)
            {
                throw new ArgumentException();
            }
            var somEvengetallen = 0l;
            var somOnevenGetallen = 0l;
            var werkcijfer = nummer / 10l;
            for (var teller = 0; teller != 6; teller++)
            {
                somOnevenGetallen += werkcijfer % 10l;
                werkcijfer /= 10;
                somEvengetallen += werkcijfer % 10l;
                werkcijfer /= 10;
            }
            var SomGetallen = somEvengetallen * 3 + somOnevenGetallen;
            var verschil =SomGetallen-SomGetallen %10 +10  - SomGetallen;
            if (verschil==10)
            {
                if (verschil != nummer % 10)
                {
                    throw new ArgumentException();
                }
            }else 
            {
                if (verschil == nummer % 10)
                {
                    throw new ArgumentException();
                }
            }
            this.isbn = nummer;
            
               

            
            
        }
        public override string ToString()
        {
            return isbn.ToString();
        }
    }
}
