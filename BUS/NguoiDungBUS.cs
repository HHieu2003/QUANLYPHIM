using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class NguoiDungBUS
    {
        public static List<NguoiDung> LayTatCa()
        {
            return NguoiDungDAL.LayTatCa();
        }

        public static void Them(NguoiDung obj)
        {
            NguoiDungDAL.Them(obj);
        }

        public static void CapNhat(NguoiDung obj)
        {
            NguoiDungDAL.CapNhat(obj);
        }

        public static void Xoa(string id)
        {
            NguoiDungDAL.Xoa(id);
        }
        // Thêm phương thức đăng nhập
        public static NguoiDung DangNhap(string tenDangNhap, string matKhau)
        {
            var danhSach = NguoiDungDAL.LayTatCa();
            return danhSach.Find(nd => nd.TenDangNhap == tenDangNhap && nd.MatKhau == matKhau);
        }
    }
}
