using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodiesApp
{
    public class UpdatePageModel : INotifyPropertyChanged
    {
        public UpdatePageModel()
        {
            UpdateCommand = new Command(() =>
            {
                Update();
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

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("id"));
            }
        }

        private async void Update()
        {
            Restaurant resturant = new Restaurant()
            {
                id = id,
                displayName = displayName,
                address = address,
                priceForTwo = priceForTwo,
                adminId = adminId
            };
            var content = await HttpServices.ServiceClientInstance.PutRestaurantAsync(resturant);
            if (content != null)
            {
                await App.Current.MainPage.DisplayAlert("Update", "Data has been Updated!", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Register Fail", "Plaese Try Again!", "OK");
            }
        }

        public Command UpdateCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
