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
        public PostScanPage(Result result)
        {
            ParkingMeter meter = APIDataStore.getData(result.Text);
            
            var fs = new FormattedString();

            fs.Spans.Add(new Span { Text = "Meter ID: ", FontAttributes = FontAttributes.Bold, FontSize = 20 });
            fs.Spans.Add(new Span { Text = meter.METER_NO + "\n", FontSize = 20 });

            fs.Spans.Add(new Span { Text = "Location: ", FontAttributes = FontAttributes.Bold, FontSize = 20 });
            fs.Spans.Add(new Span { Text = meter.STREET + " " + meter.SUBURB + "\n", FontSize = 20 });

            fs.Spans.Add(new Span { Text = "Bays available: ", FontAttributes = FontAttributes.Bold, FontSize = 20 });
            fs.Spans.Add(new Span { Text = meter.VEH_BAYS, FontAttributes = FontAttributes.Italic, FontSize = 20 });
            fs.Spans.Add(new Span { Text = " car bays & ", FontSize = 20 });
            fs.Spans.Add(new Span { Text = meter.MC_BAYS, FontAttributes = FontAttributes.Italic, FontSize = 20 });
            fs.Spans.Add(new Span { Text = " motorcycle bays. \n", FontSize = 20 });

            fs.Spans.Add(new Span { Text = "Maximum Stay: ", FontAttributes = FontAttributes.Bold, FontSize = 20 });
            fs.Spans.Add(new Span { Text = meter.MAX_STAY_HRS, FontAttributes = FontAttributes.Italic, FontSize = 20 });
            fs.Spans.Add(new Span { Text = " hours, and it costs $", FontSize = 20 });
            fs.Spans.Add(new Span { Text = meter.TAR_RATE_WEEKDAY, FontAttributes = FontAttributes.Italic, FontSize = 20 });
            fs.Spans.Add(new Span { Text = " per hour to park here.", FontSize = 20 });
            
            InitializeComponent();
            labelDetails.FormattedText = fs;
        }
    }
}