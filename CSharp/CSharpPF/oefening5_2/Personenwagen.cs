using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening5_2
{
    public class Personenwagen : Voertuig , IVervuiler
    {
        public Personenwagen()
            : base()
        {
            this.AantalDeuren = 4;
            this.AantalPassagiers = 5;
        }
        public Personenwagen(string polishouder,decimal kostprijs,int pk,float gemiddeldverbruik,string nummerplaat,int deuren,int passagiers)
            : base(polishouder, kostprijs, pk, gemiddeldverbruik, nummerplaat)
        {
            this.AantalDeuren = deuren;
            this.AantalPassagiers = passagiers;
        }
        private int aantalDeurenValue;

        public int AantalDeuren
        {
            get { return aantalDeurenValue; }
            set
            {
                if (value >= 2 && value <= 5)
                    aantalDeurenValue = value;
                
            }
        }
        private int aantalPassagiersValue;

        public int AantalPassagiers
        {
            get { return aantalPassagiersValue; }
            set
            {
                if (value >= 2 && value <= 8)
                    aantalPassagiersValue = value;
                
            }
        }
        public override void Afbeelden()
        {
            Console.WriteLine("Personenwagen");
            base.Afbeelden();
            Console.WriteLine("Aantal deuren dat de personenwagen heeft: {0}",AantalDeuren);
            Console.WriteLine("Het aantal passagiers dat maximaal in de personenwagen kunnen zitten: {0}", AantalPassagiers);
        }

        public override double GetKyotoScore()
        {
            double kyotoScore = 0.0d;
            if (AantalPassagiers != 0)
            {
                kyotoScore = (GemiddeldVerbruik * Pk) / AantalPassagiers;
            }
            return kyotoScore;
        }


        public double GeefVervuiling()
        {
            return GetKyotoScore()*5;
            
        }
    }
}
