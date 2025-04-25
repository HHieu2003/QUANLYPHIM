using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class DonHangBUS
    {
        public static List<DonHang> LayTatCa()
        {
            try
            {
                return DonHangDAL.LayTatCa();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách đơn hàng: {ex.Message}");
            }
        }

        public static DonHang LayTheoMa(string maDonHang)
        {
            if (string.IsNullOrEmpty(maDonHang))
                throw new Exception("Mã đơn hàng không được để trống!");

            try
            {
                return DonHangDAL.LayTheoMa(maDonHang);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy đơn hàng theo mã {maDonHang}: {ex.Message}");
            }
        }

        public static void Them(DonHang obj)
        {
            if (obj == null)
                throw new Exception("Đơn hàng không được để trống!");
            if (string.IsNullOrEmpty(obj.MaDonHang))
                throw new Exception("Mã đơn hàng không được để trống!");
            if (obj.TongTien < 0)
                throw new Exception("Tổng tiền không được âm!");

            try
            {
                DonHangDAL.Them(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm đơn hàng: {ex.Message}");
            }
        }

        public static void CapNhat(DonHang obj)
        {
            if (obj == null)
                throw new Exception("Đơn hàng không được để trống!");
            if (string.IsNullOrEmpty(obj.MaDonHang))
                throw new Exception("Mã đơn hàng không được để trống!");
            if (obj.TongTien < 0)
                throw new Exception("Tổng tiền không được âm!");

            try
            {
                DonHangDAL.CapNhat(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật đơn hàng: {ex.Message}");
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Mã đơn hàng không được để trống!");

            try
            {
                DonHangDAL.Xoa(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa đơn hàng: {ex.Message}");
            }
        }
    }
}