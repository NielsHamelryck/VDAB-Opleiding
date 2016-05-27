using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPF
{
    public class VerlofPeriode
    {
        
        public string Naam { get; set; }

        public DateTime BeginDatum { get; set; }
          


        public DateTime EindDatum { get; set; }



         public VerlofPeriode(string naam, DateTime begin ,DateTime einde)
        {
            this.Naam = naam;
            this.BeginDatum = begin;
            this.EindDatum = einde;
        }

         public void gegevensTonen()
         {
             Console.WriteLine("  "+ Naam + " - van "+BeginDatum.ToShortDateString() +" tot en met "+EindDatum.ToShortDateString());
         }
    }
}
