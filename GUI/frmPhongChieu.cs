using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmPhongChieu : Form
    {
        public frmPhongChieu()
        {
            InitializeComponent();
            LoadData();
            CustomizeGridView();
            dgvPhongChieu.SelectionChanged += DgvPhongChieu_SelectionChanged;
        }

        private void LoadData()
        {
            // Load danh sách phòng chiếu
            var phongChieuList = PhongChieuBUS.LayTatCa();
            dgvPhongChieu.DataSource = phongChieuList;

            // Load trạng thái vào ComboBox
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[] { "hoatdong", "baotri" });

            // Reset form
            ResetForm();
        }

        private void CustomizeGridView()
        {
            dgvPhongChieu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 166, 154);
            dgvPhongChieu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPhongChieu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvPhongChieu.EnableHeadersVisualStyles = false;
            dgvPhongChieu.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvPhongChieu.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
        }

        private void ResetForm()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtSoLuongGhe.Text = 100.ToString();
            txtTimKiem.Clear();
            cboTrangThai.SelectedIndex = -1;
            txtMaPhong.Enabled = true;
            dgvPhongChieu.ClearSelection();
        }

        private void DgvPhongChieu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhongChieu.SelectedRows.Count > 0)
            {
                var row = dgvPhongChieu.SelectedRows[0];
                txtMaPhong.Text = row.Cells["MaPhong"].Value.ToString();
                txtTenPhong.Text = row.Cells["TenPhong"].Value.ToString();
                txtSoLuongGhe.Text = row.Cells["SoLuongGhe"].Value.ToString();
                cboTrangThai.SelectedItem = row.Cells["TrangThai"].Value.ToString();
                txtMaPhong.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            PhongChieu phongChieu = new PhongChieu
            {
                MaPhong = txtMaPhong.Text.Trim(),
                TenPhong = txtTenPhong.Text.Trim(),
                SoLuongGhe = int.Parse(txtSoLuongGhe.Text.Trim()),
                TrangThai = cboTrangThai.SelectedItem.ToString()
            };

            try
            {
                PhongChieuBUS.Them(phongChieu);
                MessageBox.Show("Thêm phòng chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            PhongChieu phongChieu = new PhongChieu
            {
                MaPhong = txtMaPhong.Text.Trim(),
                TenPhong = txtTenPhong.Text.Trim(),
                SoLuongGhe = int.Parse(txtSoLuongGhe.Text.Trim()),
              

                TrangThai = cboTrangThai.SelectedItem.ToString()
            };

            try
            {
                PhongChieuBUS.CapNhat(phongChieu);
                MessageBox.Show("Cập nhật phòng chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhongChieu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng chiếu để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maPhong = txtMaPhong.Text.Trim();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng chiếu {maPhong}?", "Xác nhận",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    PhongChieuBUS.Xoa(maPhong);
                    MessageBox.Show("Xóa phòng chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            var phongChieuList = PhongChieuBUS.LayTatCa();
            var displayList = phongChieuList
                .Where(pc => pc.MaPhong.ToLower().Contains(tuKhoa) ||
                             pc.TenPhong.ToLower().Contains(tuKhoa) ||
                             pc.SoLuongGhe.ToString().Contains(tuKhoa) ||
                             pc.TrangThai.ToLower().Contains(tuKhoa))
                .ToList();
            dgvPhongChieu.DataSource = displayList;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text.Trim()))
            {
                MessageBox.Show("Mã phòng chiếu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtTenPhong.Text.Trim()))
            {
                MessageBox.Show("Tên phòng chiếu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtSoLuongGhe.Text.Trim(), out int soLuongGhe) || soLuongGhe <= 0)
            {
                MessageBox.Show("Số lượng ghế phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackColor = Color.FromArgb(77, 182, 172); // Sáng hơn khi hover
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn == btnXoa)
                btn.BackColor = Color.FromArgb(211, 47, 47);
            else if (btn == btnLamMoi || btn == btnHuy)
                btn.BackColor = Color.FromArgb(120, 120, 120);
            else
                btn.BackColor = Color.FromArgb(26, 166, 154);
        }
    }
}