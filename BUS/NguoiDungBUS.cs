using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BUS
{
    public class NguoiDungBUS
    {
        public static List<NguoiDung> LayTatCa()
        {
            try
            {
                return NguoiDungDAL.LayTatCa();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách người dùng: {ex.Message}");
            }
        }
        public static void Them(NguoiDung obj)
        {
            if (obj == null)
                throw new Exception("Người dùng không được để trống!");
            if (string.IsNullOrEmpty(obj.MaNguoiDung))
                throw new Exception("Mã người dùng không được để trống!");
            if (string.IsNullOrEmpty(obj.TenDangNhap))
                throw new Exception("Tên đăng nhập không được để trống!");
            if (string.IsNullOrEmpty(obj.MatKhau))
                throw new Exception("Mật khẩu không được để trống!");
            if (string.IsNullOrEmpty(obj.VaiTro) || !new[] { "admin", "nhanvien", "khach" }.Contains(obj.VaiTro))
                throw new Exception("Vai trò phải là 'admin', 'nhanvien' hoặc 'khach'!");

            // Mã hóa mật khẩu trước khi lưu

            try
            {
                NguoiDungDAL.Them(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm người dùng với mã {obj.MaNguoiDung}: {ex.Message}");
            }
        }
        public static void CapNhat(NguoiDung obj)
        {
            NguoiDungDAL.CapNhat(obj);
        }

      public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Mã người dùng không được để trống!");

            try
            {
                NguoiDungDAL.Xoa(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa người dùng với mã {id}: {ex.Message}");
            }
        }
        // Thêm phương thức đăng nhập
        public static NguoiDung DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrEmpty(tenDangNhap))
                throw new Exception("Tên đăng nhập không được để trống!");
            if (string.IsNullOrEmpty(matKhau))
                throw new Exception("Mật khẩu không được để trống!");
            try
            {
                var danhSach = NguoiDungDAL.LayTatCa();
            return danhSach.Find(nd => nd.TenDangNhap == tenDangNhap && nd.MatKhau == matKhau);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi đăng nhập với tên đăng nhập {tenDangNhap}: {ex.Message}");
            }
        }
    }
}
