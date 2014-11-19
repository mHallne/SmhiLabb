using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherForecastLabb;

namespace WeatherForecastLabb_NUnit
{
    [TestFixture]
    public class Class1
    {
        MyLocationRetriver myLoc;
        IWeatherForecastProvider forecastObject;
        ObjectLocation loc;

        [SetUp]
        public void Init()
        {
            myLoc = new MyLocationRetriver();
            loc = new ObjectLocation();
            forecastObject = new SmhiWeatherProvider() as IWeatherForecastProvider;
        }

        [Test]
        public void LocationTest()
        {
            myLoc.GetLocation(ref loc);
            Assert.AreNotEqual(0d, loc.Latitude);
            Assert.AreNotEqual(0d, loc.Longitude);

        }

        [Test]
        public void WeatherForecastTest()
        {
            Forecast weatherForecast = forecastObject.GetWeatherForecast(loc);
            Assert.NotNull(weatherForecast);
        }




        //}
    }
}
