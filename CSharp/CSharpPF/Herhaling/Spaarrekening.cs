using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling
{
    public class Spaarrekening : Rekening
    {
        private static double intrestValue;

        public static double Intrest
        {
            get { return intrestValue; }
            set
            {
                if (value < 0)
                    throw new Exception("Intrest mag niet negatief zijn");
                intrestValue = value; }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Intrest: {0}", Intrest);
        }
        public Spaarrekening(ulong nummer,double saldo,DateTime creatiedatum,Klant klant):base(nummer,saldo,creatiedatum,klant)
        {
           
        }
    }
}
