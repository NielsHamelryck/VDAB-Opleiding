using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCursus
{
    public partial class Rekening
    {
        
        public void Storten(decimal bedrag)
        {
            Saldo += bedrag;
        }

        public void Overschrijven(Rekening naarRekening, decimal bedrag)
        {
            if (this.Saldo <= 0)
            {
                throw new SaldoOntoereikendException();
            }
            else
            {
                this.Saldo -= bedrag;
                naarRekening.Saldo += bedrag;
            }
        }
    }
}
