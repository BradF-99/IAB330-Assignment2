using Newtonsoft.Json;
using SmartPark.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SmartPark.Services
{
    public class APIDataStore
    {
        public List<ParkingMeter> meters;
        public APIDataStore()
        {
            meters = new List<ParkingMeter>();
            string url = "http://149.28.165.104:3000/data/";
            var json = new WebClient().DownloadString(url);

            meters = JsonConvert.DeserializeObject<List<ParkingMeter>>(json);
        }
    }
}
