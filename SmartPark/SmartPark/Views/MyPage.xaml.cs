using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SmartPark.Views
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            await label.RelRotateTo(360, 1000);
        }
    }
}
