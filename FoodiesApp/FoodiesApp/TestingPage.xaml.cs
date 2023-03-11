using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FoodiesApp
{
    public partial class TestingPage : ContentPage
    {
        private const string URL = "https://xamfoodiesapi.azurewebsites.net/api/Restaurants";
        private HttpClient _httpclient = new HttpClient();
        private ObservableCollection<Restaurant> _restaurants;
        //public HttpService _httpService;
        public TestingPage()
        {
            InitializeComponent();
            //BindingContext = _httpService; 
        }

        async override protected void OnAppearing()
        {
            await ExcuteGetRestaurants();
            base.OnAppearing();
        }

        async Task ExcuteGetRestaurants()
        {
            try
            {
                var responseContent = await _httpclient.GetStringAsync(URL);
                var response = JsonConvert.DeserializeObject<List<Restaurant>>(responseContent);
                _restaurants = new ObservableCollection<Restaurant>(response);
                listView.ItemsSource = _restaurants;
            }
            catch(Exception ex)
            {
                Console.WriteLine("**************->" + ex.Message);
            }
        }
    }
}
