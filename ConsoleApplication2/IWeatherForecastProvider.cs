using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherForecastLabb
{
    interface IWeatherForecastProvider
    {
        Forecast GetWeatherForecast(ObjectLocation Location);
    }
}
