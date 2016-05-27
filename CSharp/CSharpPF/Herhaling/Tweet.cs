using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling
{
    [Serializable]
    public class Tweet
    {
        public Tweet()
        {
            this.Tijdstip = DateTime.Now;
        }


        public Tweet(string naam, string bericht)
        {
            this.Naam = naam;
            this.Bericht = bericht;
            this.Tijdstip = DateTime.Now;
        }
        public string Naam { get; set; }

        private string berichtValue;

        public string Bericht
        {
            get { return berichtValue; }
            set { berichtValue = value; }
        }

        public DateTime Tijdstip { get; set; }

        public override string ToString()
        {
            StringBuilder tweet = new StringBuilder(this.Naam + ": " + this.Bericht + "- ");
            TimeSpan verschil = DateTime.Now - Tijdstip;
            if (verschil.Days > 0)
            {
                tweet.Append(Tijdstip.ToShortDateString());
            }
            else if (verschil.Hours > 0)
            {
                tweet.Append(verschil.Hours + " uur geleden");
            }
            else if (verschil.Minutes > 0)
            {
                tweet.Append(verschil.Minutes == 1 ? verschil.Minutes + " Minuut Geleden" : verschil.Minutes + " Minuten geleden");
            }
            else tweet.Append(Tijdstip.ToShortTimeString());
            return tweet.ToString();
        }
    }
        
        
        
    
}
