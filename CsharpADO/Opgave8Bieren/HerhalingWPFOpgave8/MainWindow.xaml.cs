using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HerhalingWPFOpgave8
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
            var manager= new TuincentrumManager();
            ComboBoxSoorten.ItemsSource = manager.GetSoorten();
            ComboBoxSoorten.SelectedValuePath = "SoortNr";
            ComboBoxSoorten.DisplayMemberPath = "Naam";

        }

        private List<Plant> listboxPLantenLijst = new List<Plant>();
        private string geselecteerdeSoortNaam;

        public List<Plant> GewijzigdePlanten = new List<Plant>();
        private void ComboBoxSoorten_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {   WijzigingenOpslaan();
            geselecteerdeSoortNaam = ((Soort) ComboBoxSoorten.SelectedItem).Naam;
            try
            {
                var manager = new TuincentrumManager();
                listboxPLantenLijst = manager.GetPlantgegevens(Convert.ToInt32(ComboBoxSoorten.SelectedValue));
                ListBoxPlanten.ItemsSource = listboxPLantenLijst;
                ListBoxPlanten.DisplayMemberPath = "Naam";
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void ButtonOpslaan_OnClick(object sender, RoutedEventArgs e)
        {
            if(!PlantHasErrors())
            WijzigingenOpslaan();
            
        }

        private bool PlantHasErrors()
        {
            bool foutGevonden = false;
            if (Validation.GetHasError(TextBoxKleur)) foutGevonden = true;
            if (Validation.GetHasError(TextBoxPrijs)) foutGevonden = true;
            return foutGevonden;
        }

        private void WijzigingenOpslaan()
        {
            List<Plant> gewijzigdePlanten = new List<Plant>();

            foreach (var plant in listboxPLantenLijst)
            {
                if (plant.Changed == true)
                {
                    gewijzigdePlanten.Add(plant);
                    plant.Changed = false;
                }
            }
            if ((gewijzigdePlanten.Count > 0) && (MessageBox.Show("Gewijzigde planten van soort '"
                                                                  + geselecteerdeSoortNaam
                                                                  + "' opslaan ?", "Opslaan", MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.Yes) == MessageBoxResult.Yes))
            {
                var manager = new TuincentrumManager();
                try
                {
                    manager.SchrijfWijzigingen(gewijzigdePlanten);
                    MessageBox.Show("Planten Opgeslagen", "Opslaan", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is een fout opgetreden: " + ex.Message,"Opslaan",
                        MessageBoxButton.OK,MessageBoxImage.Information);
                }
            }

        }

        private void ComboBoxSoorten_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PlantHasErrors()) e.Handled = true;
        }

        private void ComboBoxSoorten_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (PlantHasErrors()) e.Handled = true;
        }


        private void ListBoxPlanten_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (PlantHasErrors()) e.Handled = true;
        }

        private void ListBoxPlanten_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PlantHasErrors()) e.Handled = true;
        }
    }
}
