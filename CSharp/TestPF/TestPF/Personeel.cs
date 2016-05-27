using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPF
{
    public abstract class Personeel :IKosten
    {
        private int personeelNrValue;

        public int PersoneelNr
        {
            get { return personeelNrValue; }
            private set { personeelNrValue = value; }
        }

        public string Voornaam { get; set; }
        public string Naam { get; set; }

        

        private decimal brutoValue;

        public decimal BrutoMaandloon
        {
            get { return brutoValue; }
            set
            {
                if (value <= 0)
                    throw new Exception("Persooneelnr "+this.PersoneelNr+" heeft geen geldige bruto waarde gekregen " + value);
                brutoValue = value; }
        }
        

        private static List<VerlofPeriode> verlofPeriodeValue;

        public static List<VerlofPeriode> VerlofPeriode
        {
            get { return verlofPeriodeValue; }
            set { verlofPeriodeValue = value; }
        }

        

        public decimal maandkost
        {
            get { return BrutoMaandloon*0.6m ; }
        }
        
        
        
        
        public Personeel(int personeelNr,string voornaam, string naam, decimal brutoMaandloon)
        {
            this.PersoneelNr = personeelNr;
            this.Voornaam = voornaam;
            this.Naam = naam;
            this.BrutoMaandloon = brutoMaandloon;
            
        }
        public virtual void gegevensTonen()
        {
            Console.WriteLine("Personeelsnummer:"+PersoneelNr);
            Console.WriteLine("Voornaam:"+Voornaam);
            Console.WriteLine("Naam:"+Naam);
            Console.WriteLine("Bruto Maandloon:"+BrutoMaandloon+" EUR");
            Console.WriteLine("Vakantie periode:");
            foreach(var verlof in VerlofPeriode)
            verlof.gegevensTonen();
        }
       
    }
}
