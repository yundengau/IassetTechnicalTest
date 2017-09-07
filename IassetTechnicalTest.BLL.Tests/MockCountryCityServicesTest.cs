using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IassetTechnicalTest.Domain;

namespace IassetTechnicalTest.BLL.Tests
{
    [TestClass]
    public class MockCountryCityServicesTest
    {
        [TestMethod]
        public void GetMockCountryList_ReturnCountryList()
        {
            MockCountryCityServices mockCountryService = new MockCountryCityServices();

            List<Country> countries=mockCountryService.GetMockCountryList();

            Assert.IsNotNull(countries);

            //Testing the simple mock data function, It is possibly changed regularly in the future, so only ensure it is not empty.
            Assert.IsTrue(countries.Count > 0);

        }

        [TestMethod]
        public void GetMockCountryList_ReturnCityList()
        {
            
            MockCountryCityServices mockCountryService = new MockCountryCityServices();

            List<City> cities = mockCountryService.GetMockCityList();

            Assert.IsNotNull(cities);

            //Testing the simple mock data function, It is possibly changed regularly in the future, so only ensure it is not empty.
            Assert.IsTrue(cities.Count > 0);
        }

        [TestMethod]
        public void GetMockCountryList_ReturnCountryCityList()
        {
            MockCountryCityServices mockCountryService = new MockCountryCityServices();

            List<City> cities_LowerCaseSearch = mockCountryService.GetCountryCities("australia");
            List<City> cities_UpperCaseSearch = mockCountryService.GetCountryCities("Australia");

            Assert.IsNotNull(cities_LowerCaseSearch);
            Assert.IsNotNull(cities_UpperCaseSearch);

            //Testing the simple mock data function, It is possibly changed regularly in the future, so only ensure it is not empty.
            Assert.IsTrue(cities_LowerCaseSearch.Count > 0);
            Assert.IsTrue(cities_UpperCaseSearch.Count > 0);
        }

        [TestMethod]
        public void GetMockCountryList_ReturnNullOrCityList()
        {
            MockCountryCityServices mockCountryService = new MockCountryCityServices();

            List<City> emptyCityList = mockCountryService.GetCountryCities("blabla");
            List<City> cities = mockCountryService.GetCountryCities("Australia");

            Assert.IsNull(emptyCityList);
            Assert.IsTrue(cities.Count > 0);
           
        }



    }
}
