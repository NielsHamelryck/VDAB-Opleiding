using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class Rekening
    {
        readonly DateTime controleDatum = new DateTime(1900, 1, 1);
        private ulong nrValue;

        public ulong Rekeningnr
        {
            get { return nrValue; }
            set
            {
                int eerste10Cijfers = (int)value / 100;
                int tweeLaatsteCijfers = (int)value % 100;
                if((eerste10Cijfers%97)==tweeLaatsteCijfers)
                nrValue = value;
            }
        }
        private decimal saldoValue;

        public decimal Saldo
        {
            get { return saldoValue; }
            set { saldoValue = value; }
        }

        private DateTime creatieDatumValue;

        public DateTime CreatieDatum
        {
            get { return creatieDatumValue; }
            set {   if(value>=controleDatum)
                    creatieDatumValue = value;
            else Console.WriteLine("Geen geldige Datum ingevoerd");
            }
        }
        public Rekening(ulong nr, decimal saldo, DateTime creatie)
        {
            this.Rekeningnr = nr;
            this.Saldo = saldo;
            this.CreatieDatum = creatie;
        }

        public void Afbeelden()
        {
            Console.WriteLine("Rekeningnummer {0}",Rekeningnr);
            Console.WriteLine("Saldo {0}", Saldo);
            Console.WriteLine("Creatie Datum {0}",CreatieDatum.ToShortDateString());
        }

        public void Storten(decimal bedrag)
        {
            Saldo += bedrag;
        }
        
        
    }
}
