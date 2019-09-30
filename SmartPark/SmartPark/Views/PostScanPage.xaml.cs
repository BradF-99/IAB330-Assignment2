using SmartPark.Models;
using SmartPark.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace SmartPark.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostScanPage : ContentPage
    {
        ParkingMeter meter;
        bool parkingStarted = false;
        Timer timer = new System.Timers.Timer();
        int timeElapsed;

        public PostScanPage(Result result)
        {
            meter = APIDataStore.GetData(result.Text);

            FormattedString fs = new FormattedString();
            bool btnEnabled = true;

            if(meter.METER_NO != null)
            {
                fs = SetLabelMeterDetails(meter);
            }
            else
            {
                btnEnabled = false;
                fs.Spans.Add(new Span { Text = "We were unable to retrieve\nthe data for this meter.\nPlease try again later.", FontSize = 20 });
            }

            InitializeComponent();
            labelDetails.FormattedText = fs;
            btnStart.IsVisible = btnEnabled;
            btnStart.IsEnabled = btnEnabled;
        }

        async public void BtnPress(object sender, EventArgs args)
        {
            FormattedString fs = new FormattedString();

            if (!parkingStarted)
            {
                parkingStarted = true;
                btnStart.Text = "Stop Parking";

                timeElapsed = 0;
                timer.Interval = 1000;
                timer.Enabled = true;
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
            }
            else
            {
                fs = SetLabelMeterDetails(meter);
                btnStart.Text = "Start Parking";
                btnStart.IsEnabled = false;

                timer.Stop();
                timeElapsed = 0;

                labelDetails.FormattedText = fs;
            }
            
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timeElapsed++;
            Device.BeginInvokeOnMainThread(async () =>
            {
                labelDetails.FormattedText = SetLabelTimerDetails(timeElapsed);
            });
        }

        private FormattedString SetLabelTimerDetails(int timeElapsed)
        {
            TimeSpan time = TimeSpan.FromSeconds(timeElapsed);
            FormattedString fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "Currently parked at:\n", FontSize = 20 });
            fs.Spans.Add(new Span { Text = meter.STREET + ", " + meter.SUBURB + "\n\n", FontAttributes = FontAttributes.Bold, FontSize = 20 });
            fs.Spans.Add(new Span { Text = "Duration: ", FontSize = 20 });
            fs.Spans.Add(new Span { Text = time.ToString(@"hh\:mm\:ss"), FontAttributes = FontAttributes.Bold, FontSize = 20 });
            return fs;
        }

        private FormattedString SetLabelMeterDetails(ParkingMeter meter)
        {
            FormattedString fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "Meter ID: ", FontAttributes = FontAttributes.Bold, FontSize = 20 });
            fs.Spans.Add(new Span { Text = meter.METER_NO + "\n", FontSize = 20 });

            fs.Spans.Add(new Span { Text = "Location: ", FontAttributes = FontAttributes.Bold, FontSize = 20 });
            fs.Spans.Add(new Span { Text = meter.STREET + ", " + meter.SUBURB + "\n", FontSize = 20 });

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

            return fs;
        }
    }
}