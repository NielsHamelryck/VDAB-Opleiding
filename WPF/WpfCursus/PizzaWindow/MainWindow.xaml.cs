using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaWindow
{
    /// <summary>
    /// Interaction logic for PizzaBestellen.xaml
    /// </summary>
    public partial class PizzaBestellen : Window
    {
        private string _pizzaSize;
        public PizzaBestellen()
        {

            InitializeComponent();
            TekstBlockHoeveelheid.Text = "1";
        }

        private void RepeatButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {

            var hoeveelheid = int.Parse(TekstBlockHoeveelheid.Text);
            if (hoeveelheid < 10)
                hoeveelheid++;
            TekstBlockHoeveelheid.Text = hoeveelheid.ToString();

        }

        private void PizzaSizeBepalen()
        {

            if (RadioButtonLarge.IsChecked == true)
                _pizzaSize = RadioButtonLarge.Content.ToString();
            else if (RadioButtonMedium.IsChecked == true)
                _pizzaSize = RadioButtonMedium.Content.ToString();
            else if (RadioButtonSmall.IsChecked == true)
                _pizzaSize = RadioButtonSmall.Content.ToString();
        }

        private void RepeatButtonDecrease_OnClick(object sender, RoutedEventArgs e)
        {
            int hoeveelheid = int.Parse(TekstBlockHoeveelheid.Text);
            if (hoeveelheid > 1)
                hoeveelheid--;
            TekstBlockHoeveelheid.Text = hoeveelheid.ToString();
        }

        private void ButtonPizzaBestellen_OnClick(object sender, RoutedEventArgs e)
        {
            PizzaSizeBepalen();
            var extras = ExtraPizzaEigenschappen();
            var toppings = PizzaToppings();
            TextBlockBestelling.Text = "U heeft " + TekstBlockHoeveelheid.Text + " " + _pizzaSize + " pizza('s) besteld met: "
                + toppings + "\n" +
                extras;
        }

        private string PizzaToppings()
        {
            var tekst = string.Empty;
            //List<string> toppingsList = new List<string>();
            //if (CheckBoxTomaat.IsChecked == true)
            //    toppingsList.Add(CheckBoxTomaat.Content.ToString());
            //if (CheckBoxKaas.IsChecked == true)
            //    toppingsList.Add(CheckBoxKaas.Content.ToString());
            //if (CheckBoxHam.IsChecked == true)
            //    toppingsList.Add(CheckBoxHam.Content.ToString());
            //if (CheckBoxAnanas.IsChecked == true)
            //    toppingsList.Add(CheckBoxAnanas.Content.ToString());
            //if (CheckBoxSalami.IsChecked == true)
            //    toppingsList.Add(CheckBoxSalami.Content.ToString());

            //for (var teller = 0; teller < toppingsList.Count() - 1; teller++)
            //{
            //    if (teller < 1)
            //        tekst += toppingsList[teller];
            //    else tekst +=", "+ toppingsList[teller];
            //}
            //tekst += " en " + toppingsList[toppingsList.Count()-1];

            foreach (FrameworkElement child in StackPanelToppings.Children)
            {
                if (child is CheckBox)
                {
                    if (((CheckBox)child).IsChecked == true)
                    {
                        tekst += ((CheckBox)child).Content + " ";
                    }
                }
            }
            tekst = tekst.TrimEnd();
            tekst = tekst.Replace(" ", ",");
            int k = tekst.LastIndexOf(",");
            tekst = tekst.Substring(0, k) + " en " + tekst.Substring(k+1, tekst.Length - k-1);

            return tekst;

        }


        private string ExtraPizzaEigenschappen()
        {
            var tekst = String.Empty;
            if (ExtraDikkeKorstToevoegen.IsChecked == true && ExtraKaasToevoegen.IsChecked == true)
                tekst = "overstrooid met extra kaas en een extra dikke korst.";
            else if (ExtraDikkeKorstToevoegen.IsChecked == true && ExtraKaasToevoegen.IsChecked == false)
                tekst = "met een extra dikke korst.";
            else if (ExtraDikkeKorstToevoegen.IsChecked == false && ExtraKaasToevoegen.IsChecked == true)
                tekst = "overstrooid met extra kaas.";
            return tekst;

        }
    }
}
