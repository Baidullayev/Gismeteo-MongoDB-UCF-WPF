using AngleSharp;
using AngleSharp.Common;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;

using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gisparser
{
    class Program
    {
        static string homeUrl = "https://www.gismeteo.kz";
        static IConfiguration config = Configuration.Default;
        static IBrowsingContext context = BrowsingContext.New(config);
        static async Task Main(string[] args)
        {
            string source = await GetSourceByPage(homeUrl);
            List<City> citiesList = await GetCities(source);
            MongoContext db = new MongoContext("gismeteo");

            foreach (City city in citiesList)
            {
                Weather weather = await GetWeather(city);
                city.Weather = weather;
                // Record on db       
                db.UpsertRecord("Cities", city.Url, city);
                Console.WriteLine(city.Name + "->" + city.Url + "->" + city.Weather.Status + city.Weather.Temperature);
            }
            
            Console.ReadKey();           
        }

        
        public static async Task<string> GetSourceByPage(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responce = await client.GetAsync(url);
            string source = default;
            if (responce != null && responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                source = await responce.Content.ReadAsStringAsync(); //Помещаем код страницы в переменную.
            }

            return source;
        }

        public static async Task<List<City>> GetCities(string source)
        {
            var document = await context.OpenAsync(req => req.Content(source));
            var linqsList = document.QuerySelectorAll("#noscript a");           
            List<City> citiesList = new List<City>();

            foreach (var item in linqsList)
            {
                string name = item.Attributes[2].Value;
                string url = item.Attributes[0].Value;
                citiesList.Add(new City(name, url));               
            }
            return citiesList;
        }

        public static async Task<Weather> GetWeather(City city)
        {
            string urlForTomorrow = homeUrl + city.Url + "tomorrow";
            string source = await GetSourceByPage(urlForTomorrow);

            var document = await context.OpenAsync(req => req.Content(source));
            var temperature = document.All.Where(item => item.ClassName == "unit unit_temperature_c").GetItemByIndex(3).Text();            
            var status = document.QuerySelectorAll("div").Where(x => x.ClassName == ("tab  tooltip")).FirstOrDefault().Attributes[1].Value;

            Weather weather = new Weather(temperature, status);
            return weather;
        }
    }
}
