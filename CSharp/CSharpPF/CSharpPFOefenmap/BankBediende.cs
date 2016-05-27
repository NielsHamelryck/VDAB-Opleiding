using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class BankBediende
    {
        private string voornaamValue;

        public string Voornaam
        {
            get { return voornaamValue; }
            set { voornaamValue = value; }
        }
        private string achternaamValue;

        public string Achternaam
        {
            get { return achternaamValue; }
            set { achternaamValue = value; }
        }

        public BankBediende(string voornaam, string achternaam)
        {
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
        }
       
        public void toonSaldoInRood(Rekening rekening)
        {
            Console.WriteLine("Geen afhaling mogelijk maximaal afhaalbaar bedrag is {0}",rekening.Saldo);
        }
        public void toonUittreksel(Rekening rekening)
        {
       
            Console.WriteLine("RekeningUittreksel");
            Console.WriteLine("Rekeningnummer : {0:000-0000000-00}",rekening.Rekeningnummer);
            Console.WriteLine("Vorig saldo: {0} in euro",rekening.VorigBedrag);
            Console.WriteLine("Nieuw saldo : {0} in euro", rekening.Saldo);
            if(rekening.VorigBedrag>rekening.Saldo)
                
            Console.WriteLine("afhaling {0} in euro",rekening.VorigBedrag-rekening.Saldo);
            else
                Console.WriteLine("storting {0} in euro", rekening.Saldo - rekening.VorigBedrag);
           
            }
        
    }
}
