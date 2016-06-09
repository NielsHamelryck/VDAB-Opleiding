using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ParkingBonMVVM.Model
{
    public class ParkeerBon  
    {
        public DateTime Datum { get; set; }
        public string Aankomstijd { get; set; }

        public string TeBetalen { get; set; }
        public string VertrekTijd { get; set; }

        public ParkeerBon()
        {
            Datum = DateTime.Now;
            Aankomstijd = DateTime.Now.ToShortTimeString();
            TeBetalen = "0 €";
            VertrekTijd = Aankomstijd;
        }
    }
}
