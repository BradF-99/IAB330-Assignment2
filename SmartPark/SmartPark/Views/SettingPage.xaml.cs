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
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        void CardClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new Cardinfo()));
        }

        void CarClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new Carinfo()));
        }
    }
}