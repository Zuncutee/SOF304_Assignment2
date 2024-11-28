using My_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTest
{
    [TestFixture]
    public class Mang
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new int[] { 10, 20, 30, 40, 50 }, 0, 10)]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, 2, 30)]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, 4, 50)]
        public void Test_GetElementAt1(int[] array, int index, int expected)
        {
            int result = Services.GetElementAt(array, index);
            Assert.AreEqual(expected, result);
        }

        // TH chỉ số ngoài phạm vi mảng
        [Test]
        public void Test_GetElementAt2()
        {
            int[] array = { 10, 20, 30, 40, 50 };
            Assert.Throws<IndexOutOfRangeException>(() => Services.GetElementAt(array, 10));
        }

        // TH mảng là null
        [Test]
        public void Test_GetElementAt3()
        {
            int[] array = null;
            Assert.Throws<ArgumentNullException>(() => Services.GetElementAt(array, 0));
        }

        // TH chỉ số âm
        [Test]
        public void Test_GetElementAt4()
        {
            int[] array = { 10, 20, 30, 40, 50 };
            Assert.Throws<IndexOutOfRangeException>(() => Services.GetElementAt(array, -1));
        }
    }
}

