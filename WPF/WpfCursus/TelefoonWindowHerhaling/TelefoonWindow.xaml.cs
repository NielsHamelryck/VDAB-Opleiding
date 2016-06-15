using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
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

namespace TelefoonWindowHerhaling
{
    /// <summary>
    /// Interaction logic for TelefoonWindow.xaml
    /// </summary>
    public partial class TelefoonWindow : Window
    {
        public TelefoonWindow()
        {
            InitializeComponent();
           
        }
        public List<Persoon> personen= new List<Persoon>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            personen.Add(new Persoon("Anne","0493665281",Group.Vrienden,
                new BitmapImage(new Uri(@"bestanden\anne.jpg",UriKind.Relative))));
            personen.Add(new Persoon("Bob", "0478105566", Group.Vrienden,
                new BitmapImage(new Uri(@"bestanden\bob.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Collega1", "0465821253", Group.Werk,
                new BitmapImage(new Uri(@"bestanden\collega1.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Collega2", "0441518512", Group.Werk,
                new BitmapImage(new Uri(@"bestanden\collega2.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Collega3", "0447785233", Group.Werk,
                new BitmapImage(new Uri(@"bestanden\collega3.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Ed", "04891474122", Group.Vrienden,
                new BitmapImage(new Uri(@"bestanden\ed.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Grote Zus", "0485521671", Group.Familie,new BitmapImage(new Uri(@"bestanden\grotezus.jpg",UriKind.Relative))));
            personen.Add(new Persoon("Kleine Zus", "0485521671", Group.Familie,new BitmapImage(new Uri(@"bestanden\kleinezus.jpg",UriKind.Relative))));
            personen.Add(new Persoon("Tante Nonneke", "0484477632", Group.Familie,new BitmapImage(new Uri(@"bestanden\tantenon.jpg",UriKind.Relative))));
            personen.Add(new Persoon("Vader", "0488557160", Group.Familie,new BitmapImage(new Uri(@"bestanden\vader.jpg", UriKind.Relative))));

            CategorieenComboBox.Items.Add("Iedereen");
            CategorieenComboBox.Items.Add("Familie");
            CategorieenComboBox.Items.Add("Vrienden");
            CategorieenComboBox.Items.Add("Werk");

            CategorieenComboBox.SelectedIndex = 0;
        }

        private void CategorieenComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxPersonen.Items.Clear();
            foreach (Persoon persoon in personen)
            {
                if (persoon.Groep.ToString() == CategorieenComboBox.SelectedItem.ToString()
                    || CategorieenComboBox.SelectedIndex == 0)
                {
                    ListBoxPersonen.Items.Add(persoon);
                }
            }
            ListBoxPersonen.Items.SortDescriptions.Add(new SortDescription("Naam", ListSortDirection.Ascending));
        }

        private void ButtonBellen_OnClick(object sender, RoutedEventArgs e)
        {
            Persoon persoon =(Persoon) ListBoxPersonen.SelectedItem;
            string bellen;
            
            if (ListBoxPersonen.SelectedItem != null)
            {   bellen = "Wil je " + persoon.Naam + " bellen " + "\n"
                     + " op het nummer " + persoon.Telefoonnr;
                if (
                    MessageBox.Show(bellen,"Telefoon",  MessageBoxButton.YesNo, MessageBoxImage.Question,
                        MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    SoundPlayer sp = new SoundPlayer(@"..\..\bestanden\PHONE.wav");
                    sp.Play();
                }
            }
            else MessageBox.Show("Je moet eerst iemand selecteren","Niemand gekozen",  MessageBoxButton.OK,
                MessageBoxImage.Exclamation);
        }
    }
}
