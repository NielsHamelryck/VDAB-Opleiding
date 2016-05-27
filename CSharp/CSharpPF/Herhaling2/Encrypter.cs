using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class Encrypter
    {
        public static string Encrypted(string tekst)
        {
            string encrypted=string.Empty;
            int getal;
            char letter;
            for (int teller = 0; teller < tekst.Length; teller++ )
            {
               getal = (int)tekst[teller]+1;
               letter = (char)getal;
               encrypted += letter.ToString();
               
            }
                return encrypted;
        }

        public static string Decrypt(string tekst)
        {

            string decrypted = string.Empty;
            int getal;
            char letter;
            for (int teller = 0; teller < tekst.Length; teller++)
            {
                getal = (int)tekst[teller] - 1;
                letter = (char)getal;
                decrypted += (char)letter;
            }
            return decrypted;
        }
    }
}
