using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling
{
    public class Zichtrekening : Rekening
    {
        private decimal maxKredietValue;

        public decimal MaxKrediet
        {
            get { return maxKredietValue; }
            set
            {
                if (value > 0)
                    throw new Exception("Max krediet mag geen positieve waarden hebben");
                maxKredietValue = value; }
        }

        public Zichtrekening(ulong nummer,double saldo,DateTime creatiedatum,Klant klant,decimal maxkrediet):base(nummer,saldo,creatiedatum,klant)
        {
            this.MaxKrediet = maxkrediet;
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Max krediet: {0}",MaxKrediet);
        }
        
    }
}
