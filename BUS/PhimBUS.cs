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
            return PhimDAL.LayTatCa();
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
    }
}
