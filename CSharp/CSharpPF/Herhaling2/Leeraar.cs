using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class Leraar : Persoon
    {
        public string Onderwerp { get; set; }
        public void Explain()
        {
            Console.WriteLine("Explanation begins on {0}", Onderwerp);
        }
         public Leraar(string naam,string vak)
            : base(naam)
        {
            this.Onderwerp = vak;
        }
        public override void Greet()
        {
            base.Greet();
            Explain();
        }
    }
}
