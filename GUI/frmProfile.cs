using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmProfile : Form
    {
        private string maKhachHang; private KhachHang khachHang;
        public frmProfile(string maKhachHang)
        {
            this.maKhachHang = maKhachHang;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            khachHang = KhachHangBUS.LayTheoMa(maKhachHang);
            if (khachHang == null)
            {
                MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtHoTen.Text = khachHang.HoTen;
            txtSoDienThoai.Text = khachHang.SoDienThoai;
            txtEmail.Text = khachHang.Email;

            SetReadOnly(true);
        }

        private void SetReadOnly(bool readOnly)
        {
            txtHoTen.ReadOnly = readOnly;
            txtSoDienThoai.ReadOnly = readOnly;
            txtEmail.ReadOnly = readOnly;
            btnSave.Enabled = !readOnly;
            btnCancelEdit.Enabled = !readOnly;
            btnEdit.Enabled = readOnly;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetReadOnly(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Họ tên và số điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(soDienThoai, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng 0 và có đúng 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                khachHang.HoTen = hoTen;
                khachHang.SoDienThoai = soDienThoai;
                khachHang.Email = email;

                KhachHangBUS.CapNhat(khachHang);
                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetReadOnly(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}