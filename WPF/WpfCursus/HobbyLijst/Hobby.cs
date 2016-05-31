using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HobbyLijst
{
    public class Hobby
    {
        public string Categorie { get; set; }
        public string Activiteit { get; set; }
        public BitmapImage Symbool { get; set; }

        public Hobby(string nCategorie, string nActiviteit, BitmapImage nSymbool)
        {
            this.Categorie = nCategorie;
            this.Activiteit = nActiviteit;
            this.Symbool = nSymbool;
        }
    }
}
