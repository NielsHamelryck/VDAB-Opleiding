using System;
using System.Collections.Generic;
using System.Data;
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
using AdoGemeenschap;

namespace WPFOpgave3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonToevoegen_OnClick(object sender, RoutedEventArgs e)
        {
            
            
                try
                {   
                    
                    var manager = new TuinManager();
                    Leverancier eenLeverancier= new Leverancier();
                    eenLeverancier.Naam = TextBoxNaam.Text;
                    eenLeverancier.Adres = TextBoxAdres.Text;
                    eenLeverancier.Postcode = TextBoxPostcode.Text;
                    eenLeverancier.Woonplaats = TextBoxPlaats.Text;
                    manager.LeveranciersToevoegen(eenLeverancier);
                    LabelStatus.Content =  eenLeverancier.LevNr;
                    
                   

                }
                catch (Exception ex)
                {
                    LabelStatus.Content = ex.Message;
                }
            
           
        }

        private void ButtonEindejaarKorting_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new TuinManager();

                LabelStatus.Content = manager.EindejaarsKorting() + "wijziging(en) aangebracht";

            }
            catch (Exception ex)
            {
                LabelStatus.Content = ex.Message;
            }
        }
    }
}
