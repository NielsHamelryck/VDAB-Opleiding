using DataAccessLayer;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFToysForBoys.ViewModel
{
    public partial class ManagementVM : ViewModelBase
    {
        private List<Country> countryList;
        public List<Country> CountryList
        {
            get { return countryList; }
            set
            {
                countryList = value;
                RaisePropertyChanged("CountryList");
            }
        }

        private List<Country> fcountryList;
        public List<Country> FCountryList
        {
            get { return fcountryList; }
            set
            {
                fcountryList = value;
                RaisePropertyChanged("FCountryList");
            }
        }

        private List<Country> cCountryList;
        public List<Country> CCountryList
        {
            get { return cCountryList; }
            set
            {
                cCountryList = value;
                RaisePropertyChanged("CCountryList");
            }
        }

        private int selectedCCountryI;
        public int SelectedCCountryI
        {
            get { return selectedCCountryI; }
            set
            {
                selectedCCountryI = value;
                RaisePropertyChanged("SelectedCCountryI");
            }
        }

        private int selectedCountryI;
        public int SelectedCountryI
        {
            get { return selectedCountryI; }
            set
            {
                selectedCountryI = value;
                
                if (value != -1)
                {
                    CustomerList = ccountryService.GetById(value, "customers").customers.ToList();
                }
                else
                {
                    CustomerList = cService.GetAll("country").ToList();
                    customerList.Sort(new CustomerCompare());
                }

                RaisePropertyChanged("SelectedCountryI");
            }
        }
    }
}
