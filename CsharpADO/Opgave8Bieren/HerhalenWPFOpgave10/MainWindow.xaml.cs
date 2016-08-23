using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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

namespace HerhalenWPFOpgave10
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
        ObservableCollection<Leverancier> leveranciersOb = new ObservableCollection<Leverancier>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            VulDeGrid();
            var nummers = (from l in leveranciersOb orderby l.PostNr select l.PostNr.ToString()).Distinct().ToList();
            nummers.Insert(0,"Alles");
            ComboBoxPostcode.ItemsSource = nummers;
            ComboBoxPostcode.SelectedIndex = 0;
        }

        private void VulDeGrid()
        {
            System.Windows.Data.CollectionViewSource leverancierViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("leverancierViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // leverancierViewSource.Source = [generic data source]
            var manager = new TuincentrumManager();
            leveranciersOb = manager.GetLeveranciers();
            leverancierViewSource.Source = leveranciersOb;
            leveranciersOb.CollectionChanged += this.OnCollectionChanged;
        }

        private List<Leverancier> OudeLeveranciers=new List<Leverancier>();
        private List<Leverancier> NieuweLeveranciers = new List<Leverancier>();
        private List<Leverancier> GewijzigdeLeveranciers =new List<Leverancier>();


        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (Leverancier leverancier in e.OldItems)
                {
                    OudeLeveranciers.Add(leverancier);
                }
            }
            if (e.NewItems != null)
            {
                foreach (Leverancier leverancier in e.NewItems)
                {
                    NieuweLeveranciers.Add(leverancier);
                }
            }
           
        }

        private void ComboBoxPostcode_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxPostcode.SelectedIndex == 0)
                leverancierDataGrid.Items.Filter = null;
            else
            {
                leverancierDataGrid.Items.Filter = new Predicate<object>(PostcodeFilter);
                
            }
        }

        private bool PostcodeFilter(object obj)
        {
            Leverancier leverancier = obj as Leverancier;
            bool result = (leverancier.PostNr == ComboBoxPostcode.SelectedValue.ToString());
            return result;
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            List<Leverancier> resultaatLeveranciers = new List<Leverancier>();
            var manager = new TuincentrumManager();
            if (OudeLeveranciers.Count != 0)
            {
                resultaatLeveranciers = manager.SchrijfVerwijderingen(OudeLeveranciers);
                if (resultaatLeveranciers.Count > 0)
                {
                    StringBuilder boodschap = new StringBuilder();
                    boodschap.Append("Niet verwijderd: ");//verdergaan kijk cursus 2015

                }
            }
        }
    }
}
