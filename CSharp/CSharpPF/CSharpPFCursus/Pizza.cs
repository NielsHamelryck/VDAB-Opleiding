using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    [Serializable]
    public class Pizza
    {
        public string Naam { get; set; }

        public List<String> Onderdelen { get; set; }
        
        public decimal Prijs { get; set; }

        public override string ToString()
        {
            return Naam + ": " + Prijs +"EUR";
        }
    }
}
