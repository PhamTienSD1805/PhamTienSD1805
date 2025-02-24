using DAL_QLBanHang;
using DTO_QLBanHang;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestQuanLyBanHang
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NhanVienDangNhap_TC01()
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            DAL_NhanVien login = new DAL_NhanVien();
            nv.EmailNV = "fpoly@fe.edu.vn";
            nv.MatKhau = "SD1805";
            bool result = login.NhanVienDangNhap( nv );
            Console.WriteLine("Kết quả test case:" + result.ToString());
            Assert.IsFalse( result );
        }
        [TestMethod]
        public void NhanVienDangNhap_TC02() //test case 02 -> Success
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            DAL_NhanVien login = new DAL_NhanVien();
            nv.EmailNV = "fpoly@fe.edu.vn";
            nv.MatKhau = "45223561862555188242"; //copy mật khẩu trên SQL Server
            bool result = login.NhanVienDangNhap(nv);
            Console.WriteLine("Kết quả test case: " + result.ToString());
            Assert.IsTrue(result);
        }
        [TestClass]
        public class DAL_KhachHang
        {
            [TestMethod]
            public void ThemKhachHang()
            {
                DTO_Khach KhachHang = new DTO_Khach("0987654321", "Tran Van A", "Bien Hoa", "Nam", "");
                DAL_Khach ThemKhachHang = new DAL_Khach();
                bool result = ThemKhachHang.insertKhach(KhachHang);
                Assert.IsTrue(result, "Thêm khách hàng thành công");
            }

            [TestMethod]
            public void XoaKhachHang()
            {
                DAL_Khach XoaKhachHang = new DAL_Khach();
                string sdt = "0987654321";
                bool result = XoaKhachHang.DeleteKhach(sdt);
                Assert.IsTrue(result, "Xóa khách hàng thất bại");
            }
        }

        [TestClass]
        public class DAL_BanHang
        {
            [TestMethod]
            public void ThemSanPham()
            {
                DTO_Hang SanPham = new DTO_Hang(300, "Điện thoại Samsung", 50, 5000000, 7000000, "", "");
                DAL_Hang ThemSanPham = new DAL_Hang();
                bool result = ThemSanPham.insertHang(SanPham);
                Assert.IsTrue(result, "Thêm sản phẩm thành công");
            }

            [TestMethod]
            public void XoaSanPham()
            {
                DAL_Hang XoaSanPham = new DAL_Hang();
                int maSP = 300;
                bool result = XoaSanPham.DeleteHang(maSP);
                Assert.IsTrue(result, "Xóa sản phẩm thất bại");
            }
        }
    }
}
