using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmBanVe : Form
    {
        private string maNhanVien;
        private string hoTenNhanVien;
        private List<string> selectedGheList = new List<string>();
        private List<Ve> veListToCreate = new List<Ve>();
        private List<DoAn> doAnList;
        private Dictionary<string, int> selectedDoAnDict = new Dictionary<string, int>();
        private decimal tongTienVe = 0;
        private decimal tongTienDoAn = 0;

        public frmBanVe(string maNhanVien, string hoTenNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
            this.hoTenNhanVien = hoTenNhanVien;
            txtMaNhanVien.Text = maNhanVien;
            txtHoTenNhanVien.Text = hoTenNhanVien;
            LoadData();
            txtHoaDon.Multiline = true;
            txtHoaDon.WordWrap = true;
            txtHoaDon.Font = new Font("Courier New", 10);
            txtHoaDon.ScrollBars = ScrollBars.Vertical;
        }

        private void LoadData()
        {
            var phimList = PhimBUS.LayTatCa();
            if (phimList == null || phimList.Count == 0)
            {
                MessageBox.Show("Không có phim nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cboPhim.SelectedIndexChanged -= cboPhim_SelectedIndexChanged;
            cboPhim.DataSource = phimList;
            cboPhim.DisplayMember = "TenPhim";
            cboPhim.ValueMember = "MaPhim";
            cboPhim.SelectedIndex = -1;
            cboPhim.SelectedIndexChanged += cboPhim_SelectedIndexChanged;

            var loaiVeList = LoaiVeBUS.LayTatCa();
            if (loaiVeList == null || loaiVeList.Count == 0)
            {
                MessageBox.Show("Không có loại vé nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cboLoaiVe.DataSource = loaiVeList;
            cboLoaiVe.DisplayMember = "TenLoaiVe";
            cboLoaiVe.ValueMember = "MaLoaiVe";

            doAnList = DoAnBUS.LayTatCa();
            if (doAnList == null || doAnList.Count == 0)
            {
                MessageBox.Show("Không có đồ ăn nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvDoAn.DataSource = doAnList;
            dgvDoAn.Columns["MaDoAn"].Visible = false;
            dgvDoAn.Columns["MoTa"].Visible = false;
            dgvDoAn.Columns["TenDoAn"].HeaderText = "Tên Đồ Ăn";
            dgvDoAn.Columns["Gia"].HeaderText = "Giá (VND)";
            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn
            {
                Name = "SoLuong",
                HeaderText = "Số Lượng",
                DataPropertyName = "SoLuong"
            };
            dgvDoAn.Columns.Add(colSoLuong);

            dgvDoAn.CellValueChanged -= dgvDoAn_CellValueChanged;
            dgvDoAn.CellValueChanged += dgvDoAn_CellValueChanged;

            ResetForm();
        }

        private void ResetForm()
        {
            cboPhim.SelectedIndex = -1;
            cboLichChieu.DataSource = null;
            selectedGheList.Clear();
            cboLoaiVe.SelectedIndex = -1;
            txtTongTien.Text = "0";
            txtHoaDon.Clear();
            btnChonGhe.Enabled = false;
            btnThanhToan.Enabled = false;
            btnInHoaDon.Enabled = false;
            tongTienVe = 0;
            tongTienDoAn = 0;
            selectedDoAnDict.Clear();
            foreach (DataGridViewRow row in dgvDoAn.Rows)
            {
                row.Cells["SoLuong"].Value = null;
            }
        }

        private void cboPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhim.SelectedValue != null)
            {
                string maPhim = cboPhim.SelectedValue.ToString();
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
                    MessageBox.Show($"Bạn đã chọn {selectedGheList.Count} ghế: {string.Join(", ", selectedGheList)}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnChonGhe.Enabled = false;
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

            TinhTongTienDoAn();

            decimal tongTien = tongTienVe + tongTienDoAn;
            txtTongTien.Text = tongTien.ToString("N0");
        }

        private void TinhTongTienDoAn()
        {
            tongTienDoAn = 0;
            selectedDoAnDict.Clear();

            foreach (DataGridViewRow row in dgvDoAn.Rows)
            {
                if (row.Cells["SoLuong"].Value != null && int.TryParse(row.Cells["SoLuong"].Value.ToString(), out int soLuong) && soLuong > 0)
                {
                    string maDoAn = row.Cells["MaDoAn"].Value.ToString();
                    decimal gia = Convert.ToDecimal(row.Cells["Gia"].Value);
                    tongTienDoAn += gia * soLuong;
                    selectedDoAnDict[maDoAn] = soLuong;
                }
            }
        }

        private void dgvDoAn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDoAn.Columns.Contains("SoLuong") && e.ColumnIndex == dgvDoAn.Columns["SoLuong"].Index)
            {
                TinhTongTien();
            }
        }

        private string TaoMaXacNhan()
        {
            Random random = new Random();
            string maXacNhan = "XN-" + random.Next(100000, 999999).ToString();
            return maXacNhan;
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

            string maKhachHang = "KH" + Guid.NewGuid().ToString().Substring(0, 8);
            KhachHang khachHangMoi = new KhachHang
            {
                MaKhachHang = maKhachHang,
                HoTen = "KhachHangMacDinh",
                SoDienThoai = "0000000000",
                Email = "khachhang@macdinh.com"
            };
            try
            {
                KhachHangBUS.Them(khachHangMoi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khách hàng mặc định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            veListToCreate.Clear();
            string maGiaoDich = "GD-" + Guid.NewGuid().ToString().Substring(0, 8);
            foreach (var soGhe in selectedGheList)
            {
                Ve ve = new Ve
                {
                    MaVe = Guid.NewGuid().ToString(),
                    MaLichChieu = cboLichChieu.SelectedValue.ToString(),
                    MaLoaiVe = cboLoaiVe.SelectedValue.ToString(),
                    MaKhachHang = maKhachHang,
                    SoGhe = soGhe,
                    NgayDat = DateTime.Now,
                    MaGiaoDich = maGiaoDich
                };
                veListToCreate.Add(ve);
            }

            string maDonHang = null;
            if (selectedDoAnDict.Count > 0)
            {
                maDonHang = Guid.NewGuid().ToString().Substring(0, 10);
                DonHang donHang = new DonHang
                {
                    MaDonHang = maDonHang,
                    MaKhachHang = maKhachHang,
                    NgayTao = DateTime.Now,
                    TongTien = tongTienDoAn
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

                foreach (var item in selectedDoAnDict)
                {
                    var doAn = doAnList.FirstOrDefault(da => da.MaDoAn == item.Key);
                    if (doAn != null)
                    {
                        ChiTietDoAn chiTiet = new ChiTietDoAn
                        {
                            MaChiTiet = Guid.NewGuid().ToString().Substring(0, 10),
                            MaDonHang = maDonHang,
                            MaDoAn = item.Key,
                            SoLuong = item.Value,
                            Gia = doAn.Gia,
                            ThanhTien = doAn.Gia * item.Value
                        };
                        try
                        {
                            ChiTietDoAnBUS.Them(chiTiet);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi thêm chi tiết đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            try
            {
                string maXacNhan = TaoMaXacNhan();
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

                foreach (var ve in veListToCreate)
                {
                    VeBUS.Them(ve);
                }

                MessageBox.Show($"Thanh toán thành công! Đã tạo vé.\nMã xác nhận của bạn: {maXacNhan}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiHoaDon(maDonHang, maXacNhan);
                btnThanhToan.Enabled = false;
                btnInHoaDon.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiHoaDon(string maDonHang, string maXacNhan)
        {
            var lichChieu = LichChieuBUS.LayTatCa().FirstOrDefault(lc => lc.MaLichChieu == cboLichChieu.SelectedValue.ToString());
            var phim = PhimBUS.LayTatCa().FirstOrDefault(p => p.MaPhim == lichChieu.MaPhim);
            var loaiVe = LoaiVeBUS.LayTatCa().FirstOrDefault(lv => lv.MaLoaiVe == cboLoaiVe.SelectedValue.ToString());

            string hoaDon = $"----- HÓA ĐƠN BÁN VÉ -----\n\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"Mã xác nhận: {maXacNhan}\n\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"Nhân viên: {hoTenNhanVien} (Mã: {maNhanVien})\n\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"Phim: {phim.TenPhim}\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"Lịch chiếu: {lichChieu.GioBatDau:dd/MM/yyyy HH:mm}\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"Loại vé: {loaiVe.TenLoaiVe}\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"\nDanh sách ghế: {string.Join(", ", selectedGheList)}\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"\nSố lượng vé: {veListToCreate.Count}\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"\nTổng tiền vé: {tongTienVe:N0} VND\n{Environment.NewLine}{Environment.NewLine}";



            if (maDonHang != null)
            {
                var chiTietDoAnList = ChiTietDoAnBUS.LayTheoDon(maDonHang);
                if (chiTietDoAnList != null && chiTietDoAnList.Count > 0)
                {
                    hoaDon += $"\n----- ĐỒ ĂN -----\n\n{Environment.NewLine}{Environment.NewLine}";
                    foreach (var chiTiet in chiTietDoAnList)
                    {
                        var doAn = doAnList.FirstOrDefault(da => da.MaDoAn == chiTiet.MaDoAn);
                        if (doAn != null)
                        {
                            hoaDon += $"{doAn.TenDoAn}: {chiTiet.SoLuong} x {chiTiet.Gia:N0} = {chiTiet.ThanhTien:N0} VND\n\n{Environment.NewLine}{Environment.NewLine}";
                        }
                    }
                    hoaDon += $"Tổng tiền đồ ăn: {tongTienDoAn:N0} VND\n\n{Environment.NewLine}{Environment.NewLine}";
                }
            }

            hoaDon += $"\n\nTổng tiền: {(tongTienVe + tongTienDoAn):N0} VND\n\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"\nNgày đặt: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"\nCảm ơn quý khách đã sử dụng dịch vụ!\n\n{Environment.NewLine}{Environment.NewLine}";

            txtHoaDon.Text = hoaDon;
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hóa đơn đã được in thành công!\n\n" + txtHoaDon.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackColor = Color.FromArgb(77, 182, 172);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackColor = Color.FromArgb(26, 166, 154);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var frm = new frmBanDoAn(maNhanVien, hoTenNhanVien))
            {
                frm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var frm = new frmNhanVienXuLy())
            {
                frm.ShowDialog();
            }
        }
    }
}