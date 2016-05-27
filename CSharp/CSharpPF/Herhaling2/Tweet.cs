using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Herhaling2
{
    [Serializable]
    public class Tweet
    {
        public string Naam { get; set; }
        public string Bericht { get; set; }

        public DateTime Tijdstip { get; set; }

        public Tweet(string naam, string bericht)
        {
            this.Naam = naam;
            this.Bericht = bericht;
            this.Tijdstip = DateTime.Now;
        }

        public override string ToString()
        {   StringBuilder tweet=new StringBuilder(this.Naam +": "+this.Bericht+" -");
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
            tweet.Append(verschil.Minutes == 1 ? verschil.Minutes + " minuut geleden" : verschil.Minutes + " minuten geleden");

        }
        else tweet.Append(Tijdstip.ToShortTimeString());

            return tweet.ToString();
        }

    }
}
