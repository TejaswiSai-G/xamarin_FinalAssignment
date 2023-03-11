using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace FoodiesApp
{
    public class HttpServices : IHttpServices
    {
        private static HttpServices _ServiceClientInstance;
        public static HttpServices ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new HttpServices();
                return _ServiceClientInstance;
            }
        }

        private JsonSerializer _serializer = new JsonSerializer();
        private HttpClient client;

        public HttpServices()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://xamfoodiesapi.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<User> AuthenticateUserAsync(Login login)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("Login", content);
                response.EnsureSuccessStatusCode();
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsoncontent = _serializer.Deserialize<User>(json);
                    return jsoncontent;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            try
            {
                var responseContent = await client.GetStringAsync("api/Restaurants");
                var response = JsonConvert.DeserializeObject<List<Restaurant>>(responseContent);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Restaurant> PostRestaurantAsync(string displayName, string address, int priceForTwo, int adminId)
        {
            try
            {
                Restaurant resturantModel = new Restaurant()
                {
                    displayName = displayName,
                    address = address,
                    priceForTwo = priceForTwo,
                    adminId = adminId
                };
                var content = new StringContent(JsonConvert.SerializeObject(resturantModel), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Restaurants", content);
                response.EnsureSuccessStatusCode();
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsoncontent = _serializer.Deserialize<Restaurant>(json);
                    return jsoncontent;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Restaurant> PutRestaurantAsync(Restaurant restaurant)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(restaurant), Encoding.UTF8, "application/json");
                var response = await client.PutAsync("api/Restaurants", content);
                response.EnsureSuccessStatusCode();
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsoncontent = _serializer.Deserialize<Restaurant>(json);
                    return jsoncontent;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"api/Restaurants/{id}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

