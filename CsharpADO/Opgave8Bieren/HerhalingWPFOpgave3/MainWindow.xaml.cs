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
using AdoGemeenschap;

namespace HerhalingWPFOpgave3
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
                Leverancier leverancier=new Leverancier();
                var manager = new TuincentrumManager();
                leverancier.LevNr = 0;
                leverancier.Naam = TextBoxNaam.Text;
                leverancier.Adres = TextBoxAdres.Text;
                leverancier.PostNr = TextBoxPostcode.Text;
                leverancier.Woonplaats = TextBoxPlaats.Text;
                Int64 levnr = manager.LeverancierToevoegen(leverancier);
                LabelStatus.Content = "leverancier met het nr" + levnr +" is toegevoegd";


            }
            catch (Exception ex)
            {

                LabelStatus.Content = ex.Message;
            }
        }

        private void ButtonVervangLeverancier_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new TuincentrumManager();
                manager.VervangLeverancier(3,4);
                LabelStatus.Content = "Leverancier 3 is verwijderd en vervangen door 4";
            }
            catch (Exception ex)
            {

                LabelStatus.Content = ex.Message;
            }
        }
    }
}
