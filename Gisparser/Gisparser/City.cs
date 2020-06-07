using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisparser
{
    class City
    {
               
        public string Name { get; set; }
        [BsonId]
        public string Url { get; set; }
        public Weather Weather { get; set; }
        public City(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
