using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FoodiesApp
{
    public partial class RestaurantPage : ContentPage
    {
        public List<FoodItems> _foodItems;
        public Restaurant rstData;
        public RestaurantPage(Restaurant restaurant, bool isAdmin)
        {
            InitializeComponent();
            BindingContext = this;

            rstData = restaurant;
            isAdminLayout.IsVisible = isAdmin;

            Name.Text = restaurant.displayName;
            Address.Text = restaurant.address;

            _foodItems = new List<FoodItems>
            {
                new FoodItems{foodName="Briyani",price=3000},
                new FoodItems{foodName="Veg Thali",price=2000},
                new FoodItems{foodName="Ice Cream",price=1000}
            };
            listView.ItemsSource = _foodItems;
        }

        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (FoodItems)e.Item;
            var response = await DisplayAlert("Food", "Would you like to order "+selectedItem.foodName+" of Price "+selectedItem.price, "YES", "NO");
            if (response)
            {
                await Navigation.PushAsync(new CheckOutPage(selectedItem));
            }
        }

        public async void EditRestaurant(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdatePage(rstData));
        }

        public async void DeleteRestaurant(object sender, EventArgs e)
        {
            var content = await HttpServices.ServiceClientInstance.DeleteRestaurantAsync(rstData.id);
            if(content)
            {
                await DisplayAlert("Message", "Deleted", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Message", "Server Error, Try Again!", "OK");
            }
        }
    }
}
