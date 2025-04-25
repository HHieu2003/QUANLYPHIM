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
        private List<string> selectedGheList = new List<string>(); // Danh sách ghế được chọn
        private List<Ve> veListToCreate = new List<Ve>(); // Danh sách vé sẽ tạo
        private List<DoAn> doAnList; // Danh sách đồ ăn
        private Dictionary<string, int> selectedDoAnDict = new Dictionary<string, int>(); // Danh sách đồ ăn được chọn (MaDoAn, SoLuong)
        private decimal tongTienVe = 0;
        private decimal tongTienDoAn = 0;

        public frmBanVe()
        {
            InitializeComponent();
            LoadData();
            // Thiết lập thuộc tính cho txtHoaDon
            txtHoaDon.Multiline = true;
            txtHoaDon.WordWrap = true;
            txtHoaDon.Font = new Font("Courier New", 10);
            txtHoaDon.ScrollBars = ScrollBars.Vertical;
        }

        private void LoadData()
        {
            // Load phim
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

            // Load loại vé
            var loaiVeList = LoaiVeBUS.LayTatCa();
            if (loaiVeList == null || loaiVeList.Count == 0)
            {
                MessageBox.Show("Không có loại vé nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cboLoaiVe.DataSource = loaiVeList;
            cboLoaiVe.DisplayMember = "TenLoaiVe";
            cboLoaiVe.ValueMember = "MaLoaiVe";

            // Load đồ ăn
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
            // Thêm cột số lượng
            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn
            {
                Name = "SoLuong",
                HeaderText = "Số Lượng",
                DataPropertyName = "SoLuong"
            };
            dgvDoAn.Columns.Add(colSoLuong);

            // Đăng ký sự kiện CellValueChanged sau khi cột SoLuong được thêm
            dgvDoAn.CellValueChanged -= dgvDoAn_CellValueChanged;
            dgvDoAn.CellValueChanged += dgvDoAn_CellValueChanged;

            // Reset form
            ResetForm();
        }

        private void ResetForm()
        {
            txtMaKhachHang.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
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

        private void btnTraCuuKhachHang_Click(object sender, EventArgs e)
        {
            string soDienThoai = txtSoDienThoai.Text.Trim();
            if (string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại để tra cứu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var khachHang = KhachHangBUS.TimKiemTheoSoDienThoai(soDienThoai);
                if (khachHang != null)
                {
                    txtMaKhachHang.Text = khachHang.MaKhachHang;
                    txtHoTen.Text = khachHang.HoTen;
                    txtEmail.Text = khachHang.Email;
                }
                else
                {
                    MessageBox.Show("Khách hàng không tồn tại. Vui lòng nhập thông tin để thêm mới khi thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaKhachHang.Clear();
                    txtHoTen.Clear();
                    txtEmail.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Tính tiền vé
            if (cboLichChieu.SelectedValue == null || cboLoaiVe.SelectedValue == null || selectedGheList.Count == 0)
            {
                tongTienVe = 0;
            }
            else
            {
                decimal giaVe = VeBUS.TinhGiaVe(cboLichChieu.SelectedValue.ToString(), cboLoaiVe.SelectedValue.ToString());
                tongTienVe = giaVe * selectedGheList.Count;
            }

            // Tính tiền đồ ăn
            TinhTongTienDoAn();

            // Tổng tiền
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

        // Hàm tạo mã xác nhận ngẫu nhiên
        private string TaoMaXacNhan()
        {
            Random random = new Random();
            string maXacNhan = "XN-" + random.Next(100000, 999999).ToString();
            return maXacNhan;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin khách hàng
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ số điện thoại và họ tên khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            // Kiểm tra khách hàng đã tồn tại hay chưa
            string maKhachHang = null;
            var khachHang = KhachHangBUS.TimKiemTheoSoDienThoai(soDienThoai);
            if (khachHang != null)
            {
                // Khách hàng đã tồn tại, sử dụng MaKhachHang
                maKhachHang = khachHang.MaKhachHang;
            }
            else
            {
                // Khách hàng chưa tồn tại, thêm mới
                maKhachHang = "KH" + Guid.NewGuid().ToString().Substring(0, 8); // Tạo mã khách hàng mới
                KhachHang khachHangMoi = new KhachHang
                {
                    MaKhachHang = maKhachHang,
                    HoTen = hoTen,
                    SoDienThoai = soDienThoai,
                    Email = email
                };
                try
                {
                    KhachHangBUS.Them(khachHangMoi);
                    MessageBox.Show("Đã thêm khách hàng mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Tạo vé
            veListToCreate.Clear();
            foreach (var soGhe in selectedGheList)
            {
                Ve ve = new Ve
                {
                    MaVe = Guid.NewGuid().ToString(),
                    MaLichChieu = cboLichChieu.SelectedValue.ToString(),
                    MaLoaiVe = cboLoaiVe.SelectedValue.ToString(),
                    MaKhachHang = maKhachHang,
                    SoGhe = soGhe,
                    NgayDat = DateTime.Now
                };
                veListToCreate.Add(ve);
            }

            // Tạo đơn hàng (nếu có đồ ăn)
            string maDonHang = null;
            if (selectedDoAnDict.Count > 0)
            {
                maDonHang = Guid.NewGuid().ToString().Substring(0,10);
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
                            MaChiTiet = Guid.NewGuid().ToString().Substring(0,10),
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

            // Thêm vé vào database
            try
            {
                foreach (var ve in veListToCreate)
                {
                    VeBUS.Them(ve);
                }
                // Tạo mã xác nhận và hiển thị
                string maXacNhan = TaoMaXacNhan();
                MessageBox.Show($"Thanh toán thành công! Đã tạo vé.\nMã xác nhận của bạn: {maXacNhan}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiHoaDon(maDonHang, maXacNhan); // Truyền mã xác nhận vào hóa đơn
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
            var khachHang = KhachHangBUS.TimKiemTheoSoDienThoai(txtSoDienThoai.Text.Trim());

            // Định dạng hóa đơn
            string hoaDon = $"----- HÓA ĐƠN BÁN VÉ -----{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"Mã xác nhận: {maXacNhan}{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"Khách hàng: {khachHang.HoTen}{Environment.NewLine}";
            hoaDon += $"Số điện thoại: {khachHang.SoDienThoai}{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"Phim: {phim.TenPhim}{Environment.NewLine}";
            hoaDon += $"Lịch chiếu: {lichChieu.GioBatDau:dd/MM/yyyy HH:mm}{Environment.NewLine}";
            hoaDon += $"Loại vé: {loaiVe.TenLoaiVe}{Environment.NewLine}";
            hoaDon += $"\nDanh sách ghế: {string.Join(", ", selectedGheList)}{Environment.NewLine}";
            hoaDon += $"\nSố lượng vé: {veListToCreate.Count}{Environment.NewLine}";
            hoaDon += $"\nTổng tiền vé: {tongTienVe:N0} VND{Environment.NewLine}";

            if (maDonHang != null)
            {
                var chiTietDoAnList = ChiTietDoAnBUS.LayTheoDon(maDonHang);
                if (chiTietDoAnList != null && chiTietDoAnList.Count > 0)
                {
                    hoaDon += $"\n----- ĐỒ ĂN -----\n{Environment.NewLine}{Environment.NewLine}";
                    foreach (var chiTiet in chiTietDoAnList)
                    {
                        var doAn = doAnList.FirstOrDefault(da => da.MaDoAn == chiTiet.MaDoAn);
                        if (doAn != null)
                        {
                            hoaDon += $"{doAn.TenDoAn}: {chiTiet.SoLuong} x {chiTiet.Gia:N0} = {chiTiet.ThanhTien:N0} VND\n{Environment.NewLine}{Environment.NewLine}";
                        }
                    }
                    hoaDon += $"nTổng tiền đồ ăn: {tongTienDoAn:N0} VND\n{Environment.NewLine}{Environment.NewLine}";
                }
            }

            hoaDon += $"\n\nTổng tiền: {(tongTienVe + tongTienDoAn):N0} VND\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"\nNgày đặt: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"\nCảm ơn quý khách đã sử dụng dịch vụ!{Environment.NewLine}{Environment.NewLine}";

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
            string maKhachHang = txtMaKhachHang.Text.Trim();
            if (string.IsNullOrEmpty(maKhachHang))
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng trước khi mua đồ ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new frmBanDoAn(maKhachHang))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Đã đặt đồ ăn thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TinhTongTien(); // Cập nhật lại tổng tiền trong frmBanVe nếu cần
                }
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