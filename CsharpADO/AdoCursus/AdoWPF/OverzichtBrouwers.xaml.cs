using System;
using System.CodeDom;
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
using System.Windows.Shapes;
using AdoGemeenschap;


namespace AdoWPF
{
    /// <summary>
    /// Interaction logic for OverzichtBrouwers.xaml
    /// </summary>
    public partial class OverzichtBrouwers : Window
    {
        private CollectionViewSource brouwerViewSource;
        public ObservableCollection<Brouwer> BrouwerOb= new ObservableCollection<Brouwer>();
        public OverzichtBrouwers()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulDeGrid();
            TextBoxZoeken.Focus();
            var manager= new BrouwerManager();
            ComboBoxPostcodeFilter.Items.Add("alles");
            List<String> pc = manager.getPostcodes();
            foreach (var p in pc)
            {
                ComboBoxPostcodeFilter.Items.Add(p);
            }
            ComboBoxPostcodeFilter.SelectedIndex = 0;
        }

        private void ButtonZoeken_OnClick(object sender, RoutedEventArgs e)
        {
            
            VulDeGrid();
        }

        private void VulDeGrid()
        {
            try
            {
                
                 brouwerViewSource =
                    (CollectionViewSource)(this.FindResource("brouwerViewSource"));
                var manager = new BrouwerManager();
                BrouwerOb = manager.GetBrouwersBeginNaam(TextBoxZoeken.Text);
                int TotalRowCount;
                TotalRowCount = BrouwerOb.Count();
                LabelTotalRowCount.Content = TotalRowCount;
                brouwerViewSource.Source = BrouwerOb;
                BrouwerOb.CollectionChanged += this.OnCollectionChanged;
                    goUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // een lijst maken met verwijderde brouwers

        public List<Brouwer> OudeBrouwers = new List<Brouwer>();
        
        // een lijst maken voor het toevoegen van brouwers

        public List<Brouwer> NieuweBrouwers = new List<Brouwer>();

        // een lijst voor de gewijzigde brouwers

        public List<Brouwer> GewijzigdeBrouwers=new List<Brouwer>();
        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (Brouwer oudeBrouwer in e.OldItems)
                {
                    OudeBrouwers.Add(oudeBrouwer);
                }
            }
            if (e.NewItems != null)
            {
                foreach (Brouwer nieuweBrouwer in e.NewItems)
                {
                    NieuweBrouwers.Add(nieuweBrouwer);
                }
            }
            

        }

        

       
        private void ButtonZoeken_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                VulDeGrid();
            }
        }

        private void GoToFirstButton_OnClick(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToFirst();
            goUpdate();
        }

        private void GoToPreviousButton_OnClick(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToPrevious();
            goUpdate();
        }

        private void GoToNextButton_OnClick(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToNext();
            goUpdate();
        }

        private void GoToLastButton_OnClick(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToLast();
            goUpdate();
        }

        private void goUpdate()
        {
            goToPreviousButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == 0);
            goToFirstButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == 0);
            goToNextButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == brouwerDataGrid.Items.Count - 2);
            goToLastButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == brouwerDataGrid.Items.Count - 2);
            if (brouwerDataGrid.Items.Count != 0)
            {
                if (brouwerDataGrid.SelectedItem != null)
                {
                   brouwerDataGrid.ScrollIntoView(brouwerDataGrid.SelectedItem);
                    ListBoxBrouwers.ScrollIntoView(brouwerDataGrid.SelectedItem);
                }
            }
            TextBoxGo.Text = (brouwerViewSource.View.CurrentPosition + 1).ToString();
        }

        private void ButtonGo_OnClick(object sender, RoutedEventArgs e)
        {
            int position;
            int.TryParse(TextBoxGo.Text, out position);
            if (position > 0 || position <= brouwerDataGrid.Items.Count)
            {
                brouwerViewSource.View.MoveCurrentToPosition(position - 1);
            }
            else
            {
                MessageBox.Show("The input index is not valid");
            }
            goUpdate();
        }

        private void BrouwerDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            goUpdate();
        }

        // Validatie controle bij mouse/keydown

        bool CheckOpFouten()
        {
            bool foutGevonden = false;
            foreach (var c in gridDetail.Children)
            {
                if (c is AdornerDecorator)
                {
                    if(Validation.GetHasError(((AdornerDecorator)c).Child))
                    {
                        foutGevonden = true;
                    }
                }
                else if(Validation.GetHasError((DependencyObject)c))
                {
                    foutGevonden = true;
                }
            }
            return foutGevonden;
        }

        private void BrouwerDataGrid_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (CheckOpFouten())
            {
                e.Handled = true;
            }
        }

        private void BrouwerDataGrid_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(CheckOpFouten())
            {
                e.Handled = true;
            }
        }

        private void ComboBoxPostcodeFilter_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxPostcodeFilter.SelectedIndex == 0)
            {
                brouwerDataGrid.Items.Filter = null;
            }
            else brouwerDataGrid.Items.Filter = new Predicate<object>(PostCodeFilter);
        }

        public bool PostCodeFilter(object br)
        {
            Brouwer b = br as Brouwer;
            bool result = (b.Postcode == Convert.ToInt16(ComboBoxPostcodeFilter.SelectedValue));
            return result;
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            var manager = new BrouwerManager();
            if (OudeBrouwers.Count() != 0)
            {
                manager.SchrijfVerwijderingen(OudeBrouwers);
                LabelTotalRowCount.Content = (int) LabelTotalRowCount.Content - OudeBrouwers.Count();
            }
            OudeBrouwers.Clear();
            MessageBox.Show("Alles is opgeslagen in de database", "Info", MessageBoxButton.OK,
                MessageBoxImage.Information);
            if (NieuweBrouwers.Count() != 0)
            {
                manager.SchrijfToevoegingen(NieuweBrouwers);
                LabelTotalRowCount.Content = (int) LabelTotalRowCount.Content + NieuweBrouwers.Count();
            }
            NieuweBrouwers.Clear();
            
            foreach (Brouwer b in BrouwerOb)
            {
                if (b.Changed == true)
                {
                    GewijzigdeBrouwers.Add(b);
                }
                b.Changed = false;
            }
            if (GewijzigdeBrouwers.Count != 0)
            {
                manager.SchrijfWijzigingen(GewijzigdeBrouwers);
                
            }
            GewijzigdeBrouwers.Clear();
            VulDeGrid();
        }
    }
}
