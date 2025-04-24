using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DAL;
using DTO;

namespace BUS
{
    public static class KhachHangBUS
    {
        private static readonly KhachHangDAL khachHangDAL = new KhachHangDAL();

        public static List<KhachHang> LayTatCa()
        {
            try
            {
                return khachHangDAL.LayTatCa();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách khách hàng: {ex.Message}");
            }
        }

        public static KhachHang LayTheoMa(string maKhachHang)
        {
            if (string.IsNullOrEmpty(maKhachHang))
                throw new Exception("Mã khách hàng không được để trống!");

            try
            {
                return khachHangDAL.LayTheoMa(maKhachHang);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin khách hàng với mã {maKhachHang}: {ex.Message}");
            }
        }

        public static KhachHang TimKiemTheoSoDienThoai(string soDienThoai)
        {
            if (string.IsNullOrEmpty(soDienThoai))
                throw new Exception("Số điện thoại không được để trống!");

            try
            {
                return khachHangDAL.TimKiemTheoSoDienThoai(soDienThoai);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm khách hàng với số điện thoại {soDienThoai}: {ex.Message}");
            }
        }
        public static bool KiemTraTonTai(string maKhachHang)
        {
            if (string.IsNullOrEmpty(maKhachHang))
                throw new Exception("Mã khách hàng không được để trống!");

            try
            {
                return true ;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra khách hàng '{maKhachHang}': {ex.Message}");
            }
        }
        public static void Them(KhachHang khachHang)
        {
            if (string.IsNullOrEmpty(khachHang.MaKhachHang))
                throw new Exception("Mã khách hàng không được để trống!");

            if (string.IsNullOrEmpty(khachHang.HoTen))
                throw new Exception("Họ tên không được để trống!");

            if (string.IsNullOrEmpty(khachHang.SoDienThoai))
                throw new Exception("Số điện thoại không được để trống!");

            if (!Regex.IsMatch(khachHang.SoDienThoai, @"^0\d{9}$"))
                throw new Exception("Số điện thoại phải bắt đầu bằng 0 và có đúng 10 chữ số!");

            if (!string.IsNullOrEmpty(khachHang.Email) && !Regex.IsMatch(khachHang.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception("Email không đúng định dạng!");

            var khachHangTonTai = khachHangDAL.LayTheoMa(khachHang.MaKhachHang);
            if (khachHangTonTai != null)
                throw new Exception($"Mã khách hàng {khachHang.MaKhachHang} đã tồn tại!");

            try
            {
                khachHangDAL.Them(khachHang);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm khách hàng với mã {khachHang.MaKhachHang}: {ex.Message}");
            }
        }

        public static void CapNhat(KhachHang khachHang)
        {
            if (string.IsNullOrEmpty(khachHang.MaKhachHang))
                throw new Exception("Mã khách hàng không được để trống!");

            if (string.IsNullOrEmpty(khachHang.HoTen))
                throw new Exception("Họ tên không được để trống!");

            if (string.IsNullOrEmpty(khachHang.SoDienThoai))
                throw new Exception("Số điện thoại không được để trống!");

            if (!Regex.IsMatch(khachHang.SoDienThoai, @"^0\d{9}$"))
                throw new Exception("Số điện thoại phải bắt đầu bằng 0 và có đúng 10 chữ số!");

            if (!string.IsNullOrEmpty(khachHang.Email) && !Regex.IsMatch(khachHang.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception("Email không đúng định dạng!");

            var khachHangTonTai = khachHangDAL.LayTheoMa(khachHang.MaKhachHang);
            if (khachHangTonTai == null)
                throw new Exception($"Khách hàng với mã {khachHang.MaKhachHang} không tồn tại!");

            try
            {
                khachHangDAL.CapNhat(khachHang);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật khách hàng với mã {khachHang.MaKhachHang}: {ex.Message}");
            }
        }

        public static void Xoa(string maKhachHang)
        {
            if (string.IsNullOrEmpty(maKhachHang))
                throw new Exception("Mã khách hàng không được để trống!");

            var khachHangTonTai = khachHangDAL.LayTheoMa(maKhachHang);
            if (khachHangTonTai == null)
                throw new Exception($"Khách hàng với mã {maKhachHang} không tồn tại!");

            try
            {
                khachHangDAL.Xoa(maKhachHang);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa khách hàng với mã {maKhachHang}: {ex.Message}");
            }
        }
    }
}