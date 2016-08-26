using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;
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
using AdoGemeenschappelijk;

namespace TestADOWPF
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

        public ObservableCollection<Film> filmsOB = new ObservableCollection<Film>();
        public List<Genre> genres = new List<Genre>();
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var manager = new FilmManager();
                filmsOB = manager.GetFilms();
                ListBoxFilms.ItemsSource = filmsOB;
                ListBoxFilms.DisplayMemberPath = "Titel";
                ListBoxFilms.SelectedIndex = 0;
                genres=manager.GetGenres();
                genres.Insert(0,new Genre(0,"-"));
                ComboBoxGenre.ItemsSource = genres;
                ComboBoxGenre.DisplayMemberPath = "GenreNaam";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ListBoxFilms_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ButtonToevoegen_OnClick(object sender, RoutedEventArgs e)
        {
            if ((string) ButtonToevoegen.Content == "Toevoegen")
            {
                ButtonToevoegen.Content = "Bevestigen";
                filmsOB.Add(new Film());
                ListBoxFilms.ItemsSource = filmsOB;
                ListBoxFilms.DisplayMemberPath="Titel";
                ListBoxFilms.SelectedItem = filmsOB.Last();
            }
            else ButtonToevoegen.Content = "Toevoegen";
        }
    }
}
