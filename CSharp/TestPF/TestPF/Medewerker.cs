using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPF
{
    public class Medewerker : Personeel
    {
        //public int Cursisten { get; set; }

        private int cursistenValue;

        public int Cursisten
        {
            get { return cursistenValue; }
            set
            {
                if (value < 0)
                    throw new Exception("Personeelnummer " + this.PersoneelNr + " heeft geen geldig aantal cursisten gekregen " + value);
                cursistenValue = value; }
        }
        
        public Medewerker(int personeelNr,string voornaam,string naam,decimal brutoMaandloon,int cursisten)
            :base(personeelNr,voornaam,naam,brutoMaandloon)
        {
            this.Cursisten = cursisten;
        }

        public override void gegevensTonen()
        {
            base.gegevensTonen();
            Console.WriteLine("Aantal Cursisten: "+ Cursisten);
        }

    }
}
