// frmNguoiDung.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmNguoiDung : Form
    {
        public frmNguoiDung()
        {
            InitializeComponent();
            LoadData();
            dgvNguoiDung.SelectionChanged += DgvNguoiDung_SelectionChanged;
        }

        private void LoadData()
        {
            var ds = NguoiDungBUS.LayTatCa();
            dgvNguoiDung.DataSource = ds.Select(nd => new
            {
                nd.MaNguoiDung,
                nd.TenDangNhap,
                nd.MatKhau,
                nd.VaiTro,
                nd.NgayTao
            }).ToList();
            cboVaiTro.DataSource = new[] { "admin", "nhanvien", "khach" };
            cboVaiTro.SelectedIndex = -1;
            ResetForm();
        }

        private void ResetForm()
        {
            txtMaNguoiDung.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboVaiTro.SelectedIndex = -1;
            txtTimKiem.Clear();
            dgvNguoiDung.ClearSelection();
            txtMaNguoiDung.Enabled = true;
        }

        private void DgvNguoiDung_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNguoiDung.SelectedRows.Count > 0)
            {
                var row = dgvNguoiDung.SelectedRows[0];
                txtMaNguoiDung.Text = row.Cells["MaNguoiDung"].Value.ToString();
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                cboVaiTro.SelectedItem = row.Cells["VaiTro"].Value.ToString();
                txtMaNguoiDung.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var nd = new NguoiDung
                {
                    MaNguoiDung = txtMaNguoiDung.Text.Trim(),
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    VaiTro = cboVaiTro.SelectedItem?.ToString(),
                    NgayTao = DateTime.Now
                };
                NguoiDungBUS.Them(nd);
                MessageBox.Show("Thêm người dùng thành công!", "Thông báo");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var nd = new NguoiDung
                {
                    MaNguoiDung = txtMaNguoiDung.Text.Trim(),
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    VaiTro = cboVaiTro.SelectedItem?.ToString(),
                    NgayTao = DateTime.Now
                };
                NguoiDungBUS.CapNhat(nd);
                MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.SelectedRows.Count == 0) return;
            var id = txtMaNguoiDung.Text.Trim();
            var result = MessageBox.Show($"Xóa người dùng {id}?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    NguoiDungBUS.Xoa(id);
                    MessageBox.Show("Xóa thành công");
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            var ds = NguoiDungBUS.LayTatCa();
            dgvNguoiDung.DataSource = ds.Where(nd =>
                nd.MaNguoiDung.ToLower().Contains(tuKhoa) ||
                nd.TenDangNhap.ToLower().Contains(tuKhoa) ||
                nd.VaiTro.ToLower().Contains(tuKhoa)).ToList();
        }
    }
}
