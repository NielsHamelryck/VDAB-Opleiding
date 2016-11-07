using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MVC_CultuurHuisSelf.Models
{
    public class MandjeItem
    {
        public Int16 VoorstellingsNr { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yy HH:mm}")]
        public DateTime Datum { get; set; }

        public string Title { get; set; }
        public string Uitvoerders { get; set; }

        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal Prijs { get; set; }

        public Int16 Plaatsen { get; set; }

        public MandjeItem(short voorstellingsNr, DateTime datum, string title, string uitvoerders, decimal prijs, short plaatsen)
        {
            VoorstellingsNr = voorstellingsNr;
            Datum = datum;
            Title = title;
            Uitvoerders = uitvoerders;
            Prijs = prijs;
            Plaatsen = plaatsen;
        }
    }
}
