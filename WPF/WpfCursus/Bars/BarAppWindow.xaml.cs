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

namespace Bars
{
    /// <summary>
    /// Interaction logic for BarAppWindow.xaml
    /// </summary>
    public partial class BarAppWindow : Window
    {
        public BarAppWindow()
        {
            InitializeComponent();
        }

        private void MenuVet_OnClick(object sender, RoutedEventArgs e)
        {
            Vet_Aan_Uit();
        }

        private void Vet_Aan_Uit()
        {
            if (TextBoxVoorbeeld.FontWeight == FontWeights.Normal)
            {
                TextBoxVoorbeeld.FontWeight = FontWeights.Bold;
                MenuVet.IsChecked = true;
            }
            else
            {
                TextBoxVoorbeeld.FontWeight = FontWeights.Normal;
                MenuVet.IsChecked = false;
            }
        }

        private void MenuSchuin_OnClick(object sender, RoutedEventArgs e)
        {
            Schuin_Aan_Uit();
        }

        private void Schuin_Aan_Uit()
        {
            if (TextBoxVoorbeeld.FontStyle == FontStyles.Normal)
            {
                TextBoxVoorbeeld.FontStyle = FontStyles.Italic;
                MenuSchuin.IsChecked = true;
            }
            else
            {
                TextBoxVoorbeeld.FontStyle = FontStyles.Normal;
                MenuSchuin.IsChecked = false;
            }
        }

        private void Courier_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
