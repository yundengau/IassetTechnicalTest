using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;

namespace IassetTechnicalTest.BLL.Tests
{
    [TestClass]
    public class WeatherServicesTest
    {
        [TestMethod]
        public void GetCityWeather_ReceiveCityNotFount()
        {
            Exception expectedExcetpion = null;

            WeatherServices weatherService = new WeatherServices();
            try
            {
                object jsonObject = weatherService.GetCityWeather("blabla", "blabla");
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }


            Assert.IsNotNull(expectedExcetpion);
            Assert.AreEqual("There is a problem to connect the weather web service", expectedExcetpion.Message);


        }

        [TestMethod]
        public void GetWeatherJson_ReceiveCityNotFount()
        {
            Exception expectedExcetpion = null;

            WeatherServices weatherService = new WeatherServices();
            try
            {
                object jsonObject = weatherService.GetWeatherJson("blabla", "blabla");
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }


            Assert.IsNotNull(expectedExcetpion);
            Assert.AreEqual("There is a problem to connect the weather web service", expectedExcetpion.Message);
        }

        [TestMethod]
        public void GetWeatherJson_ReturnSydneyWeatherJsonString()
        {
            WeatherServices weatherService = new WeatherServices();
           
            string jsonObject = weatherService.GetWeatherJson("AU", "Sydney");

            Assert.IsNotNull(jsonObject);

        }
    }
}
