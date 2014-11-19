using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastLabb
{
    [DataContract]
    public class Forecast
    {
        [DataMember(Name = "lat")]
        public string Lat { get; set; }
        [DataMember(Name = "lon")]
        public string Lon { get; set; }
        [DataMember(Name = "referenceTime")]
        public string ReferenceTime { get; set; }
        [DataMember(Name = "timeseries")]
        public TimeSerie[] TimeSeries { get; set; }
    }

    [DataContract]
    public class TimeSerie
    {
        [DataMember(Name = "validTime")]
        public string ValidTime { get; set; }
        // Lufttemperatur på 2 meters höjd över marken [C]
        [DataMember(Name = "t")]
        public string T { get; set; }
        [DataMember(Name = "msl")]
        public string Msl { get; set; }
        [DataMember(Name = "vis")]
        public string Vis { get; set; }
        // Vindriktning [grader]
        [DataMember(Name = "wd")]
        public string Wd { get; set; }
        // Vindhastiget [m/s]
        [DataMember(Name = "ws")]
        public string Ws { get; set; }
        // Luftfuktighet [%]
        [DataMember(Name = "r")]
        public string R { get; set; }
        // Sannolikhet för åska [%]
        [DataMember(Name = "tstm")]
        public string Tstm { get; set; }
        // tcc_mean är totala molnigheten, alltså hur stor del av himlen som täcks av moln.
        [DataMember(Name = "tcc")]
        public string Tcc { get; set; }
        [DataMember(Name = "lcc")]
        public string Lcc { get; set; }
        [DataMember(Name = "mcc")]
        public string Mcc { get; set; }
        [DataMember(Name = "hcc")]
        public string Hcc { get; set; }
        [DataMember(Name = "gust")]
        public string Gust { get; set; }
        // Precipitation intensity snow [mm/h]
        [DataMember(Name = "pis")]
        public string Pis { get; set; }
        // Precipitation intensity total [mm/h]
        [DataMember(Name = "pit")]
        public string Pit { get; set; }
        // Nederbördskategori 
        [DataMember(Name = "pcat")]
        public string Pcat { get; set; }
    }

}
