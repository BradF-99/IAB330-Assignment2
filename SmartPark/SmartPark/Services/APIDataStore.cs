using Newtonsoft.Json;
using SmartPark.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace SmartPark.Services
{
    public class APIDataStore
    {
        public List<ParkingMeter> meters;
        public APIDataStore()
        {
            meters = new List<ParkingMeter>();
            string url = "http://149.28.165.104:3000/data/";
            try
            {
                string json = new WebClient().DownloadString(url);
                meters = JsonConvert.DeserializeObject<List<ParkingMeter>>(json);
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
            string url = "http://149.28.165.104:3000/data/"+query;
            try
            {
                var json = new WebClient().DownloadString(url);
                List<ParkingMeter> meter = JsonConvert.DeserializeObject<List<ParkingMeter>>(json);
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
