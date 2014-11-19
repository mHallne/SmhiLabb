using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastLabb
{
    public class SmhiWeatherProvider : IWeatherForecastProvider
    {
        // Edge coordinates for area that a weather forecast is provided for
        internal double ALATN { get; private set; }
        internal double ALATS { get; private set; }
        internal double ALONW { get; private set; }
        internal double ALONE { get; private set; }

        public SmhiWeatherProvider()
        {
            ALATN = 70.75;
            ALATS = 52.50;
            ALONW = 2.25;
            ALONE = 38.00;
        }

        private bool ValidateCoordinates(double inLat, double inLon)
        {
            if (inLat < ALATS || inLat > ALATN)
                return false;
            if (inLon < ALONW || inLon > ALONE)
                return false;

            return true;
        }

        private string CreateRequestString(double lat, double lng)
        {
            return string.Format(new CultureInfo("en-US"), 
                "http://opendata-download-metfcst.smhi.se/api/category/pmp1.5g/" +
                "version/1/geopoint/lat/{0}/lon/{1}/data.json", lat, lng);
        }

        public Forecast GetWeatherForecast(ObjectLocation Location)
        {
            if (!ValidateCoordinates(Location.Latitude, Location.Longitude))
                return null;

            string requestString = CreateRequestString(Location.Latitude, Location.Longitude);

            Forecast jsonResponse = null;

            try
            {
                // Init request and receive JSON response
                var request = WebRequest.Create(requestString) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Check that response is ok
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                                "Server error (HTTP {0}: {1}).",
                                response.StatusCode,
                                response.StatusDescription));
                    //[Data]
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Forecast));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    jsonResponse = objResponse as Forecast;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }

            return jsonResponse;
        }

    }
}
