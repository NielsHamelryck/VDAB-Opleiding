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
            nummers.Insert(0, "Alles");
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

        private List<Leverancier> OudeLeveranciers = new List<Leverancier>();
        private List<Leverancier> NieuweLeveranciers = new List<Leverancier>();
        private List<Leverancier> GewijzigdeLeveranciers = new List<Leverancier>();


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
            if (MessageBox.Show("Wilt u alles wegschrijven naar de database ?",
                "Opslaan", MessageBoxButton.YesNo, MessageBoxImage.Question
                , MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                leverancierDataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                List<Leverancier> resultaatLeveranciers = new List<Leverancier>();
                StringBuilder NietGoed = new StringBuilder();
                StringBuilder WelGoed = new StringBuilder();
                WelGoed.Append("\n \n ");
                var manager = new TuincentrumManager();
                if (OudeLeveranciers.Count != 0)
                {
                    resultaatLeveranciers = manager.SchrijfVerwijderingen(OudeLeveranciers);
                    if (resultaatLeveranciers.Count > 0)
                    {


                        foreach (var l in resultaatLeveranciers)
                        {
                            NietGoed.Append("Niet verwijderd : " + l.LevNr + " : " + l.Naam + "\n");
                        }


                    }
                    WelGoed.Append(OudeLeveranciers.Count - resultaatLeveranciers.Count +
                                   " leverancier(s) verwijderd in de database \n");

                    resultaatLeveranciers.Clear();
                }

                if (NieuweLeveranciers.Count != 0)
                {
                    resultaatLeveranciers = manager.ToevoegenLeveranciers(NieuweLeveranciers);
                    if (resultaatLeveranciers.Count > 0)
                    {

                        foreach (var l in resultaatLeveranciers)
                        {
                            NietGoed.Append("Niet Toegevoegd : " + l.LevNr + " : " + l.Naam + " \n");
                        }

                    }
                    WelGoed.Append(NieuweLeveranciers.Count - resultaatLeveranciers.Count +
                                   " leverancier(s) toegevoegd aan de database \n");
                    resultaatLeveranciers.Clear();
                }
                foreach (var l in leveranciersOb)
                {
                    if ((l.Changed == true) && (l.LevNr != 0)) GewijzigdeLeveranciers.Add(l);
                    l.Changed = false;
                }
                if (GewijzigdeLeveranciers.Count != 0)
                {
                    resultaatLeveranciers = manager.LeverancierWijzigen(GewijzigdeLeveranciers);
                    if (resultaatLeveranciers.Count > 0)
                    {
                        foreach (var rl in resultaatLeveranciers)
                        {
                            NietGoed.Append("Niet gewijzigd : " + rl.LevNr + " : " + rl.Naam + "\n");
                        }

                    }
                    WelGoed.Append(GewijzigdeLeveranciers.Count - resultaatLeveranciers.Count +
                                   " leverancier(s) gewijzigd in de database");
                    resultaatLeveranciers.Clear();
                }
                if (NietGoed.Length > 0 || WelGoed.Length > 4)
                    MessageBox.Show(NietGoed.ToString() + WelGoed.ToString(), "Info",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                else MessageBox.Show("Er werd niets aangepast dus ook niets opgeslagen","Info",MessageBoxButton.OK,MessageBoxImage.Information);
                OudeLeveranciers.Clear();
                NieuweLeveranciers.Clear();
                GewijzigdeLeveranciers.Clear();
            }
            else
            {
                OudeLeveranciers.Clear();
                NieuweLeveranciers.Clear();
                GewijzigdeLeveranciers.Clear();
                MessageBox.Show("Alle aanpassingen zijn niet Opgeslagen", "Info", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

        }
    }
}
