using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPF
{
    class Infrastructuur : IKosten
    {
        public decimal maandkost
        {
            get { return MaandHuurPrijs; }
        }
        
        public string Naam { get; set; }
        

        private decimal maandhuurprijsValue;

        public decimal MaandHuurPrijs
        {
            get { return maandhuurprijsValue; }
            set
            {
                 if (value <= 0)throw new Exception("Gebouw "+this.Naam+" heeft geen geldige waarde voor de huurprijs gekregen "+value); 
                maandhuurprijsValue = value; }
        }
                

        public Infrastructuur(string naam,decimal maandhuurprijs)
        {
            this.Naam = naam;
            this.MaandHuurPrijs = maandhuurprijs;
        }
        public void gegevensTonen()
        {
            Console.WriteLine("Gebouw: "+Naam);
            Console.WriteLine("Maandelijkse Huurprijs "+ MaandHuurPrijs +" EUR ");
        }
    }
}
