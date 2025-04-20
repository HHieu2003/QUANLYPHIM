using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class LoaiVeBUS
    {
        public static List<LoaiVe> LayTatCa()
        {
            return LoaiVeDAL.LayTatCa();
        }
    }
}