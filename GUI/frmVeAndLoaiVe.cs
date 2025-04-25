using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmVeAndLoaiVe : Form
    {
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
            var veList = VeBUS.LayTatCa();
            dgvVe.DataSource = veList;
            txtMaVe.Clear();
            txtTimKiemVe.Clear();
            dgvVe.ClearSelection();
        }

        private void CustomizeGridViews()
        {
            // Customize dgvVe
            dgvVe.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 166, 154);
            dgvVe.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            /*dgvVe.EnableHeadersVisualStyles = false;*/
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

        private void DgvVe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVe.SelectedRows.Count > 0)
            {
                var row = dgvVe.SelectedRows[0];
                txtMaVe.Text = row.Cells["MaVe"].Value.ToString();
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
            else if (btn == btnLamMoiLoaiVe)
                btn.BackColor = Color.FromArgb(120, 120, 120);
            else
                btn.BackColor = Color.FromArgb(26, 166, 154);
        }
    }
}