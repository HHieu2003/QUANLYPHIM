using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmProfile
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private GroupBox groupThongTin;
        private Label lblHoTen, lblSoDienThoai, lblEmail;
        private TextBox txtHoTen, txtSoDienThoai, txtEmail;
        private Button btnEdit, btnSave, btnCancelEdit, btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Font = new Font("Segoe UI", 12F);
            this.BackColor = Color.White; // Đổi màu nền thành trắng để loại bỏ khoảng màu xám
            this.ClientSize = new Size(700, 500);
            this.Text = "Thông Tin Cá Nhân";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Header Panel
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(0, 150, 136), // Màu Teal đậm
                Padding = new Padding(10)
            };

            lblTitle = new Label
            {
                Text = "THÔNG TIN CÁ NHÂN",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlHeader.Controls.Add(lblTitle);

            // GroupBox: Thông tin khách hàng
            groupThongTin = new GroupBox
            {
                Text = "Thông Tin Khách Hàng",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136), // Màu Teal
                Location = new Point(10, 70), // Giảm khoảng cách để sát viền
                Size = new Size(680, 380), // Tăng kích thước để thoáng hơn
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White
            };

            // Labels và TextBoxes
            lblHoTen = new Label
            {
                Text = "👤 Họ tên:",
                Location = new Point(30, 50),
                AutoSize = true,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136)
            };
            txtHoTen = new TextBox
            {
                Location = new Point(150, 45),
                Width = 500,
                ReadOnly = true,
                Font = new Font("Segoe UI", 12F),
                BackColor = Color.FromArgb(240, 240, 240),
                BorderStyle = BorderStyle.FixedSingle,
            };

            lblSoDienThoai = new Label
            {
                Text = "📞 Điện thoại:",
                Location = new Point(30, 110), // Tăng khoảng cách giữa các hàng
                AutoSize = true,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136)
            };
            txtSoDienThoai = new TextBox
            {
                Location = new Point(150, 105),
                Width = 500,
                ReadOnly = true,
                Font = new Font("Segoe UI", 12F),
                BackColor = Color.FromArgb(240, 240, 240),
                BorderStyle = BorderStyle.FixedSingle,
            };

            lblEmail = new Label
            {
                Text = "📧 Email:",
                Location = new Point(30, 170), // Tăng khoảng cách
                AutoSize = true,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136)
            };
            txtEmail = new TextBox
            {
                Location = new Point(150, 165),
                Width = 500,
                ReadOnly = true,
                Font = new Font("Segoe UI", 12F),
                BackColor = Color.FromArgb(240, 240, 240),
                BorderStyle = BorderStyle.FixedSingle,
            };

            // Buttons trong GroupBox
            btnEdit = new Button
            {
                Text = "✏️ Sửa",
                Location = new Point(150, 230), // Đặt ở vị trí căn giữa
                Size = new Size(140, 40),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(77, 182, 172);
            btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            btnSave = new Button
            {
                Text = "💾 Lưu",
                Location = new Point(310, 230), // Căn giữa
                Size = new Size(140, 40),
                BackColor = Color.FromArgb(46, 139, 87),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Enabled = false
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 161, 111);
            btnSave.Click += new System.EventHandler(this.btnSave_Click);

            btnCancelEdit = new Button
            {
                Text = "❌ Hủy",
                Location = new Point(470, 230), // Căn giữa
                Size = new Size(140, 40),
                BackColor = Color.FromArgb(211, 47, 47),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Enabled = false
            };
            btnCancelEdit.FlatAppearance.BorderSize = 0;
            btnCancelEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(231, 67, 67);
            btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);

            groupThongTin.Controls.AddRange(new Control[] { lblHoTen, txtHoTen, lblSoDienThoai, txtSoDienThoai, lblEmail, txtEmail, btnEdit, btnSave, btnCancelEdit });

            // Button: Close
            btnClose = new Button
            {
                Text = "🚪 Đóng",
                Location = new Point(540, 460), // Căn giữa dưới GroupBox
                Size = new Size(140, 40),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(77, 182, 172);
            btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // Add controls to form
            this.Controls.AddRange(new Control[] { groupThongTin, btnClose, pnlHeader });
        }
    }
}