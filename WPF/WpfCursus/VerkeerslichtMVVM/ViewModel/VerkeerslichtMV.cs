using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VerkeerslichtMVVM.Model;

namespace VerkeerslichtMVVM.ViewModel
{
    public class VerkeerslichtMV : ViewModelBase
    {
        public VerkeersLicht licht
        {
            get { return _licht; }
            set
            {
                _licht = value;
                RaisePropertyChanged("licht");
            }
        }

        public VerkeerslichtMV(VerkeersLicht vlLicht)
        {
            licht = vlLicht;

        }

        public bool RoodKnop;
        private VerkeersLicht _licht;

        public int RoodZichtbaar
        {
            get { return licht.RoodLicht; }
            set
            {
                licht.RoodLicht = value;
                RaisePropertyChanged("RoodZichtbaar");
                RaisePropertyChanged("VerandLicht");
                RaisePropertyChanged("licht");
            }
        }


        public int OranjeZichtbaar
        {
            get { return licht.OranjeLicht; }
            set
            {
                licht.OranjeLicht = value;
                RaisePropertyChanged("OranjeZichtbaar");
                RaisePropertyChanged("VeranderLicht");
                RaisePropertyChanged("licht");
            }
        }


        public int GroenZichtbaar
        {
            get { return licht.GroenLicht; }
            set
            {
                licht.GroenLicht = value;
                RaisePropertyChanged("GroenZichtbaar");
                RaisePropertyChanged("VeranderLicht");
                RaisePropertyChanged("licht");
            }
        }

        public Boolean WasRood
        {
            get { return licht.WasRood; }
            set
            {
                licht.WasRood = value;
                RaisePropertyChanged("WasRood");
                RaisePropertyChanged("VeranderLicht");
            }
        }

        public RelayCommand VeranderLicht
        {
            get { return new RelayCommand(Verander); }
        }


        private void Verander()
        {
            if (RoodZichtbaar != 0 && WasRood)
            {
                RoodZichtbaar = 0;
                OranjeZichtbaar = 1;
                GroenZichtbaar = 0;
                WasRood = true;
            }
            else if (OranjeZichtbaar != 0 && WasRood)

            {
               
                RoodZichtbaar = 0;
                OranjeZichtbaar = 0;
                GroenZichtbaar = 1;
                WasRood = false;
            }
            else if (OranjeZichtbaar != 0 && !WasRood)
            {
                RoodZichtbaar = 1;
                OranjeZichtbaar = 0;
                GroenZichtbaar = 0;
                
                WasRood = true;
            }
            else if (GroenZichtbaar != 0 && !WasRood)
            {
                RoodZichtbaar = 0;
                OranjeZichtbaar = 1;
                GroenZichtbaar = 0;
                
                WasRood = false;


            }
        }
    }

    public class RoodLichtConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            VerkeersLicht licht = (VerkeersLicht) value;

            if (licht.WasRood && licht.OranjeLicht == 1)
            {
                return false;
            }
            else if (!licht.WasRood && licht.OranjeLicht == 1)
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class GroenLichtConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            VerkeersLicht licht = (VerkeersLicht)value;

            if (licht.WasRood && licht.OranjeLicht == 1)
            {
                return true;
            }
            else if (!licht.WasRood && licht.OranjeLicht == 1)
                return false;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class OranjeLichtConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            VerkeersLicht licht = (VerkeersLicht)value;

            if (licht.WasRood && licht.OranjeLicht == 1)
            {
                return false;
            }
            else if (!licht.WasRood && licht.OranjeLicht == 1)
                return false;
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
