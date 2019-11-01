using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartPark.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cardinfo : ContentPage
    {
        public Cardinfo()
        {
            InitializeComponent();
        }
        async void SaveClicked(object sender, EventArgs args)
        {
            await DisplayAlert("Notice", "Your card detail has been saved successfully, please press go back button", "OK");
        }
    }
}