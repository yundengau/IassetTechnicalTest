using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IassetTechnicalTest.IBLL;
using IassetTechnicalTestAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using Moq;
using IassetTechnicalTest.Domain;
using System.Collections.Generic;

namespace IassetTechnicalTestAPI.Tests.Controllers
{
    [TestClass]
    public class CountryCityControllerTest
    {
        [TestMethod]
        public void GetCountryCity_ReturnHttpResponseMessageWith204Status()
        {
            //Arrange
            var mockCountryCityServices = new Mock<ICountryCityServices>();
            mockCountryCityServices.Setup(e => e.GetCountryCities(It.IsAny<string>())).Returns((List<City>)null);
            CountryCityController countryCityController = new CountryCityController(mockCountryCityServices.Object);
            countryCityController.Request = new HttpRequestMessage();
            countryCityController.Configuration = new HttpConfiguration();
            //Act
            HttpResponseMessage message = countryCityController.GetCountryCity("blabla");
            //Assert
            Assert.IsNotNull(message);
            Assert.AreEqual(204, (int)message.StatusCode);
        }

        public void GetCountryCity_ReturnHttpResponseMessageWithCorrectData()
        {
            //Arrange

            List<City> cities = new List<City>();
            
            cities.Add(new City() { Name = "London", CountryCode = "UK" });
            cities.Add(new City() { Name = "Liverpool", CountryCode = "UK" });
            cities.Add(new City() { Name = "Birmingham", CountryCode = "UK" });

            var mockCountryCityServices = new Mock<ICountryCityServices>();
            mockCountryCityServices.Setup(e => e.GetCountryCities(It.IsAny<string>())).Returns(cities);
            
            CountryCityController countryCityController = new CountryCityController(mockCountryCityServices.Object);
            countryCityController.Request = new HttpRequestMessage();
            countryCityController.Configuration = new HttpConfiguration();
            //Act
            HttpResponseMessage message = countryCityController.GetCountryCity("blabla");
            //Assert
            Assert.IsNotNull(message);
            Assert.AreEqual(200, (int)message.StatusCode);
            Assert.IsNotNull(message.Content);
        }
    }
}
