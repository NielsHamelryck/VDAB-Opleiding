using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    public class Overuren   
    {
        private int[] overurenValue = new int[12]; //(1)
        private static readonly string[] maanden = {"jan","feb","maa","apr","mei","jun","jul",
                                                   "aug","sep","oct","nov","dec"}; //(2)
        public int this[int maand]          //(3)
        {
            get                             //(4)
            {
                return overurenValue[maand]; //(5)
            }
            set                              //(6)
            {
                overurenValue[maand] = value; //(7)
            }
        }
        public int this[string maand] //(8)
        {
            get                     //(9)
            {
                return overurenValue[WelkeMaand(maand)]; //(10)
            }
            set                                         //(11)
            {
                overurenValue[WelkeMaand(maand)]=value; //(12)
            }
        }
        private int WelkeMaand(string maand)            //(13)
        {
            int maandNr = Array.IndexOf(maanden,maand); //(14)
            if(maandNr == -1)                           
                throw new IndexOutOfRangeException("Ongeldige maand: "+maand); //(15)
            return maandNr;                             //(16)
        }
        public int Totaal  //(17)
        {
            get
            {
                int totaal = 0;
                foreach (int overuur in overurenValue)
                    totaal += overuur;
                return totaal;
            }
        }
    }
}
