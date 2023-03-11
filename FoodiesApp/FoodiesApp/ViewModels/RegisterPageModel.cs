using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodiesApp
{
    public class RegisterPageModel : INotifyPropertyChanged
    {
        public RegisterPageModel()
        {
            RegisterCommand = new Command(() =>
            {
                Register();
            });
            MapCommand = new Command(() =>
            {
                OpenMap();
            });
        }

        private string _displayName;
        public string displayName
        {
            get { return _displayName; }
            set
            {
                _displayName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("displayName"));
            }
        }

        private string _address;
        public string address
        {
            get { return _address; }
            set
            {
                _address = value;
                PropertyChanged(this, new PropertyChangedEventArgs("address"));
            }
        }

        private int _priceForTwo;
        public int priceForTwo
        {
            get { return _priceForTwo; }
            set
            {
                _priceForTwo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("priceForTwo"));
            }
        }

        private int _adminId;
        public int adminId
        {
            get { return _adminId; }
            set
            {
                _adminId = value;
                PropertyChanged(this, new PropertyChangedEventArgs("adminId"));
            }
        }

        private async void Register()
        {
            if (string.IsNullOrEmpty(displayName) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(priceForTwo.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Alret", "Please fill all the details, Try Again!", "OK"); ;
            }
            else
            {
                var content = await HttpServices.ServiceClientInstance.PostRestaurantAsync(displayName, address, priceForTwo, adminId);
                if (content != null)
                {
                    await App.Current.MainPage.DisplayAlert("Register", "Registered!", "OK");
                    displayName = "";
                    address = "";
                    priceForTwo = 0;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Register Fail", "Plaese Try Again!", "OK");
                }
            }
        }

        private async void OpenMap()
        {
            var page = new MapPage();
            page.mapAddress += Page_mapAddress;
            await App.Current.MainPage.Navigation.PushAsync(page);
        }
        private void Page_mapAddress(object sender, string e)
        {
            address = e;
        }

        public Command RegisterCommand { get; }
        public Command MapCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
