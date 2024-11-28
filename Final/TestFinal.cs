namespace Final
{
    public class Sinhvien
    {
        public string Id { get; set; }
        public string Hoten { get; set; }
        public string Malop { get; set; }
        public string Tenlop { get; set; }
        public string Masv { get; set; }

        // Constructor
        public Sinhvien(string id, string hoten, string malop, string tenlop, string masv)
        {
            Id = id;
            Hoten = hoten;
            Malop = malop;
            Tenlop = tenlop;
            Masv = masv;
        }
    }

    public class Sinhvienpoly
    {
        private List<Sinhvien> sinhviens = new List<Sinhvien>();

        public void Them(Sinhvien sv)
        {
            if (sv == null)
            {
                throw new ArgumentNullException(nameof(sv), "Sinh viên không thể là null");
            }
            sinhviens.Add(sv);
        }

        // Tìm sinh viên theo mã sinh viên (masv)
        public Sinhvien TimKiemTheoMasv(string masv)
        {
            return sinhviens.FirstOrDefault(sv => sv.Masv.Equals(masv, StringComparison.OrdinalIgnoreCase));
        }

        // Kiểm tra tên lớp không chứa ký tự đặc biệt
        public bool TenlopHopLe(string tenlop)
        {
            return !string.IsNullOrEmpty(tenlop) && !tenlop.Any(ch => !char.IsLetterOrDigit(ch));
        }
    }

    public class Tests
    {
        private Sinhvienpoly _sinhvienpoly;

        [SetUp]
        public void Setup()
        {
            _sinhvienpoly = new Sinhvienpoly();
        }

        // Kiểm thử thêm sinh viên hợp lệ
        [TestCase("SV001", "Nguyen A", "CS01", "Lop1", "PH001")]
        [TestCase("SV002", "Tran B", "CS02", "Lop2", "PH002")]
        [TestCase("SV003", "Le C", "CS03", "Lop3", "PH003")]
        [TestCase("SV004", "Nguyen D", "CS04", "Lop4", "PH004")]
        [TestCase("SV005", "Pham E", "CS05", "Lop5", "PH005")]
        public void Test_ThemSinhVien(string id, string hoten, string malop, string tenlop, string masv)
        {
            var sinhvien = new Sinhvien(id, hoten, malop, tenlop, masv);
            _sinhvienpoly.Them(sinhvien);
            Assert.IsNotNull(_sinhvienpoly.TimKiemTheoMasv(masv));
        }

        // Kiểm thử thêm sinh viên với null
        [Test]
        public void Test_ThemSinhVien_Null()
        {
            Assert.Throws<ArgumentNullException>(() => _sinhvienpoly.Them(null));
        }

        // Kiểm thử tên lớp không hợp lệ (chứa ký tự đặc biệt)
        [TestCase("Lop!1")]
        [TestCase("Lop@2")]
        [TestCase("Lop#3")]
        [TestCase("Lop$4")]
        public void Test_Tenlop_KhongChuaKyTuDacBiet(string tenlop)
        {
            Assert.IsFalse(_sinhvienpoly.TenlopHopLe(tenlop));
        }

        // Kiểm thử tên lớp hợp lệ (không chứa ký tự đặc biệt)
        [TestCase("Lop1")]
        [TestCase("Lop2")]
        [TestCase("LopA")]
        public void Test_Tenlop_HopLe(string tenlop)
        {
            Assert.IsTrue(_sinhvienpoly.TenlopHopLe(tenlop));
        }
    }
}