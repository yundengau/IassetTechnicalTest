using IassetTechnicalTest.Domain;
using IassetTechnicalTest.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IassetTechnicalTestAPI.Controllers
{
    public class CountryCityController : ApiController
    {
        private ICountryCityServices _countryCityServices;

        [Ninject.Inject]
        public CountryCityController(ICountryCityServices countryServices)
        {
            this._countryCityServices = countryServices;
        }


        /// <summary>
        /// Get Country City API
        /// </summary>
        /// <param name="country">country name</param>
        /// <returns>City list of a country</returns>
        [HttpGet]
        public HttpResponseMessage GetCountryCity(string country)
        {
            IEnumerable<City> cities = _countryCityServices.GetCountryCities(country);
            if (cities != null)
            {
                var message = Request.CreateResponse(HttpStatusCode.OK, cities.ToList());
                return message;
            }
            else
            {
                var message = Request.CreateResponse(HttpStatusCode.NoContent);
                return message;
            }
        }
    }
}
