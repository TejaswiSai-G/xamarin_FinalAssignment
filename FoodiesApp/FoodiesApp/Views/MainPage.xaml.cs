using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace FoodiesApp
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Restaurant> _restaurants;
        public bool IsAdmin;
        public int UserId;
        public MainPage(bool isAdmin, int Userid)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            if (Device.RuntimePlatform == Device.iOS)
            {
                mainLayout.Margin = new Thickness(0, 50, 0, 0);
            }

            IsAdmin = isAdmin;
            UserId = Userid;
            isAdminLayout.IsVisible = isAdmin;
        }

        async override protected void OnAppearing()
        {
            var content = await HttpServices.ServiceClientInstance.GetRestaurantsAsync();
            if (content != null)
            { 
                _restaurants = new ObservableCollection<Restaurant>(content);
                listView.ItemsSource = _restaurants;
            }
            else
            {
                await DisplayAlert("Message", "No Restaurants available in your area.Try Again!", "OK");
            }
            base.OnAppearing();
        }

        public IEnumerable<Restaurant> GetSearches(string searchText = null)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return _restaurants;
            }
            else
            {
                return _restaurants.Where(x => x.displayName.Contains(searchText));
            }
        }

        public void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetSearches(e.NewTextValue);
        }

        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (Restaurant)e.Item;
            await Navigation.PushAsync(new RestaurantPage(selectedItem,IsAdmin));
        }

        public async void AddRestaurant(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(UserId));
        }
    }
}
