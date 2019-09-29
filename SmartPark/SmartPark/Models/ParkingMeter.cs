using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPark.Models
{
    public class ParkingMeter
    {
        public string METER_NO { get; set; }
        public string CATEGORY { get; set; }
        public string STREET { get; set; }
        public string SUBURB { get; set; }
        public string MAX_STAY_HRS { get; set; }
        public string RESTRICTIONS { get; set; }
        public string OPERATIONAL_DAY { get; set; }
        public string OPERATIONAL_TIME { get; set; }
        public string TAR_ZONE { get; set; }
        public string TAR_RATE_WEEKDAY { get; set; }
        public string TAR_RATE_AH_WE { get; set; }
        public string LOC_DESC { get; set; }
        public string VEH_BAYS { get; set; }
        public string MC_BAYS { get; set; }
        public string MC_RATE { get; set; }
        public string LONGITUDE { get; set; }
        public string LATITUDE { get; set; }
        public string MOBILE_ZONE { get; set; }
        public string MAX_CAP_CHG { get; set; }
    }
}
