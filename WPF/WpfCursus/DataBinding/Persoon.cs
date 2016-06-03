using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding
{
    public class Persoon : INotifyPropertyChanged
    {
        private string naamValue;

        public string Naam
        {
            get { return naamValue; }
            set
            {
                naamValue = value;
                RaisePropertyChanged("Naam");
            }
        }
        private decimal weddeValue;

        public decimal Wedde
        {
            get { return weddeValue; }
            set
            {
                weddeValue = value;
                RaisePropertyChanged("Wedde");
            }
        }

        private DateTime indienstValueDateTime;

        public DateTime InDienst
        {
            get { return indienstValueDateTime; }
            set
            {
                indienstValueDateTime = value;
                RaisePropertyChanged("InDienst");
            }
        }
        

        private void RaisePropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Persoon(string naam,decimal wedde, DateTime indienst)
        {
            this.Naam = naam;
            this.Wedde = wedde;
            this.InDienst = indienst;
        }
    }
}
