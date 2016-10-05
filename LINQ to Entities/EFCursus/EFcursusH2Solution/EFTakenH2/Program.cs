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

namespace EFTakenH2
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var entities = new Bank3Entities())
            {
                var hoogsteInHierarchie = (from peroneel in entities.Personeel
                    where peroneel.Manager == null
                    select peroneel).ToList();

                new Program().Afbeelden(hoogsteInHierarchie,0);
            }
            
        }

        void Afbeelden(List<Personeelslid> personeel, int aantalTab)
        {
            
            foreach (var manager in personeel)
            {
                Console.Write(new string('\t', aantalTab));
                Console.WriteLine(manager.Voornaam);
                
                if (manager.Beschermelingen.Count != 0)
                {
                    Afbeelden(manager.Beschermelingen.ToList(),aantalTab+1);
                }
            }
        }
        
        
    }
}

