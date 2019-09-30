using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SmartPark.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            await DisplayAlert("Notice", "You have been signed up successfully, please press go back button", "OK");
        }

        private Page AccountPage()
        {
            throw new NotImplementedException();
        }
    }
}
