using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GismeteoService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IGismeteoService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IGismeteoService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",UriTemplate = "/GetAllCity",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        List<City> GetAllCity();


        [WebInvoke(Method = "GET", UriTemplate = "/GetCityById/{id}",
             BodyStyle = WebMessageBodyStyle.Wrapped,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json)]
        City GetCityById(string id);

    }
}
