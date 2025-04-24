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
                throw new Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
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
                throw new Exception("Lỗi khi lấy thông tin khách hàng: " + ex.Message);
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
                throw new Exception("Lỗi khi tìm kiếm khách hàng theo số điện thoại: " + ex.Message);
            }
        }

        public static void Them(KhachHang khachHang)
        {
            // Kiểm tra thông tin đầu vào
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

            // Kiểm tra mã khách hàng đã tồn tại
            var khachHangTonTai = khachHangDAL.LayTheoMa(khachHang.MaKhachHang);
            if (khachHangTonTai != null)
                throw new Exception("Mã khách hàng đã tồn tại!");

            try
            {
                khachHangDAL.Them(khachHang);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm khách hàng: " + ex.Message);
            }
        }

        public static void CapNhat(KhachHang khachHang)
        {
            // Kiểm tra thông tin đầu vào
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

            // Kiểm tra khách hàng có tồn tại
            var khachHangTonTai = khachHangDAL.LayTheoMa(khachHang.MaKhachHang);
            if (khachHangTonTai == null)
                throw new Exception("Khách hàng không tồn tại!");

            try
            {
                khachHangDAL.CapNhat(khachHang);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
        }

        public static void Xoa(string maKhachHang)
        {
            if (string.IsNullOrEmpty(maKhachHang))
                throw new Exception("Mã khách hàng không được để trống!");

            // Kiểm tra khách hàng có tồn tại
            var khachHangTonTai = khachHangDAL.LayTheoMa(maKhachHang);
            if (khachHangTonTai == null)
                throw new Exception("Khách hàng không tồn tại!");

            try
            {
                khachHangDAL.Xoa(maKhachHang);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa khách hàng: " + ex.Message);
            }
        }
    }
}