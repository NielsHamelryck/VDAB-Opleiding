using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPF
{
    public class Instructeur : Personeel
    {
        private string adresValue;

        public string EmailAdres
        {
            get { return adresValue; }
            set {
                bool controle = false;
                for (int teller = 0; teller < value.Length; teller++)
                    if (value[teller] == '@')
                        controle = true;
                if (!controle)
                    throw new OngeldigEmailadresException(value);
                adresValue = value; }

                
        }

        public VakGebied Vakgebied { get; set; }

        public Instructeur(int personeelNr,string voornaam,string naam,decimal brutoMaandloon, string Email ,VakGebied vakgebied)
            :base(personeelNr,voornaam,naam,brutoMaandloon)
        {
            this.EmailAdres = Email;
            this.Vakgebied = vakgebied;
        }

        public override void gegevensTonen()
        {
            base.gegevensTonen();
            Console.WriteLine("Email:"+EmailAdres);
        }
       
        
    }
}
