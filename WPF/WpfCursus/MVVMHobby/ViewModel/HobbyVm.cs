using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMHobby.View;
using System.Windows;
using System.Windows.Controls;


namespace MVVMHobby.ViewModel
{
    public class HobbyVM : ViewModelBase
    {
        private Model.Hobby hobby;

        public HobbyVM(Model.Hobby nhobby)
        {
            this.hobby = nhobby;
        }
       

        public string Categorie
        {
            get { return hobby.Categorie; }
            set
            {
                hobby.Categorie = value;
                RaisePropertyChanged("Categorie");
            }
        }

        public string Activiteit
        {
            get { return hobby.Activiteit; }
            set
            {
                hobby.Activiteit = value;
                RaisePropertyChanged("Activiteit");
            }
        }

        public BitmapImage Symbool
        {
            get { return hobby.Symbool; }
            set
            {
                hobby.Symbool = value;
                RaisePropertyChanged("Symbool");
            }
        }

        View.ImageView groteView;

        public RelayCommand<MouseEventArgs> MouseCommand
        {
            get { return new RelayCommand<MouseEventArgs>(MuisIn);}
        }

        private void MuisIn(MouseEventArgs e)
        {
            Image tg = (Image) e.OriginalSource;
            groteView = new View.ImageView();
            groteView.GroteImage.Source = tg.Source;
            groteView.Show();
        }

        public RelayCommand<MouseEventArgs> MouseUpCommand
        {
            get { return new RelayCommand<MouseEventArgs>(MuisUit);}
        }

        private void MuisUit(MouseEventArgs e)
        {
            if(groteView!=null)
                groteView.Close();
            groteView = null;
        }
    }
}
