using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
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
using TestADOWPF.Annotations;

namespace TestADOWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        private bool controlEnable;
        public Boolean ControlEnable
        {
            get
            {
                
                return controlEnable;
            }
            set
            {
                controlEnable = value;
                OnPropertyChanged("ControlEnable");
            }
        }

        private Boolean controlReadOnlyValue;

        public Boolean ControlReadOnly
        {
            get
            {
                return controlReadOnlyValue;
            }
            set
            {
                controlReadOnlyValue = value;
                OnPropertyChanged("ControlReadOnly");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public ObservableCollection<Film> filmsOB = new ObservableCollection<Film>();
        public List<Genre> genres = new List<Genre>();
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var manager = new FilmManager();
                filmsOB = manager.GetFilms();
                UpdateNaAnnulatie();
                genres = manager.GetGenres();
                genres.Insert(0, new Genre(0, "-"));
                ComboBoxGenre.ItemsSource = genres;

                filmsOB.CollectionChanged += this.OnCollectionChanged;
                ControlReadOnly = true;
                ControlEnable = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        

        public List<Film> OudeFilms = new List<Film>();
        public List<Film> NieuwFilms = new List<Film>();
        public List<Film> GewijzigdeFilms = new List<Film>();


        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (Film oudefilm in e.OldItems)
                {
                    OudeFilms.Add(oudefilm);
                }
            }
            if (e.NewItems != null)
            {
                foreach (Film nieuweFilm in e.NewItems)
                {
                    NieuwFilms.Add(nieuweFilm);
                }
            }
        }


        private void ButtonToevoegen_OnClick(object sender, RoutedEventArgs e)
        {
            if ((string) ButtonToevoegen.Content == "Toevoegen")
            {
                ButtonToevoegen.Content = "Bevestigen";
                ButtonVerwijderen.Content = "Annuleren";
                filmsOB.Add(new Film(0, "", 0, 0, 0, 0, 0));
                UpdateNaAnnulatie();

                ListBoxFilms.SelectedItem = filmsOB.Last();
                ComboBoxGenre.SelectedIndex = 0;
                ListBoxFilms.ScrollIntoView(ListBoxFilms.SelectedItem);
                ControlEnable = true;
                ControlReadOnly = false;
            }
            else
            {
                //TextBoxTitel.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                //ComboBoxGenre.GetBindingExpression(ComboBox.SelectedIndexProperty).UpdateSource();
                //TextBoxInVoorraad.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                //TextBoxUitVoorraad.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                //TextBoxPrijs.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                //TextBoxTotaalVerhuurd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                RefreshDeTextboxen();
                if (!FilmToevoegenHasErrors()) {
                    ControlEnable = false;
                    ControlReadOnly = true;
                    ButtonToevoegen.Content = "Toevoegen";
                    ButtonVerwijderen.Content = "Verwijderen";
                }
                
            }
            
               
        }

        private void RefreshDeTextboxen()
        {
            TextBoxTitel.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            ComboBoxGenre.GetBindingExpression(ComboBox.SelectedIndexProperty).UpdateSource();
            TextBoxInVoorraad.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TextBoxUitVoorraad.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TextBoxPrijs.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TextBoxTotaalVerhuurd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private bool FilmToevoegenHasErrors()
        {
            bool foutGevonden = false;
            foreach (var c in StackPanelBoxen.Children)
            {
                if (Validation.GetHasError((DependencyObject)c))
                {
                    foutGevonden = true;
                }
            }
            return foutGevonden;
        }

        private void ButtonVerwijderen_OnClick(object sender, RoutedEventArgs e)
                    {
                 if ((string) ButtonVerwijderen.Content == "Annuleren")
                 {
                     ButtonToevoegen.Content = "Toevoegen";
                     ButtonVerwijderen.Content = "Verwijderen";
                     filmsOB.Remove(filmsOB.Last());
                     OudeFilms.Remove(OudeFilms.Last());
                     NieuwFilms.Remove(NieuwFilms.Last());
                     UpdateNaAnnulatie();
                     ListBoxFilms.ScrollIntoView(ListBoxFilms.SelectedItem);
                     ControlEnable = false;
                     ControlReadOnly = true;
                 }
                 else
                 {
                     if ((ListBoxFilms.SelectedItem != null) &&(MessageBox.Show("Wilt u de film '"+((Film)ListBoxFilms.SelectedValue).Titel.TrimEnd()+"' verwijderen? ","Verwijderen"
                     ,MessageBoxButton.YesNo,MessageBoxImage.Question,MessageBoxResult.Yes)==MessageBoxResult.Yes))
                     {
                         var index = 0;
                          foreach (var nieuweFilm in NieuwFilms)
                         {
                             if ((Film) ListBoxFilms.SelectedItem == nieuweFilm)
                             {
                                 NieuwFilms.IndexOf(nieuweFilm);
                             }
                         }
                         NieuwFilms.RemoveAt(index);
                         filmsOB.Remove((Film)ListBoxFilms.SelectedItem);
                         ListBoxFilms.SelectedIndex = 0;
                        
                        
                     }else MessageBox.Show("Verwijderen geannuleerd","Verwijderen",MessageBoxButton.OK,MessageBoxImage.Information);
                 } // als de button "verwijderen" is selecteditem deleten
        }
        private void UpdateNaAnnulatie()
        {
            ListBoxFilms.ItemsSource = filmsOB;
            ListBoxFilms.SelectedIndex = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private void ButtonOpslaan_OnClick(object sender, RoutedEventArgs e)
        {
            var manager = new FilmManager();
            if (NieuwFilms.Count > 0)
            {
                manager.ToevoegingenWegschrijven(NieuwFilms);
            }
            if (GewijzigdeFilms.Count > 0)
            {
                manager.GewijzigdeFilmsToevoegen(GewijzigdeFilms);
            }

            if (OudeFilms.Count > 0)
            {
                manager.VerwijderingenToevoegen(OudeFilms);
            }
            
            OudeFilms.Clear();
            NieuwFilms.Clear();
            GewijzigdeFilms.Clear();
            MessageBox.Show("Opslaan is geslaagd", "Opslaan", MessageBoxButton.OK, MessageBoxImage.Information);
            filmsOB = manager.GetFilms();
            ListBoxFilms.ItemsSource = filmsOB;
            ListBoxFilms.SelectedIndex = 0;
        }

        private void ButtonVerhuur_OnClick(object sender, RoutedEventArgs e)
        {
            if (((Film)ListBoxFilms.SelectedItem).InVoorraad != 0)
            {
                //Film verhuurFilm = new Film();
                //verhuurFilm = (Film) ListBoxFilms.SelectedItem;
                //verhuurFilm.InVoorraad= verhuurFilm.InVoorraad-1;
                //verhuurFilm.UitVoorraad = verhuurFilm.UitVoorraad+1;
                //verhuurFilm.TotaalVerhuurd = verhuurFilm.TotaalVerhuurd+1;
                //GewijzigdeFilms.Add(verhuurFilm);
                //MessageBox.Show("Film verhuurt", "Verhuur", MessageBoxButton.OK, MessageBoxImage.Information);
                Film verhuurFilm = (Film)ListBoxFilms.SelectedItem;
                verhuurFilm.InVoorraad = verhuurFilm.InVoorraad - 1;
                verhuurFilm.UitVoorraad = verhuurFilm.UitVoorraad + 1;
                verhuurFilm.TotaalVerhuurd = verhuurFilm.TotaalVerhuurd + 1;
                GewijzigdeFilms.Add(verhuurFilm);
                
                MessageBox.Show("Film verhuurt", "Verhuur", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            MessageBox.Show("Er zijn geen films meer in voorraad", "Verhuur", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
