using System;
using System.Collections.Generic;
using System.Linq;
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
using RestSharp;
using Newtonsoft.Json;




namespace ClarissaJoyFlores.WeatherPanel2.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_GetWeather_Click(object sender, RoutedEventArgs e)
        {
            var client = new RestClient("https://api.darksky.net/forecast/64ee9d4e589bb2cb3788596fd477b0f7/14.8781,120.4546");

            var request = new RestRequest("", Method.GET);

            IRestResponse response = client.Execute(request);

            var content = response.Content;

            var area = JsonConvert.DeserializeObject<WeatherArea>(content);

            lblSummary.Content = DateTime.Now.ToString("hh:mm tt");
            lblSummary.Content = area.Currently.Summary;
            lblIcon.Content = area.Currently.Icon;
            lblTemperature.Content = area.Currently.Temperature;
            lblHumidity.Content = area.Currently.Humidity;

            lblSummary.Content = DateTime.Now.ToString("hh:mm tt");

            BitmapImage WeatherIcon = new BitmapImage();
            WeatherIcon.BeginInit();
            WeatherIcon.UriSource = new Uri("C:\\Users\\VGD PC 9\\Desktop\\weather.png");
            WeatherIcon.EndInit();
            imgWeather.Source = WeatherIcon;

        }
    }
}
