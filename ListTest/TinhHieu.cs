
using My_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTest
{
    [TestFixture]
    public class TinhHieu
    {
        private Services _services;

        [SetUp]
        public void Setup()
        {
            _services = new Services();
        }

        // Các TestCase hợp lệ, biên và không hợp lệ
        [TestCase(5, 10, -5)]
        [TestCase(-5, -10, 5)]
        [TestCase(-5, 10, -15)]
        [TestCase(0, 10, -10)]
        [TestCase(0, 0, 0)]
        [TestCase(int.MinValue, 0, int.MinValue)]
        [TestCase(int.MaxValue, 1, 2147483646)]
        [TestCase(int.MinValue, int.MaxValue, 1)]
        [TestCase("abc", 10, 0)]
        [TestCase("$", "@", 0)]
        public void TinhHieuTest(object a, object b, int ex)
        {
            if (a is not int || b is not int)
            {
                Assert.Throws<ArgumentException>(() => _services.Hieu(a, b));
            }
            else
            {
                int result = _services.Hieu((int)a, (int)b);
                Assert.AreEqual(ex, result);
            }
        }
    }
}
