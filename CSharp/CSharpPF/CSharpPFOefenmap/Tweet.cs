using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    [Serializable]
    public class Tweet
    {
        public Tweet()
        {
            this.Tijdstip = DateTime.Now;

        }
        public string Naam { get; set; }
        private string berichtValue;

        public string Bericht
        {
            get { return berichtValue; }
            set
            {
                
                berichtValue = value.Length<=140? value : value.Substring(0,140); }
        }

        public DateTime Tijdstip { get; private set; }
        

        public override string ToString()
        {
            string tijdsAanduiding;
            if (Tijdstip.Date < DateTime.Now)
            {
                tijdsAanduiding = Tijdstip.Date.ToString();
            }
            else if (Tijdstip.Hour < DateTime.Now.Hour)
            {
                int verschil = DateTime.Now.Hour - Tijdstip.Hour;
                tijdsAanduiding = verschil.ToString() + "uur geleden";
            }
            else if (DateTime.Now.Hour - Tijdstip.Hour == 0 && DateTime.Now.Minute - Tijdstip.Minute > 10)
            {
                tijdsAanduiding = "10 minuten geleden";
            }
            else tijdsAanduiding = DateTime.Now.TimeOfDay.ToString();
                    
            return Naam + ": "+ Bericht +" - "+tijdsAanduiding;
                
        }
    }
}
