using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening5_2
{
    public class Vrachtwagen : Voertuig , IVervuiler
    {
        public Vrachtwagen()
            : base()
        {
            this.MaxLading = 10000f;
        }
        
        public Vrachtwagen(string polishouder, decimal kostprijs, int pk, float gemiddeldverbruik, string nummerplaat,float maxlading)
            : base(polishouder,kostprijs,pk,gemiddeldverbruik,nummerplaat) 
        {
            this.MaxLading = maxlading;
        }
        private float maxladingValue;

        public float MaxLading
        {
            get { return maxladingValue; }
            set
            {
                if (value >= 0f)
                    maxladingValue = value;
                
            }
        }
        public override void Afbeelden()
        {
            Console.WriteLine("Vrachtwagen");
            base.Afbeelden();
            Console.WriteLine("de Max Lading capaciteit : {0} kg", MaxLading);
        }

        public override double GetKyotoScore()
        {
            double kyotoScore = 0.0d;
            if (MaxLading != 0)
            {
                kyotoScore = (GemiddeldVerbruik * Pk) / MaxLading;
            }
            return kyotoScore;
        }


        public double GeefVervuiling()
        {
            return GetKyotoScore()*20;
        }
    }
}
