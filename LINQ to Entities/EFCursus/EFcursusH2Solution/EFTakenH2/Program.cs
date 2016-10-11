using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IsolationLevel = System.Transactions.IsolationLevel;


namespace EFTakenH2
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var entities = new Bank3Entities())
            {

                var query = entities.Klanten.Join(entities.Rekeningen,
                    (klant => klant.KlantNr),
                    (rekening => rekening.KlantNr),
                    ((klant, rekening) => new {Klante = klant, Rekeningen = rekening})
                    ).Where(rekening=>rekening.Rekeningen is Spaarrekening);

                foreach (var rekening in query)
                {
                    Console.WriteLine("{0} : {1} - {2} : {3}",
                        rekening.Klante.KlantNr,rekening.Klante.Voornaam,rekening.Rekeningen.RekeningNr,rekening.Rekeningen.Saldo);
                }
            }
        
        }

        
        
          
    }


}


