using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening4_1
{
    class Program
    {
        const string Sleutel = "QSPATVXBCRJYEDUOHZGIFLNWKM";
        static void Main(string[] args)
        {
            string invoer,nieuw;
            
            Console.WriteLine("Tik een tekst in die gecodeerd moet worden");
            invoer=Console.ReadLine();
            
            nieuw=Versleuteld(invoer.ToUpper());
            Console.WriteLine("{0} geeft gecodeerd {1}",invoer,nieuw);
            
            
        }
        static string Versleuteld(string text)
        {
            char[] arraySleutel = new char[Sleutel.Length];
            char[] sleutelGesorteerd = new char[Sleutel.Length];
            char[] arrayText = new char[text.Length];
            string gecodeerd=String.Empty;
            //text in een array opslaan
            for (int teller = 0; teller <= text.Length - 1; teller++)
            {
                arrayText[teller] = text[teller];
            }
            // een copy maken van het sleutel array voor het sorteren
            for(int teller=0;teller<=Sleutel.Length-1;teller++)
            {
                arraySleutel[teller] = Sleutel[teller];
            }
            Array.Copy(arraySleutel,sleutelGesorteerd,Sleutel.Length);
            Array.Sort(sleutelGesorteerd);
            for (int letter=0; letter<text.Length;letter++)
            {
                if (text[letter] >= 'A' && text[letter] <= 'Z')
                {
                    for (int teller = 0; teller < Sleutel.Length; teller++)
                    {
                        if (sleutelGesorteerd[teller] == text[letter])
                            gecodeerd += arraySleutel[teller];
                    }
                }
                else gecodeerd += text[letter] ;
            }
                return gecodeerd;
        }
    }
}
