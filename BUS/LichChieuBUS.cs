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
            return LichChieuDAL.LayTatCa();
        }

        public static void Them(LichChieu obj)
        {
            var danhSach = LichChieuDAL.LayTatCa();
            if (danhSach.Any(lc => lc.MaLichChieu == obj.MaLichChieu))
                throw new Exception("Mã lịch chiếu đã tồn tại!");
            LichChieuDAL.Them(obj);
        }

        public static void CapNhat(LichChieu obj)
        {
            LichChieuDAL.CapNhat(obj);
        }

        public static void Xoa(string id)
        {
            LichChieuDAL.Xoa(id);
        }

        public static bool KiemTraTrungLich(LichChieu lichChieu, string truMaLichChieu = null)
        {
            var danhSach = LayTatCa();
            var phimList = PhimBUS.LayTatCa();
            var phim = phimList.FirstOrDefault(p => p.MaPhim == lichChieu.MaPhim);
            if (phim == null) throw new Exception("Phim không tồn tại!");

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