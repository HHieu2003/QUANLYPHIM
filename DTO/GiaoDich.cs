using System;

namespace DTO
{
    public class GiaoDich
    {
        public string MaGiaoDich { get; set; }
        public string MaXacNhan { get; set; }
        public string MaKhachHang { get; set; }
        public string MaDonHang { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
    }
}