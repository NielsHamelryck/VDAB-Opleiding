using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling
{
    class BankBediende
    {
        public string Voornaam { get; set; }
        public string Naam { get; set; }

        public BankBediende(string voornaam, string naam)
        {
            this.Voornaam = voornaam;
            this.Naam = naam;
        }

        public void ToonRekeningUittreksel(Rekening rekening)
        {
             Console.WriteLine("RekeningUittreksel");
            Console.WriteLine("Rekeningnummer : {0:000-0000000-00}",rekening.Rekeningnummer);
            Console.WriteLine("Vorig saldo: {0} in euro",rekening.VorigSaldo);
            Console.WriteLine("Nieuw saldo : {0} in euro", rekening.Saldo);
            if(rekening.VorigSaldo>rekening.Saldo)
                
            Console.WriteLine("afhaling {0} in euro",rekening.VorigSaldo-rekening.Saldo);
            else
                Console.WriteLine("storting {0} in euro", rekening.Saldo - rekening.VorigSaldo);
           
            
        }

        public void ToonInhetRood(Rekening rekening)
        {
            Console.WriteLine("afhaling niet mogelijk! Ontoereikend Saldo");
        }

        public void Afbeelden()
        {
            Console.WriteLine("BankBediende: "+Voornaam+" "+Naam);
        }

    }
}
