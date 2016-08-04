using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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


namespace WPFOpgave6
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

        private void ButtonOpzoeken_OnClick(object sender, RoutedEventArgs e)
        {
           
            try
            {
                var manager = new TuinManager();
                var info= manager.PlantEigenschappenRaadplegen(Decimal.Parse(TextBoxPlantnr.Text));
                LabelPlantNaam.Content = info.Naam;
                LabelPlantSoort.Content = info.Soort;
                LabelLeverancier.Content = info.Leverancier;
                LabelPlantKleur.Content = info.Kleur;
                LabelPlantPrijs.Content = info.VerkoopPrijs.ToString("N");
                LabelStatus.Content = String.Empty;

            }
            catch (Exception ex)
            {
                LabelPlantNaam.Content = String.Empty;
                LabelPlantSoort.Content = String.Empty;
                LabelLeverancier.Content = String.Empty;
                LabelPlantKleur.Content = String.Empty;
                LabelPlantPrijs.Content = String.Empty;
                LabelStatus.Content = ex.Message;
            }
        }
    }
}
