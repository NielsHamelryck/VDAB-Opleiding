using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening5_2
{
    public abstract class Voertuig : IMilieu,IPrivaat
    {
        private string valuePolisHouder;
        private decimal valueKostPrijs;
        private int valuePk;
        private float valueGemiddeldVerbruik;
        private string valueNummerplaat;

        public Voertuig()
            : this("onbepaald", 0, 0, 0, "onbepaald")
        {
        }
        public Voertuig(string polishouder, decimal kostprijs, int pk, float gemiddeldverbruik, string nummerplaat)
        {
            this.Polishouder = polishouder;
            this.KostPrijs = kostprijs;
            this.Pk = pk;
            this.GemiddeldVerbruik = gemiddeldverbruik;
            this.Nummerplaat = nummerplaat;
        }
        public string Polishouder
        {
            get
            {
                return valuePolisHouder;
            }
            set
            {
                valuePolisHouder = value;
            }
        }
        public decimal KostPrijs
        {
            get
            {
                return valueKostPrijs;
            }
            set
            {
                valueKostPrijs = value;
            }
        }
        public int Pk
        {
            get
            {
                return valuePk;
            }
            set
            {
                valuePk = value;
            }
        }
        public float GemiddeldVerbruik
        {
            get
            {
                return valueGemiddeldVerbruik;
            }
            set
            {
                valueGemiddeldVerbruik = value;
            }
        }
        public string Nummerplaat
        {
            get
            {
                return valueNummerplaat;
            }
            set
            {
                valueNummerplaat = value;
            }
        }
        public virtual void Afbeelden()
        {
            Console.WriteLine("Polis houder : {0}", Polishouder);
            Console.WriteLine("Kostprijs : {0} ", KostPrijs);
            Console.WriteLine("Pk : {0}", Pk);
            Console.WriteLine("Het gemiddelde verbruik : {0}", GemiddeldVerbruik);
            Console.WriteLine("De nummerplaat : {0} ", Nummerplaat);
        }


        public abstract double GetKyotoScore();




        public string GeefMilieuData()
        {
            return string.Format("Milieu :pk: {0} , kostprijs: {1} , gemiddeldverbruik : {2}", Pk, KostPrijs, GemiddeldVerbruik);
        }

        public string GeefPrivateData()
        {
            return string.Format("Gegevens : polishouder : {0} , Nummerplaat {1}", Polishouder, Nummerplaat);
        }
    }
}