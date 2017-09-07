using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IassetTechnicalTest;
using IassetTechnicalTest.Controllers;
using Moq;
using IassetTechnicalTest.IBLL;
using System.Dynamic;
using System.Reflection;

namespace IassetTechnicalTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestHomeView()
        {
            Mock<IWeatherServices> mockWeatherService = new Moq.Mock<IWeatherServices>();
            Mock<ICountryCityServices> mockCountryCityService = new Moq.Mock<ICountryCityServices>();
            var controller = new HomeController(mockWeatherService.Object,mockCountryCityService.Object);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void TestGetCountryCity()
        {
            Mock<IWeatherServices> mockWeatherService = new Moq.Mock<IWeatherServices>();
            Mock<ICountryCityServices> mockCountryCityService = new Moq.Mock<ICountryCityServices>();
            var controller = new HomeController(mockWeatherService.Object, mockCountryCityService.Object);

            var result = controller.GetCountryCity("Australia");
            dynamic obj = new JsonResultDynamicWrapper(result);
            Assert.AreEqual(true, obj.success);

        }

        public class JsonResultDynamicWrapper : DynamicObject
        {
            private readonly object _resultObject;

            public JsonResultDynamicWrapper( JsonResult resultObject)
            {
                if (resultObject == null) throw new ArgumentNullException(nameof(resultObject));
                _resultObject = resultObject.Data;
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                if (string.IsNullOrEmpty(binder.Name))
                {
                    result = null;
                    return false;
                }

                PropertyInfo property = _resultObject.GetType().GetProperty(binder.Name);

                if (property == null)
                {
                    result = null;
                    return false;
                }

                result = property.GetValue(_resultObject, null);
                return true;
            }
        }
    }
}
