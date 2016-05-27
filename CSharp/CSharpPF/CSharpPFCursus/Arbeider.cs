using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    public class Arbeider : Werknemer 
    {
        public Arbeider(string naam, DateTime inDienst, Geslacht geslacht, decimal uurloon, byte ploegenstelsel)
            : base(naam, inDienst, geslacht)
        {
            Uurloon = uurloon;
            Ploegenstelsel = ploegenstelsel;
        }
        private decimal uurloonValue;

        public decimal Uurloon
        {
            get { return uurloonValue; }
            set { if(value >=0m)
                uurloonValue = value; }
        }
        private byte ploegenstelselValue;

        public byte Ploegenstelsel
        {
            get { return ploegenstelselValue; }
            set {if (value >=1 && value<=3) 
                ploegenstelselValue = value; }
        }
        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine(Uurloon);
            Console.WriteLine(Ploegenstelsel);
        }
        public override string ToString()
        {
            return base.ToString()+" "+ Uurloon + " euro/uur";
          
        }
        

        public override decimal Premie
        {
            get { return  Uurloon*150; }
        }

        public override decimal Bedrag
        {
            get { return Uurloon*2000m; }
        }
    }
}
