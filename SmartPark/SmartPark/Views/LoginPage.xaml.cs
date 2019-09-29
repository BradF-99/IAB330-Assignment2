using System;
using System.Collections.Generic;
using SmartPark.Models;
using Xamarin.Forms;

namespace SmartPark.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void LoginAccepted(object sender, EventArgs e)
        {
            User user = new User(User_email.Text, User_password.Text);
            if(user.CheckInformation())
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());

            }
            else
            {
                await DisplayAlert("Login", "Login Not Correct, Empty Username or Password", "Ok");
            }
        }
    }
}
