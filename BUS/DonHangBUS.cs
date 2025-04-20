using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class DonHangBUS
    {
        public static List<DonHang> LayTatCa()
        {
            return DonHangDAL.LayTatCa();
        }

        public static void Them(DonHang obj)
        {
            DonHangDAL.Them(obj);
        }

        public static void Xoa(string id)
        {
            DonHangDAL.Xoa(id);
        }
    }
}
