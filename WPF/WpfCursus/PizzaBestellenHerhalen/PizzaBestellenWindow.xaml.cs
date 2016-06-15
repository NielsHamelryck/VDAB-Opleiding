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
using System.Windows.Shapes;

namespace PizzaBestellenHerhalen
{
    /// <summary>
    /// Interaction logic for PizzaBestellenWindow.xaml
    /// </summary>
    public partial class PizzaBestellenWindow : Window
    {
        private string pizzaGrootte;
        
        public PizzaBestellenWindow()
        {
            InitializeComponent();
            BestellingLabel.Content = string.Empty;
        }

        private void PizzaBestellen_OnClick(object sender, RoutedEventArgs e)
        {   string laatsteIngredient=string.Empty;
            string Stringetje;
            BestellingLabel.Content = string.Empty;
            BestellingLabel.Content = " U Heeft " + HoeveelheidLabel.Content + pizzaGrootte 
                + "pizza('s) Besteld met: ";

            foreach (FrameworkElement kind in Ingredienten.Children)
            {
                
                if (kind is CheckBox)
                {
                    var ingredient = (CheckBox) kind;
                    if (ingredient.IsChecked == true)
                    {
                        BestellingLabel.Content += ingredient.Content.ToString()+" , ";
                        laatsteIngredient = ingredient.Content.ToString();

                    }
                }
                
            }
            BestellingLabel.Content = BestellingLabel.Content.ToString().Remove(
                    BestellingLabel.Content.ToString().Length-3,3 );
            Stringetje= 
                BestellingLabel.Content.ToString().Substring(
                BestellingLabel.Content.ToString().Length - laatsteIngredient.Length-3).
                Replace(" , ", " en ");
            BestellingLabel.Content = BestellingLabel.Content.ToString().Remove(
                   BestellingLabel.Content.ToString().Length - Stringetje.Length+1, Stringetje.Length-1);
            BestellingLabel.Content += Stringetje; 
            BestellingLabel.Content += "\n";
            if (ExtraDikkeKorst.IsChecked == true)
            {
                BestellingLabel.Content += " met een extra dikke korst";
            }
            if (ExtraKaas.IsChecked == true)
            {
                BestellingLabel.Content += " overstrooid met extra kaas ";
            }
           

            
        }

        private void Vermeerderen_OnClick(object sender, RoutedEventArgs e)
        {
            int aantal=int.Parse((string)HoeveelheidLabel.Content);
            if (aantal < 10)
            {
                aantal += 1;
            }

            HoeveelheidLabel.Content = aantal.ToString();
        }

        private void Verminderen_OnClick(object sender, RoutedEventArgs e)
        {
            int aantal = int.Parse((string)HoeveelheidLabel.Content);
            if (aantal > 1)
            {
                aantal -= 1;
            }

            HoeveelheidLabel.Content = aantal.ToString();
        }

        private void SmallPizza_OnChecked(object sender, RoutedEventArgs e)
        {
            pizzaGrootte = " small ";
        }

        private void MediumPizza_OnChecked(object sender, RoutedEventArgs e)
        {
            pizzaGrootte = " medium ";
        }
        private void LargePizza_OnChecked(object sender, RoutedEventArgs e)
        {
            pizzaGrootte = " large ";
        }
    }
}
