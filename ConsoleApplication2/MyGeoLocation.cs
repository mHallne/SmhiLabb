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
    public class MyLocationRetriver
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }

        public MyLocationRetriver()
        {
            try
            {
                var request = WebRequest.Create(new Uri("http://www.telize.com/geoip")) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Check that response is ok
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                                "Server error (HTTP {0}: {1}).",
                                response.StatusCode,
                                response.StatusDescription));

                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Location));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    Location jsonResponse = objResponse as Location;

                    Latitude = jsonResponse.Latitude;
                    Longitude = jsonResponse.Longitude;
                    City = jsonResponse.City;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal void GetLocation(ref ObjectLocation loc)
        {
            loc.Latitude = Latitude;
            loc.Longitude = Longitude;
            loc.City = City;
        }
    }
}
