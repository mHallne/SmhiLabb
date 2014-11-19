using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastLabb
{
    [DataContract]
    public class Location
    {
        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }
        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }
        [DataMember(Name = "asn")]
        public string Asn { get; set; }
        [DataMember(Name = "offset")]
        public string Offset { get; set; }
        [DataMember(Name = "ip")]
        public string Ip { get; set; }
        [DataMember(Name = "area_code")]
        public string AreaCode { get; set; }
        [DataMember(Name = "continent_code")]
        public string ContinentCode { get; set; }
        [DataMember(Name = "dma_code")]
        public string DmaCode { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "timezone")]
        public string Timezone { get; set; }
        [DataMember(Name = "region")]
        public string Region { get; set; }
        [DataMember(Name = "country_code")]
        public string CountryCode { get; set; }
        [DataMember(Name = "isp")]
        public string Isp { get; set; }
        [DataMember(Name = "country")]
        public string Country { get; set; }
        [DataMember(Name = "country_code3")]
        public string CountryCode3 { get; set; }
        [DataMember(Name = "region_code")]
        public string RegionCode { get; set; }
    }
}
