using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FoodiesApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new LoginPageModel();

            if (Device.RuntimePlatform == Device.iOS)
            {
                //btmTextLabel.Margin = new Thickness(60, 0, 0, 0);
                user.TextColor = Color.Black;
            }
            else
            {
                //btmTextLabel.Margin = new Thickness(50, 0, 0, 0);
                user.TextColor = Color.Black;
            }
        }

        //async public void RegisterButton_Clicked(Object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new RegisterPage());
        //}
    }
}
