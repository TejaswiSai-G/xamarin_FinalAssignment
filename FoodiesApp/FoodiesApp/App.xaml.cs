using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodiesApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new TestingPage();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
