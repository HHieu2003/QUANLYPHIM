using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmPhim : Form
    {
        public frmPhim()
        {
            InitializeComponent();
            LoadData();
            CustomizeGridView();
            dgvPhim.SelectionChanged += DgvPhim_SelectionChanged;
        }

        private void LoadData()
        {
            // Load danh sách phim
            var phimList = PhimBUS.LayTatCa();
            var theLoaiList = TheLoaiPhimBUS.LayTatCa();
            var displayList = phimList.Select(p => new
            {
                p.MaPhim,
                p.TenPhim,
                TenTheLoai = theLoaiList.FirstOrDefault(t => t.MaTheLoai == p.MaTheLoai)?.TenTheLoai,
                p.ThoiLuong,
                p.MoTa
            }).ToList();
            dgvPhim.DataSource = displayList;

            // Load thể loại phim vào ComboBox
            cboTheLoai.DataSource = theLoaiList;
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";

            // Reset form
            ResetForm();
        }

        private void CustomizeGridView()
        {
            dgvPhim.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 166, 154);
            dgvPhim.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPhim.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvPhim.EnableHeadersVisualStyles = false;
            dgvPhim.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvPhim.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
        }

        private void ResetForm()
        {
            txtMaPhim.Clear();
            txtTenPhim.Clear();
            txtThoiLuong.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();
            cboTheLoai.SelectedIndex = -1;
            txtMaPhim.Enabled = true;
            dgvPhim.ClearSelection();
        }

        private void DgvPhim_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhim.SelectedRows.Count > 0)
            {
                var row = dgvPhim.SelectedRows[0];
                txtMaPhim.Text = row.Cells["MaPhim"].Value.ToString();
                txtTenPhim.Text = row.Cells["TenPhim"].Value.ToString();
                var tenTheLoai = row.Cells["TenTheLoai"].Value.ToString();
                cboTheLoai.SelectedValue = TheLoaiPhimBUS.LayTatCa().FirstOrDefault(t => t.TenTheLoai == tenTheLoai)?.MaTheLoai;
                txtThoiLuong.Text = row.Cells["ThoiLuong"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                txtMaPhim.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Phim phim = new Phim
            {
                MaPhim = txtMaPhim.Text.Trim(),
                TenPhim = txtTenPhim.Text.Trim(),
                MaTheLoai = cboTheLoai.SelectedValue.ToString(),
                ThoiLuong = int.Parse(txtThoiLuong.Text.Trim()),
                MoTa = txtMoTa.Text.Trim()
            };

            try
            {
                PhimBUS.Them(phim);
                MessageBox.Show("Thêm phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            Phim phim = new Phim
            {
                MaPhim = txtMaPhim.Text.Trim(),
                TenPhim = txtTenPhim.Text.Trim(),
                MaTheLoai = cboTheLoai.SelectedValue.ToString(),
                ThoiLuong = int.Parse(txtThoiLuong.Text.Trim()),
                MoTa = txtMoTa.Text.Trim()
            };

            try
            {
                PhimBUS.CapNhat(phim);
                MessageBox.Show("Cập nhật phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhim.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phim để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maPhim = txtMaPhim.Text.Trim();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phim {maPhim}?", "Xác nhận",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    PhimBUS.Xoa(maPhim);
                    MessageBox.Show("Xóa phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var phimList = PhimBUS.LayTatCa();
            var theLoaiList = TheLoaiPhimBUS.LayTatCa();
            var displayList = phimList
                .Where(p => p.TenPhim.ToLower().Contains(tuKhoa) ||
                            theLoaiList.Any(t => t.MaTheLoai == p.MaTheLoai && t.TenTheLoai.ToLower().Contains(tuKhoa)))
                .Select(p => new
                {
                    p.MaPhim,
                    p.TenPhim,
                    TenTheLoai = theLoaiList.FirstOrDefault(t => t.MaTheLoai == p.MaTheLoai)?.TenTheLoai,
                    p.ThoiLuong,
                    p.MoTa
                }).ToList();
            dgvPhim.DataSource = displayList;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtMaPhim.Text.Trim()))
            {
                MessageBox.Show("Mã phim không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtTenPhim.Text.Trim()))
            {
                MessageBox.Show("Tên phim không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboTheLoai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn thể loại phim!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtThoiLuong.Text.Trim(), out int thoiLuong) || thoiLuong <= 0)
            {
                MessageBox.Show("Thời lượng phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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