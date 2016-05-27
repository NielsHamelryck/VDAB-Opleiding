using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    class Kasbons : ISpaarmiddel
    {
        private DateTime aankoopDatumValue;
        private readonly DateTime eersteAankoop = new DateTime(1900, 1, 1);
        public DateTime AankoopDatum
        {
            get { return aankoopDatumValue; }
            set 
            { 
                if(value>=eersteAankoop) 
                aankoopDatumValue = value;
                else throw new Exception("Ongeldige datum:  " + value);
            }
        }
        private double bedragValue;

        public double Bedrag
        {
            get { return bedragValue; }
            set
            {
                if (value > 0)
                    bedragValue = value;
                else throw new Exception("waarde mag niet <0 zijn: " + value);
            }
        }
        private int looptijdValue;

        public int Looptijd
        {
            get { return looptijdValue; }
            set 
            {
                if (value > 0)
                    looptijdValue = value;
                else throw new Exception("looptijd kan niet negatief zijn:" + value);
            }
        }
        private double intrestValue;

        public double Intrest
        {
            get { return intrestValue; }
            set 
            {
                if (value > 0)
                    intrestValue = value;
                else throw new Exception("Interest kan niet negatief zijn;" + value);
            }
        }
        private Klant eigenaarValue;

        public Klant Eigenaar
        {
            get { return eigenaarValue; }
            set { eigenaarValue = value; }
        }

        public Kasbons(DateTime aankoopdatum,double bedrag,int looptijd,double intrest,Klant eigenaar)
        {
            this.AankoopDatum = aankoopdatum;
            this.Bedrag = bedrag;
            this.Looptijd = looptijd;
            this.Intrest = intrest;
            this.Eigenaar = eigenaar;
        }



        public void Afbeelden()
        {
            if (Eigenaar != null)
            {
                Console.WriteLine("Eigenaar:");
                Eigenaar.Afbeelden();
            }
            Console.WriteLine("Aangekocht op: {0}",AankoopDatum);
            Console.WriteLine("Voor het bedrag van: {0}", Bedrag);
            Console.WriteLine("duurtijd: {0} jaar",Looptijd);
            Console.WriteLine("Intrest: {0}",Intrest);
           

        }
    }
}
