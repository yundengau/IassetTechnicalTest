using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IassetTechnicalTest.IBLL;

namespace IassetTechnicalTestAPI.Controllers
{
    public class WeatherController : ApiController
    {
        private IWeatherServices _weatherServices;
     

        [Ninject.Inject]
        public WeatherController(IWeatherServices weatherServices)
        {
            this._weatherServices = weatherServices;
        }

        /// <summary>
        /// Get City weather info
        /// </summary>
        /// <param name="city">City name</param>
        /// <param name="countryCode">Country's standard code</param>
        /// <returns>Weather info</returns>
        [HttpGet]
        public HttpResponseMessage GetWeather(string city, string countryCode)
        {
            try
            {
                Object weather = _weatherServices.GetCityWeather(countryCode, city);
                var message = Request.CreateResponse(HttpStatusCode.OK, weather);
                return message;
            }
            catch (Exception e)
            {
                var message = Request.CreateResponse(HttpStatusCode.NoContent);
                return message;
            }


        }

    }
}
