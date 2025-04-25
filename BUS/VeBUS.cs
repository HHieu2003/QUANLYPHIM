using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BUS
{
    public class VeBUS
    {
        public static List<Ve> LayTatCa()
        {
            try
            {
                return VeDAL.LayTatCa();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách vé: {ex.Message}");
            }
        }

        public static void Them(Ve obj)
        {
            if (obj == null)
                throw new Exception("Vé không được để trống!");
            /*if (obj.MaVe == Guid.Empty)
                throw new Exception("Mã vé không được để trống!");*/
            if (string.IsNullOrEmpty(obj.MaLichChieu))
                throw new Exception("Mã lịch chiếu không được để trống!");
            if (string.IsNullOrEmpty(obj.MaLoaiVe))
                throw new Exception("Mã loại vé không được để trống!");
            if (string.IsNullOrEmpty(obj.MaKhachHang))
                throw new Exception("Mã khách hàng không được để trống!");
            if (string.IsNullOrEmpty(obj.SoGhe))
                throw new Exception("Số ghế không được để trống!");

            var danhSach = VeDAL.LayTatCa();
            if (danhSach.Any(v => v.MaVe == obj.MaVe))
                throw new Exception($"Mã vé {obj.MaVe} đã tồn tại!");
            if (danhSach.Any(v => v.MaLichChieu == obj.MaLichChieu && v.SoGhe == obj.SoGhe))
                throw new Exception($"Ghế {obj.SoGhe} đã được đặt cho lịch chiếu này!");

            try
            {
                VeDAL.Them(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm vé với mã {obj.MaVe}: {ex.Message}");
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Mã vé không được để trống!");

            try
            {
                VeDAL.Xoa(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa vé với mã {id}: {ex.Message}");
            }
        }

        public static List<Ve> LayTheoLichChieu(string maLichChieu)
        {
            if (string.IsNullOrEmpty(maLichChieu))
                throw new Exception("Mã lịch chiếu không được để trống!");

            try
            {
                return VeDAL.LayTheoLichChieu(maLichChieu);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách vé theo lịch chiếu {maLichChieu}: {ex.Message}");
            }
        }

        public static decimal TinhGiaVe(string maLichChieu, string maLoaiVe)
        {
            if (string.IsNullOrEmpty(maLichChieu))
                throw new Exception("Mã lịch chiếu không được để trống!");
            if (string.IsNullOrEmpty(maLoaiVe))
                throw new Exception("Mã loại vé không được để trống!");

            try
            {
                var lichChieu = LichChieuBUS.LayTheoMa(maLichChieu);
                var loaiVe = LoaiVeBUS.LayTheoMa(maLoaiVe);
                if (lichChieu == null || loaiVe == null)
                    return 0;
                return lichChieu.GiaVe + loaiVe.PhuThu;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tính giá vé: {ex.Message}");
            }
        }
        public static List<Ve> LayTheoGiaoDich(string maGiaoDich)
        {
            if (string.IsNullOrEmpty(maGiaoDich))
                throw new Exception("Mã giao dịch không được để trống!");

            try
            {
                return VeDAL.LayTheoGiaoDich(maGiaoDich);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách vé theo giao dịch '{maGiaoDich}': {ex.Message}");
            }
        }
    }
}