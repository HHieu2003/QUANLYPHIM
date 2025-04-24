using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BUS
{
    public class PhongChieuBUS
    {
        public static List<PhongChieu> LayTatCa()
        {
            return PhongChieuDAL.LayTatCa();
        }

        public static void Them(PhongChieu obj)
        {
            var danhSach = PhongChieuDAL.LayTatCa();
            if (danhSach.Any(pc => pc.MaPhong == obj.MaPhong))
                throw new Exception("Mã phòng chiếu đã tồn tại!");
            PhongChieuDAL.Them(obj);
        }

        public static void CapNhat(PhongChieu obj)
        {
            PhongChieuDAL.CapNhat(obj);
        }

        public static void Xoa(string id)
        {
            PhongChieuDAL.Xoa(id);
        }

        public static PhongChieu LayTheoMa(string maPhong)
        {
            if (string.IsNullOrEmpty(maPhong))
                throw new Exception("Mã phòng chiếu không được để trống!");

            try
            {
                return PhongChieuDAL.LayTheoMa(maPhong);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin phòng chiếu: " + ex.Message);
            }
        }
    }
}