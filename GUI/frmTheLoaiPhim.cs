using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTheLoaiPhim : Form
    {


        public frmTheLoaiPhim()
        {
            InitializeComponent();
            LoadData();
            CustomizeGridView();
            dgvTheLoaiPhim.SelectionChanged += DgvTheLoaiPhim_SelectionChanged;
        }

        private void LoadData()
        {
            // Load danh sách thể loại phim
            var theLoaiList = TheLoaiPhimBUS.LayTatCa();
            dgvTheLoaiPhim.DataSource = theLoaiList;

            // Reset form
            ResetForm();
        }

        private void CustomizeGridView()
        {
            dgvTheLoaiPhim.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 166, 154);
            dgvTheLoaiPhim.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTheLoaiPhim.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvTheLoaiPhim.EnableHeadersVisualStyles = false;
            dgvTheLoaiPhim.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvTheLoaiPhim.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
        }

        private void ResetForm()
        {
            txtMaTheLoai.Clear();
            txtTenTheLoai.Clear();
            txtTimKiem.Clear();
            txtMaTheLoai.Enabled = true;
            dgvTheLoaiPhim.ClearSelection();
        }

        private void DgvTheLoaiPhim_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTheLoaiPhim.SelectedRows.Count > 0)
            {
                var row = dgvTheLoaiPhim.SelectedRows[0];
                txtMaTheLoai.Text = row.Cells["MaTheLoai"].Value.ToString();
                txtTenTheLoai.Text = row.Cells["TenTheLoai"].Value.ToString();
                txtMaTheLoai.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            TheLoaiPhim theLoai = new TheLoaiPhim
            {
                MaTheLoai = txtMaTheLoai.Text.Trim(),
                TenTheLoai = txtTenTheLoai.Text.Trim()
            };

            try
            {
                TheLoaiPhimBUS.Them(theLoai);
                MessageBox.Show("Thêm thể loại phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            TheLoaiPhim theLoai = new TheLoaiPhim
            {
                MaTheLoai = txtMaTheLoai.Text.Trim(),
                TenTheLoai = txtTenTheLoai.Text.Trim()
            };

            try
            {
                TheLoaiPhimBUS.CapNhat(theLoai);
                MessageBox.Show("Cập nhật thể loại phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTheLoaiPhim.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thể loại phim để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maTheLoai = txtMaTheLoai.Text.Trim();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa thể loại phim {maTheLoai}?", "Xác nhận",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    TheLoaiPhimBUS.Xoa(maTheLoai);
                    MessageBox.Show("Xóa thể loại phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var theLoaiList = TheLoaiPhimBUS.LayTatCa();
            var displayList = theLoaiList
                .Where(tl => tl.MaTheLoai.ToLower().Contains(tuKhoa) ||
                             tl.TenTheLoai.ToLower().Contains(tuKhoa))
                .ToList();
            dgvTheLoaiPhim.DataSource = displayList;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtMaTheLoai.Text.Trim()))
            {
                MessageBox.Show("Mã thể loại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtTenTheLoai.Text.Trim()))
            {
                MessageBox.Show("Tên thể loại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
         
            else
                btn.BackColor = Color.FromArgb(26, 166, 154);
        }
    }
}