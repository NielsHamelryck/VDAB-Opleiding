using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer.Services
{
    public class CountryService : ICountryService
    {
        public void Insert(Country country)
        {
            using (var entities = new toysforboysEntities())
            {
                
                entities.countries.Add(country);
                entities.SaveChanges();
            }
        }

        public void Delete(Country country)
        {
            using (var entities = new toysforboysEntities())
            {
                entities.countries.Attach(country);
                entities.countries.Remove(country);
                entities.SaveChanges();
            }
        }

        public void Edit(Country country)
        {

            using (var entities = new toysforboysEntities())
            {
                var originalCountry = entities.countries.Find(country.id);
                if (country.name!=string.Empty)
                {
                    originalCountry.name = country.name;
                }
                
                entities.SaveChanges();
            }
        }

        public IEnumerable<Country> GetAll()
        {
            List<Country> AllCountries = new List<Country>();
            using (var entities = new toysforboysEntities())
            {
                foreach (var country in entities.countries)
                {
                    AllCountries.Add(country);
                }
            }
            return AllCountries;
        }

        public IEnumerable<Country> GetAll(string includes)
        {
            return GetAll(c => true, includes);
        }

        public IEnumerable<Country> GetAll(Func<Country, bool> predicate, string includes)
        {
            List<Country> AllCountries = new List<Country>();
            using (var entities = new toysforboysEntities())
            {
                foreach (var country in (String.IsNullOrEmpty(includes) ? entities.countries : entities.countries.Include(includes)).Where(predicate))
                {
                    AllCountries.Add((Country)country);
                }
            }

            return AllCountries;
        }

        public Country GetById(int countryID)
        {
            using (var entities = new toysforboysEntities())
            {
                var query = (from country in entities.countries
                             where country.id == countryID
                             orderby country.id
                             select country).First();

                return query;
            }
        }

        public Country GetById(int countryID, string includes)
        {
            using (var entities = new toysforboysEntities())
            {
                var query = (from country in entities.countries
                             where country.id == countryID
                             orderby country.id
                             select country).Include(includes).First();

                return query;
            }
        }
    }
}
