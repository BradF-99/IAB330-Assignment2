using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPark.Models
{
    class ParkingMeter
    {
        public int ID { get; set; }
        public string description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Category { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public int HoursMax { get; set; }
        public double RateWkday { get; set; }
        public double RateWkend { get; set; }
        public int baysCar { get; set; }
        public int baysMotorcycle { get; set; }
        public string operationalDays { get; set; }
        public string operationalTimes { get; set; }
    }
}
