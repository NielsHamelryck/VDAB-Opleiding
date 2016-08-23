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

namespace WPFOpgave8
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
            try
            {
                var manager = new TuinManager();
                ComboBoxSoorten.DisplayMemberPath = "SoortNaam";
                ComboBoxSoorten.SelectedValuePath = "SoortNr";
                ComboBoxSoorten.ItemsSource = manager.GetSoorten();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //aanpassing aan oefening 8 voor 9

        private List<Plant> listBoxPlantenLijst = new List<Plant>();
        private string GeselecteerdeSoortNaam; //om de huidige soortnaam bij te houden die je nodig hebt om op te slaan
        private void ComboBoxSoorten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   WijzigingenOpslaan();
            GeselecteerdeSoortNaam=((Soort)ComboBoxSoorten.SelectedItem).SoortNaam;
            try
            {
                
                var manager= new TuinManager();
                listBoxPlantenLijst = manager.getPlanten(Convert.ToInt32(ComboBoxSoorten.SelectedValue));
                ListBoxPlantenNamen.ItemsSource = listBoxPlantenLijst;
                ListBoxPlantenNamen.DisplayMemberPath = "PlantNaam";
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void WijzigingenOpslaan()
        {
            List<Plant> gewijzigdePlanten = new List<Plant>();

            foreach (Plant p in listBoxPlantenLijst)
            {
                if (p.Changed==true)
                {
                    gewijzigdePlanten.Add(p);
                    p.Changed = false;
                }
                if ((gewijzigdePlanten.Count > 0) &&
                    (MessageBox.Show("Gewijzigde planten van soort '" + GeselecteerdeSoortNaam +
                                     "' opslaan?", "Opslaan", MessageBoxButton.YesNo, MessageBoxImage.Question,
                        MessageBoxResult.Yes) == MessageBoxResult.Yes))
                {
                    var manager=new TuinManager();
                    try
                    {
                        manager.GewijzigdePlantenOpslaan(gewijzigdePlanten);
                        MessageBox.Show("Planten opgeslagen", "Opslaan", MessageBoxButton.OK
                            , MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Er is een fout opgetreden:" + ex.Message,
                            "Opslaan", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
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
            if (Validation.GetHasError(TextBoxKleur))
            {
                foutGevonden = true;
            }
            if (Validation.GetHasError(TextBoxPrijs))
            {
                foutGevonden = true;
            }
            return foutGevonden;
        }

        private void ListBoxPlantenNamen_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PlantHasErrors())
            {
                e.Handled = true;
            }
            
        }

        private void ListBoxPlantenNamen_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (PlantHasErrors())
            {
                e.Handled = true;
            }
        }

        private void ComboBoxSoorten_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PlantHasErrors())
            {
                e.Handled = true;
            }
        }

        private void ComboBoxSoorten_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (PlantHasErrors())
            {
                e.Handled = true;
            }
        }
    }
}
