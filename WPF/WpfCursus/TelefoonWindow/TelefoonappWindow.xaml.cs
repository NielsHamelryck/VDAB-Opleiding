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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace TelefoonWindow
{
    /// <summary>
    /// Interaction logic for TelefoonappWindow.xaml
    /// </summary>
    public partial class TelefoonappWindow : Window
    {
        public TelefoonappWindow()
        {
            InitializeComponent();
        }

        private void ComboBoxCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxPersonen.Items.Clear();
            foreach (Persoon persoon in PersonenList)
            {
                if (persoon.Groep.ToString() == ComboBoxCategorie.SelectedItem.ToString() || ComboBoxCategorie.SelectedIndex == 0)
                {
                    ListBoxPersonen.Items.Add(persoon);
                }
                ListBoxPersonen.Items.SortDescriptions.Add(new SortDescription("Naam",ListSortDirection.Ascending));
            }


        }
        public List<Persoon> PersonenList = new List<Persoon>();
        private void TelefoonappWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            PersonenList.Add(new Persoon("Anne","0487/45.23.14",GroepEnum.Vrienden,new BitmapImage(new Uri(@"bestanden\anne.jpg",UriKind.Relative))));
            PersonenList.Add(new Persoon("Bob", "0486/15.03.31", GroepEnum.Vrienden, new BitmapImage(new Uri(@"bestanden\bob.jpg", UriKind.Relative))));
            PersonenList.Add(new Persoon("Ed", "0497/38.08.25", GroepEnum.Vrienden, new BitmapImage(new Uri(@"bestanden\ed.jpg", UriKind.Relative))));
            PersonenList.Add(new Persoon("Collega1", "0486/45.03.88", GroepEnum.Werk, new BitmapImage(new Uri(@"bestanden\collega1.jpg", UriKind.Relative))));
            PersonenList.Add(new Persoon("Collega2", "0487/69.96.01", GroepEnum.Werk, new BitmapImage(new Uri(@"bestanden\collega2.jpg", UriKind.Relative))));
            PersonenList.Add(new Persoon("Collega3", "0496/66.43.04", GroepEnum.Werk, new BitmapImage(new Uri(@"bestanden\collega3.jpg", UriKind.Relative))));
            PersonenList.Add(new Persoon("Grote Zus", "0498/55.64.99",GroepEnum.Familie, new BitmapImage(new Uri(@"bestanden\grotezus.jpg",UriKind.Relative))));
            PersonenList.Add(new Persoon("Kleine Zus", "0498/55.64.93", GroepEnum.Familie, new BitmapImage(new Uri(@"bestanden\kleinezus.jpg", UriKind.Relative))));
            PersonenList.Add(new Persoon("Vader", "0498/55.64.96", GroepEnum.Familie, new BitmapImage(new Uri(@"bestanden\vader.jpg", UriKind.Relative))));
            PersonenList.Add(new Persoon("Tante Nonneke", "0497/45.84.09", GroepEnum.Familie, new BitmapImage(new Uri(@"bestanden\tantenon.jpg", UriKind.Relative))));
            ComboBoxCategorie.Items.Add("Iedereen");
            ComboBoxCategorie.Items.Add("Familie");
            ComboBoxCategorie.Items.Add("Vrienden");
            ComboBoxCategorie.Items.Add("Werk");
            ComboBoxCategorie.SelectedIndex = 0;
        }

        private void Bellen_OnClick(object sender, RoutedEventArgs e)
        {
            

            
            
            if (ListBoxPersonen.SelectedItem == null)
            {
                MessageBox.Show("Je moet eerst iemand selecteren", "Niemand gekozen", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }else if (ListBoxPersonen.SelectedItem != null)
            {
                Persoon teBellenPersoon = (Persoon) ListBoxPersonen.SelectedItem;
                string tekst = "Wil je " + teBellenPersoon.Naam + " bellen \nop het nummer "
                               + teBellenPersoon.Telefoonnr;
                if (MessageBox.Show(tekst, "Telefoon", MessageBoxButton.YesNo, MessageBoxImage.Question,
                    MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    SoundPlayer speler = new SoundPlayer("../../bestanden/PHONE.wav");
                    speler.Play();
                }
                
            }
        }
    }
}
