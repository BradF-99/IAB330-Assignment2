using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace SmartPark.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRScannerPage : ContentPage
    {
        ZXingScannerView scanner;
        public QRScannerPage()
        {
            InitializeComponent();
            ScannerGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            ScannerGrid.HorizontalOptions = LayoutOptions.FillAndExpand;
            CreateScanner();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CreateScanner();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ReleaseScanner();
        }

        void CreateScanner()
        {
            ReleaseScanner();

            Device.BeginInvokeOnMainThread(() => {
                scanner = new ZXingScannerView
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    AutomationId = "zxingScannerView",
                    IsScanning = true,
                    IsAnalyzing = true
                };
                scanner.OnScanResult += Scanner_OnScanResult;
                ScannerGrid.Children.Add(scanner);
            });
        }

        void ReleaseScanner()
        {
            Device.BeginInvokeOnMainThread(() => {
                if (scanner != null)
                {
                    scanner.IsTorchOn = false;
                    scanner.IsAnalyzing = false;
                    scanner.IsScanning = false;
                    scanner.IsVisible = false;
                    scanner.OnScanResult -= Scanner_OnScanResult;
                    ScannerGrid.Children.Remove(scanner);
                    scanner = null;
                }
            });
        }

        void Scanner_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                ReleaseScanner();
                scanner.IsAnalyzing = false;
                await Navigation.PushAsync(new PostScanPage(result));
            });
        }
    }
}