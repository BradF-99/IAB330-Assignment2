using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SmartPark.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void LoginAccepted(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            await Navigation.PushAsync(new MainPage());
        }
    }
}
