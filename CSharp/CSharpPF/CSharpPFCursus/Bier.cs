using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpPFCursus
{
    public class Bier
    {
        public int BierNr { get; set; }
        public string BierNaam { get; set; }
        public float Alcohol { get; set; }
        public Brouwer Brouwer { get; set; } // associatie met brouwer
        public override String ToString() { return BierNaam + ": " + Alcohol + " % alcohol"; }
    }
}
