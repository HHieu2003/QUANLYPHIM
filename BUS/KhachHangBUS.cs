using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class KhachHangBUS
    {
        public static List<KhachHang> LayTatCa()
        {
            return KhachHangDAL.LayTatCa();
        }

    }
}
