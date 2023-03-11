using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace FoodiesApp
{
    public partial class MapPage : ContentPage
    {
        private readonly Geocoder geocoder = new Geocoder();
        RegisterPageModel registerPageModel = new RegisterPageModel();
        public event EventHandler<string> mapAddress;
        public MapPage()
        {
            BindingContext = registerPageModel;
            InitializeComponent();
        }

        async public void Map_MapClicked(object sender, MapClickedEventArgs e)
        {
            var addressList = await geocoder.GetAddressesForPositionAsync(e.Position);
            var address = addressList.FirstOrDefault();

            var response = await DisplayAlert("Adress", address, "OK","Try Again");
            if (response)
            {
                mapAddress?.Invoke(this,address);
                await Navigation.PopAsync();
            }
            //await DisplayAlert("Coordinates", $"Latitude:{latitude} and Longitude:{longitude}", "OK");
        }
    }
}
