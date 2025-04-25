using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmDonHang : Form
    {
        public frmDonHang()
        {
            InitializeComponent();
            TaiLai();
        }

        private void TaiLai()
        {
            try
            {
                dgvDonHang.DataSource = DonHangBUS.LayTatCa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải đơn hàng: " + ex.Message);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TaiLai();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DonHang dh = new DonHang
                {
                    MaDonHang = txtMaDonHang.Text.Trim(),
                    MaKhachHang = txtMaKhachHang.Text.Trim(),
                    NgayTao = dtpNgayTao.Value,
                    TongTien = decimal.Parse(txtTongTien.Text.Trim())
                };
                DonHangBUS.Them(dh);
                TaiLai();
                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm đơn hàng: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DonHang dh = new DonHang
                {
                    MaDonHang = txtMaDonHang.Text.Trim(),
                    MaKhachHang = txtMaKhachHang.Text.Trim(),
                    NgayTao = dtpNgayTao.Value,
                    TongTien = decimal.Parse(txtTongTien.Text.Trim())
                };
                DonHangBUS.CapNhat(dh);
                TaiLai();
                MessageBox.Show("Sửa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật đơn hàng: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count > 0)
            {
                var ma = dgvDonHang.SelectedRows[0].Cells["MaDonHang"].Value.ToString();
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        DonHangBUS.Xoa(ma);
                        TaiLai();
                        MessageBox.Show("Xóa thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa đơn hàng: " + ex.Message);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDonHang.Clear();
            txtMaKhachHang.Clear();
            txtTongTien.Clear();
            dtpNgayTao.Value = DateTime.Now;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtTimKiem.Text.Trim();
                if (!string.IsNullOrEmpty(ma))
                {
                    var dh = DonHangBUS.LayTheoMa(ma);
                    if (dh != null)
                    {
                        List<DonHang> list = new List<DonHang> { dh };
                        dgvDonHang.DataSource = list;
                    }
                    else
                        MessageBox.Show("Không tìm thấy đơn hàng!");
                }
                else
                {
                    TaiLai();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
    }
}
