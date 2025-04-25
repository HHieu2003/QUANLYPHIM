using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BUS
{
    public class TheLoaiPhimBUS
    {
        public static List<TheLoaiPhim> LayTatCa()
        {
            try
            {
                return TheLoaiPhimDAL.LayTatCa();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách thể loại phim: {ex.Message}");
            }
        }

        public static void Them(TheLoaiPhim obj)
        {
            if (obj == null)
                throw new Exception("Thể loại phim không được để trống!");
            if (string.IsNullOrEmpty(obj.MaTheLoai))
                throw new Exception("Mã thể loại không được để trống!");
            if (string.IsNullOrEmpty(obj.TenTheLoai))
                throw new Exception("Tên thể loại không được để trống!");

            var danhSach = TheLoaiPhimDAL.LayTatCa();
            if (danhSach.Any(tl => tl.MaTheLoai == obj.MaTheLoai))
                throw new Exception($"Mã thể loại {obj.MaTheLoai} đã tồn tại!");

            try
            {
                TheLoaiPhimDAL.Them(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm thể loại phim với mã {obj.MaTheLoai}: {ex.Message}");
            }
        }

        public static void CapNhat(TheLoaiPhim obj)
        {
            if (obj == null)
                throw new Exception("Thể loại phim không được để trống!");
            if (string.IsNullOrEmpty(obj.MaTheLoai))
                throw new Exception("Mã thể loại không được để trống!");
            if (string.IsNullOrEmpty(obj.TenTheLoai))
                throw new Exception("Tên thể loại không được để trống!");

            try
            {
                TheLoaiPhimDAL.CapNhat(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật thể loại phim với mã {obj.MaTheLoai}: {ex.Message}");
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Mã thể loại không được để trống!");

            try
            {
                TheLoaiPhimDAL.Xoa(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa thể loại phim với mã {id}: {ex.Message}");
            }
        }
    }
}