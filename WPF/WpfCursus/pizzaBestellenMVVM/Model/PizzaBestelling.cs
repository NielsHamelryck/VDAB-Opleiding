using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace pizzaBestellenMVVM.Model
{
    public class PizzaBestelling
    {
        public Boolean SmallPizza { get; set; }
        public Boolean MediumPizza { get; set; }
        public Boolean LargePizza { get; set; }

        public Boolean DikkeKorst { get; set; }

        public Boolean ExtraKaas { get; set; }

        public string AantalPizzas { get; set; }

        public Boolean Tomaat { get; set; }

        public Boolean Kaas { get; set; }

        public Boolean Ham { get; set; }

        public Boolean Ananas { get; set; }

        public Boolean Salami { get; set; }
        public BitmapImage Logo { get; set; }

        public PizzaBestelling()
        {
            LargePizza = true;
            DikkeKorst = false;
            ExtraKaas = false;
            AantalPizzas = "1";
            Tomaat = true;
            Kaas = true;
            Ham = false;
            Ananas = false;
            Salami = false;
            Logo=new BitmapImage(new Uri("images/pizza.jpg",UriKind.Relative));
        }
    }
}
