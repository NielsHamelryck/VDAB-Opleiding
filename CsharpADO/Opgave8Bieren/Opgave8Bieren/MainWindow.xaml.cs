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

namespace Opgave8Bieren
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

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var manager = new BierManager();
            ComboBoxSoorten.DisplayMemberPath = "Naam";
            ComboBoxSoorten.SelectedValuePath = "SoortNr";
            ComboBoxSoorten.ItemsSource = manager.GetSoorten();

            System.Windows.Data.CollectionViewSource bierViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bierViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // bierViewSource.Source = [generic data source]
        }

        private List<Bier> ListBoxBierenLijst = new List<Bier>();
        private String GeselecteerdeSoortNaam;
        private void ComboBoxSoorten_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            var manager = new BierManager();

            ListBoxBierenLijst = manager.GetBieren(Convert.ToInt32(ComboBoxSoorten.SelectedValue));
            ListBoxBieren.ItemsSource = ListBoxBierenLijst;
            ListBoxBieren.DisplayMemberPath = "Naam";

        }

        private bool test = false;

        private void ButtonTest_OnClick(object sender, RoutedEventArgs e)
        {

            if (!test)
            {
                naamTextBox.IsReadOnly = false;
                OpslaanButton.Visibility=Visibility.Visible;
                VerwijderenButton.Visibility = Visibility.Visible;
                test = true;
            }
            else
            {
                naamTextBox.IsReadOnly = true;
                OpslaanButton.Visibility = Visibility.Hidden;
                VerwijderenButton.Visibility = Visibility.Hidden;
                test = false;
            }
        }

        public void WijzigingenOpslaan()
        {
            List<Bier> gewijzigdeBieren = new List<Bier>();

            //foreach (var b in ListBoxBierenLijst)
            //{
            //    if(b.)
            //}
        }
    }
}
