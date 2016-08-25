using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace AdoGemeenschap
{
    public class Brouwer
    {

        public bool Changed { get; set; }

        private Int32 brouwerNrValue;

        public Int32 BrouwerNr
        {
            get { return brouwerNrValue; }
            
        }

        private String brNaamValue;

        public String BrNaam
        {
            get { return brNaamValue; }
            set
            {
                brNaamValue = value;
                Changed = true;
            }
        }

        private String adresValue;

        public String Adres
        {
            get { return adresValue; }
            set
            {
                
                adresValue = value;
                Changed = true;
            }
        }

        private Int16 postcodeValue;

        public Int16 Postcode
        {
            get { return postcodeValue; }
            set
            {
                //if (value < 1000 || value > 9999)
                //{
                //    throw new Exception("Postcode moet tussen 1000 en 9999 liggen");
                //}
                //else
                 postcodeValue = value;
                Changed = true;
            }
        }

        private String gemeenteValue;

        public String Gemeente
        {
            get { return gemeenteValue; }
            set
            {
                gemeenteValue = value;
                Changed = true;
            }
        }

        private Int32? omzetValue;

        public Int32? Omzet
        {
            get { return omzetValue; }
            set
            {
                if (value.HasValue && Convert.ToInt32(value) < 0)
                {
                    throw new Exception("Omzet moet positief zijn");
                }
                else
                {
                    omzetValue = value;
                    Changed = true;
                }
            }
        }

        public Brouwer(Int32 brouwerNr,String brNaam, String adres, Int16 postcode,
                        String gemeente,Int32? omzet)
        {
            brouwerNrValue = brouwerNr;

            this.BrNaam = brNaam;
            this.Adres = adres;
            this.Postcode = postcode;
            this.Gemeente = gemeente;
            this.Omzet = omzet;
            this.Changed = false;
        }

        public Brouwer()
        {
                
        }
    }
}
