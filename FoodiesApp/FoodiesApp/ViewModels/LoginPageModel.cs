using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodiesApp
{
    public class LoginPageModel : INotifyPropertyChanged
    {
        public LoginPageModel()
        {
            LogInCommand = new Command(() =>
            {
                LogIn();
            });
        }

        private string _username;
        public string username
        {
            get { return _username; }
            set
            {
                _username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("username"));
            }
        }
        private string _password;
        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("password"));
            }
        }

        private async void LogIn()
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Username and Password", "OK");
            }
            else
            {
                Login login = new Login()
                {
                    username = username,
                    password = password
                };
                var content = await HttpServices.ServiceClientInstance.AuthenticateUserAsync(login);
                if (content != null)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new MainPage(content.isAdmin, content.id));
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Login Fail", "Incorrect cerdentials. Try Again!", "OK");
                }
            }
        }

        public Command LogInCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

