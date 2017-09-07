using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using IassetTechnicalTest.Domain;
using IassetTechnicalTest.IBLL;

namespace IassetTechnicalTest.BLL
{
    public class CountryCityServices : ICountryCityServices
    {
        /// <summary>
        /// This function is not working appropriately for the weather web services. Most 
        /// of the cities can not handled well by the weather web services.
        /// </summary>
        /// <param name="country">Country name</param>
        /// <returns>List of city in the Country</returns>
        [Obsolete("The method is replaced by the MockDataFactory class's method GetMockCityList(string country)")]
        public List<City> GetCountryCities(string country)
        {
            CountryCityService.GlobalWeatherSoapClient client = new CountryCityService.GlobalWeatherSoapClient("GlobalWeatherSoap");
            string result = client.GetCitiesByCountry(country);
            XDocument doc = XDocument.Parse(result);
            var cities = from elem in doc.Descendants("Table") select new City() { Name = elem.Element("City").Value };

            return cities.ToList();
        }


    }
}
