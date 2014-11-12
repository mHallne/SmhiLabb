//﻿using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System.Net;
//using System.Reflection;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Json;
//using System.Xml;


//class TestSmhi
//{
//    public static string CreateRequest()
//    {
//        double latitude = 58.34;
//        double longitude = 16.00;

//        bool coordOk = ValidCoord(latitude, longitude);

//        if (!coordOk)
//            return "";

//        string UrlRequest = "http://opendata-download-metfcst.smhi.se/api/category/pmp1.5g/version/1/geopoint/lat/" + 
//                            latitude + 
//                            "/lon/" + 
//                            longitude + 
//                            "/data.json";

//        return (UrlRequest);
//    }

//    // Edge coordinates for map
//    private const double ALATN = 70.75;
//    private const double ALATS = 52.50;
//    private const double ALONW = 2.25;
//    private const double ALONE = 38.00;

//    public static bool ValidCoord(double inLat, double inLon)
//    {
//        if (inLat < ALATS || inLat > ALATN)
//            return false;
//        if (inLon < ALONW || inLon > ALONE)
//            return false;

//        return true;
//    }


//    static void Main()
//    {
//        try
//        {
//            // Init request and receive JSON response
//            HttpWebRequest request = WebRequest.Create(TestSmhi.CreateRequest()) as HttpWebRequest;
//            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
//            {

//                // Check that response is ok
//                if (response.StatusCode != HttpStatusCode.OK)
//                    throw new Exception(String.Format(
//                            "Server error (HTTP {0}: {1}).",
//                            response.StatusCode,
//                            response.StatusDescription));
//                //[Data]
//                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Forecast));
//                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
//                Forecast jsonResponse = objResponse as Forecast;

//            }

//        }
//        catch (Exception e)
//        {
//            Console.WriteLine(e.Message);
//        }
//    }
//}

//[DataContract]
//public class Forecast
//{
//    [DataMember(Name = "lat")]
//    public string Lat { get; set; }
//    [DataMember(Name = "lon")]
//    public string Lon { get; set; }
//    [DataMember(Name = "referenceTime")]
//    public string ReferenceTime { get; set; }
//    [DataMember(Name = "timeseries")]
//    public TimeSerie[] TimeSeries { get; set; }
//}

//[DataContract]
// public class TimeSerie
// {
//    [DataMember(Name = "validTime")]
//    public string ValidTime { get; set; }
//    [DataMember(Name = "t")]
//    public string T { get; set; }
//    [DataMember(Name = "msl")]
//    public string Msl { get; set; }
//    [DataMember(Name = "vis")]
//    public string Vis { get; set; }
//    [DataMember(Name = "wd")]
//    public string Wd { get; set; }
//    [DataMember(Name = "ws")]
//    public string Ws { get; set; }
//    [DataMember(Name = "r")]
//    public string R { get; set; }
//    [DataMember(Name = "tstm")]
//    public string Tstm { get; set; }
//    [DataMember(Name = "tcc")]
//    public string Tcc { get; set; }
//    [DataMember(Name = "lcc")]
//    public string Lcc { get; set; }
//    [DataMember(Name = "mcc")]
//    public string Mcc { get; set; }
//    [DataMember(Name = "hcc")]
//    public string Hcc { get; set; }
//    [DataMember(Name = "gust")]
//    public string Gust { get; set; }
//    [DataMember(Name = "pis")]
//    public string Pis { get; set; }
//    [DataMember(Name = "pit")]
//    public string Pit { get; set; }
//    [DataMember(Name = "pcat")]
//    public string Pcat { get; set; }
// }

