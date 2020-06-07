using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisparser
{
    class MongoContext
    {
        public IMongoDatabase db;
        public MongoContext(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public List<T> GetAllCity<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();            
        }
        public T GetById<T>(string table, string id)
        {
            id = "/" + id + "/";
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);
            return collection.Find(filter).First();
        }
    }
}
