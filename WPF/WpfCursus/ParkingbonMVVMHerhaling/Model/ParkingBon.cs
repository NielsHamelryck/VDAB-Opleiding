using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ParkingbonMVVMHerhaling.Model
{
    public class ParkingBon
    {
        private DateTime DatumBonValue;

        public DateTime DatumBon
        {
            get { return DatumBonValue; }
            set
            {
                DatumBonValue = value;
               
            }
        }

        private string AankomstTijdValue;

        public string AankomstTijd
        {
            get { return AankomstTijdValue; }
            set { AankomstTijdValue = value; }
        }


        private string vertrekTijdValueDateTime;

        public string VertrekTijd
        {
            get { return vertrekTijdValueDateTime; }
            set { vertrekTijdValueDateTime = value; }
        }

        public string TeBetalenBedrag { get; set; }

        public BitmapImage Logo { get; set; }

        public ParkingBon()
        {
            DatumBon = DateTime.Now;
            AankomstTijd = DateTime.Now.ToShortTimeString();
            VertrekTijd = AankomstTijd;
            TeBetalenBedrag = "0 €";
        }
    }
}
