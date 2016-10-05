using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EFTakenHerhaling
{
    public class Program
    {
        static void Main(string[] args)
        {
            //TAAK 1.1 Bank Maken
            //********
            //////////


            //TAAK 1.2 Klanten en hun Rekeningen
            ////////////////////////////////////

            //////////try
            //////////{

            //////////    using (var entities = new BankEntities())
            //////////    {
            //////////        var query = from klant in entities.Klanten
            //////////                    //join rekening in entities.Rekeningen
            //////////                    //on klant.KlantNr equals rekening.KlantNr
            //////////                    orderby klant.Voornaam
            //////////                    select klant;
            //////////        foreach (var klant in query)
            //////////        {   var totaal = 0m;
            //////////            Console.WriteLine(klant.Voornaam);
            //////////            if (klant.Rekeningen.Count > 0)
            //////////            {
            //////////                foreach (var rekening in klant.Rekeningen)
            //////////                {
            //////////                    Console.WriteLine(rekening.RekeningNr);
            //////////                    totaal += rekening.Saldo;
            //////////                }
            //////////            }
            //////////            Console.WriteLine("Totaal: {0}",totaal);
            //////////            Console.WriteLine("\n");

            //////////        }
            //////////    }
            //////////}
            //////////catch (Exception ex)
            //////////{

            //////////   Console.WriteLine(ex.Message);
            //////////}

            ///Taak 1.3 Zichtrekening toevoegen
            /// 
            /// 
            //////////try
            //////////{
            //////////    int klantNr;
            //////////    using (var entities = new BankEntities())
            //////////    {
            //////////        var query = from klant in entities.Klanten
            //////////                    orderby klant.Voornaam
            //////////                    select klant;

            //////////        foreach (var klant in query)
            //////////        {
            //////////            Console.WriteLine("{0}:{1} ", klant.KlantNr, klant.Voornaam);
            //////////        }
            //////////        Console.WriteLine("KlantNr: ");
            //////////        if (!int.TryParse(Console.ReadLine(), out klantNr))
            //////////        {
            //////////            throw new FormatException();
            //////////        }
            //////////        var klantGevonden = entities.Klanten.Find(klantNr);
            //////////        if (klantGevonden != null)
            //////////        {
            //////////            Console.WriteLine("Geef de nieuwe rekeningnummer");
            //////////           var nieuweReknr= Console.ReadLine();
            //////////            Rekening nieuweZichtRekening = new Rekening
            //////////            {
            //////////                RekeningNr = nieuweReknr ,
            //////////                Saldo = 0,
            //////////                Soort = "Z"
            //////////            };
            //////////            klantGevonden.Rekeningen.Add(nieuweZichtRekening);
            //////////            entities.SaveChanges();
            //////////        }else Console.WriteLine("Klant niet gevonden");
            //////////    }
            //////////}
            //////////catch (FormatException)
            //////////{

            //////////    Console.WriteLine("Tik een getal");
            //////////}



            ////taak 1.4

            //////////    try
            //////////    {
            //////////        string rekeningNr;
            //////////        decimal bedrag = 0m;


            //////////        using (var entities = new BankEntities())
            //////////        {
            //////////            //var queryStorten = from rekening in entities.Rekeningen
            //////////            //                   select rekening;
            //////////            Console.WriteLine("Voer een RekeningNummer in:");
            //////////            rekeningNr = Console.ReadLine();
            //////////            var rekeningGevonden = entities.Rekeningen.Find(rekeningNr);
            //////////            if (rekeningGevonden == null)
            //////////            {
            //////////                Console.WriteLine("Rekening niet gevonden");
            //////////            }
            //////////            else
            //////////            {
            //////////                Console.WriteLine("Geef het te storten Bedrag");
            //////////                if (!decimal.TryParse(Console.ReadLine(), out bedrag))
            //////////                {
            //////////                    Console.WriteLine("Tik een getal");
            //////////                }
            //////////                else
            //////////                {
            //////////                    if (bedrag <= 0)
            //////////                    {
            //////////                        Console.WriteLine("Tik een positief getal");
            //////////                    }
            //////////                    else
            //////////                    {
            //////////                        rekeningGevonden.Storten(bedrag);
            //////////                        entities.SaveChanges();
            //////////                    }
            //////////                }
            //////////            }
            //////////        }


            //////////    }
            //////////    catch (Exception ex)
            //////////    {

            //////////        Console.WriteLine(ex.Message);
            //////////    }
            //////////}

            ////taak 1.5 Klant verwijderen
            /// 
            ////////using (var entities = new BankEntities())
            ////////{
            ////////    try
            ////////    {
            ////////        var klantNr=0;
            ////////        Console.WriteLine("klantNr (te verwijderen klant):");
            ////////        klantNr= Int32.Parse(Console.ReadLine());
            ////////        var klantEntity = entities.Klanten.Find(klantNr);
            ////////        if (klantEntity == null)
            ////////        {
            ////////            Console.WriteLine("Klant niet gevonden");
            ////////        }
            ////////        else
            ////////        {
            ////////            if (klantEntity.Rekeningen.Count != 0)
            ////////            {
            ////////                Console.WriteLine("Klant heeft nog rekeningen");
            ////////            }
            ////////            else
            ////////            {
            ////////                entities.Klanten.Remove(klantEntity);
            ////////                entities.SaveChanges();
            ////////            }
            ////////        }    
            ////////    }
            ////////    catch (FormatException)
            ////////    {
            ////////        Console.WriteLine("Tik een getal in");
            ////////    }
            ////////}
            /////
            /// Taak 1.6 overschrijven
            /// 

            ////////    string vanRekNr;
            ////////    string naarRekNr;
            ////////    var bedrag = 0m;
            ////////    Console.WriteLine("Van Rekening nummer :");
            ////////    vanRekNr = Console.ReadLine();
            ////////    Console.WriteLine("Naar Rekening nummer :");
            ////////    naarRekNr = Console.ReadLine();
            ////////    try
            ////////    {
            ////////        Console.WriteLine("Bedrag:");
            ////////        if (!decimal.TryParse(Console.ReadLine(), out bedrag))
            ////////        {
            ////////            throw new FormatException();
            ////////        }
            ////////        else
            ////////        {
            ////////            var transacionOptions = new TransactionOptions
            ////////            {
            ////////                IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead
            ////////            };
            ////////            using (var transactionScope = new System.Transactions.TransactionScope(
            ////////                TransactionScopeOption.Required, transacionOptions))
            ////////            {
            ////////                using (var entities = new BankEntities())
            ////////                {
            ////////                    var vanRekening = entities.Rekeningen.Find(vanRekNr);
            ////////                    if (vanRekening == null)
            ////////                    {
            ////////                        Console.WriteLine("Van rekening bestaat niet");
            ////////                    }
            ////////                    else
            ////////                    {
            ////////                        var naarRekening = entities.Rekeningen.Find(naarRekNr);
            ////////                        if (naarRekening == null)
            ////////                        {
            ////////                            Console.WriteLine("Naar rekening bestaat niet");
            ////////                        }
            ////////                        else
            ////////                        {
            ////////                            try
            ////////                            {
            ////////                                vanRekening.Overschrijven(naarRekening,bedrag);
            ////////                                entities.SaveChanges();
            ////////                                transactionScope.Complete();
            ////////                            }
            ////////                            catch (SaldoOntoereikendException)
            ////////                            {

            ////////                                Console.WriteLine("Saldo ontoereikend");
            ////////                            }



            ////////                        }
            ////////                    }

            ////////                }
            ////////            }
            ////////        }
            ////////    }
            ////////    catch (FormatException)
            ////////    {

            ////////        Console.WriteLine("Tik een getal");
            ////////    }



            ////////}
            /// Taak 1.7 klant wijzigen
            //////    try
            //////    {
            //////        int klantNr;
            //////        Console.WriteLine("KlantNr: ");
            //////        if (!int.TryParse(Console.ReadLine(), out klantNr))
            //////        {
            //////            throw new FormatException();
            //////        }
            //////        else
            //////        {
            //////            using (var entities = new BankEntities())
            //////            {
            //////                var klant = entities.Klanten.Find(klantNr);
            //////                if (klant == null)
            //////                {
            //////                    Console.WriteLine("Klant niet gevonden");
            //////                }
            //////                else
            //////                {
            //////                    Console.WriteLine("Voornaam: ");
            //////                    klant.Voornaam = Console.ReadLine();
            //////                    entities.SaveChanges();
            //////                }
            //////            }
            //////        }
            //////    }
            //////    catch (DbUpdateConcurrencyException)
            //////    {
            //////        Console.WriteLine("Een andere gebbruiker wijzigde deze klant");
            //////    }
            //////    catch (FormatException)
            //////    {
            //////        Console.WriteLine("Tik een getal");
            //////    }
            //////}
            /// 
            /// Taak 1.8 Personeel
            /// 
            //////////////////    using (var entities = new BankEntities())
            //////////////////    {
            //////////////////        var hoogsteInHiarchie = (from personeel in entities.Personeel
            //////////////////            where personeel.Manager == null
            //////////////////            select personeel).ToList();

            //////////////////        new Program().Afbeelden(hoogsteInHiarchie, 0);
            //////////////////    }
            //////////////////}

            //////////////////void Afbeelden(List<Personeelslid> personeel, int insprong)
            //////////////////{
            //////////////////    foreach (var personeelslid in personeel)
            //////////////////    {
            //////////////////        Console.Write(new String('\t',insprong));
            //////////////////        Console.WriteLine(personeelslid.Voornaam);
            //////////////////        if (personeelslid.Personeel.Count != 0)
            //////////////////        {
            //////////////////            Afbeelden(personeelslid.Personeel.ToList(),insprong+1);
            //////////////////        }
            //////////////////    }
            //////////////////}
            /// 
            /// Taak 1.9 Zichtrekening - Spaarrekening
            /// //
            ////////using (var entities = new BankEntities())
            ////////{
            ////////    var zichtrekeningen = from rekening in entities.Rekeningen
            ////////        where rekening is ZichtRekening
            ////////        select rekening;

            ////////    foreach (var rekening in zichtrekeningen)
            ////////    {
            ////////        Console.WriteLine("{0}:{1}",rekening.RekeningNr,rekening.Saldo);
            ////////    }
            ////////}
            /// 
            /// 
            /// Taak 1.10 Totaal saldo per klant
            /// 
            ////////////using (var entities = new BankEntities())
            ////////////{
            ////////////    try
            ////////////    {
            ////////////        Console.WriteLine("KlantNr");
            ////////////        int klantNr;
            ////////////        if (!int.TryParse(Console.ReadLine(), out klantNr))
            ////////////        {
            ////////////            throw new FormatException();
            ////////////        }
            ////////////        else
            ////////////        {
            ////////////            var klant = from totaleSaldoPerKlant in entities.TotaleSaldoPerKlant
            ////////////                        orderby totaleSaldoPerKlant.Voornaam
            ////////////                        select totaleSaldoPerKlant;
            ////////////            foreach (var totaleSaldoPerKlant in klant)
            ////////////            {
            ////////////                Console.WriteLine("{0}:{1}- {2} ",totaleSaldoPerKlant.KlantNr,totaleSaldoPerKlant.Voornaam,totaleSaldoPerKlant.TotaleSaldo);
            ////////////            }
                        


            ////////////        }
            ////////////    }
            ////////////    catch (FormatException)
            ////////////    {

            ////////////        Console.WriteLine("Tik een getal");
            ////////////    }
                
                
            ////////////}
            ///
            /// taak 1.11 Administratieve kost
            /// 
            //////try
            //////{
            //////    var kost = 0m;
            //////    Console.WriteLine("Kost: ");
            //////    if (!decimal.TryParse(Console.ReadLine(), out kost))
            //////    {
            //////        throw new FormatException();
            //////    }
            //////    else
            //////    {
            //////        using (var entities = new BankEntities())
            //////        {
            //////            var aantalRekeningenAangepast = entities.AdministratieveKost(kost);
            //////            Console.WriteLine("{0} rekeningen aangepast",aantalRekeningenAangepast);
            //////        }
            //////    }
            //////}
            //////catch (FormatException)
            //////{

            //////    Console.WriteLine("Tik een getal in");
            //////}
            /// 

            using (var entities = new BankEntities())
            {
                try
                {
                    Console.WriteLine("klantNr:");
                    var klantNr = 0;
                    if (!int.TryParse(Console.ReadLine(), out klantNr))
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        var klant = entities.Klanten.Find(klantNr);
                        if (klant == null)
                        {
                            Console.WriteLine("Klant niet gevonden");
                        }
                        else
                        {
                            if (klant.Rekeningen.Count > 0)
                            {
                                Console.WriteLine("Klant heeft nog rekeningen");
                            }
                            else
                            {
                                entities.Klanten.Remove(klant);
                                entities.SaveChanges();
                            }
                        }
                    }
                }
                catch (FormatException)
                {

                    Console.WriteLine("Tik een getal");
                }
            }
            
            
        }
    }
}