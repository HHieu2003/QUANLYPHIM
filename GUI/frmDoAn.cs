using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmDoAn : Form
    {
        public frmDoAn()
        {
            InitializeComponent();
            LoadData();
            dgvDoAn.SelectionChanged += DgvDoAn_SelectionChanged;
        }

        private void LoadData()
        {
            var list = DoAnBUS.LayTatCa();
            dgvDoAn.DataSource = list.Select(d => new
            {
                d.MaDoAn,
                d.TenDoAn,
                Gia = d.Gia.ToString("N0") + " đ",
                d.MoTa
            }).ToList();
            ResetForm();
        }

        private void ResetForm()
        {
            txtMaDoAn.Clear();
            txtTenDoAn.Clear();
            txtGia.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();
            dgvDoAn.ClearSelection();
            txtMaDoAn.Enabled = true;
        }

        private void DgvDoAn_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDoAn.SelectedRows.Count > 0)
            {
                var row = dgvDoAn.SelectedRows[0];
                txtMaDoAn.Text = row.Cells["MaDoAn"].Value.ToString();
                txtTenDoAn.Text = row.Cells["TenDoAn"].Value.ToString();
                txtGia.Text = row.Cells["Gia"].Value.ToString().Replace(" đ", "").Replace(",", "");
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();
                txtMaDoAn.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = new DoAn
                {
                    MaDoAn = txtMaDoAn.Text.Trim(),
                    TenDoAn = txtTenDoAn.Text.Trim(),
                    Gia = decimal.Parse(txtGia.Text.Trim()),
                    MoTa = txtMoTa.Text.Trim()
                };
                DoAnBUS.Them(obj);
                MessageBox.Show("Thêm đồ ăn thành công!", "Thông báo");
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
                var obj = new DoAn
                {
                    MaDoAn = txtMaDoAn.Text.Trim(),
                    TenDoAn = txtTenDoAn.Text.Trim(),
                    Gia = decimal.Parse(txtGia.Text.Trim()),
                    MoTa = txtMoTa.Text.Trim()
                };
                DoAnBUS.CapNhat(obj);
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDoAn.SelectedRows.Count == 0) return;
            var id = txtMaDoAn.Text.Trim();
            if (MessageBox.Show($"Xóa đồ ăn {id}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DoAnBUS.Xoa(id);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            var list = DoAnBUS.LayTatCa();
            dgvDoAn.DataSource = list.Where(d =>
                d.MaDoAn.ToLower().Contains(keyword) ||
                d.TenDoAn.ToLower().Contains(keyword) ||
                d.MoTa.ToLower().Contains(keyword)).ToList();
        }
    }
}