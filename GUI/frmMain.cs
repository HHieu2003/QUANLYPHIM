using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmMain : Form
    {
        private string maKhachHang;
        private string hoTenKhachHang;
        private List<string> selectedGheList = new List<string>();
        private List<Ve> veListToCreate = new List<Ve>();
        private decimal tongTienVe = 0;
        private decimal tongTienDoAn = 0;
        private string maDonHang = null;

        public frmMain(string maKhachHang, string hoTenKhachHang)
        {
            InitializeComponent();
            this.maKhachHang = maKhachHang;
            this.hoTenKhachHang = hoTenKhachHang;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtHoTen.Text = hoTenKhachHang;
            LoadData();
        }

        private void LoadData()
        {
            // Load thể loại phim
            var theLoaiList = TheLoaiPhimBUS.LayTatCa();
            if (theLoaiList == null || theLoaiList.Count == 0)
            {
                MessageBox.Show("Không có thể loại phim nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cboTheLoai.DataSource = theLoaiList;
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";
            cboTheLoai.SelectedIndex = -1;

            // Load loại vé
            var loaiVeList = LoaiVeBUS.LayTatCa();
            if (loaiVeList == null || loaiVeList.Count == 0)
            {
                MessageBox.Show("Không có loại vé nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cboLoaiVe.DataSource = loaiVeList;
            cboLoaiVe.DisplayMember = "TenLoaiVe";
            cboLoaiVe.ValueMember = "MaLoaiVe";
            cboLoaiVe.SelectedIndex = -1;

            ResetForm();
        }

        private void ResetForm()
        {
            txtTimKiem.Text = string.Empty;
            cboTheLoai.SelectedIndex = -1;
            lstPhim.Items.Clear();
            cboLichChieu.DataSource = null;
            selectedGheList.Clear();
            cboLoaiVe.SelectedIndex = -1;
            txtGhe.Text = string.Empty;
            txtTongTien.Text = "0";
            txtHoaDon.Text = string.Empty;
            btnChonGhe.Enabled = false;
            btnThanhToan.Enabled = false;
            btnInHoaDon.Enabled = false;
            tongTienVe = 0;
            tongTienDoAn = 0;
            maDonHang = null;
        }

        private void cboTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTheLoai.SelectedValue != null)
            {
                string maTheLoai = cboTheLoai.SelectedValue.ToString();
                var phimList = PhimBUS.LayTheoTheLoai(maTheLoai);
                lstPhim.Items.Clear();
                if (phimList == null || phimList.Count == 0)
                {
                    MessageBox.Show("Không có phim nào thuộc thể loại này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (var phim in phimList)
                {
                    lstPhim.Items.Add(new ListViewItem(new[] { phim.TenPhim, phim.MoTa }) { Tag = phim.MaPhim });
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                cboTheLoai_SelectedIndexChanged(null, null);
                return;
            }

            var phimList = PhimBUS.TimKiem(keyword);
            lstPhim.Items.Clear();
            if (phimList == null || phimList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phim nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (var phim in phimList)
            {
                lstPhim.Items.Add(new ListViewItem(new[] { phim.TenPhim, phim.MoTa }) { Tag = phim.MaPhim });
            }
        }

        private void lstPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPhim.SelectedItems.Count > 0)
            {
                string maPhim = lstPhim.SelectedItems[0].Tag.ToString();
                var lichChieuList = LichChieuBUS.LayTatCa().Where(lc => lc.MaPhim == maPhim).ToList();
                if (lichChieuList == null || lichChieuList.Count == 0)
                {
                    MessageBox.Show("Không có lịch chiếu nào cho phim này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboLichChieu.DataSource = null;
                    btnChonGhe.Enabled = false;
                    return;
                }
                cboLichChieu.DataSource = lichChieuList;
                cboLichChieu.DisplayMember = "GioBatDau";
                cboLichChieu.ValueMember = "MaLichChieu";
                btnChonGhe.Enabled = true;
            }
            else
            {
                cboLichChieu.DataSource = null;
                btnChonGhe.Enabled = false;
            }
        }

        private void btnChonGhe_Click(object sender, EventArgs e)
        {
            if (cboLichChieu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lịch chiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLichChieu = cboLichChieu.SelectedValue.ToString();
            using (var frm = new frmSoDoGhe(maLichChieu))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    selectedGheList = frm.SelectedGheList;
                    txtGhe.Text = string.Join(", ", selectedGheList);
                    btnThanhToan.Enabled = true;
                    TinhTongTien();
                }
            }
        }

        private void cboLoaiVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            if (cboLichChieu.SelectedValue == null || cboLoaiVe.SelectedValue == null || selectedGheList.Count == 0)
            {
                tongTienVe = 0;
            }
            else
            {
                decimal giaVe = VeBUS.TinhGiaVe(cboLichChieu.SelectedValue.ToString(), cboLoaiVe.SelectedValue.ToString());
                tongTienVe = giaVe * selectedGheList.Count;
            }

            decimal tongTien = tongTienVe + tongTienDoAn;
            txtTongTien.Text = tongTien.ToString("N0");
        }

        private void btnMuaDoAn_Click(object sender, EventArgs e)
        {
            using (var frm = new frmBanDoAn(maKhachHang))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    maDonHang = frm.MaDonHang;
                    var donHang = DonHangBUS.LayTheoMa(maDonHang);
                    tongTienDoAn = donHang.TongTien;
                    TinhTongTien();
                }
            }
        }

        private string TaoMaXacNhan()
        {
            Random random = new Random();
            return "XN-" + random.Next(100000, 999999).ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedGheList.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ghế!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboLoaiVe.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại vé!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            veListToCreate.Clear();
            string maGiaoDich = "GD-" + Guid.NewGuid().ToString().Substring(0, 8);
            foreach (var soGhe in selectedGheList)
            {
                Ve ve = new Ve
                {
                    MaVe = Guid.NewGuid().ToString(), // Sử dụng toàn bộ chuỗi GUID
                    MaLichChieu = cboLichChieu.SelectedValue.ToString(),
                    MaLoaiVe = cboLoaiVe.SelectedValue.ToString(),
                    MaKhachHang = maKhachHang,
                    SoGhe = soGhe,
                    NgayDat = DateTime.Now,
                    MaGiaoDich = maGiaoDich
                };
                veListToCreate.Add(ve);
            }

            try
            {
                // Kiểm tra xem MaKhachHang có tồn tại không trước khi thêm vé
                if (!KhachHangBUS.KiemTraTonTai(maKhachHang))
                {
                    throw new Exception($"Mã khách hàng '{maKhachHang}' không tồn tại trong hệ thống. Vui lòng kiểm tra lại!");
                }

                // Tạo mã xác nhận
                string maXacNhan = TaoMaXacNhan();

                // Tạo giao dịch
                GiaoDich giaoDich = new GiaoDich
                {
                    MaGiaoDich = maGiaoDich,
                    MaXacNhan = maXacNhan,
                    MaKhachHang = maKhachHang,
                    MaDonHang = maDonHang,
                    NgayGiaoDich = DateTime.Now,
                    TongTien = tongTienVe + tongTienDoAn
                };
                GiaoDichBUS.Them(giaoDich);

                // Thêm các vé
                foreach (var ve in veListToCreate)
                {
                    VeBUS.Them(ve);
                }

                // Hiển thị thông báo thành công với mã xác nhận
                HienThiHoaDon(maXacNhan);
                MessageBox.Show($"Thanh toán thành công! Đã tạo vé.\nMã xác nhận của bạn: {maXacNhan}\nVui lòng sử dụng mã này tại rạp để nhận vé và đồ ăn (nếu có).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThanhToan.Enabled = false;
                btnInHoaDon.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HienThiHoaDon(string maXacNhan)
        {
            var lichChieu = LichChieuBUS.LayTatCa().FirstOrDefault(lc => lc.MaLichChieu == cboLichChieu.SelectedValue.ToString());
            var phim = PhimBUS.LayTatCa().FirstOrDefault(p => p.MaPhim == lichChieu.MaPhim);
            var loaiVe = LoaiVeBUS.LayTatCa().FirstOrDefault(lv => lv.MaLoaiVe == cboLoaiVe.SelectedValue.ToString());

            string hoaDon = $"----- HÓA ĐƠN BÁN VÉ -----\n\n";
            hoaDon += $"Mã xác nhận: {maXacNhan}\n\n";
            hoaDon += $"Khách hàng: {hoTenKhachHang}\n\n";
            hoaDon += $"Phim: {phim.TenPhim}\n";
            hoaDon += $"Lịch chiếu: {lichChieu.GioBatDau:dd/MM/yyyy HH:mm}\n";
            hoaDon += $"Loại vé: {loaiVe.TenLoaiVe}\n";
            hoaDon += $"Danh sách ghế: {string.Join(", ", selectedGheList)}\n";
            hoaDon += $"Số lượng vé: {veListToCreate.Count}\n";
            hoaDon += $"Tổng tiền vé: {tongTienVe:N0} VND\n";

            if (maDonHang != null)
            {
                var chiTietDoAnList = ChiTietDoAnBUS.LayTheoDon(maDonHang);
                if (chiTietDoAnList != null && chiTietDoAnList.Count > 0)
                {
                    hoaDon += $"\n----- ĐỒ ĂN -----\n";
                    foreach (var chiTiet in chiTietDoAnList)
                    {
                        var doAn = DoAnBUS.LayTatCa().FirstOrDefault(da => da.MaDoAn == chiTiet.MaDoAn);
                        if (doAn != null)
                        {
                            string tenDoAn = doAn.TenDoAn.PadRight(20, '.');
                            string soLuong = chiTiet.SoLuong.ToString().PadLeft(2, ' ');
                            string gia = $"{chiTiet.Gia:N0}".PadLeft(10, ' ');
                            string thanhTien = $"{chiTiet.ThanhTien:N0} VND".PadLeft(15, ' ');
                            hoaDon += $"{tenDoAn} {soLuong} x {gia} = {thanhTien}\n";
                        }
                    }
                    hoaDon += $"Tổng tiền đồ ăn: {tongTienDoAn:N0} VND\n";
                }
            }

            hoaDon += $"\nTổng tiền: {(tongTienVe + tongTienDoAn):N0} VND\n";
            hoaDon += $"Ngày đặt: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n\n";
            hoaDon += $"Cảm ơn quý khách đã sử dụng dịch vụ!\n";
            hoaDon += $"Vui lòng sử dụng mã xác nhận {maXacNhan} tại rạp để nhận vé và đồ ăn (nếu có).";

            txtHoaDon.Text = hoaDon;
            return hoaDon;
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hóa đơn đã được in thành công!\n\n" + txtHoaDon.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();
        }
    }
}