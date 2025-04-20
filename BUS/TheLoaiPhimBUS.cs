using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class TheLoaiPhimBUS
    {
        public static List<TheLoaiPhim> LayTatCa()
        {
            return TheLoaiPhimDAL.LayTatCa();
        }

        public static void Them(TheLoaiPhim obj)
        {
            TheLoaiPhimDAL.Them(obj);
        }

        public static void CapNhat(TheLoaiPhim obj)
        {
            TheLoaiPhimDAL.CapNhat(obj);
        }

        public static void Xoa(string id)
        {
            TheLoaiPhimDAL.Xoa(id);
        }
    }
}
