using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
            LoadData();
            dgvKhachHang.SelectionChanged += DgvKhachHang_SelectionChanged;
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource = KhachHangBUS.LayTatCa().Select(kh => new
            {
                kh.MaKhachHang,
                kh.HoTen,
                kh.SoDienThoai,
                kh.Email
            }).ToList();
            ResetForm();
        }

        private void ResetForm()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtTimKiem.Clear();
            txtMaKH.Enabled = true;
            dgvKhachHang.ClearSelection();
        }

        private void DgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                var row = dgvKhachHang.SelectedRows[0];
                txtMaKH.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtMaKH.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var kh = new KhachHang
                {
                    MaKhachHang = txtMaKH.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };
                KhachHangBUS.Them(kh);
                MessageBox.Show("Thêm thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var kh = new KhachHang
                {
                    MaKhachHang = txtMaKH.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };
                KhachHangBUS.CapNhat(kh);
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count == 0) return;
            var ma = txtMaKH.Text.Trim();
            var confirm = MessageBox.Show($"Xóa khách hàng {ma}?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    KhachHangBUS.Xoa(ma);
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadData();
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            dgvKhachHang.DataSource = KhachHangBUS.LayTatCa()
                .Where(kh =>
                    kh.MaKhachHang.ToLower().Contains(tuKhoa) ||
                    kh.HoTen.ToLower().Contains(tuKhoa) ||
                    kh.SoDienThoai.Contains(tuKhoa) ||
                    (kh.Email ?? "").ToLower().Contains(tuKhoa))
                .ToList();
        }
    }
}
