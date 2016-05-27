using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Zichtrekening : Rekening
    {
        public Zichtrekening(ulong rekeningnummer, DateTime creatieDatum, double saldo, double maxkrediet,Klant Eigenaar)
            : base(rekeningnummer, creatieDatum, saldo,Eigenaar)
        {
           
            this.MaxKrediet = maxkrediet;
        }
        private double maxKredietValue;

        public double MaxKrediet
        {
            get { return maxKredietValue; }
            set
            {
                if (value > 0)
                    throw new Exception("Geen negatieve waarde: " + value);
                    maxKredietValue = value;
                 
            }
        }
        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Max bedrag in het rood : {0}", MaxKrediet);
        }




    }
}
