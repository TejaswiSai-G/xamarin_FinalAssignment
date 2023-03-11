using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FoodiesApp
{
    public partial class RegisterPage : ContentPage
    {
        //MapPage mapPage = new MapPage();
        public RegisterPage(int AdminID)
        {
            InitializeComponent();
            BindingContext = new RegisterPageModel();

            adminId.Text = AdminID.ToString();
        }
    }
}
