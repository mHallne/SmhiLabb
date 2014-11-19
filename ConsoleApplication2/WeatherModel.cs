using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastLabb
{
    class WeatherModel
    {
        enum PrecipitationCategory {
            [Description("Uppehåll")]
            No = 0,
            [Description("Snö")]
            Snow,
            [Description("Snönblandat regn")]
            Sleet,
            [Description("Regn")]
            Rain, 
            [Description("Duggregn")]
            Drizzle,
            [Description("Underkylt regn")]
            FreezingRain, 
            [Description("Underkylt duggregn")]
            FreezingDrizzle
        }

        enum CloudType {
            [Description("Klart, molnfritt")]
            ClearSky,
            [Description("Nästan klart, mestadels klart")]
            OneOkta,
            [Description("Klart till halvklart")]
            TwoOktas,
            [Description("Halvklart")]
            ThreeOktas,
            [Description("Omkring halvklart")]
            FourOktas,
            [Description("Mycket moln")]
            FiveOktas,
            [Description("Halvklart till mulet")]
            SixOktas,
            [Description("Klart till halvklart")]
            SevenOktas,
            [Description("Mulet")]
            EightOktas
        }
    }
}
