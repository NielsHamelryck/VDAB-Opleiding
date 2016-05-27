using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening5_1
{
    public class Rekening
    {
        private readonly DateTime bedrijfCreatie = new DateTime(1900, 1, 1);
        public Rekening()
            : this(000000000000, new DateTime(1900, 1, 1), 0)
        {

        }
        public Rekening(ulong rekeningnummer, DateTime creatiedatum, double saldo)
        {
            this.Rekeningnummer = rekeningnummer;
            this.Creatiedatum = creatiedatum;
            this.Saldo = saldo;

        }
        private ulong rekeningnummerValue;

        public ulong Rekeningnummer
        {
            get { return rekeningnummerValue; }
            set
            {
                ulong eerste10 = value / 100ul;
                int laatste2 = (int)(value % 100ul);
                if((int)(eerste10%97ul)==laatste2)
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
            set { if(value>=bedrijfCreatie)
                creatiedatumValue = value; }
        }

        public void Afbeelden()
        {
            Console.WriteLine("Het rekeningnummer : {0:000-0000000-00}", Rekeningnummer);
            Console.WriteLine("Het beschikbare Saldo : {0}", Saldo);
            Console.WriteLine("Creatiedatum : {0}", Creatiedatum);
        }
        public double Storten(double bedrag)
        {
            return this.Saldo += bedrag;
        }
    }
}
