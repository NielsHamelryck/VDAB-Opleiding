using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICountryService
    {
        void Insert(Country country);
        void Delete(Country country);

        void Edit(Country country);

        IEnumerable<Country> GetAll();
        IEnumerable<Country> GetAll(string includes);
        IEnumerable<Country> GetAll(Func<Country, bool> predicate, string includes);

        Country GetById(int countryID);
        Country GetById(int countryID, string includes); 
    }
}
