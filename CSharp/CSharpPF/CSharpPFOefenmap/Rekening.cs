using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{   
    public abstract class Rekening : ISpaarmiddel
    {
        private readonly DateTime bedrijfCreatie = new DateTime(1900, 1, 1);
        public delegate void Transactie(Rekening rekening);
        public Rekening(ulong rekeningnummer, DateTime creatiedatum, double saldo, Klant eigenaar)
        {
            this.Rekeningnummer = rekeningnummer;
            this.Creatiedatum = creatiedatum;
            this.Saldo = saldo;
            Eigenaar = eigenaar;

        }
        private ulong rekeningnummerValue;

        public ulong Rekeningnummer
        {
            get { return rekeningnummerValue; }
            set
            {
                ulong eerste10 = value / 100ul;
                int laatste2 = (int)(value % 100ul);
                if ((int)(eerste10 % 97ul) != laatste2)
                    throw new Exception("Geen geldig rekening nummer: " + string.Format("{0:000-0000000-00}", value));
                    rekeningnummerValue = value;
                
            }

        }

        private double saldoValue;

        public double Saldo
        {
            get { return saldoValue; }
            set { saldoValue = value; }
        }

        private DateTime creatiedatumValue;

        public DateTime Creatiedatum
        {
            get { return creatiedatumValue; }
            set
            {
                if (value >= bedrijfCreatie)
                    creatiedatumValue = value;
                else throw new Exception("Ongeldige datum:  " + value);
            }
        }

        public virtual void Afbeelden()
        {
            Console.WriteLine("Het rekeningnummer : {0:000-0000000-00}", Rekeningnummer);
            Console.WriteLine("Het beschikbare Saldo : {0}", Saldo);
            Console.WriteLine("Creatiedatum : {0}", Creatiedatum);
            if (Eigenaar != null)
                Eigenaar.Afbeelden();
        }
        public void Storten(double bedrag)
        {
            VorigBedrag = Saldo;
            Saldo += bedrag;
            RekeningUittrekselEvent(this);
            
           
        }

        private double vorigbedragValue;

        public double VorigBedrag
        {
            get { return vorigbedragValue; }
            set { vorigbedragValue = value; }
        }

        public void Afhalen(double bedrag)
        {
            VorigBedrag = Saldo;
            if ((VorigBedrag - bedrag) >= 0)
            {
                Saldo = VorigBedrag - bedrag;
                RekeningUittrekselEvent(this);
                   
            }
            else
            {

                SaldoInHetRood(this);
                    
            }
        }

        public Transactie RekeningUittrekselEvent;
     
        public  Transactie SaldoInHetRood;
        

        private Klant eigenaarValue;

        public Klant Eigenaar
        {
            get { return eigenaarValue; }
            set { eigenaarValue = value; }
        }



        
    }
}
