
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GismeteoClient
{
    
    public class City
    {
               
        public string Name { get; set; }
      

        public string Url { get; set; }
       
        public Weather Weather { get; set; }       
        
        public City(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
