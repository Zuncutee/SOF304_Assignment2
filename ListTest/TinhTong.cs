using My_Data;

namespace ListTest
{
    [TestFixture]
    public class Tests
    {
        private  Services _services;
        [SetUp]
        public void Setup()
        {
            _services = new Services();
        }
        // Test case hợp lệ
        [TestCase(5, 10, 15)]
        [TestCase(-5, -10, -15)]
        [TestCase(-5, 10, 5)]
        [TestCase(0, 10, 10)]
        [TestCase(0, 0, 0)]

        // Test case biên
        [TestCase(int.MinValue, 1, -2147483647)]
        [TestCase(int.MaxValue, -1, 2147483646)]
        [TestCase(int.MinValue, int.MaxValue, -1)]
        // Test case không hợp lệ
        [TestCase("abc", 10,0)]
        [TestCase("$", "@",0)]

        [Test]
        public void TinhTongTest(object a, object b, int ex)
        {
            if (a is not int || b is not int)
            {
                Assert.Throws<ArgumentException>(() => _services.Tong(a, b));
            }
            else
            {
                int result = _services.Tong(a, b);
                Assert.AreEqual(ex, result, $"Kết quả không đúng với a={a}, b={b}.");
            }
        }
    }
}