using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BUS
{
    public class LoaiVeBUS
    {
        public static List<LoaiVe> LayTatCa()
        {
            try
            {
                return LoaiVeDAL.LayTatCa();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách loại vé: {ex.Message}");
            }
        }

        public static void Them(LoaiVe obj)
        {
            if (obj == null)
                throw new Exception("Loại vé không được để trống!");
            if (string.IsNullOrEmpty(obj.MaLoaiVe))
                throw new Exception("Mã loại vé không được để trống!");
            if (string.IsNullOrEmpty(obj.TenLoaiVe))
                throw new Exception("Tên loại vé không được để trống!");
            if (obj.PhuThu < 0)
                throw new Exception("Phụ thu không được âm!");

            var danhSach = LoaiVeDAL.LayTatCa();
            if (danhSach.Any(lv => lv.MaLoaiVe == obj.MaLoaiVe))
                throw new Exception($"Mã loại vé {obj.MaLoaiVe} đã tồn tại!");

            try
            {
                LoaiVeDAL.Them(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm loại vé với mã {obj.MaLoaiVe}: {ex.Message}");
            }
        }

        public static void Sua(LoaiVe obj)
        {
            if (obj == null)
                throw new Exception("Loại vé không được để trống!");
            if (string.IsNullOrEmpty(obj.MaLoaiVe))
                throw new Exception("Mã loại vé không được để trống!");
            if (string.IsNullOrEmpty(obj.TenLoaiVe))
                throw new Exception("Tên loại vé không được để trống!");
            if (obj.PhuThu < 0)
                throw new Exception("Phụ thu không được âm!");

            try
            {
                LoaiVeDAL.Sua(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi sửa loại vé với mã {obj.MaLoaiVe}: {ex.Message}");
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Mã loại vé không được để trống!");

            var veList = VeDAL.LayTatCa();
            if (veList.Any(v => v.MaLoaiVe == id))
                throw new Exception("Loại vé đang được sử dụng, không thể xóa!");

            try
            {
                LoaiVeDAL.Xoa(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa loại vé với mã {id}: {ex.Message}");
            }
        }

        public static LoaiVe LayTheoMa(string maLoaiVe)
        {
            if (string.IsNullOrEmpty(maLoaiVe))
                throw new Exception("Mã loại vé không được để trống!");

            try
            {
                return LoaiVeDAL.LayTheoMa(maLoaiVe);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin loại vé với mã {maLoaiVe}: {ex.Message}");
            }
        }
    }
}