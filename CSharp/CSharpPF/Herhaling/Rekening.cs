using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling
{
    
    public abstract class Rekening :ISpaarmiddel
    {
        private ulong rekNrValue;
        public delegate void Transactie(Rekening rekening);
        public ulong Rekeningnummer
        {
            get { return rekNrValue; }
            set
            {
                ulong eerste10 = value / 100UL;
                int laatste2 = (int)(value % 100UL);

                if ((int)(eerste10 % 97) != laatste2)
                    throw new Exception(value +" is geen geldig rekening nummer");
                    rekNrValue = value; }
        }
        private double saldoValue;

        public double Saldo
        {
            get { return saldoValue; }
            set { saldoValue = value; }
        }
        private DateTime datumValue;

        public DateTime CreatieDatum
        {
            get { return datumValue; }
            set
            {
                if (value.Date < new DateTime(1900, 1, 1))
                    throw new Exception("Dit is geen geldige creatie datum");
                datumValue = value; }
        }
        public event Transactie RekeningUitreksel;
        public event Transactie SaldoInHetRood;
        public void Storten(double bedrag)
        {
            VorigSaldo = Saldo;
            Saldo = VorigSaldo + bedrag;
            if(RekeningUitreksel!=null)
            RekeningUitreksel(this);
            
        }

        public void Afhalen(double bedrag)
        {
            VorigSaldo = Saldo;
            if ((VorigSaldo - bedrag) >= 0)
            {
                
                Saldo = VorigSaldo - bedrag;
                if(RekeningUitreksel != null)
                RekeningUitreksel(this);
                
            }
            else
            {
                
                if(SaldoInHetRood!=null)
                SaldoInHetRood(this);
                
            }
            
        }

        public virtual void Afbeelden()
        {
            Console.WriteLine("Rekeningnummer: {0}",Rekeningnummer);
            Console.WriteLine("Saldo: {0}",Saldo);
            Console.WriteLine("CreatieDatum: {0:yyyy.MM.dd}", CreatieDatum);
            if (Klant != null)
                Klant.Afbeelden();
        }

        public Rekening(ulong nummer,double saldo, DateTime creatiedatum, Klant Klant)
        {
            this.Rekeningnummer = nummer;
            this.Saldo = saldo;
            this.CreatieDatum= creatiedatum;
            this.Klant = Klant;
        }

        private Klant klantValue;

        public Klant Klant
        {
            get { return klantValue; }
            set { klantValue = value; }
        }

        private double vorigSaldoValue;

        public double VorigSaldo
        {
            get { return vorigSaldoValue; }
            set { vorigSaldoValue = value; }
        }
        
       
        
        
    }
}
