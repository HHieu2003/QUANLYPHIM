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
            return VeDAL.LayTatCa();
        }

        public static void Them(Ve obj)
        {
            var danhSach = VeDAL.LayTatCa();
            if (danhSach.Any(v => v.MaVe == obj.MaVe))
                throw new Exception("Mã vé đã tồn tại!");
            if (danhSach.Any(v => v.MaLichChieu == obj.MaLichChieu && v.SoGhe == obj.SoGhe))
                throw new Exception("Ghế này đã được đặt cho lịch chiếu này!");
            VeDAL.Them(obj);
        }

        public static void Xoa(string id)
        {
            VeDAL.Xoa(id);
        }

        public static List<Ve> LayTheoLichChieu(string maLichChieu)
        {
            return VeDAL.LayTheoLichChieu(maLichChieu);
        }

        public static decimal TinhGiaVe(string maLichChieu, string maLoaiVe)
        {
            var lichChieu = LichChieuBUS.LayTatCa().FirstOrDefault(lc => lc.MaLichChieu == maLichChieu);
            var loaiVe = LoaiVeBUS.LayTatCa().FirstOrDefault(lv => lv.MaLoaiVe == maLoaiVe);
            if (lichChieu == null || loaiVe == null) return 0;
            return lichChieu.GiaVe + loaiVe.PhuThu;
        }
    }
}