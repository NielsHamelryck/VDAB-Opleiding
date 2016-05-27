using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Spaarrekening : Rekening
    {
        
        public Spaarrekening(ulong nummer,DateTime creatiedatum,double saldo,Klant Eigenaar):base(nummer,creatiedatum,saldo,Eigenaar)
        {
            
            
    }
        private static double intrestValue;

        public static double Intrest
        {
            get { return intrestValue; }
            set 
            {
                if (value >= 0d)
                    intrestValue = value;
                else throw new Exception("Intrest mag geen negatieve waarde hebben!:" + value);
            }
        
        }
        
        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Intrest op De spaarrekening : {0}",Intrest);
        }
    }
}
