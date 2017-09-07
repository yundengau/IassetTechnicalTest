using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IassetTechnicalTest.IBLL;
using IassetTechnicalTest.Domain;

namespace IassetTechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        private IWeatherServices _weatherServices;
        private ICountryCityServices _countryCityServices;

        [Ninject.Inject]
        public HomeController(IWeatherServices weatherServices, ICountryCityServices countryCityServices)
        {
            this._weatherServices = weatherServices;
            this._countryCityServices = countryCityServices;
        }

        public ActionResult Index()
        {
           
            return View("Index");
        }


        public JsonResult GetCountryCity(string country)
        {
            IEnumerable<City> cities = _countryCityServices.GetCountryCities(country);
            if (cities != null)
            {
                return Json(new { success = true, cities = _countryCityServices.GetCountryCities(country) }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "We have not surport this country's weather forcase yet." }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetWeather(string city, string countryCode)
        {
            try
            {
                return Json(new { success = true, weather = _weatherServices.GetCityWeather(countryCode, city) }, JsonRequestBehavior.AllowGet);
            }catch(Exception e)
            {
                return Json(new { success=false, message=e.Message}, JsonRequestBehavior.AllowGet);
            }


        }

       
    }
}