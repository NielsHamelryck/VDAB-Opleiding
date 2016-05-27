using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Klant
    {
        public Klant(string voornaam, string achternaam)
        {
            this.Voornaam = voornaam; 
            this.Achternaam = achternaam;
        }
        private string voornaamValue;

        public string Voornaam
        {
            get { return voornaamValue; }
            set { voornaamValue = value; }
        }

        private string achternaamValue;

        public string Achternaam
        {
            get { return achternaamValue; }
            set { achternaamValue = value; }
        }
        public void Afbeelden()
        {
            Console.WriteLine("Informatie Klant");
            Console.WriteLine("Voornaam: {0}", Voornaam);
            Console.WriteLine("Achternaam: {0}", Achternaam);
        }
        public override string ToString()
        {
            return String.Format("{0} {1}", Voornaam,Achternaam);
        }
       
        
        
    }
}
