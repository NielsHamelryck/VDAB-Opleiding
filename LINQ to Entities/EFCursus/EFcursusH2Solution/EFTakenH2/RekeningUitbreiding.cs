using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTakenH2
{
    public partial class Rekening
    {
       
        public void Storten(decimal bedrag)
        {
            this.Saldo += bedrag;
        }

        public void Overschrijven(Rekening naarRekening, decimal bedrag)
        {
            if (bedrag > this.Saldo)
                throw new SaldoOntoereikendException();
            else
            {
                this.Saldo -= bedrag;
                naarRekening.Saldo += bedrag;
            }
        }
    }
}
