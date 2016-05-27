using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling
{
    
    public class Kasbons : ISpaarmiddel
    {
        DateTime BeginCreatie = new DateTime(1900, 1, 1);
        private DateTime aankoopdatumValue;

        public DateTime AankoopDatum
        {
            get { return aankoopdatumValue; }
            set
            {
                if (value < BeginCreatie)
                    throw new Exception("Ongeldige datum: "+value);
                aankoopdatumValue = value; }
        }
        private double bedragValue;

        public double Bedrag
        {
            get { return bedragValue; }
            set
            {
                if (value <= 0)
                    throw new Exception("Bedrag mag niet negatief zijn: " + value);
                bedragValue = value; }
        }
        private int looptijdvalue;

        public int Looptijd
        {
            get { return looptijdvalue; }
            set
            {
                if (value <= 0)
                    throw new Exception("Looptijd kan niet negatief zijn: " + value);
                looptijdvalue = value; }
        }

        private double intrestvalue;
                    
        public double Intrest
        {
            get { return intrestvalue; }
            set { intrestvalue = value; }
        }

        private Klant eigenaarValue;

        public Klant Eigenaar
        {
            get { return eigenaarValue; }
            set { eigenaarValue = value; }
        }

        public Kasbons(DateTime aankoopdatum,double bedrag,int looptijd,double intrest,Klant eigenaar):base()
        {
            this.AankoopDatum = aankoopdatum;
            this.Bedrag = bedrag;
            this.Looptijd = looptijd;
            this.Intrest = intrest;
            this.Eigenaar = eigenaar;
        }

        public void Afbeelden()
        {
            Console.WriteLine("Aankoop Datum kasbon : {0}",AankoopDatum);
            Console.WriteLine("Bedrag :{0} ", Bedrag);
            Console.WriteLine("Looptijd: {0}", Looptijd);
            Console.WriteLine("Intrest : {0}", Intrest);
            if (Eigenaar != null)
                Eigenaar.Afbeelden();
        }

        
        
        
    }
}
