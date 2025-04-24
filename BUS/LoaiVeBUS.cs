using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public static void Them(LoaiVe obj)
        {
            var danhSach = LoaiVeDAL.LayTatCa();
            if (danhSach.Any(lv => lv.MaLoaiVe == obj.MaLoaiVe))
                throw new Exception("Mã loại vé đã tồn tại!");
            LoaiVeDAL.Them(obj);
        }

        public static void Xoa(string id)
        {
            var veList = VeDAL.LayTatCa();
            if (veList.Any(v => v.MaLoaiVe == id))
                throw new Exception("Loại vé đang được sử dụng, không thể xóa!");
            LoaiVeDAL.Xoa(id);
        }

        public static void Sua(LoaiVe obj)
        {
            LoaiVeDAL.Sua(obj);
        }
     

        public static LoaiVe LayTheoMa(string maLoaiVe)
        {
            if (string.IsNullOrEmpty(maLoaiVe))
                throw new Exception("Mã loại vé không được để trống!");

            try
            {
                return LoaiVeDAL.LayTheoMa(maLoaiVe);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin loại vé: " + ex.Message);
            }
        }
    }
}