using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartPark.Models.Test
{
    [TestClass]
    public class ParkingMeterModelTest
    {
        [TestMethod]
        public void TestParkingMeterInitEmpty()
        {
            ParkingMeter meter = new ParkingMeter();
            Assert.IsNotNull(meter);
        }
    }
}
