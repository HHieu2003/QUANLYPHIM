using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmVeAndLoaiVe : Form
    {
        private Dictionary<string, Button> gheButtons = new Dictionary<string, Button>();
        private string selectedGhe = null;

        public frmVeAndLoaiVe()
        {
            InitializeComponent();
            LoadDataVe();
            LoadDataLoaiVe();
            CustomizeGridViews();
        }

        // --- Quản lý vé ---

        private void LoadDataVe()
        {
            // Load danh sách vé
            var veList = VeBUS.LayTatCa();
            dgvVe.DataSource = veList;

            // Load lịch chiếu
            var lichChieuList = LichChieuBUS.LayTatCa();
            cboLichChieu.DataSource = lichChieuList;
            cboLichChieu.DisplayMember = "MaLichChieu";
            cboLichChieu.ValueMember = "MaLichChieu";

            // Load loại vé
            var loaiVeList = LoaiVeBUS.LayTatCa();
            cboLoaiVe.DataSource = loaiVeList;
            cboLoaiVe.DisplayMember = "TenLoaiVe";
            cboLoaiVe.ValueMember = "MaLoaiVe";

            // Load khách hàng
            var khachHangList = KhachHangBUS.LayTatCa();
            cboKhachHang.DataSource = khachHangList;
            cboKhachHang.DisplayMember = "HoTen";
            cboKhachHang.ValueMember = "MaKhachHang";

            // Reset form
            ResetFormVe();
        }

        private void CustomizeGridViews()
        {
            // Customize dgvVe
            dgvVe.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 166, 154);
            dgvVe.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvVe.EnableHeadersVisualStyles = false;
            dgvVe.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvVe.DefaultCellStyle.Font = new Font("Segoe UI", 11F);

            // Customize dgvLoaiVe
            dgvLoaiVe.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 166, 154);
            dgvLoaiVe.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLoaiVe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvLoaiVe.EnableHeadersVisualStyles = false;
            dgvLoaiVe.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvLoaiVe.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
        }

        private void ResetFormVe()
        {
            txtMaVe.Clear();
            cboLichChieu.SelectedIndex = -1;
            cboLoaiVe.SelectedIndex = -1;
            cboKhachHang.SelectedIndex = -1;
            txtSoGhe.Clear();
            txtGiaVe.Clear();
            txtNgayDat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txtMaVe.Enabled = true;
            selectedGhe = null;
            tblGhe.Controls.Clear();
            gheButtons.Clear();
            dgvVe.ClearSelection();
        }

        private void DgvVe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVe.SelectedRows.Count > 0)
            {
                var row = dgvVe.SelectedRows[0];
                txtMaVe.Text = row.Cells["MaVe"].Value.ToString();
                cboLichChieu.SelectedValue = row.Cells["MaLichChieu"].Value.ToString();
                cboLoaiVe.SelectedValue = row.Cells["MaLoaiVe"].Value.ToString();
                cboKhachHang.SelectedValue = row.Cells["MaKhachHang"].Value.ToString();
                txtSoGhe.Text = row.Cells["SoGhe"].Value.ToString();
                var ngayDat = (DateTime)row.Cells["NgayDat"].Value;
                txtNgayDat.Text = ngayDat == default(DateTime)
                    ? string.Empty
                    : ngayDat.ToString("dd/MM/yyyy HH:mm:ss");
                txtMaVe.Enabled = false;
                LoadSoDoGhe();
                TinhGiaVe();
            }
        }

        private void CboLichChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLichChieu.SelectedValue != null)
            {
                LoadSoDoGhe();
                TinhGiaVe();
            }
        }

        private void CboLoaiVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhGiaVe();
        }

        private void LoadSoDoGhe()
        {
            if (cboLichChieu.SelectedValue == null) return;

            tblGhe.Controls.Clear();
            gheButtons.Clear();

            var lichChieu = LichChieuBUS.LayTatCa().FirstOrDefault(lc => lc.MaLichChieu == cboLichChieu.SelectedValue.ToString());
            if (lichChieu == null) return;

            var phongChieu = PhongChieuBUS.LayTatCa().FirstOrDefault(pc => pc.MaPhong == lichChieu.MaPhong);
            if (phongChieu == null) return;

            int soLuongGhe = phongChieu.SoLuongGhe;
            int soHang = (int)Math.Ceiling(Math.Sqrt(soLuongGhe));
            int soCot = (int)Math.Ceiling((double)soLuongGhe / soHang);

            tblGhe.RowCount = soHang;
            tblGhe.ColumnCount = soCot;
            for (int i = 0; i < soHang; i++)
            {
                tblGhe.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / soHang));
                for (int j = 0; j < soCot; j++)
                {
                    if (i * soCot + j >= soLuongGhe) break;
                    if (i == 0) tblGhe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / soCot));

                    string soGhe = $"{(char)('A' + i)}{j + 1}";
                    Button btnGhe = new Button
                    {
                        Text = soGhe,
                        Size = new Size(50, 50),
                        Font = new Font("Segoe UI", 10F),
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 1 }
                    };

                    var veList = VeBUS.LayTheoLichChieu(lichChieu.MaLichChieu);
                    if (veList.Any(v => v.SoGhe == soGhe))
                        btnGhe.BackColor = Color.FromArgb(211, 47, 47);
                    else
                        btnGhe.BackColor = Color.FromArgb(26, 166, 154);

                    btnGhe.Click += (s, e) =>
                    {
                        if (btnGhe.BackColor == Color.FromArgb(211, 47, 47)) return;
                        if (selectedGhe != null && gheButtons.ContainsKey(selectedGhe))
                            gheButtons[selectedGhe].BackColor = Color.FromArgb(26, 166, 154);
                        selectedGhe = soGhe;
                        btnGhe.BackColor = Color.Yellow;
                        txtSoGhe.Text = soGhe;
                    };

                    tblGhe.Controls.Add(btnGhe, j, i);
                    gheButtons[soGhe] = btnGhe;
                }
            }
        }

        private void TinhGiaVe()
        {
            if (cboLichChieu.SelectedValue == null || cboLoaiVe.SelectedValue == null) return;

            decimal giaVe = VeBUS.TinhGiaVe(cboLichChieu.SelectedValue.ToString(), cboLoaiVe.SelectedValue.ToString());
            txtGiaVe.Text = giaVe.ToString("N0");
        }

        private void btnThemVe_Click(object sender, EventArgs e)
        {
            if (!ValidateInputVe()) return;

            DateTime ngayDat;
            if (!DateTime.TryParseExact(txtNgayDat.Text, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out ngayDat))
            {
                MessageBox.Show("Ngày đặt không đúng định dạng dd/MM/yyyy HH:mm:ss!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Ve ve = new Ve
            {
                MaVe = txtMaVe.Text.Trim(),
                MaLichChieu = cboLichChieu.SelectedValue.ToString(),
                MaLoaiVe = cboLoaiVe.SelectedValue.ToString(),
                MaKhachHang = cboKhachHang.SelectedValue.ToString(),
                SoGhe = txtSoGhe.Text,
                NgayDat = ngayDat
            };

            try
            {
                VeBUS.Them(ve);
                MessageBox.Show("Thêm vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataVe();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaVe_Click(object sender, EventArgs e)
        {
            if (dgvVe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maVe = txtMaVe.Text.Trim();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa vé {maVe}?", "Xác nhận",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    VeBUS.Xoa(maVe);
                    MessageBox.Show("Xóa vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataVe();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoiVe_Click(object sender, EventArgs e)
        {
            ResetFormVe();
            LoadDataVe();
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            ResetFormVe();
        }

        private void btnTimKiemVe_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemVe.Text.Trim().ToLower();
            var veList = VeBUS.LayTatCa();
            var displayList = veList
                .Where(v => v.MaVe.ToLower().Contains(tuKhoa) ||
                            v.MaLichChieu.ToLower().Contains(tuKhoa) ||
                            v.SoGhe.ToLower().Contains(tuKhoa))
                .ToList();
            dgvVe.DataSource = displayList;
        }

        private bool ValidateInputVe()
        {
            if (string.IsNullOrEmpty(txtMaVe.Text.Trim()))
            {
                MessageBox.Show("Mã vé không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboLichChieu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn lịch chiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboLoaiVe.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại vé!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboKhachHang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtSoGhe.Text))
            {
                MessageBox.Show("Vui lòng chọn ghế!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtNgayDat.Text))
            {
                MessageBox.Show("Ngày đặt không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // --- Quản lý loại vé ---

        private void LoadDataLoaiVe()
        {
            var loaiVeList = LoaiVeBUS.LayTatCa();
            dgvLoaiVe.DataSource = loaiVeList;
            ResetFormLoaiVe();
        }

        private void ResetFormLoaiVe()
        {
            txtMaLoaiVe.Clear();
            txtTenLoaiVe.Clear();
            txtPhuThu.Clear();
            txtMaLoaiVe.Enabled = true;
            dgvLoaiVe.ClearSelection();
        }

        private void DgvLoaiVe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoaiVe.SelectedRows.Count > 0)
            {
                var row = dgvLoaiVe.SelectedRows[0];
                txtMaLoaiVe.Text = row.Cells["MaLoaiVe"].Value.ToString();
                txtTenLoaiVe.Text = row.Cells["TenLoaiVe"].Value.ToString();
                txtPhuThu.Text = row.Cells["PhuThu"].Value.ToString();
                txtMaLoaiVe.Enabled = false;
            }
        }

        private void btnThemLoaiVe_Click(object sender, EventArgs e)
        {
            if (!ValidateInputLoaiVe()) return;

            LoaiVe loaiVe = new LoaiVe
            {
                MaLoaiVe = txtMaLoaiVe.Text.Trim(),
                TenLoaiVe = txtTenLoaiVe.Text.Trim(),
                PhuThu = Convert.ToDecimal(txtPhuThu.Text.Trim())
            };

            try
            {
                LoaiVeBUS.Them(loaiVe);
                MessageBox.Show("Thêm loại vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataLoaiVe();
                LoadDataVe(); // Cập nhật lại ComboBox loại vé trong tab Quản lý vé
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaLoaiVe_Click(object sender, EventArgs e)
        {
            if (dgvLoaiVe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn loại vé để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maLoaiVe = txtMaLoaiVe.Text.Trim();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa loại vé {maLoaiVe}?", "Xác nhận",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    LoaiVeBUS.Xoa(maLoaiVe);
                    MessageBox.Show("Xóa loại vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataLoaiVe();
                    LoadDataVe(); // Cập nhật lại ComboBox loại vé trong tab Quản lý vé
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaLoaiVe_Click(object sender, EventArgs e)
        {
            if (dgvLoaiVe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn loại vé để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputLoaiVe()) return;

            LoaiVe loaiVe = new LoaiVe
            {
                MaLoaiVe = txtMaLoaiVe.Text.Trim(),
                TenLoaiVe = txtTenLoaiVe.Text.Trim(),
                PhuThu = Convert.ToDecimal(txtPhuThu.Text.Trim())
            };

            try
            {
                LoaiVeBUS.Sua(loaiVe);
                MessageBox.Show("Sửa loại vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataLoaiVe();
                LoadDataVe(); // Cập nhật lại ComboBox loại vé trong tab Quản lý vé
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoiLoaiVe_Click(object sender, EventArgs e)
        {
            ResetFormLoaiVe();
            LoadDataLoaiVe();
        }

        private bool ValidateInputLoaiVe()
        {
            if (string.IsNullOrEmpty(txtMaLoaiVe.Text.Trim()))
            {
                MessageBox.Show("Mã loại vé không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtTenLoaiVe.Text.Trim()))
            {
                MessageBox.Show("Tên loại vé không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtPhuThu.Text.Trim()) || !decimal.TryParse(txtPhuThu.Text.Trim(), out _))
            {
                MessageBox.Show("Phụ thu phải là một số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackColor = Color.FromArgb(77, 182, 172);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn == btnXoaVe || btn == btnXoaLoaiVe)
                btn.BackColor = Color.FromArgb(211, 47, 47);
            else if (btn == btnLamMoiVe || btn == btnHuyVe || btn == btnLamMoiLoaiVe)
                btn.BackColor = Color.FromArgb(120, 120, 120);
            else
                btn.BackColor = Color.FromArgb(26, 166, 154);
        }
    }
}