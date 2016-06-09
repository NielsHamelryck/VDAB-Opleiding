using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMHobby.Model;
using MVVMHobby.View;

namespace MVVMHobby.ViewModel
{
    class HobbLijstVM : ViewModelBase
    {
        public HobbLijstVM()
        {
            HobbyLijst.Add(new HobbyVM(new Model.Hobby("sport", "voetbal",
                        new BitmapImage(new Uri("pack://application:,,,/images/voetbal.jpg", UriKind.Absolute)))));
            HobbyLijst.Add(new HobbyVM(new Model.Hobby("sport", "atletiek",
                        new BitmapImage(new Uri("pack://application:,,,/images/atletiek.jpg", UriKind.Absolute)))));
            HobbyLijst.Add(new HobbyVM(new Model.Hobby("sport", "basketbal",
                        new BitmapImage(new Uri("pack://application:,,,/images/basketbal.jpg", UriKind.Absolute)))));
            HobbyLijst.Add(new HobbyVM(new Model.Hobby("sport", "tennis",
                        new BitmapImage(new Uri("pack://application:,,,/images/tennis.jpg", UriKind.Absolute)))));
            HobbyLijst.Add(new HobbyVM(new Model.Hobby("sport", "turnen",
                       new BitmapImage(new Uri("pack://application:,,,/images/turnen.jpg", UriKind.Absolute)))));
            HobbyLijst.Add(new HobbyVM(new Model.Hobby("muziek", "trompet",
                new BitmapImage(new Uri("pack://application:,,,/Images/trompet.jpg", UriKind.Absolute)))));
            HobbyLijst.Add(new HobbyVM(new Model.Hobby("muziek", "drum",
                new BitmapImage(new Uri("pack://application:,,,/Images/drum.jpg", UriKind.Absolute)))));
            HobbyLijst.Add(new HobbyVM(new Model.Hobby("muziek", "gitaar",
                new BitmapImage(new Uri("pack://application:,,,/Images/gitaar.jpg", UriKind.Absolute)))));
            HobbyLijst.Add(new HobbyVM(new Model.Hobby("muziek", "piano",
                new BitmapImage(new Uri("pack://application:,,,/Images/piano.jpg", UriKind.Absolute)))));

        }

        private ObservableCollection<HobbyVM> hobbyLijst =
            new ObservableCollection<HobbyVM>();

        public ObservableCollection<HobbyVM> HobbyLijst
        {
            get { return hobbyLijst; }
            set
            {
                hobbyLijst = value;
                RaisePropertyChanged("HobbyLijst");
            }
        }

        private HobbyVM selectedHobby;

        public HobbyVM SelectedHobby
        {
            get { return selectedHobby; }
            set
            {
                selectedHobby = value;
                RaisePropertyChanged("SelectedHobby");
            }
        }

        public RelayCommand<RoutedEventArgs> VerwijderCommand
        {
            get { return new RelayCommand<RoutedEventArgs>(Verwijder);}
        }

        private void Verwijder(RoutedEventArgs e)
        {
            HobbyLijst.Remove(selectedHobby);
        }

    }
}
