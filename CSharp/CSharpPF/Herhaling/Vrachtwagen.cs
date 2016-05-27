using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling
{
    public class Vrachtwagen : Voertuig
    {
        private float maxLadingValue;

        public float MaximumLading
        {
            get { return maxLadingValue; }
            set
            {
                if (value <0)
                    throw new Exception("max lading mag niet negatief zijn");
                maxLadingValue = value; }
        }

        public Vrachtwagen(string naam,decimal prijs,int pk, float gemVerbruik,string nummerplaat,float maxlading):base
            (naam,prijs,pk,gemVerbruik,nummerplaat)
        {
            this.MaximumLading = maxlading;
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Max lading : {0}", MaximumLading);
        }

        public Vrachtwagen():base()
        {
            MaximumLading = 10000f;
        }
        public override double KyotoScore()
        {
            return (GemiddeldVerbruik * Pk) / MaximumLading;
        }
    }
}
