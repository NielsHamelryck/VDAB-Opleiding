using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cultuurhuis3.Models
{
    public class MandjeItem
    {
        public int VoorstellingsNr { get; set; }

        [DisplayFormat(DataFormatString = "{0 : dd/MM/yy HH:mm}")]
        public DateTime Datum { get; set; }

        public string Titel { get; set; }

        public string Uitvoerders { get; set; }

        [DisplayFormat(DataFormatString = "{0:€ #,##0.00 }")]
        public decimal Prijs { get; set; }

        public Int16 Plaatsen { get; set; }

        public MandjeItem(int voorstellingsNr, DateTime datum, string titel, string uitvoerders, decimal prijs, short plaatsen)
        {
            VoorstellingsNr = voorstellingsNr;
            Datum = datum;
            Titel = titel;
            Uitvoerders = uitvoerders;
            Prijs = prijs;
            Plaatsen = plaatsen;
        }
    }
}