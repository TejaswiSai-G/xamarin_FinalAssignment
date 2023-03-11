using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoodiesApp
{
    public class HttpService_test 
    {
        private const string BaseURL = "https://xamfoodiesapi.azurewebsites.net/";
        private HttpClient _httpclient = new HttpClient();
        public async Task<IEnumerable<User>> GetUsers()
        {
            //var response = await _httpclient.GetAsync(URL);
            //response.EnsureSuccessStatusCode();
            //var responseAsString = await response.Content.ReadAsStringAsync();
            //return JsonConvert.DeserializeObject<List<User>>(responseAsString);

            var responseContent = await _httpclient.GetStringAsync(BaseURL);
            var response = JsonConvert.DeserializeObject<List<User>>(responseContent);
            return response;

            //_user = new ObservableCollection<User>(responseList);
            //listView.ItemsSource = _user;
        }

        public async Task AddUser(User user)
        {
            //var insertusers = new User { username = "Tej", displayname = "Tejaswi", email = "Tej@gmail.com", password = "tej123", isAdmin = false, address = "Flat no 302B, Kondapur, Hyderabad" };
            //_user.Insert(1, insertusers);

            var response = JsonConvert.SerializeObject(user);
            await _httpclient.PostAsync(BaseURL, new StringContent(response));
        }

        public async Task<List<Restaurant>> GetRestaurants()
        {
            var URL = BaseURL + "api/Restaurants";
            var responseContent = await _httpclient.GetStringAsync(URL);
            var response = JsonConvert.DeserializeObject<List<Restaurant>>(responseContent);
            return response;
        }

        public async Task<bool> AddRestaurants(Restaurant restaurant)
        {
            if(restaurant.id == 0)
            {
                var response = JsonConvert.SerializeObject(restaurant);
                StringContent content = new StringContent(response, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                string url = "https://xamfoodiesapi.azurewebsites.net/api/Restaurants";
                client.BaseAddress = new Uri(url);
                HttpResponseMessage httpResponse = await client.PostAsync("", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            return await Task.FromResult(false);
        }
    }
}
