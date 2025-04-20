using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class BaoCaoBUS
    {
        public static List<BaoCao> LayTatCa()
        {
            return BaoCaoDAL.LayTatCa();
        }

        public static void Them(BaoCao obj)
        {
            BaoCaoDAL.Them(obj);
        }

        public static void Xoa(string id)
        {
            BaoCaoDAL.Xoa(id);
        }
    }
}
