using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GismeteoClient
{

    public class Weather
    {       
        public string Temperature { get; set; }        
        public string Status { get; set; }        
        public Weather(string temperature, string status)
        {
            Temperature = temperature;
            Status = status;
        }

        public override string ToString()
        {
            return this.Temperature + " " + this.Status;
        }
    }
}
