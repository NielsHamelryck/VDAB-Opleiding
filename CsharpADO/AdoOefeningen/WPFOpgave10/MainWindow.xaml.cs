using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WPFOpgave10
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

        private CollectionViewSource leverancierViewSource;
        public ObservableCollection<Leverancier> leverancierOb = new ObservableCollection<Leverancier>();

        private void VulDeGrid()
        {

            leverancierViewSource =
                ((CollectionViewSource) (this.FindResource("leverancierViewSource")));
            var manager = new TuinManager();
            leverancierOb = manager.GetLeverancier();
            leverancierViewSource.Source = leverancierOb;
            leverancierOb.CollectionChanged += this.OnCollectionChanged;
        }

        //oude leveranciers lijsten voor toevoegen, verwijderen en aanpassingen 

        public List<Leverancier> OudeLeveranciers =new List<Leverancier>();
        public List<Leverancier> NieuweLeveranciers = new List<Leverancier>();
        public List<Leverancier> GeupdateLeveranciers = new List<Leverancier>();
        
        private void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //OnCollectionChanged voor verwijderen van leveranciers
            if (e.OldItems != null)
            {
                foreach (Leverancier oudeLeverancier in e.OldItems)
                {
                    OudeLeveranciers.Add(oudeLeverancier);
                }
            }
            //OnCollectionChanged voor toevoegen van Leveranciers
            if (e.NewItems != null)
            {
                foreach (Leverancier leverancier in e.NewItems)
                {
                    NieuweLeveranciers.Add(leverancier);
                }
            }
           

        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulDeGrid();
            var manager= new TuinManager();
            List<String> postcodes = new List<string>();
            postcodes = manager.GetPostCodes();
            ComboBoxPostcode.Items.Add("Alles");
            foreach (var postcode in postcodes)
            {
                ComboBoxPostcode.Items.Add(postcode);
            }
            ComboBoxPostcode.SelectedIndex = 0;
            
        }

        private void ComboBoxPostcode_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxPostcode.SelectedIndex == 0)
            {
                leverancierDataGrid.Items.Filter = null;
            }
            else
            {
                leverancierDataGrid.Items.Filter = new Predicate<object>(PostcodeFilter);
            }
        }

        private bool PostcodeFilter(object obj)
        {
            Leverancier l =  obj as Leverancier;
            bool result = (l.Postcode == Convert.ToString(ComboBoxPostcode.SelectedValue));
            return result;
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            OpslaanInDatabase();

        }

        
        private void OpslaanInDatabase()
        {
            leverancierDataGrid.CommitEdit(DataGridEditingUnit.Row, true);
            var manager = new TuinManager();
            foreach (Leverancier l in leverancierOb)
            {
                if (l.Changed == true)
                {
                    GeupdateLeveranciers.Add(l);
                }
                l.Changed = false;
            }
            if (OudeLeveranciers.Count() != 0 || NieuweLeveranciers.Count() != 0 || GeupdateLeveranciers.Count() != 0)
            {


                if (MessageBox.Show("Wilt u alles wegschrijven naar de database", "Opslaan", MessageBoxButton.YesNo
                    , MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    if (OudeLeveranciers.Count() != 0)
                    {
                        try
                        {
                            manager.SchrijfVerwijderingen(OudeLeveranciers);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        
                        OudeLeveranciers.Clear();
                    }


                    if (NieuweLeveranciers.Count() != 0)
                    {
                       
                        manager.SchrijfToevoegingen(NieuweLeveranciers);
                        NieuweLeveranciers.Clear();

                    }

                    

                    if (GeupdateLeveranciers.Count() != 0)
                    {
                        try
                        {
                            manager.SchrijfWijzigingen(GeupdateLeveranciers);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        GeupdateLeveranciers.Clear();
                    }
                    VulDeGrid();

                }
            }
            else
            {
                MessageBox.Show("Er zijn geen wijzigingen om op te slaan", "Opslaan",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ButtonOpslaan_OnClick(object sender, RoutedEventArgs e)
        {
            OpslaanInDatabase();
        }
    }
    
}
