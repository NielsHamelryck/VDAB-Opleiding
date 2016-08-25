using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
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

namespace Herhaling1
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

        public ObservableCollection<BierEigenschappen> bierEigenschappenOB = new ObservableCollection<BierEigenschappen>();
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            
            var manager = new BierManager();
            ComboBoxSoorten.DisplayMemberPath = "Naam";
            ComboBoxSoorten.SelectedValuePath = "SoortNr";
            ComboBoxSoorten.ItemsSource = manager.GetSoorten();
            ListBoxBieren.ItemsSource = bierEigenschappenOB;
            ListBoxBieren.DisplayMemberPath = "Naam";
            bierEigenschappenOB.CollectionChanged += this.OnCollectionChanged;
            Update();
        }

        
        
        private void ComboBoxSoorten_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //bierEigenschappenViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bierEigenschappenViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // bierEigenschappenViewSource.Source = [generic data source]
            var manager=new BierManager();
            try
            {
               // List<BierEigenschappen> bierEigenschappen = new List<BierEigenschappen>();
               // ListBoxBieren.Items.Clear();
                int soortnr = Convert.ToInt32(ComboBoxSoorten.SelectedValue);
                //bierEigenschappen = manager.GetBierEigenschappen(soortnr);
                bierEigenschappenOB = manager.GetBierEigenschappen(soortnr);
                //bierEigenschappenViewSource.Source = bierEigenschappenOB;
                ListBoxBieren.ItemsSource = bierEigenschappenOB;
                ListBoxBieren.DisplayMemberPath = "Naam";
                bierEigenschappenOB.CollectionChanged += this.OnCollectionChanged;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<BierEigenschappen> NieuweBieren = new List<BierEigenschappen>();
        public List<BierEigenschappen> OudeBieren = new List<BierEigenschappen>();
        public List<BierEigenschappen> GewijzigdeBieren = new List<BierEigenschappen>();
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            

            if (e.NewItems != null)
            {
                foreach (BierEigenschappen bier in e.NewItems)
                {
                    NieuweBieren.Add(bier);
                    Update();
                }
            }
            if (e.OldItems != null)
            {
                foreach (BierEigenschappen bier in e.OldItems)
                {
                    OudeBieren.Add(bier);
                    Update();
                }
            }

            
        }

        public void Update()
        {
            if (NieuweBieren.Count() == 0 || OudeBieren.Count() == 0 || GewijzigdeBieren.Count() == 0)
            {
                Opslaan.IsEnabled = false;
            }
            else Opslaan.IsEnabled = true;
        }

        private void Opslaan_OnClick(object sender, RoutedEventArgs e)
        {
            
            var manager = new BierManager();
            if (NieuweBieren.Count() != 0)
            {
                
                manager.Toevoegingen(NieuweBieren);
                
            }
            NieuweBieren.Clear();
            if (OudeBieren.Count() != 0)
            {
                manager.Verwijderingen(OudeBieren);
            }
            OudeBieren.Clear();
            foreach (var bier in bierEigenschappenOB)
            {
                if (bier.Changed == true)
                {
                    
                    GewijzigdeBieren.Add(bier);
                    Update();
                    bier.Changed = false;
                }
            }
            if (GewijzigdeBieren.Count() != 0)
            {
                
                foreach (var bier in GewijzigdeBieren)
                {
                    if (bier.BierNr >0)
                    {
                        manager.Wijzigingen(GewijzigdeBieren);
                    }
                }
                
            }
            GewijzigdeBieren.Clear();
        }


        private void ButtonNieuw_OnClick(object sender, RoutedEventArgs e)
        {
            
            
            if (MessageBox.Show("Wilt u een nieuw Bier toevoegen?", "Nieuw bier toevoegen", MessageBoxButton.YesNo,
                MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                foreach (var gewijzigdBier in bierEigenschappenOB)
                {
                    if (gewijzigdBier.Changed == true)
                    {

                        GewijzigdeBieren.Add(gewijzigdBier);
                        Update();
                        gewijzigdBier.Changed = false;
                    }
                }
                BierEigenschappen bier = new BierEigenschappen();
                
                bier.BierNr = 0;
                bier.Naam = "-";
                
                bierEigenschappenOB.Add(bier);
                ListBoxBieren.SelectedItem = ListBoxBieren.Items[0];

                //als men op de nieuw knop drukt na een update moet deze bewaard worden in de gewijzigdebierenLijst
               
            }
            else MessageBox.Show("Nieuw Bier toevoegen geannnuleerd!", "annulatie", MessageBoxButton.OK,MessageBoxImage.Information);


        }

        bool CheckOpFouten()
        {
            bool foutgevonden = false;
            foreach (var c in grid1.Children)
            {
                //zonder adornerDecorator 
                //if (Validation.GetHasError((DependencyObject) c)) foutgevonden = true;
                if (c is AdornerDecorator)
                {
                    if (Validation.GetHasError((AdornerDecorator) c))
                    {
                        foutgevonden = true;
                    }
                }
                else if (Validation.GetHasError((DependencyObject) c))
                {
                    foutgevonden = true;
                }
            }
            return foutgevonden;
        }

        private void ListBoxBieren_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (CheckOpFouten()){ e.Handled = true;}
            if (e.Key == Key.Delete && e.Handled==false)
            {
                
                if (MessageBox.Show("Wilt u het gekozen bier verwijderen?", "Delete", MessageBoxButton.YesNo,
                    MessageBoxImage.Question,
                    MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    bierEigenschappenOB.Remove((BierEigenschappen)ListBoxBieren.SelectedValue);
                }
            }
        }

        private void Grid1_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CheckOpFouten()) e.Handled = true;
        }

        public bool edit=true;
        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {


            if (edit)
            {
                Edit.Content = "Cancel";
                TextBoxenReadOnlyStatus();
                Opslaan.Visibility = Visibility.Visible;
                ButtonNieuw.Visibility=Visibility.Visible;
                


                edit = false;
                
            }

            else if(!edit)
            {
                Edit.Content = "Edit";
                TextBoxenReadOnlyStatus();
                Opslaan.Visibility = Visibility.Hidden;
                ButtonNieuw.Visibility = Visibility.Hidden;

                edit = true;
                
            }

            }

        public void TextBoxenReadOnlyStatus()
        {
            if (!edit)
            {
                foreach (Control c in grid1.Children)
                {
                    if (c is TextBox)
                    {
                        TextBox tb = c as TextBox;
                        tb.IsReadOnly = true;
                    }

                }
            }
            else if (edit)
            {
                foreach (Control c in grid1.Children)
                {
                    if (c is TextBox)
                    {
                        TextBox tb = c as TextBox;
                        tb.IsReadOnly = false;
                    }
                }
            }

        }


    }
        
        
    }

