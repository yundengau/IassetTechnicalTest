using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IassetTechnicalTest.Domain;
using IassetTechnicalTest.IBLL;


namespace IassetTechnicalTest.BLL
{
    public class MockCountryCityServices : ICountryCityServices
    {
        
        public List<Country> GetMockCountryList()
        {
            List<Country> countries = new List<Country>();
            countries.Add(new Country() { Name = "Australia", CountryCode = "AU" });
            countries.Add(new Country() { Name = "United States", CountryCode = "US" });
            countries.Add(new Country() { Name = "United Kingdom", CountryCode = "UK" });
            countries.Add(new Country() { Name = "China", CountryCode = "CH" });
            countries.Add(new Country() { Name = "India", CountryCode = "IN" });

            return countries;
        }
        public List<City> GetMockCityList()
        {
            List<City> cities = new List<City>();
            cities.Add(new City() { Name = "Sydney", CountryCode = "AU" });
            cities.Add(new City() { Name = "Melbourne", CountryCode = "AU" });
            cities.Add(new City() { Name = "New York", CountryCode = "US" });
            cities.Add(new City() { Name = "Los Angeles", CountryCode = "US" });
            cities.Add(new City() { Name = "London", CountryCode = "UK" });
            cities.Add(new City() { Name = "Liverpool", CountryCode = "UK" });
            cities.Add(new City() { Name = "Birmingham", CountryCode = "UK" });
            cities.Add(new City() { Name = "Beijing", CountryCode = "CH" });
            cities.Add(new City() { Name = "Shanghai", CountryCode = "CH" });
            cities.Add(new City() { Name = "Mumbai", CountryCode = "IN" });
            cities.Add(new City() { Name = "New Delhi", CountryCode = "IN" });

            return cities;

        }

        public List<City> GetCountryCities(string country)
        {
            string countryCode = GetMockCountryList().Where(c => c.Name.ToLower() == country.ToLower()).Select(c => c.CountryCode).FirstOrDefault();
            
            // Cannot find the matching country code, there is something wrong with the input
            if (countryCode == null) return null;

            IEnumerable<City> countryCityList = GetMockCityList().Where(c => c.CountryCode.ToLower() == countryCode.ToLower());

            if (countryCityList != null && countryCityList.Count() > 0)
            {
                return countryCityList.ToList();
            }
            else return null;

        }

    }
}
