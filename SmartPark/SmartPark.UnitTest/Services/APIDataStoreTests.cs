using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartPark.Models;
using SmartPark.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPark.Services.Tests
{
    [TestClass()]
    public class APIDataStoreTests
    {
        [TestMethod()]
        public void APIDataStoreTest()
        {
            APIDataStore apiDataStore = new APIDataStore();
            Assert.IsNotNull(apiDataStore); // fail if nothing returned
            Assert.AreEqual(984, apiDataStore.meters.Count); // make sure all parking meters have been parsed
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetDataInvalidQueryTest()
        {
            ParkingMeter meter = APIDataStore.GetData("4000");
        }

        [TestMethod()]
        public void GetDataValidQueryTest()
        {
            try
            {
                ParkingMeter meter = APIDataStore.GetData("5601");
                Assert.IsNotNull(meter);
                Assert.AreEqual("5601", meter.METER_NO);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}