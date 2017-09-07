using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IassetTechnicalTest.Domain;

namespace IassetTechnicalTest.IBLL
{
    public interface ICountryCityServices
    {
        /// <summary>
        /// Get all the cities from the country
        /// </summary>
        /// <param name="Country">Country Name</param>
        /// <returns>List of cities</returns>
        List<City> GetCountryCities(string country);
    }
}
