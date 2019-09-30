using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace SmartPark.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRScannerPage : ContentPage
    {
        public QRScannerPage()
        {
            InitializeComponent();
            _scanView.IsScanning = false;
        }

        public void Handle_OnScanResult(Result result)
        {
            _scanView.IsScanning = false;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Navigation.PushAsync(new PostScanPage(result));
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _scanView.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _scanView.IsScanning = false;
        }
    }
}