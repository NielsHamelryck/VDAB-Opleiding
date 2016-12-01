using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoVerhuur.Models
{
    public class MandjeItem
    {
        public Int32 BandNr { get; set; }
        public string Titel { get; set; }
        [DisplayFormat(DataFormatString = "{0: € #,##0.00}")]
        public decimal Prijs { get; set; }

        
    }
}