using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GismeteoService
{
    [DataContract]
    public class City
    {

        [DataMember]
        public string Name { get; set; }

        [BsonId]
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public Weather Weather { get; set; }       
        
        public City(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
