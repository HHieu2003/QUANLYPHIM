using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NguoiDung nguoiDung = NguoiDungBUS.DangNhap(username, password);
            if (nguoiDung != null)
            {
                Form mainForm;
                if (nguoiDung.VaiTro == "admin")
                {
                    mainForm = new MainFormAdmin();
                }
                else if (nguoiDung.VaiTro == "nhanvien")
                {
                    mainForm = new MainFormNhanVien();
                }
                else // VaiTro == "khach"
                {
                    /* MessageBox.Show("Tài khoản khách không được phép đăng nhập vào hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;*/
                    mainForm = new frmMain(nguoiDung.MaNguoiDung, nguoiDung.TenDangNhap);
                }

                this.Hide();
                mainForm.Show(); // không dùng ShowDialog()

            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register registerform = new Register();
            registerform.ShowDialog();

        }
    }
}