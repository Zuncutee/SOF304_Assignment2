using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Services
    {
        public int Tong(object a, object b)
        {
            if (a is not int || b is not int)
            {
                throw new ArgumentException("Các tham số phải là số nguyên.");
            }
            return (int)a + (int)b;
        }

        public int Tich(object a, object b)
        {
            if (!(a is int) || !(b is int))
            {
                throw new ArgumentException("Các tham số phải là số nguyên.");
            }

            return (int)a * (int)b;
        }

        public int Hieu(object a, object b)
        {
            if (a is not int || b is not int)
            {
                throw new ArgumentException("Các tham số phải là số nguyên.");
            }
            return (int)a - (int)b;
        }

        public double CalculateAverage(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException("Danh sách không được rỗng.");

            return numbers.Average();
        }
        public static int GetElementAt(int[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Mảng không được null");
            }
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException("Chỉ số ngoài phạm vi");
            }
            return array[index];
        }
    }
}
