using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TelefoonWindow
{
    public class Persoon
    {
        public string Naam { get; set; }
        public string Telefoonnr { get; set; }
        public GroepEnum Groep { get; set; }

        public BitmapImage Foto { get; set; }

        public Persoon(string naam,string telNummer, GroepEnum groep,BitmapImage img)
        {
            this.Naam = naam;
            this.Telefoonnr = telNummer;
            this.Groep = groep;
            this.Foto = img;
        }
    }
}
