using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_Data;
using NUnit.Framework;

namespace ListTest
{
    public class TinhTich
    {
        private Services services;
        [SetUp]
        public void SetUp()
        {
            services = new Services();
        }
        [TestCase(2,3,6)]
        [TestCase(-2,-3,6)]
        [TestCase(2,-3,-6)]
        [TestCase(-2,3,-6)]
        [TestCase(0,3,0)]
        [TestCase(2,0,0)]
        [TestCase(int.MaxValue, 1, int.MaxValue)]
        [TestCase(int.MinValue, 1, int.MinValue)]
        [TestCase(int.MaxValue, 0, 0)]
        [TestCase("a", 3, 0)]
        [TestCase(2, "b", 0)]

        [Test]
        public void TinhTichTest(object a, object b,int ex)
        {
            if (a is int && b is int)
            {
                var result = services.Tich(a, b);
                Assert.AreEqual(ex, result, "Kết quả tính tích không đúng.");
            }
            else
            {
                Assert.Throws<ArgumentException>(() => services.Tich(a, b));
            }
        }

    }
}
