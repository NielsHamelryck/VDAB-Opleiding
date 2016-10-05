using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AdoGemeenschappelijk;

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
                VulDeLijst();
                genres = manager.GetGenres();
                genres.Insert(0, new Genre(0, ""));
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
                VulDeLijst();
                ListBoxFilms.SelectedItem = filmsOB.Last();
                ListBoxFilms.ScrollIntoView(ListBoxFilms.SelectedItem);
                ControlEnable = true;
                ControlReadOnly = false;
            }
            else
            {
               
                RefreshDeBoxen();
                if (!FilmToevoegenHasErrors())
                {
                    ControlEnable = false;
                    ControlReadOnly = true;
                    ButtonToevoegen.Content = "Toevoegen";
                    ButtonVerwijderen.Content = "Verwijderen";
                    VulDeLijst();
                }
                else
                    MessageBox.Show("Er zijn nog velden die niet voldoen aan de juiste verreisten",
                        "Toevoegen - Error", MessageBoxButton.OK, MessageBoxImage.Information);



            }
            
               
        }

        private void RefreshDeBoxen()
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
                     GeselecteerdeIndexInView();
                     ControlEnable = false;
                     ControlReadOnly = true;
                 }
                 else
                 {
                     if ((ListBoxFilms.SelectedItem != null) &&
                         (MessageBox.Show("Ben je zeker dat je deze film wil verwijderen? ", "Verwijderen"
                             , MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) ==
                          MessageBoxResult.No))
                     {
                         MessageBox.Show("Verwijderen geannuleerd", "Verwijderen", MessageBoxButton.OK,
                             MessageBoxImage.Information);

                     }
                     else
                     {
                         if (NieuwFilms.Count > 0)
                         {

                             var index = -1;
                             foreach (var nieuweFilm in NieuwFilms)
                             {
                                 if ((Film)ListBoxFilms.SelectedItem == nieuweFilm)
                                 {
                                     index=NieuwFilms.IndexOf(nieuweFilm);
                                 }
                             }
                             if(index>=0)
                                NieuwFilms.RemoveAt(index);
                         }
                         filmsOB.Remove((Film)ListBoxFilms.SelectedItem);
                         GeselecteerdeIndexInView();
                     } 
                 } // als de button "verwijderen" is selecteditem deleten
        }
        private void VulDeLijst()
        {
            ListBoxFilms.ItemsSource = filmsOB;
            GeselecteerdeIndexInView();
            
        }

        private void GeselecteerdeIndexInView()
        {
            ListBoxFilms.SelectedIndex = 0;
            ListBoxFilms.ScrollIntoView(ListBoxFilms.SelectedItem);
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
            if ((MessageBox.Show("Wilt u alles wegschrijven naar de database ?", "Opslaan", MessageBoxButton.YesNo,
                MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes))
            {
                var manager = new FilmManager();
                if (NieuwFilms.Count > 0)
                {
                    manager.ToevoegingenWegschrijven(NieuwFilms);
                }
                foreach (var gewijzigdeFilm in filmsOB)
                {
                    if (gewijzigdeFilm.Changed == true && gewijzigdeFilm.BandNr != 0)
                    {
                        GewijzigdeFilms.Add(gewijzigdeFilm);
                    }
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
                filmsOB = manager.GetFilms();
                VulDeLijst();
            } else MessageBox.Show("Opslaan geanulleerd", "Opslaan", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ButtonVerhuur_OnClick(object sender, RoutedEventArgs e)
        {
            if (((Film)ListBoxFilms.SelectedItem).InVoorraad != 0)
            {

                Film verhuurFilm = (Film)ListBoxFilms.SelectedItem;
                verhuurFilm.InVoorraad = verhuurFilm.InVoorraad - 1;
                verhuurFilm.UitVoorraad = verhuurFilm.UitVoorraad + 1;
                verhuurFilm.TotaalVerhuurd = verhuurFilm.TotaalVerhuurd + 1;
                MessageBox.Show("Film verhuurd", "Verhuur", MessageBoxButton.OK, MessageBoxImage.Information);
                GeselecteerdeIndexInView();
                
            }
            else
            MessageBox.Show("Alle films zijn verhuurd !", "Verhuur", MessageBoxButton.OK,
                MessageBoxImage.Exclamation);
        }
    }
}
