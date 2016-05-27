using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening3_4
{
    class Program
    {
        const string ALFABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static void Main(string[] args)
        {
            string ibanRekeningnr,controleGetal;
            ulong rest97;
            ibanRekeningnr = "BE23 7390 1021 3491";
            controleGetal=ibanRekeningnr.Replace(" ","");
            //de eerste 4 tekens naar uiterst rechts verplaatsen
            controleGetal = controleGetal.Insert(controleGetal.Length, controleGetal.Substring(0, 4)).Remove(0, 4);
           //letters vervangen door de corresponderende cijfers
            controleGetal =VervangLetters(controleGetal);
            rest97 = ulong.Parse(controleGetal)%97ul;
            Console.WriteLine(rest97==1 ? "Iban: {0} is een geldig nummer" : "Iban: {0} is geen geldig nummer",ibanRekeningnr );

            Console.WriteLine(rest97);
            Console.WriteLine(controleGetal);
        }
        static string VervangLetters(string nummer)
        {
            char teken;
            string nr = string.Empty;
            for (int teller=0;teller<=nummer.Length-1;teller++)
            {
                teken=nummer[teller];
                if (teken >= 'A' && teken <= 'Z')
                    nr += ALFABET.IndexOf(teken)+10;
                else nr+= teken;
            }
            return nr;
        }
    }
}
