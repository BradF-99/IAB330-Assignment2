using SmartPark.Models;
using SmartPark.Services;
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
    public partial class PostScanPage : ContentPage
    {
        public string labelResult { get; set; }

        public PostScanPage(Result result)
        {
            ParkingMeter meter = APIDataStore.getData(result.Text);

            string resultText = "Meter Details: " + meter.STREET + ", " + meter.SUBURB + "(" + meter.METER_NO + ")";

            //labelDetails.SetBinding(Label.TextProperty, labelTest);
            InitializeComponent();
            labelDetails.Text = resultText;
        }
    }
}