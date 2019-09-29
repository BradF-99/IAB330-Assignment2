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
        void LoginAccepted(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
            //await Navigation.PushAsync(new MainPage());
            User user = new User(User_email.Text, User_password.Text);
            if(user.CheckInformation())
            {
                DisplayAlert("Login", "Login Success", "Oke");
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, Empty Username or Password", "Oke");
            }
        }
    }
}
