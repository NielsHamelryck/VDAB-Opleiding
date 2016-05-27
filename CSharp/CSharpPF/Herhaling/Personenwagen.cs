using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling
{
    public class Personenwagen :Voertuig
    {
        private int deurenValue;

        public int AantalDeuren
        {
            get { return deurenValue; }
            set
            {
                if (value <= 0)
                    throw new Exception("Aantal deuren mag niet negatief zijn" + value);
                deurenValue = value; }
        }
        private int passagiersValue;

        public int AantalPassagiers
        {
            get { return passagiersValue; }
            set {
                if (value <= 0)
                    throw new Exception("Hoeveelheid passagiers mag niet negatief zijn" + value);
                passagiersValue = value; }
        }

        public Personenwagen():base()
        {
            AantalDeuren = 4;
            AantalPassagiers = 5;
        }
        public Personenwagen(string naam,decimal prijs, int pk, float gemVerbruik,string nummerplaat,int deuren,int passagiers):base
            (naam,prijs,pk,gemVerbruik,nummerplaat)
        {
            this.AantalDeuren = deuren;
            this.AantalPassagiers = passagiers;
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Aantal deuren: {0}",AantalDeuren);
            Console.WriteLine("Aantal passagiersplaatsen: {0}",AantalPassagiers);
        }

        public override double KyotoScore()
        {
            return (GemiddeldVerbruik * Pk) / AantalPassagiers;
        }
        
    }
}
