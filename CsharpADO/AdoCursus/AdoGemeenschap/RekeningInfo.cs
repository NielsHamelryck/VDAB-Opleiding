using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class RekeningInfo
    {
        public Decimal Saldo { get; set; }

        public String KlantNaam { get; set; }

        public RekeningInfo(Decimal saldo, String klantNaam)
        {
            this.KlantNaam = klantNaam;
            this.Saldo = saldo;
        }
    }
}
