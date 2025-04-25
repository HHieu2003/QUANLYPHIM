using BUS;
using DAL;
using DTO;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            btnRegister.Click += BtnRegister_Click;
            btnCancel.Click += BtnCancel_Click;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(fullName) ||
                string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường bắt buộc!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(phoneNumber, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng 0 và có đúng 10 chữ số!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Check if username already exists
                var existingUser = NguoiDungDAL.TimKiemTheoTenDangNhap(username);
                if (existingUser != null)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Generate unique IDs
                string userId = "ND" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
                string customerId = userId;

                // Create NguoiDung
                NguoiDung newUser = new NguoiDung
                {
                    MaNguoiDung = userId,
                    TenDangNhap = username,
                    MatKhau = password, // Note: In a real application, password should be hashed
                    VaiTro = "khach",
                    NgayTao = DateTime.Now
                };

                // Create KhachHang
                KhachHang newCustomer = new KhachHang
                {
                    MaKhachHang = customerId,
                    HoTen = fullName,
                    SoDienThoai = phoneNumber,
                    Email = email
                };

                // Save to database
                NguoiDungBUS.Them(newUser);
                KhachHangBUS.Them(newCustomer);

                MessageBox.Show("Đăng ký thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng ký: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}