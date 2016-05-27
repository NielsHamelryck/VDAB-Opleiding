using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    public class Manager : Bediende
    {
        public void OnderhoudNoteren(Firma.Materiaal.Fotokopiemachine machine)
        {
            Console.WriteLine("{0} registreert het onderhoud" + "van machine {1} in het logboek.", Naam, machine.SerieNummer) ;
        }
        public Manager(string naam, DateTime inDienst, Geslacht geslacht, decimal wedde, decimal bonus)
            : base(naam, inDienst, geslacht,wedde)
        {
            this.Bonus = bonus;
        }

        private decimal bonusValue;

        public decimal Bonus
        {
            get { return bonusValue; }
            set {if(value>=0m) 
                bonusValue = value; }
        }
        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Bonus : {0} ",Bonus);
        }
        public override string ToString()
        {
            return base.ToString()+ ", Bonus:" +Bonus ;
        }
        

         public override decimal Premie
         {
             get { return Bonus * 3; }
         }
         public override decimal Bedrag
         {
             get
             {
                 return base.Bedrag+Bonus;
             }
         }
    }
}
