using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefeningen3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef een rekeningnr in om de IBAN te bepalen");
            string rekeningNummer,ibanNr;
            long deelgetal = 0;
            int rest = 0;
            rekeningNummer = Console.ReadLine();
            ibanNr=rekeningNummer.Remove(3,1);
            ibanNr = ibanNr.Remove(10,1);
            ibanNr = ibanNr.Insert(12, "BE00");
            ibanNr = ibanNr.Replace("BE", "1114");
            deelgetal = Convert.ToInt64(ibanNr) % 97;
            rest = 98 - (int)deelgetal;
            
            if (rest < 10)
            {

                ibanNr = ibanNr.Insert(0, "0");
            }
            else ibanNr = ibanNr.Insert(0, Convert.ToString(rest));
            ibanNr = ibanNr.Remove(ibanNr.Length - 6, 6);
            ibanNr = ibanNr.Insert(0,"BE");
            

                Console.WriteLine("{0} {1} {2} {3}", ibanNr.Substring(0,4),ibanNr.Substring(4,4),ibanNr.Substring(8,4),ibanNr.Substring(12,4));
            
        }
    }
}
//juiste oplossing!!!!!!
//const string ALFABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
//        static void Main(string[] args)
//        {
//            string ibanRekeningnr,controleGetal;
//            ulong rest97;
//            ibanRekeningnr = "BE23 7390 1021 3491";
//            controleGetal=ibanRekeningnr.Replace(" ","");
//            //de eerste 4 tekens naar uiterst rechts verplaatsen
//            controleGetal = controleGetal.Insert(controleGetal.Length, controleGetal.Substring(0, 4)).Remove(0, 4);
//           //letters vervangen door de corresponderende cijfers
//            controleGetal =VervangLetters(controleGetal);
//            rest97 = ulong.Parse(controleGetal)%97ul;
//            Console.WriteLine(rest97==1 ? "Iban: {0} is een geldig nummer" : "Iban: {0} is geen geldig nummer",ibanRekeningnr );

//            Console.WriteLine(rest97);
//            Console.WriteLine(controleGetal);
//        }
//        static string VervangLetters(string nummer)
//        {
//            char teken;
//            string nr = string.Empty;
//            for (int teller=0;teller<=nummer.Length-1;teller++)
//            {
//                teken=nummer[teller];
//                if (teken >= 'A' && teken <= 'Z')
//                    nr += ALFABET.IndexOf(teken)+10;
//                else nr+= teken;
//            }
//            return nr;