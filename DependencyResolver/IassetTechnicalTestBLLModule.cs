using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IassetTechnicalTest.BLL;
using IassetTechnicalTest.IBLL;

namespace DependencyResolver
{
    public class IassetTechnicalTestBLLModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeatherServices>().To<WeatherServices>();
            Bind<ICountryCityServices>().To<MockCountryCityServices>();


        }
    }
}
