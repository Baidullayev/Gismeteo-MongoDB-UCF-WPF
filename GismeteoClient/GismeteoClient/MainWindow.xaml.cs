using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GismeteoClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<City> cityList;
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
             GetCityListAsync();           
        }
        public async void GetCityListAsync()
        {
            string url = "http://localhost:49327/GismeteoService.svc/getallcity";
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            using (var response = await client.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var dirtyCityList = JsonConvert.DeserializeObject(content);

                cityList = FillingCityList(dirtyCityList.ToString());

                listBox.Items.Clear();
                foreach(City city in cityList)
                {
                    listBox.Items.Add(city.Name);
                }

            }

        }

        public List<City> FillingCityList(string dirtyCityList)
        {
            if(dirtyCityList != null && dirtyCityList != "")
            {
                int firstInd = dirtyCityList.IndexOf("[");
                dirtyCityList = dirtyCityList.Remove(0, firstInd - 1);
                int secondInd = dirtyCityList.IndexOf("]");
                dirtyCityList = dirtyCityList.Remove(secondInd + 1);
                return  JsonConvert.DeserializeObject<List<City>>(dirtyCityList);
            }
            return null;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                int index = listBox.SelectedIndex;
                string weather = cityList[index].Weather.ToString();
                string cityName = cityList[index].Name;
                MessageBox.Show(cityName + "\n" + weather, "Погода на завтра");
            }
        }
    }
}
