using My_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTest
{
    [TestFixture]
    public class TinhTBC
    {
        private Services _services;

        [SetUp]
        public void Setup()
        {
            _services = new Services();
        }

        [TestCase(new[]  { 1, 2, 3, 4, 5 }, 3)]
        [TestCase(new[]  { -1, 0, 1 }, 0)]
        [TestCase(new[] { 10, 20, 30, 40 }, 25)]
        public void TestAverage(int[] numbers, double ex)
        {
            List<int> numberList = new List<int>(numbers);
            double result = _services.CalculateAverage(numberList);
            Assert.AreEqual(ex, result);
        }

        //  danh sách trống
        [Test]
        public void TestAverage_EmptyList()
        {
            Assert.Throws<ArgumentException>(() => _services.CalculateAverage(new List<int>()));
        }

        //  danh sách null
        [Test]
        public void TestAverage_NullList()
        {
            Assert.Throws<ArgumentException>(() => _services.CalculateAverage(null));
        }
    }
}
