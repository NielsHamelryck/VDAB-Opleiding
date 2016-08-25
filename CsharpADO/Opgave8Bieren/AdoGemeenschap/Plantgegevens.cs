using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Plantgegevens
    {
        
        public String Naam { get; set; }
       public String Soort { get; set; }
        public String Leverancier { get; set; }
        public String Kleur { get; set; }

        public Decimal Kostprijs { get; set; }
        
        public Plantgegevens()
        {
            
        }
    }
}
