using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmChiTietDoAn : Form
    {
        public frmChiTietDoAn()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var ds = ChiTietDoAnBUS.LayTheoDon("DH001"); // Ví dụ, bạn nên thay bằng mã đơn động
            dgvChiTietDoAn.DataSource = ds.Select(c => new
            {
                c.MaChiTiet,
                c.MaDonHang,
                c.MaDoAn,
                c.SoLuong,
                c.Gia,
                c.ThanhTien
            }).ToList();
            dgvChiTietDoAn.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = new ChiTietDoAn
                {
                    MaChiTiet = txtMaChiTiet.Text.Trim(),
                    MaDonHang = txtMaDonHang.Text.Trim(),
                    MaDoAn = txtMaDoAn.Text.Trim(),
                    SoLuong = int.Parse(txtSoLuong.Text),
                    Gia = decimal.Parse(txtGia.Text),
                    ThanhTien = decimal.Parse(txtThanhTien.Text)
                };
                ChiTietDoAnBUS.Them(obj);
                MessageBox.Show("Thêm chi tiết thành công!", "Thông báo");
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
                var obj = new ChiTietDoAn
                {
                    MaChiTiet = txtMaChiTiet.Text.Trim(),
                    MaDonHang = txtMaDonHang.Text.Trim(),
                    MaDoAn = txtMaDoAn.Text.Trim(),
                    SoLuong = int.Parse(txtSoLuong.Text),
                    Gia = decimal.Parse(txtGia.Text),
                    ThanhTien = decimal.Parse(txtThanhTien.Text)
                };
                ChiTietDoAnBUS.CapNhat(obj);
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTietDoAn.SelectedRows.Count > 0)
            {
                var id = dgvChiTietDoAn.SelectedRows[0].Cells["MaChiTiet"].Value.ToString();
                var confirm = MessageBox.Show("Xoá chi tiết " + id + "?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    ChiTietDoAnBUS.Xoa(id);
                    LoadData();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            txtMaChiTiet.Clear();
            txtMaDonHang.Clear();
            txtMaDoAn.Clear();
            txtSoLuong.Clear();
            txtGia.Clear();
            txtThanhTien.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            var tuKhoa = txtTimKiem.Text.Trim().ToLower();
            var ds = ChiTietDoAnBUS.LayTheoDon("DH001"); // Thay bằng input
            dgvChiTietDoAn.DataSource = ds.Where(c =>
                c.MaChiTiet.ToLower().Contains(tuKhoa) ||
                c.MaDoAn.ToLower().Contains(tuKhoa)).ToList();
        }
    }
}