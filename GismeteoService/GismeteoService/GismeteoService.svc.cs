using Gisparser;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.UI.WebControls;

namespace GismeteoService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "GismeteoService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы GismeteoService.svc или GismeteoService.svc.cs в обозревателе решений и начните отладку.
    public class GismeteoService : IGismeteoService
    {

        
        public List<City> GetAllCity()
        {
            MongoContext db = new MongoContext("gismeteo");
            string table = "Cities";
            List<City> cityList = db.GetAllCity<City>(table);
            return cityList;
        }

        public City GetCityById(string id)
        {
            MongoContext db = new MongoContext("gismeteo");
            string table = "Cities";
            City city = db.GetById<City>(table, id);

            Console.WriteLine(city.Name + " " + city.Url);
            return city;
        }
    }
}
