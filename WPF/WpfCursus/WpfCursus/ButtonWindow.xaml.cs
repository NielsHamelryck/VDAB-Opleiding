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

namespace WpfCursus
{
    /// <summary>
    /// Interaction logic for ButtonWindow.xaml
    /// </summary>
    public partial class ButtonWindow : Window
    {
        public ButtonWindow()
        {
            InitializeComponent();
        }


        private void ButtonKleur_OnClick(object sender, RoutedEventArgs e)
        {
            Button knop = (Button) sender;
            SolidColorBrush kleur = (SolidColorBrush) new BrushConverter().ConvertFromString(knop.Tag.ToString());
            this.Background = kleur;
        }


        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            textBlockAanmelding.TextWrapping =TextWrapping.Wrap;
            textBlockAanmelding.Text = "Je probeerde aan te melden met:" +
                                       TextboxGebruikersnaam.Text + " en paswoord: " + PsdBox.Password;
        }
    }
}
