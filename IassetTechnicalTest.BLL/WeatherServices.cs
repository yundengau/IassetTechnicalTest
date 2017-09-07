using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using IassetTechnicalTest.IBLL;
using System.Net;
using System.Xml.Serialization;
using System.Data;
using System.Xml;
using System.IO;
using IassetTechnicalTest.Domain;
using System.Web.Script.Serialization;
using System.Configuration;


namespace IassetTechnicalTest.BLL
{
    public class WeatherServices : IWeatherServices
    {
        
        /// <summary>
        /// Encapsulate the json string into an object entity
        /// </summary>
        /// <param name="country">Country name</param>
        /// <param name="city">City name</param>
        /// <returns>Encapsulated object</returns>
        public Object GetCityWeather(string countryCode, string city)
        {
            string jsonString = GetWeatherJson(countryCode, city);
            var serializer = new JavaScriptSerializer();
            Object jsonContent = serializer.Deserialize<Object>(jsonString);

            return jsonContent;
        }

        /// <summary>
        /// Get Json string returned from the Web Service
        /// </summary>
        /// <param name="country">Country name</param>
        /// <param name="city">City name</param>
        /// <returns></returns>
        public string GetWeatherJson(string countryCode, string city)
        {
            try
            {
              
                string serviceUrl = "http://api.openweathermap.org/data/2.5/weather?q={" + city + "," + countryCode + "}&APPID=db285d1488774ddccf11868ca84c30d5&mode=json";
                WebClient client = new WebClient();
                string content = client.DownloadString(serviceUrl);

                return content;
            }catch(Exception e)
            {
                throw new Exception("There is a problem to connect the weather web service");
            }
        }

    }
}
