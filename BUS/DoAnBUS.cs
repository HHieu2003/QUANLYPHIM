using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class DoAnBUS
    {
        public static List<DoAn> LayTatCa()
        {
            try
            {
                return DoAnDAL.LayTatCa();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách đồ ăn: {ex.Message}");
            }
        }

        public static void Them(DoAn obj)
        {
            if (obj == null)
                throw new Exception("Đồ ăn không được để trống!");
            if (string.IsNullOrEmpty(obj.MaDoAn))
                throw new Exception("Mã đồ ăn không được để trống!");
            if (string.IsNullOrEmpty(obj.TenDoAn))
                throw new Exception("Tên đồ ăn không được để trống!");
            if (obj.Gia < 0)
                throw new Exception("Giá không được âm!");

            try
            {
                DoAnDAL.Them(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm đồ ăn với mã {obj.MaDoAn}: {ex.Message}");
            }
        }

        public static void CapNhat(DoAn obj)
        {
            if (obj == null)
                throw new Exception("Đồ ăn không được để trống!");
            if (string.IsNullOrEmpty(obj.MaDoAn))
                throw new Exception("Mã đồ ăn không được để trống!");
            if (string.IsNullOrEmpty(obj.TenDoAn))
                throw new Exception("Tên đồ ăn không được để trống!");
            if (obj.Gia < 0)
                throw new Exception("Giá không được âm!");

            try
            {
                DoAnDAL.CapNhat(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật đồ ăn với mã {obj.MaDoAn}: {ex.Message}");
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Mã đồ ăn không được để trống!");

            try
            {
                DoAnDAL.Xoa(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa đồ ăn với mã {id}: {ex.Message}");
            }
        }
        public static DoAn LayTheoMa(string maDoAn)
        {
            try
            {
                return DoAnDAL.LayTheoMa(maDoAn);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy đồ ăn '{maDoAn}': {ex.Message}");
            }
        }
    }
}