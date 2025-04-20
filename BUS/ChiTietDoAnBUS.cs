using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class ChiTietDoAnBUS
    {
        public static List<ChiTietDoAn> LayTheoDon(string maDon)
        {
            return ChiTietDoAnDAL.LayTheoDon(maDon);
        }

        public static void Them(ChiTietDoAn obj)
        {
            ChiTietDoAnDAL.Them(obj);
        }

        public static void Xoa(string id)
        {
            ChiTietDoAnDAL.Xoa(id);
        }
  
    }
}
