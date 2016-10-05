using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFToysForBoys.ViewModel
{
    public class CountryCustomerVM: ViewModelBase
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

        public CountryCustomerVM()
        {
            ICountryService cService = new CountryService();
            CountryList = cService.GetAll("customers").ToList();
        }
    }
}
