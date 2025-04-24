using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BUS
{
    public class LichChieuBUS
    {
        public static List<LichChieu> LayTatCa()
        {
            try
            {
                return LichChieuDAL.LayTatCa();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách lịch chiếu: {ex.Message}");
            }
        }

        public static LichChieu LayTheoMa(string maLichChieu)
        {
            if (string.IsNullOrEmpty(maLichChieu))
                throw new Exception("Mã lịch chiếu không được để trống!");

            try
            {
                return LichChieuDAL.LayTheoMa(maLichChieu);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin lịch chiếu với mã {maLichChieu}: {ex.Message}");
            }
        }

        public static void Them(LichChieu obj)
        {
            if (obj == null)
                throw new Exception("Lịch chiếu không được để trống!");
            if (string.IsNullOrEmpty(obj.MaLichChieu))
                throw new Exception("Mã lịch chiếu không được để trống!");
            if (string.IsNullOrEmpty(obj.MaPhim))
                throw new Exception("Mã phim không được để trống!");
            if (string.IsNullOrEmpty(obj.MaPhong))
                throw new Exception("Mã phòng không được để trống!");
            if (obj.GioBatDau < DateTime.Now)
                throw new Exception("Giờ bắt đầu không được là thời điểm trong quá khứ!");
            if (obj.GiaVe < 0)
                throw new Exception("Giá vé không được âm!");

            var danhSach = LichChieuDAL.LayTatCa();
            if (danhSach.Any(lc => lc.MaLichChieu == obj.MaLichChieu))
                throw new Exception($"Mã lịch chiếu {obj.MaLichChieu} đã tồn tại!");

            if (KiemTraTrungLich(obj))
                throw new Exception("Lịch chiếu bị trùng với một lịch chiếu khác trong cùng phòng!");

            try
            {
                LichChieuDAL.Them(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm lịch chiếu với mã {obj.MaLichChieu}: {ex.Message}");
            }
        }

        public static void CapNhat(LichChieu obj)
        {
            if (obj == null)
                throw new Exception("Lịch chiếu không được để trống!");
            if (string.IsNullOrEmpty(obj.MaLichChieu))
                throw new Exception("Mã lịch chiếu không được để trống!");
            if (string.IsNullOrEmpty(obj.MaPhim))
                throw new Exception("Mã phim không được để trống!");
            if (string.IsNullOrEmpty(obj.MaPhong))
                throw new Exception("Mã phòng không được để trống!");
            if (obj.GioBatDau < DateTime.Now)
                throw new Exception("Giờ bắt đầu không được là thời điểm trong quá khứ!");
            if (obj.GiaVe < 0)
                throw new Exception("Giá vé không được âm!");

            if (KiemTraTrungLich(obj, obj.MaLichChieu))
                throw new Exception("Lịch chiếu bị trùng với một lịch chiếu khác trong cùng phòng!");

            try
            {
                LichChieuDAL.CapNhat(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật lịch chiếu với mã {obj.MaLichChieu}: {ex.Message}");
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Mã lịch chiếu không được để trống!");

            try
            {
                LichChieuDAL.Xoa(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa lịch chiếu với mã {id}: {ex.Message}");
            }
        }

        public static bool KiemTraTrungLich(LichChieu lichChieu, string truMaLichChieu = null)
        {
            var danhSach = LayTatCa();
            var phimList = PhimBUS.LayTatCa();
            var phim = phimList.FirstOrDefault(p => p.MaPhim == lichChieu.MaPhim);
            if (phim == null) throw new Exception($"Phim với mã {lichChieu.MaPhim} không tồn tại!");

            var gioKetThucMoi = lichChieu.GioBatDau.AddMinutes(phim.ThoiLuong);

            foreach (var lc in danhSach)
            {
                if (lc.MaLichChieu == truMaLichChieu) continue; // Bỏ qua lịch chiếu hiện tại khi sửa
                var phimHienTai = phimList.FirstOrDefault(p => p.MaPhim == lc.MaPhim);
                if (phimHienTai == null) continue;

                var gioKetThucHienTai = lc.GioBatDau.AddMinutes(phimHienTai.ThoiLuong);

                if (lc.MaPhong == lichChieu.MaPhong &&
                    !(gioKetThucMoi <= lc.GioBatDau || lichChieu.GioBatDau >= gioKetThucHienTai))
                {
                    return true; // Có trùng lịch
                }
            }
            return false;
        }
      
    }
}