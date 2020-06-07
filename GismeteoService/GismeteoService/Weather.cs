using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GismeteoService
{
    [DataContract]
    public class Weather
    {
        [DataMember]
        public string Temperature { get; set; }
        [DataMember]
        public string Status { get; set; }
        
        public Weather(string temperature, string status)
        {
            Temperature = temperature;
            Status = status;
        }
    }
}
