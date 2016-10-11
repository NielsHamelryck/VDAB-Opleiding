using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTakenH2
{
    public partial class Rekening
    {
        public void Overschrijven2(Rekening naarRekening, decimal bedrag)
        {
            if (this.Saldo < bedrag)
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
