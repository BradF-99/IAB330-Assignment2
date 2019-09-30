using System;
using System.Collections.Generic;
using SmartPark.Models;
using Xamarin.Forms;

namespace SmartPark.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        void Start_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}