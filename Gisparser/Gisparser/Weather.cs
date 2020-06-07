using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisparser
{
    class Weather
    {
        public string Temperature { get; set; }
        public string Status { get; set; }
        public Weather(string temperature, string status)
        {
            Temperature = temperature;
            Status = status;
        }
    }
}
