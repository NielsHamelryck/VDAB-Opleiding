using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    public class Persoon
    {
        public string Naam { get; set; }
        public int aantalKinderen { get; set; }
        public Persoon()
        {
           
        }
        public Persoon(string naam)
        {
            this.Naam = naam;
        }
        public Persoon(string naam,int aantalkinderen)
        {
            this.Naam = naam;
            this.aantalKinderen = aantalkinderen;
        }
    }
}
