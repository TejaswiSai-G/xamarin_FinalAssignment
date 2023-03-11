using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FoodiesApp
{
    public partial class CheckOutPage : ContentPage
    {
        public CheckOutPage(FoodItems foodItems)
        {
            InitializeComponent();
            BindingContext = this;
            Name.Text = foodItems.foodName + " of Price "+ foodItems.price;
            //Price.Text = foodItems.price;
        }
    }
}
