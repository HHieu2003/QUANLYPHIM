using System;
using DAL;
using DTO;

namespace BUS
{
    public class GiaoDichBUS
    {
        public static void Them(GiaoDich giaoDich)
        {
            if (giaoDich == null)
                throw new Exception("Giao dịch không được để trống!");
            if (string.IsNullOrEmpty(giaoDich.MaGiaoDich))
                throw new Exception("Mã giao dịch không được để trống!");
            if (string.IsNullOrEmpty(giaoDich.MaXacNhan))
                throw new Exception("Mã xác nhận không được để trống!");
            if (string.IsNullOrEmpty(giaoDich.MaKhachHang))
                throw new Exception("Mã khách hàng không được để trống!");

            if (GiaoDichDAL.KiemTraTonTai(giaoDich.MaGiaoDich))
                throw new Exception($"Mã giao dịch '{giaoDich.MaGiaoDich}' đã tồn tại!");

            try
            {
                GiaoDichDAL.Them(giaoDich);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm giao dịch '{giaoDich.MaGiaoDich}': {ex.Message}");
            }
        }

        public static GiaoDich LayTheoMaXacNhan(string maXacNhan)
        {
            if (string.IsNullOrEmpty(maXacNhan))
                throw new Exception("Mã xác nhận không được để trống!");

            try
            {
                return GiaoDichDAL.LayTheoMaXacNhan(maXacNhan);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy giao dịch theo mã xác nhận '{maXacNhan}': {ex.Message}");
            }
        }

        public static void CapNhatTrangThai(string maXacNhan, string trangThai)
        {
            if (string.IsNullOrEmpty(maXacNhan))
                throw new Exception("Mã xác nhận không được để trống!");
            if (string.IsNullOrEmpty(trangThai))
                throw new Exception("Trạng thái không được để trống!");

            try
            {
                GiaoDichDAL.CapNhatTrangThai(maXacNhan, trangThai);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái giao dịch '{maXacNhan}': {ex.Message}");
            }
        }
    }
}