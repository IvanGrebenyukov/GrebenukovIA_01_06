using System.Security.Cryptography.X509Certificates;
using WarehouseLibrary;

namespace TestWarehouseProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFieldNameProduct()
        {
            new BaseWarehouse(" ", 1500.99, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFieldPrice()
        {
            new BaseWarehouse("Ручка", -1, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFieldCount()
        {
            new BaseWarehouse("Ручка", 20.55, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFieldReleaseYearMaxValue()
        {
            new WarehouseChild(" ", 1500.99, 10, 2025);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFieldReleaseYearMinValue()
        {
            new WarehouseChild(" ", 1500.99, 10, 1899);
        }

        [TestMethod]
        public void TestBaseQuality()
        {
            double expectedQuality = 2500 / 10;
            var baseElement = new BaseWarehouse("Ручка", 2500, 10);
            Assert.AreEqual(expectedQuality, baseElement.Quality());
        }

        [TestMethod]
        public void TestChildQualityLessThanOrEqual3()
        {
            double expectedQuality = (2500 / 10) + 0.5 * (DateTime.Now.Year - 2021);
            var childElement = new WarehouseChild("Ручка", 2500, 10, 2021);
            Assert.AreEqual(expectedQuality, childElement.Quality());
        }
        [TestMethod]
        public void TestChildQualityGreatestThan3()
        {
            double expectedQuality = (2500 / 10) + 1.3 * (DateTime.Now.Year - 2020);
            var childElement = new WarehouseChild("Ручка", 2500, 10, 2020);
            Assert.AreEqual(expectedQuality, childElement.Quality());
        }
    }
}