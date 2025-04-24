using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class ChiTietDoAnBUS
    {
        public static List<ChiTietDoAn> LayTheoDon(string maDon)
        {
            if (string.IsNullOrEmpty(maDon))
                throw new Exception("Mã đơn hàng không được để trống!");

            try
            {
                return ChiTietDoAnDAL.LayTheoDon(maDon);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy chi tiết đơn hàng theo mã đơn {maDon}: {ex.Message}");
            }
        }

        public static void Them(ChiTietDoAn obj)
        {
            if (obj == null)
                throw new Exception("Chi tiết đơn hàng không được để trống!");
            if (string.IsNullOrEmpty(obj.MaChiTiet))
                throw new Exception("Mã chi tiết không được để trống!");
            if (string.IsNullOrEmpty(obj.MaDonHang))
                throw new Exception("Mã đơn hàng không được để trống!");
            if (string.IsNullOrEmpty(obj.MaDoAn))
                throw new Exception("Mã đồ ăn không được để trống!");
            if (obj.SoLuong <= 0)
                throw new Exception("Số lượng phải lớn hơn 0!");
            if (obj.Gia < 0)
                throw new Exception("Giá không được âm!");
            if (obj.ThanhTien < 0)
                throw new Exception("Thành tiền không được âm!");

            try
            {
                ChiTietDoAnDAL.Them(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm chi tiết đơn hàng: {ex.Message}");
            }
        }

        public static void CapNhat(ChiTietDoAn obj)
        {
            if (obj == null)
                throw new Exception("Chi tiết đơn hàng không được để trống!");
            if (string.IsNullOrEmpty(obj.MaChiTiet))
                throw new Exception("Mã chi tiết không được để trống!");
            if (obj.SoLuong <= 0)
                throw new Exception("Số lượng phải lớn hơn 0!");
            if (obj.Gia < 0)
                throw new Exception("Giá không được âm!");
            if (obj.ThanhTien < 0)
                throw new Exception("Thành tiền không được âm!");

            try
            {
                ChiTietDoAnDAL.CapNhat(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật chi tiết đơn hàng: {ex.Message}");
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Mã chi tiết không được để trống!");

            try
            {
                ChiTietDoAnDAL.Xoa(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa chi tiết đơn hàng: {ex.Message}");
            }
        }
    }
}