using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoVerhuur.Models
{
    public class AfrekeningDetails
    {
        public Klant Klant { get; set; }
        public List<MandjeItem> Winkelmandje { get; set; }
    }
}