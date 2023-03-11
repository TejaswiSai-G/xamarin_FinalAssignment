using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FoodiesApp
{
    public partial class UpdatePage : ContentPage
    {
        public UpdatePage(Restaurant rstData)
        {
            InitializeComponent();
            BindingContext = new UpdatePageModel();

            id.Text = rstData.id.ToString();
            displayName.Text = rstData.displayName;
            address.Text = rstData.address;
            priceForTwo.Text = rstData.priceForTwo.ToString();
            adminId.Text = rstData.adminId.ToString();
        }
    }
}
