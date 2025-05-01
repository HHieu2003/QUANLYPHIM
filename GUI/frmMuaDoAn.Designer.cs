using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmMuaDoAn
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Font = new Font("Segoe UI", 12F);
            this.BackColor = Color.White;
            this.ClientSize = new Size(1000, 600);
            this.Text = "Mua Đồ Ăn";
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
                Text = "MUA ĐỒ ĂN",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlHeader.Controls.Add(lblTitle);

            // GroupBox: Thông tin khách hàng
            var groupThongTin = new GroupBox
            {
                Text = "Thông Tin Khách Hàng",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136), // Màu Teal
                Location = new Point(10, 70),
                Size = new Size(980, 80),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White
            };

            lblHoTen = new Label
            {
                Text = "👤 Họ tên:",
                Location = new Point(20, 40),
                AutoSize = true,
                Font = new Font("Segoe UI", 12F)
            };

            txtHoTen = new TextBox
            {
                Location = new Point(150, 35),
                Width = 800,
                ReadOnly = true,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11F)
            };

            groupThongTin.Controls.AddRange(new Control[] { lblHoTen, txtHoTen });

            // GroupBox: Danh sách đồ ăn
            var groupDoAn = new GroupBox
            {
                Text = "Danh Sách Đồ Ăn",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136),
                Location = new Point(10, 160),
                Size = new Size(980, 320),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White
            };

            dgvDoAn = new DataGridView
            {
                Location = new Point(10, 40),
                Size = new Size(960, 270),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(224, 224, 224),
                RowHeadersVisible = false
            };

            // Tùy chỉnh phong cách DataGridView
            dgvDoAn.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 136);
            dgvDoAn.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDoAn.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvDoAn.EnableHeadersVisualStyles = false;
            dgvDoAn.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvDoAn.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgvDoAn.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 182, 172);
            dgvDoAn.DefaultCellStyle.SelectionForeColor = Color.White;

            groupDoAn.Controls.Add(dgvDoAn);

            // GroupBox: Tổng tiền và nút
            var groupTongTien = new GroupBox
            {
                Text = "Tổng Tiền",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136),
                Location = new Point(10, 490),
                Size = new Size(980, 80),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White
            };

            lblTongTien = new Label
            {
                Text = "💰 Tổng tiền:",
                Location = new Point(20, 40),
                AutoSize = true,
                Font = new Font("Segoe UI", 12F)
            };

            txtTongTien = new TextBox
            {
                Location = new Point(150, 35),
                Width = 200,
                ReadOnly = true,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11F)
            };

            btnXacNhan = new Button
            {
                Text = "✅ Xác nhận",
                Location = new Point(650, 35),
                Size = new Size(150, 36),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            btnXacNhan.FlatAppearance.BorderSize = 0;
            btnXacNhan.FlatAppearance.MouseOverBackColor = Color.FromArgb(77, 182, 172);
            btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);

            btnHuy = new Button
            {
                Text = "❌ Hủy",
                Location = new Point(800, 35),
                Size = new Size(150, 36),
                BackColor = Color.FromArgb(204, 0, 0), // Màu đỏ đậm
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 0, 0);
            btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            groupTongTien.Controls.AddRange(new Control[] { lblTongTien, txtTongTien, btnXacNhan, btnHuy });

            // Thêm các control vào form
            this.Controls.AddRange(new Control[] { pnlHeader, groupThongTin, groupDoAn, groupTongTien });
        }

        private Label lblHoTen, lblTongTien;
        private TextBox txtHoTen, txtTongTien;
        private DataGridView dgvDoAn;
        private Button btnXacNhan, btnHuy;
    }
}