using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EFcursusH2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var entities = new Opleidingen2Entities())
            {
                var cursussen = from cursus in entities.Cursussen.Include("BoekenCursussen2.Boek")
                    orderby cursus.Naam
                    select cursus;

                foreach (var cursus in cursussen)
                {
                    Console.WriteLine(cursus.Naam);
                    foreach (var boekCursus in cursus.BoekenCursussen2)
                    {

                        Console.WriteLine("\t"+ boekCursus.VolgNr+" : "+boekCursus.Boek.Titel);
                    }
                }
            }
            
        }
    }
}
