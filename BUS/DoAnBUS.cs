using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class DoAnBUS
    {
        public static List<DoAn> LayTatCa()
        {
            return DoAnDAL.LayTatCa();
        }

        public static void Them(DoAn obj)
        {
            DoAnDAL.Them(obj);
        }

        public static void Xoa(string id)
        {
            DoAnDAL.Xoa(id);
        }
    }
}
