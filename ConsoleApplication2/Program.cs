﻿using WeatherForecastLabb;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;

public struct ObjectLocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string City { get; set; }
}

class TestSmhi
{
    static void Main()
    {
        // Determine geographic location for this device
        MyLocationRetriver myLoc = new MyLocationRetriver();
        ObjectLocation loc = new ObjectLocation();
        myLoc.GetLocation(ref loc);

        IWeatherForecastProvider forecast = new SmhiWeatherProvider() as IWeatherForecastProvider;
        Forecast weatherForecast = forecast.GetWeatherForecast(loc);

        PrintForecast(loc, weatherForecast);
    }

    private static void PrintForecast(ObjectLocation loc, Forecast weatherForecast)
    {
        try
        {
            DateTime date = DateTime.Today;
            Console.WriteLine(String.Format(
                "Prognos för {0} {1} {2}",
                loc.City,
                date.ToString("dddd", new CultureInfo("sv-SE")),
                date.ToString("D", new CultureInfo("sv-SE"))
                ));

            int loopcount = 0;
            foreach (TimeSerie ts in weatherForecast.TimeSeries)
            {
                DateTime forecastTime = Convert.ToDateTime(ts.ValidTime);
                Console.WriteLine(String.Format(
                    "{0} {1}\nVind: {2} m/s, Moln: {3}, Väder: {4}\n" +
                    "Temperatur: {5}°C, Luftfuktighet: {6}%\n" +
                    "Nederbörd: {7} mm/h, Vindriktning: {8}°",
                    forecastTime.ToString("dddd", new CultureInfo("sv-SE")),
                    forecastTime.ToString("HH:mm", new CultureInfo("sv-SE")),
                    ts.Ws, ts.Tcc, ts.Pcat,
                    ts.T, ts.R,
                    ts.Pit, ts.Wd
                ));
                Console.WriteLine();

                // Dont show so many forecasts... 
                if (loopcount++ >= 3)
                    break;
            }

            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
        }
    }
}



