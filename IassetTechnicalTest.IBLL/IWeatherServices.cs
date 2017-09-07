using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IassetTechnicalTest.Domain;

namespace IassetTechnicalTest.IBLL
{
    public interface IWeatherServices
    {
        /// <summary>
        /// Get weather info of the city
        /// </summary>
        /// <param name="country">Country name</param>
        /// <param name="city">City name</param>
        /// <returns>Weather entity</returns>
        Object GetCityWeather(string country, string city);

        /// <summary>
        /// Get Json string from the webservice
        /// </summary>
        /// <param name="country">Country name</param>
        /// <param name="city">City name</param>
        /// <returns>Weather json string</returns>
        string GetWeatherJson(string country, string city);


    }
}
