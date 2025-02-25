using BUS_QLBanHang;
using DAL_QLBanHang;
using DTO_QLBanHang;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestQuanLyBanHang
{
    [TestClass]
    public class Test_QuanLyHang
    {
        private DAL_Hang dalHang;

        [TestInitialize]
        public void Test_KhoiTaoTest()
        {
            dalHang = new DAL_Hang();
        }

        [TestMethod]
        public void Test_ThemSanPhamThatBai()
        {
            bool result = dalHang.insertHang(new DTO_Hang("Sản phẩm nào đó??", 200, 5000, 3000, "\\Images\\product.png", "Ai mà biết được", "fpoly22222222@fe.edu.vn"));
            Assert.IsFalse(result, "Thêm sản phẩm thất bại");
        }

        [TestMethod]
        public void Test_ThemSanPhamThanhCong()
        {
            bool result = dalHang.insertHang(new DTO_Hang("Sản phẩm nào đó??", 200, 5000, 3000, "\\Images\\product.png", "Ai mà biết được", "fpoly@fe.edu.vn"));
            Assert.IsTrue(result, "Thêm sản phẩm thành công");
        }

        [TestMethod]
        public void Test_SuaSanPhamThatBai()
        {
            bool result = dalHang.UpdateHang(new DTO_Hang(38337, "Sản phẩm nào đó??", 200, 5000, 3000, "\\Images\\product.png", "Ai mà biết được"));
            Assert.IsFalse(result, "Sữa sản phẩm thất bại");
        }

        [TestMethod]
        public void Test_SuaSanPhamThanhCong()
        {
            bool result = dalHang.UpdateHang(new DTO_Hang(8, "Sản phẩm nào đó??", 200, 5000, 3000, "\\Images\\product.png", "Ai mà biết được"));
            Assert.IsTrue(result, "Sữa sản phẩm thành công");
        }

        [TestMethod]
        public void Test_XoaSanPhamThatBai()
        {
            bool result = dalHang.DeleteHang(844);
            Assert.IsFalse(result, "Xóa sản phẩm thất bại");
        }

        [TestMethod]
        public void Test_XoaSanPhamThanhCong()
        {
            bool result = dalHang.DeleteHang(8);
            Assert.IsTrue(result, "Xóa sản phẩm thành công");
        }

        [TestMethod]
        public void Test_SearchHangThanhCong()
        {
            var result = dalHang.SearchHang("_");
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Rows.Count, "Tìm kiếm hàng thành công");
        }

        [TestMethod]
        public void Test_SearchHangThatBai()
        {
            var result = dalHang.SearchHang("kfjhfjh");
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count, "Tìm kiếm hàng thất bại");
        }
    }
    [TestClass]
    public class Test_KhachHang
    {
        private BUS_Khach busKhach;

        [TestInitialize]
        public void Test_KhoiTaoTest()
        {
            busKhach = new BUS_Khach();
        }

        [TestMethod]
        public void Test_InsertKhachHangThanhCong()
        {
            var khach = new DTO_Khach("0738273647", "NGUYỄN THỊ ANH", "HCM", "Nữ", "fps@fe.edu.vn");

            var result = busKhach.InsertKhach(khach);

            Assert.IsFalse(result, "Thêm khách hàng thành công");
        }

        [TestMethod]
        public void Test_InsertKhachHangThatBai()
        {
            var khach = new DTO_Khach("8574857483", "NGUYẾN VĂN ANH", "HCM", "Nam", "fpoly@fe.edu.vn");

            var result = busKhach.InsertKhach(khach);

            Assert.IsTrue(result, "Thêm khách hàng thất bại");
        }

        [TestMethod]
        public void Test_CapNhatKhachHangThanhCong()
        {
            var khach = new DTO_Khach("4", "NGUYỄN THỊ NGỌC", "DNG", "Nữ", "ffs@fe.edu.vn");

            var result = busKhach.UpdateKhach(khach);

            Assert.IsTrue(result, "Cập nhật khách hàng thành công");
        }

        [TestMethod]
        public void Test_CapNhatKhachHangThatBai()
        {
            var khach = new DTO_Khach("?", "BÙI THỊ TRÂM", "DNG", "Nữ", "ffs@fe.edu.vn");

            var result = busKhach.UpdateKhach(khach);

            Assert.IsFalse(result, "Cập nhật khách hàng thất bại");
        }

        [TestMethod]
        public void Test_XoaKhachHangThanhCong()
        {
            var result = busKhach.DeleteKhach("8574857483");

            Assert.IsTrue(result, "Xóa khách hàng thành công");
        }

        [TestMethod]
        public void Test_XoaKhachHangThatBai()
        {
            var result = busKhach.DeleteKhach("?");

            Assert.IsFalse(result, "Xóa khách hàng thất bại");
        }

        [TestMethod]
        public void Test_TimKiemKhachHangThanhCong()
        {
            var result = busKhach.SearchKhach("5");

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Rows.Count, "Tìm kiếm khách hàng thành công");
        }

        [TestMethod]
        public void SearchKhach_InvalidPhoneNumber()
        {
            var result = busKhach.SearchKhach("?");

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count, "Tìm kiếm khách hàng thất bại");
        }
    }
    [TestClass]
    public class Test_QuanLyNhanVien
    {
        private BUS_NhanVien _busNhanVien;

        [TestInitialize]
        public void Test_KhoiTaoTest()
        {
            _busNhanVien = new BUS_NhanVien();

        }
        [TestMethod]
        public void Test_DangNhapThatBai()
        {
            DTO_NhanVien nv = new DTO_NhanVien
            {
                EmailNV = "fpoly@fe.edu.vn",
                MatKhau = "?"
            };
            DAL_NhanVien login = new DAL_NhanVien();

            bool result = login.NhanVienDangNhap(nv);
            Assert.IsFalse(result, "Đăng nhập thất bại");
        }

        [TestMethod]
        public void Test_DangNhapThanhCong()
        {
            DTO_NhanVien nv = new DTO_NhanVien
            {
                EmailNV = "fpoly@fe.edu.vn",
                MatKhau = "23315424196402035621"
            };
            DAL_NhanVien login = new DAL_NhanVien();

            bool result = login.NhanVienDangNhap(nv);
            Assert.IsTrue(result, "Đăng nhập thành công");
        }
        [TestMethod]
        [Priority(1)]
        public void Test_ThemNhanVienThaiBai()
        {
            var dal = new DAL_NhanVien();
            var nhanVien = new DTO_NhanVien
            {
                EmailNV = "fps@gmail.com",
                TenNhanVien = "FPS",
                DiaChi = "???",
                VaiTro = 1
            };
            bool result = dal.insertNhanVien(nhanVien);
            Assert.IsTrue(result, "Thêm nhân viên thất bại");
        }
        [TestMethod]
        [Priority(1)]
        public void Test_ThemNhanVienThanhCong()
        {
            var dal = new DAL_NhanVien();
            var nhanVien = new DTO_NhanVien
            {
                EmailNV = "fps@gmail.com",
                TenNhanVien = "FPS",
                DiaChi = "??",
                VaiTro = 1,
                TinhTrang = 1,
                MatKhau = "23315424196402035621"
            };
            bool result = dal.insertNhanVien(nhanVien);
            Assert.IsTrue(result, "Thêm nhân viên thành công");
        }
        [TestMethod]
        [Priority(2)]
        public void Test_UpdateNhanVienThatBai()
        {
            var dal = new DAL_NhanVien();
            DTO_NhanVien nv = new DTO_NhanVien
            {
                EmailNV = "fpssss@gmail.com",
                TenNhanVien = "FPS NEW",
                DiaChi = "HCM",
                VaiTro = 2,
                TinhTrang = 0
            };

            bool isUpdated = dal.UpdateNhanVien(nv);
            Assert.IsFalse(isUpdated, "Cập nhật nhân viên thất bại");
        }
        [TestMethod]
        [Priority(2)]
        public void Test_UpdateNhanVienThanhCong()
        {
            var dal = new DAL_NhanVien();
            DTO_NhanVien nv = new DTO_NhanVien
            {
                EmailNV = "fps@gmail.com",
                TenNhanVien = "FPS NEW",
                DiaChi = "HCM",
                VaiTro = 2,
                TinhTrang = 0
            };

            bool isUpdated = dal.UpdateNhanVien(nv);
            Assert.IsTrue(isUpdated, "Cập nhật nhân viên thành công");
        }
        [TestMethod]
        [Priority(3)]
        public void Test_DeleteNhanVienThatBai()
        {
            var dal = new DAL_NhanVien();
            bool isDeleted = dal.DeleteNnhanVien("fpss@gmail.com");
            Assert.IsFalse(isDeleted, "Xóa nhân viên thất bại");
        }
        [Priority(3)]
        public void Test_DeleteNhanVienThanhCong()
        {
            var dal = new DAL_NhanVien();
            bool isDeleted = dal.DeleteNnhanVien("fps@gmail.com");
            Assert.IsTrue(isDeleted, "Xóa nhân viên thành công");
        }

        [TestMethod]
        public void Test_SearchNhanVienThanhCong()
        {
            var result = _busNhanVien.SearchNhanVien("Fpoly");

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Rows.Count, "Tìm kiếm nhân viên thành công");
        }

        [TestMethod]
        public void Test_SearchNhanVienThatBai()
        {
            var result = _busNhanVien.SearchNhanVien("?");

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count, "Tìm kiếm nhân viên thất bại");
        }
    }
}
