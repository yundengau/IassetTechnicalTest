using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IassetTechnicalTest.IBLL;
using IassetTechnicalTestAPI.Controllers;
using Moq;
using System.Net.Http;
using System.Web.Http;

namespace IassetTechnicalTestAPI.Tests.Controllers
{
    /// <summary>
    /// Summary description for WeatherControllerTest
    /// </summary>
    [TestClass]
    public class WeatherControllerTest
    {
       
        [TestMethod]
        public void GetWeather_ReturnReturnHttpResponseMessageWith204Status()
        {
            //Arrange
            var mockWeatherServices = new Mock<IWeatherServices>();
            mockWeatherServices.Setup(e => e.GetCityWeather(It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());
            WeatherController weatherController = new WeatherController(mockWeatherServices.Object);
            weatherController.Request = new HttpRequestMessage();
            weatherController.Configuration = new HttpConfiguration();
            //Act
            HttpResponseMessage message=weatherController.GetWeather("blabla", "blabla");
            //Assert
            Assert.IsNotNull(message);
            Assert.AreEqual(204, (int)message.StatusCode);

        }

        [TestMethod]
        public void GetWeather_ReturnReturnHttpResponseMessageWithCorrectData()
        {
            //Arrange
            var mockWeatherServices = new Mock<IWeatherServices>();
            Object returnObj = new { name = "testing object" };
            mockWeatherServices.Setup(e => e.GetCityWeather(It.IsAny<string>(), It.IsAny<string>())).Returns(returnObj);
            WeatherController weatherController = new WeatherController(mockWeatherServices.Object);
            weatherController.Request = new HttpRequestMessage();
            weatherController.Configuration = new HttpConfiguration();
            //Act
            HttpResponseMessage message = weatherController.GetWeather("blabla", "blabla");
            //Assert
            Assert.IsNotNull(message);
            Assert.AreEqual(200, (int)message.StatusCode);
            Assert.IsNotNull(message.Content);
        }
    }
}
