using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BUS
{
    public class PhimBUS
    {
        public static List<Phim> LayTatCa()
        {
            try
            {
                return PhimDAL.LayTatCa();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách phim: " + ex.Message);
            }
        }

     

        public static void CapNhat(Phim obj)
        {
            PhimDAL.CapNhat(obj);
        }

        public static void Xoa(string id)
        {
            PhimDAL.Xoa(id);
        }

        public static void Them(Phim obj)
        {
            var danhSach = PhimDAL.LayTatCa();
            if (danhSach.Any(p => p.MaPhim == obj.MaPhim))
                throw new Exception("Mã phim đã tồn tại!");
            PhimDAL.Them(obj);
        }
        public static Phim LayTheoMa(string maPhim)
        {
            if (string.IsNullOrEmpty(maPhim))
                throw new Exception("Mã phim không được để trống!");

            try
            {
                return PhimDAL.LayTheoMa(maPhim);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin phim: " + ex.Message);
            }
        }
    }
}
