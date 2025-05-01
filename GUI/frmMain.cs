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
            var theLoaiList = TheLoaiPhimBUS.LayTatCa();
            cboTheLoai.DataSource = theLoaiList;
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";
            cboTheLoai.SelectedIndex = -1;

            var loaiVeList = LoaiVeBUS.LayTatCa();
            cboLoaiVe.DataSource = loaiVeList;
            cboLoaiVe.DisplayMember = "TenLoaiVe";
            cboLoaiVe.ValueMember = "MaLoaiVe";
            cboLoaiVe.SelectedIndex = -1;

            ResetForm();
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
            foreach (var phim in phimList)
            {
                lstPhim.Items.Add(new ListViewItem(new[] { phim.TenPhim, phim.MoTa }) { Tag = phim.MaPhim });
            }
        }

        private void cboTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTheLoai.SelectedValue != null)
            {
                string maTheLoai = cboTheLoai.SelectedValue.ToString();
                var phimList = PhimBUS.LayTheoTheLoai(maTheLoai);
                lstPhim.Items.Clear();
                foreach (var phim in phimList)
                {
                    lstPhim.Items.Add(new ListViewItem(new[] { phim.TenPhim, phim.MoTa }) { Tag = phim.MaPhim });
                }
            }
        }

        private void lstPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPhim.SelectedItems.Count > 0)
            {
                string maPhim = lstPhim.SelectedItems[0].Tag.ToString();
                var lichChieuList = LichChieuBUS.LayTatCa().Where(lc => lc.MaPhim == maPhim).ToList();
                cboLichChieu.DataSource = lichChieuList;
                cboLichChieu.DisplayMember = "GioBatDau";
                cboLichChieu.ValueMember = "MaLichChieu";
                btnChonGhe.Enabled = lichChieuList.Count > 0;
            }
        }

        private void cboLoaiVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void btnChonGhe_Click(object sender, EventArgs e)
        {
            if (cboLichChieu.SelectedValue == null) return;
            using (var frm = new frmSoDoGhe(cboLichChieu.SelectedValue.ToString()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    selectedGheList = frm.SelectedGheList;
                    txtGhe.Text = string.Join(", ", selectedGheList);
                    btnThanhToan.Enabled = selectedGheList.Count > 0;
                    TinhTongTien();
                }
            }
        }

        private void btnMuaDoAn_Click(object sender, EventArgs e)
        {
            using (var frm = new frmMuaDoAn(maKhachHang, hoTenKhachHang))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    tongTienDoAn = frm.TongTienDoAn;
                    maDonHang = frm.MaDonHang;
                    TinhTongTien();
                    MessageBox.Show("Đã thêm đồ ăn vào hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void TinhTongTien()
        {
            if (cboLichChieu.SelectedValue != null && cboLoaiVe.SelectedValue != null && selectedGheList.Count > 0)
            {
                decimal giaVe = VeBUS.TinhGiaVe(cboLichChieu.SelectedValue.ToString(), cboLoaiVe.SelectedValue.ToString());
                tongTienVe = giaVe * selectedGheList.Count;
            }
            else tongTienVe = 0;

            txtTongTien.Text = (tongTienVe + tongTienDoAn).ToString("N0");
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string maGiaoDich = "GD-" + Guid.NewGuid().ToString("N").Substring(0, 8);
            string maXacNhan = "XN-" + new Random().Next(100000, 999999);

            if (!KhachHangBUS.KiemTraTonTai(maKhachHang))
            {
                MessageBox.Show("Khách hàng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            veListToCreate.Clear();
            foreach (string ghe in selectedGheList)
            {
                veListToCreate.Add(new Ve
                {
                    MaVe = Guid.NewGuid().ToString(),
                    MaLichChieu = cboLichChieu.SelectedValue.ToString(),
                    MaLoaiVe = cboLoaiVe.SelectedValue.ToString(),
                    MaKhachHang = maKhachHang,
                    SoGhe = ghe,
                    NgayDat = DateTime.Now,
                    MaGiaoDich = maGiaoDich
                });
            }

            string maDonHang = null;
           
                maDonHang = Guid.NewGuid().ToString().Substring(0, 10);
                DonHang donHang = new DonHang
                {
                    MaDonHang = maDonHang,
                    MaKhachHang = maKhachHang,
                    NgayTao = DateTime.Now,
                    TongTien = tongTienVe + tongTienDoAn
                };
                try
                {
                    DonHangBUS.Them(donHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tạo đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                GiaoDich giaoDich = new GiaoDich
            {
                MaGiaoDich = maGiaoDich,
                MaXacNhan = maXacNhan,
                MaKhachHang = maKhachHang,
                MaDonHang = maDonHang,
                NgayGiaoDich = DateTime.Now,
                TongTien = tongTienVe + tongTienDoAn
            };

            try
            {
                GiaoDichBUS.Them(giaoDich);
                veListToCreate.ForEach(VeBUS.Them);
                HienThiHoaDon(maXacNhan);
                btnThanhToan.Enabled = false;
                btnInHoaDon.Enabled = true;
                MessageBox.Show("Thanh toán thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In hóa đơn thành công!\n\n" + txtHoaDon.Text, "Thông báo");
            ResetForm();
        }
        private void ResetForm()
        {
            cboTheLoai.SelectedIndex = -1;
            txtTimKiem.Text = "";
            lstPhim.Items.Clear();
            cboLichChieu.DataSource = null;
            cboLoaiVe.SelectedIndex = -1;
            txtGhe.Text = "";
            txtTongTien.Text = "0";
            txtHoaDon.Text = "";
            selectedGheList.Clear();
            tongTienVe = 0;
            tongTienDoAn = 0;
            maDonHang = null;
            btnChonGhe.Enabled = false;
            btnThanhToan.Enabled = false;
            btnInHoaDon.Enabled = false;
        }

        private void HienThiHoaDon(string maXacNhan)
        {
            var lichChieu = LichChieuBUS.LayTatCa().FirstOrDefault(lc => lc.MaLichChieu == cboLichChieu.SelectedValue.ToString());
            var phim = PhimBUS.LayTatCa().FirstOrDefault(p => p.MaPhim == lichChieu.MaPhim);
            var loaiVe = LoaiVeBUS.LayTatCa().FirstOrDefault(lv => lv.MaLoaiVe == cboLoaiVe.SelectedValue.ToString());

            string hoaDon = $"----- HÓA ĐƠN -----\n {Environment.NewLine}{Environment.NewLine} Mã xác nhận: {maXacNhan}\n {Environment.NewLine}{Environment.NewLine} Khách: {hoTenKhachHang}\n {Environment.NewLine}{Environment.NewLine} Phim: {phim?.TenPhim}\n" +
                $" {Environment.NewLine}{Environment.NewLine} Giờ: {lichChieu?.GioBatDau:dd/MM/yyyy HH:mm}\n" +
                $"{Environment.NewLine}{Environment.NewLine}" +
                $" Loại vé: {loaiVe?.TenLoaiVe}\n" +
                $"{Environment.NewLine}{Environment.NewLine} Ghế: {string.Join(", ", selectedGheList)}\n" +
                $"{Environment.NewLine}{Environment.NewLine} Số vé: {selectedGheList.Count}\n" +
                $"{Environment.NewLine}{Environment.NewLine} Tổng tiền vé: {tongTienVe:N0} VND\n" +
                $"{Environment.NewLine}{Environment.NewLine}";

            if (maDonHang != null)
            {
                var chiTietDoAnList = ChiTietDoAnBUS.LayTheoDon(maDonHang);
                if (chiTietDoAnList != null && chiTietDoAnList.Count > 0)
                {
                    hoaDon += "\n--- Đồ ăn ---\n {Environment.NewLine}{Environment.NewLine} ";
                    foreach (var chiTiet in chiTietDoAnList)
                    {
                        var doAn = DoAnBUS.LayTatCa().FirstOrDefault(da => da.MaDoAn == chiTiet.MaDoAn);
                        if (doAn != null)
                        {
                            hoaDon += $"{doAn.TenDoAn}: {chiTiet.SoLuong} x {chiTiet.Gia:N0} = {chiTiet.ThanhTien:N0} VND\n {Environment.NewLine}{Environment.NewLine}";
                        }
                    }
                    hoaDon += $"Tổng tiền đồ ăn: {tongTienDoAn:N0} VND\n {Environment.NewLine}{Environment.NewLine}";
                }
            }

            hoaDon += $"\nTổng cộng: {(tongTienVe + tongTienDoAn):N0} VND\n{Environment.NewLine}{Environment.NewLine}Ngày: {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            txtHoaDon.Text = hoaDon;
        }

        // Added: Method to open frmProfile for viewing/editing personal information
        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            using (var frm = new frmProfile(maKhachHang))
            {
                frm.ShowDialog();
                // Update hoTenKhachHang in case it was changed
                var khachHang = KhachHangBUS.LayTheoMa(maKhachHang);
                if (khachHang != null)
                {
                    hoTenKhachHang = khachHang.HoTen;
                    txtHoTen.Text = hoTenKhachHang;
                }
            }
        }


        // Added: Method to open frmLichSuMuaVe for viewing purchased tickets
        private void btnLichSuMuaVe_Click(object sender, EventArgs e)
        {
            using (var frm = new frmLichSuMuaVe(maKhachHang))
            {
                frm.ShowDialog();
            }
        }
        // Added: Method to handle logout
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Login loginForm = new Login();
                loginForm.Show();
            }
        }
    }

}