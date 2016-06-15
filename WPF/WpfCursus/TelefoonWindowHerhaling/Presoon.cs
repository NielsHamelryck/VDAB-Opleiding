using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TelefoonWindowHerhaling
{
    public class Persoon
    {

        public string Naam { get; set; }
        public string Telefoonnr { get; set; }

        public Group Groep { get; set; }

        public BitmapImage Foto { get; set; }

        public Persoon(string nNaam, string nTelefoonnr, Group nGroep, BitmapImage nFoto)
        {
            this.Naam = nNaam;
            this.Telefoonnr = nTelefoonnr;
            this.Groep = nGroep;
            this.Foto = nFoto;
        }
    }
}
