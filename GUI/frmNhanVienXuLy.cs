using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmNhanVienXuLy : Form
    {
        public frmNhanVienXuLy()
        {
            InitializeComponent();
        }

        private void frmNhanVienXuLy_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtMaXacNhan.Text = string.Empty;
            txtThongTin.Text = string.Empty;
            btnXacNhan.Enabled = false;
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            string maXacNhan = txtMaXacNhan.Text.Trim();
            if (string.IsNullOrEmpty(maXacNhan))
            {
                MessageBox.Show("Vui lòng nhập mã xác nhận!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var giaoDich = GiaoDichBUS.LayTheoMaXacNhan(maXacNhan);
                if (giaoDich == null)
                {
                    MessageBox.Show("Mã xác nhận không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    return;
                }

                if (giaoDich.TrangThai == "DaXuLy")
                {
                    MessageBox.Show("Giao dịch này đã được xử lý trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    return;
                }

                HienThiThongTin(giaoDich);
                btnXacNhan.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra mã xác nhận: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetForm();
            }
        }

        private void HienThiThongTin(GiaoDich giaoDich)
        {
            var veList = VeBUS.LayTheoGiaoDich(giaoDich.MaGiaoDich);
            if (veList == null || veList.Count == 0)
            {
                txtThongTin.Text = "Không tìm thấy vé cho giao dịch này.";
                return;
            }

            var ve = veList.First();
            var lichChieu = LichChieuBUS.LayTheoMa(ve.MaLichChieu);
            var phim = lichChieu != null ? PhimBUS.LayTheoMa(lichChieu.MaPhim) : null;
            var loaiVe = LoaiVeBUS.LayTheoMa(ve.MaLoaiVe);
            var khachHang = KhachHangBUS.LayTheoMa(giaoDich.MaKhachHang);

            decimal tongTienVe = veList.Count * VeBUS.TinhGiaVe(ve.MaLichChieu, ve.MaLoaiVe);

            string thongTin = $"----- THÔNG TIN GIAO DỊCH -----\n\n";
            thongTin += $"Mã xác nhận: {giaoDich.MaXacNhan}\n";
            thongTin += $"Khách hàng: {khachHang?.HoTen ?? "Không xác định"}\n\n";
            thongTin += $"Phim: {phim?.TenPhim ?? "Không xác định"}\n";
            thongTin += $"Lịch chiếu: {lichChieu?.GioBatDau.ToString("dd/MM/yyyy HH:mm") ?? "Không xác định"}\n";
            thongTin += $"Loại vé: {loaiVe?.TenLoaiVe ?? "Không xác định"}\n";
            thongTin += $"Danh sách ghế: {string.Join(", ", veList.Select(v => v.SoGhe))}\n";
            thongTin += $"Số lượng vé: {veList.Count}\n";
            thongTin += $"Tổng tiền vé: {tongTienVe:N0} VND\n";

            if (!string.IsNullOrEmpty(giaoDich.MaDonHang))
            {
                var chiTietDoAnList = ChiTietDoAnBUS.LayTheoDon(giaoDich.MaDonHang);
                if (chiTietDoAnList != null && chiTietDoAnList.Count > 0)
                {
                    thongTin += $"\n----- ĐỒ ĂN -----\n";
                    foreach (var chiTiet in chiTietDoAnList)
                    {
                        var doAn = DoAnBUS.LayTheoMa(chiTiet.MaDoAn);
                        if (doAn != null)
                        {
                            string tenDoAn = doAn.TenDoAn.PadRight(20, '.');
                            string soLuong = chiTiet.SoLuong.ToString().PadLeft(2, ' ');
                            string gia = $"{chiTiet.Gia:N0}".PadLeft(10, ' ');
                            string thanhTien = $"{chiTiet.ThanhTien:N0} VND".PadLeft(15, ' ');
                            thongTin += $"{tenDoAn} {soLuong} x {gia} = {thanhTien}\n";
                        }
                    }
                    decimal tongTienDoAn = chiTietDoAnList.Sum(ct => ct.ThanhTien);
                    thongTin += $"Tổng tiền đồ ăn: {tongTienDoAn:N0} VND\n";
                }
            }

            thongTin += $"\nTổng tiền: {giaoDich.TongTien:N0} VND\n";
            thongTin += $"Ngày giao dịch: {giaoDich.NgayGiaoDich:dd/MM/yyyy HH:mm:ss}\n";
            thongTin += $"Trạng thái: {giaoDich.TrangThai}\n";

            txtThongTin.Text = thongTin;
        }

        private string InVe(GiaoDich giaoDich)
        {
            var veList = VeBUS.LayTheoGiaoDich(giaoDich.MaGiaoDich);
            if (veList == null || veList.Count == 0)
            {
                return "Không tìm thấy vé để in.";
            }

            var ve = veList.First();
            var lichChieu = LichChieuBUS.LayTheoMa(ve.MaLichChieu);
            var phim = lichChieu != null ? PhimBUS.LayTheoMa(lichChieu.MaPhim) : null;
            var loaiVe = LoaiVeBUS.LayTheoMa(ve.MaLoaiVe);
            var khachHang = KhachHangBUS.LayTheoMa(giaoDich.MaKhachHang);

            decimal tongTienVe = veList.Count * VeBUS.TinhGiaVe(ve.MaLichChieu, ve.MaLoaiVe);

            string veContent = $"----- VÉ XEM PHIM -----\n\n";
            veContent += $"Mã xác nhận: {giaoDich.MaXacNhan}\n";
            veContent += $"Khách hàng: {khachHang?.HoTen ?? "Không xác định"}\n\n";
            veContent += $"Phim: {phim?.TenPhim ?? "Không xác định"}\n";
            veContent += $"Lịch chiếu: {lichChieu?.GioBatDau.ToString("dd/MM/yyyy HH:mm") ?? "Không xác định"}\n";
            veContent += $"Loại vé: {loaiVe?.TenLoaiVe ?? "Không xác định"}\n";
            veContent += $"Danh sách ghế: {string.Join(", ", veList.Select(v => v.SoGhe))}\n";
            veContent += $"Số lượng vé: {veList.Count}\n";
            veContent += $"Tổng tiền vé: {tongTienVe:N0} VND\n";

            if (!string.IsNullOrEmpty(giaoDich.MaDonHang))
            {
                var chiTietDoAnList = ChiTietDoAnBUS.LayTheoDon(giaoDich.MaDonHang);
                if (chiTietDoAnList != null && chiTietDoAnList.Count > 0)
                {
                    veContent += $"\n----- ĐỒ ĂN -----\n";
                    foreach (var chiTiet in chiTietDoAnList)
                    {
                        var doAn = DoAnBUS.LayTheoMa(chiTiet.MaDoAn);
                        if (doAn != null)
                        {
                            string tenDoAn = doAn.TenDoAn.PadRight(20, '.');
                            string soLuong = chiTiet.SoLuong.ToString().PadLeft(2, ' ');
                            string gia = $"{chiTiet.Gia:N0}".PadLeft(10, ' ');
                            string thanhTien = $"{chiTiet.ThanhTien:N0} VND".PadLeft(15, ' ');
                            veContent += $"{tenDoAn} {soLuong} x {gia} = {thanhTien}\n";
                        }
                    }
                    decimal tongTienDoAn = chiTietDoAnList.Sum(ct => ct.ThanhTien);
                    veContent += $"Tổng tiền đồ ăn: {tongTienDoAn:N0} VND\n";
                }
            }

            veContent += $"\nTổng tiền: {giaoDich.TongTien:N0} VND\n";
            veContent += $"Ngày giao dịch: {giaoDich.NgayGiaoDich:dd/MM/yyyy HH:mm:ss}\n";
            veContent += $"Trạng thái: {giaoDich.TrangThai}\n\n";
            veContent += $"Cảm ơn quý khách đã sử dụng dịch vụ!";

            return veContent;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string maXacNhan = txtMaXacNhan.Text.Trim();
            try
            {
                var giaoDich = GiaoDichBUS.LayTheoMaXacNhan(maXacNhan);
                if (giaoDich == null)
                {
                    MessageBox.Show("Giao dịch không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                GiaoDichBUS.CapNhatTrangThai(maXacNhan, "DaXuLy");

                string veContent = InVe(giaoDich);
                MessageBox.Show($"Xác nhận giao dịch thành công! Vé và đồ ăn (nếu có) đã được giao.\n\n{veContent}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận giao dịch: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}