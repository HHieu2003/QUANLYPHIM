using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BUS
{
    public class PhongChieuBUS
    {
        public static List<PhongChieu> LayTatCa()
        {
            try
            {
                return PhongChieuDAL.LayTatCa();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách phòng chiếu: {ex.Message}");
            }
        }

        public static void Them(PhongChieu obj)
        {
            if (obj == null)
                throw new Exception("Phòng chiếu không được để trống!");
            if (string.IsNullOrEmpty(obj.MaPhong))
                throw new Exception("Mã phòng chiếu không được để trống!");
            if (string.IsNullOrEmpty(obj.TenPhong))
                throw new Exception("Tên phòng chiếu không được để trống!");
            if (obj.SoLuongGhe <= 0)
                throw new Exception("Số lượng ghế phải lớn hơn 0!");
            if (string.IsNullOrEmpty(obj.TrangThai) || !new[] { "hoatdong", "baotri" }.Contains(obj.TrangThai))
                throw new Exception("Trạng thái phải là 'hoatdong' hoặc 'baotri'!");

            var danhSach = PhongChieuDAL.LayTatCa();
            if (danhSach.Any(pc => pc.MaPhong == obj.MaPhong))
                throw new Exception($"Mã phòng chiếu {obj.MaPhong} đã tồn tại!");

            try
            {
                PhongChieuDAL.Them(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm phòng chiếu với mã {obj.MaPhong}: {ex.Message}");
            }
        }

        public static void CapNhat(PhongChieu obj)
        {
            if (obj == null)
                throw new Exception("Phòng chiếu không được để trống!");
            if (string.IsNullOrEmpty(obj.MaPhong))
                throw new Exception("Mã phòng chiếu không được để trống!");
            if (string.IsNullOrEmpty(obj.TenPhong))
                throw new Exception("Tên phòng chiếu không được để trống!");
            if (obj.SoLuongGhe <= 0)
                throw new Exception("Số lượng ghế phải lớn hơn 0!");
            if (string.IsNullOrEmpty(obj.TrangThai) || !new[] { "hoatdong", "baotri" }.Contains(obj.TrangThai))
                throw new Exception("Trạng thái phải là 'hoatdong' hoặc 'baotri'!");

            try
            {
                PhongChieuDAL.CapNhat(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật phòng chiếu với mã {obj.MaPhong}: {ex.Message}");
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Mã phòng chiếu không được để trống!");

            try
            {
                PhongChieuDAL.Xoa(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa phòng chiếu với mã {id}: {ex.Message}");
            }
        }

        public static PhongChieu LayTheoMa(string maPhong)
        {
            if (string.IsNullOrEmpty(maPhong))
                throw new Exception("Mã phòng chiếu không được để trống!");

            try
            {
                return PhongChieuDAL.LayTheoMa(maPhong);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin phòng chiếu với mã {maPhong}: {ex.Message}");
            }
        }
    }
}