using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodiesApp
{
    public interface IHttpServices
    {
        Task<User> AuthenticateUserAsync(Login login);

        Task<List<Restaurant>> GetRestaurantsAsync();
        Task<Restaurant> PostRestaurantAsync(string displayName, string address, int priceForTwo, int adminId);
        Task<Restaurant> PutRestaurantAsync(Restaurant restaurant);
        Task<bool> DeleteRestaurantAsync(int id);
    }
}
