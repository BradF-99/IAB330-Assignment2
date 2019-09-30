using Newtonsoft.Json;
using SmartPark.Models;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;

namespace SmartPark.Services
{
    public class APIDataStore
    {
        public List<ParkingMeter> meters;
        private readonly string url = "http://149.28.165.104:3000/data/";
        public APIDataStore()
        {
            meters = new List<ParkingMeter>();
            try
            {
                meters = JsonConvert.DeserializeObject<List<ParkingMeter>>(new WebClient().DownloadString(url));
            }
            catch
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Something's gone wrong", "There has been an error in getting the parking meter data. Please try again later.", "OK");
                });
            }
        }

        public static ParkingMeter GetData(string query)
        {
            string url = "http://149.28.165.104:3000/data/" + query; // required for static method
            try
            {
                List<ParkingMeter> meter = JsonConvert.DeserializeObject<List<ParkingMeter>>(new WebClient().DownloadString(url));
                return meter[0];
            }
            catch
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Something's gone wrong", "There has been an error in getting the parking meter data. Please try again later.", "OK");
                });
            }
            return new ParkingMeter();
        }
    }
}
