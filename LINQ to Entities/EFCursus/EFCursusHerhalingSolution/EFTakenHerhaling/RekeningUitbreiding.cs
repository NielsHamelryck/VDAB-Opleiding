using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTakenHerhaling
{
    public partial class Rekening
    {
        

        public void Storten(decimal bedrag)
        {
            
            Saldo += bedrag;
        }

        public void Overschrijven(Rekening naarRekening, decimal bedrag)
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
