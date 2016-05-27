using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling
{
    public abstract class Voertuig
    {
        private string polishouderValue;

        public string Polishouder
        {
            get { return polishouderValue; }
            set { 
                polishouderValue = value; }
        }

        private decimal kostprijsValue;

        public decimal Kostprijs
        {
            get { return kostprijsValue; }
            set
            {
                if (value < 0)
                    throw new Exception("Kostprijs kan niet negatief zijn");
                kostprijsValue = value; }
        }

        private int pkValue;

        public int Pk
        {
            get { return pkValue; }
            set
            {
                if (value < 0)
                    throw new Exception("Pk kan niet negatief zijn"); 
                pkValue = value; }
        }

        private float gemVerbruikValue;

        public float GemiddeldVerbruik
        {
            get { return gemVerbruikValue; }
            set
            {
                if (value < 0)
                    throw new Exception("GemiddeldVerbruik kan niet negatief zijn"); 
                gemVerbruikValue = value; }
        }
        private string nummerplaatValue;

        public string NummerPlaat
        {
            get { return nummerplaatValue; }
            set { nummerplaatValue = value; }
        }
        
        
        

        public Voertuig()
        {
            Polishouder = "onbepaald";
            Kostprijs = 0;
            Pk = 0;
            GemiddeldVerbruik = 0;
            NummerPlaat = "onbepaald";
        }
        public Voertuig(string naam,decimal prijs,int pk,float gemVerbruik,string nummerplaat)
        {
            this.Polishouder = naam;
            this.Kostprijs = prijs;
            this.Pk = pk;
            this.GemiddeldVerbruik = gemVerbruik;
            this.NummerPlaat = nummerplaat;
        }
        public virtual void Afbeelden()
        {
            Console.WriteLine("Naam polishouder: {0}",Polishouder);
            Console.WriteLine("Kostprijs: {0}",Kostprijs);
            Console.WriteLine("Pk : {0}",Pk);
            Console.WriteLine("Gemiddeld verbruik: {0}",GemiddeldVerbruik);
            Console.WriteLine("Nummerplaat : {0}",NummerPlaat);
        }

        public abstract double KyotoScore();
    }
}
