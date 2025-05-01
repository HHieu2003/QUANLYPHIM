using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Font = new Font("Segoe UI", 12F);
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(1200, 700);
            this.Text = "Mua Vé Xem Phim";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Load += new System.EventHandler(this.frmMain_Load);

            // ---------- Navbar ----------
            var pnlNavbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.Teal
            };

            var flowLayoutPanelNavbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft, // Align buttons to the right
                Padding = new Padding(10, 5, 10, 5),
                WrapContents = false
            };

            // Instantiate buttons that will be moved to navbar
            btnViewProfile = new Button
            {
                Text = "👤 Thông Tin Cá Nhân",
                Size = new Size(185, 36),
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnViewProfile.Click += new System.EventHandler(this.btnViewProfile_Click);

            btnLichSuMuaVe = new Button
            {
                Text = "🎟️ Lịch Sử Mua Vé",
                Size = new Size(175, 36),
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnLichSuMuaVe.Click += new System.EventHandler(this.btnLichSuMuaVe_Click);

            btnDangXuat = new Button
            {
                Text = "🚪 Đăng xuất",
                Size = new Size(130, 36),
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);

            // Add only the specified buttons to navbar
            flowLayoutPanelNavbar.Controls.AddRange(new Control[]
            {
                btnDangXuat, // Order reversed due to RightToLeft flow
                btnLichSuMuaVe,
                btnViewProfile
            });

            pnlNavbar.Controls.Add(flowLayoutPanelNavbar);

            // ---------- Group 1: Chọn phim ----------
            var groupChonPhim = new GroupBox
            {
                Text = "🟢 Chọn phim",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.Teal,
                Location = new Point(20, 70), // Shifted down to accommodate navbar
                Size = new Size(500, 260)
            };

            labelTimKiem = new Label { Text = "🔍 Tìm kiếm:", Location = new Point(20, 40), AutoSize = true };
            txtTimKiem = new TextBox { Location = new Point(150, 35), Width = 320 };
            txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            labelTheLoai = new Label { Text = "🎞️ Thể loại:", Location = new Point(20, 80), AutoSize = true };
            cboTheLoai = new ComboBox { Location = new Point(150, 75), Width = 320, DropDownStyle = ComboBoxStyle.DropDownList };
            cboTheLoai.SelectedIndexChanged += new System.EventHandler(this.cboTheLoai_SelectedIndexChanged);

            lstPhim = new ListView
            {
                Location = new Point(20, 120),
                Size = new Size(450, 120),
                View = View.Details,
                FullRowSelect = true
            };
            lstPhim.Columns.Add("Tên phim", 200);
            lstPhim.Columns.Add("Mô tả", 230);
            lstPhim.SelectedIndexChanged += new System.EventHandler(this.lstPhim_SelectedIndexChanged);

            groupChonPhim.Controls.AddRange(new Control[] { labelTimKiem, txtTimKiem, labelTheLoai, cboTheLoai, lstPhim });

            // ---------- Group 2: Lịch chiếu + Vé ----------
            var groupVe = new GroupBox
            {
                Text = "🟠 Lịch chiếu và vé",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.Teal,
                Location = new Point(20, 340), // Shifted down
                Size = new Size(500, 250)
            };

            labelLichChieu = new Label { Text = "🕒 Lịch chiếu:", Location = new Point(20, 40), AutoSize = true ,BackColor = Color.Transparent };
            cboLichChieu = new ComboBox { Location = new Point(150, 35), Width = 320, DropDownStyle = ComboBoxStyle.DropDownList };

            labelLoaiVe = new Label { Text = "🎫 Loại vé:", Location = new Point(20, 90), AutoSize = true };
            cboLoaiVe = new ComboBox { Location = new Point(150, 85), Width = 320, DropDownStyle = ComboBoxStyle.DropDownList };
            cboLoaiVe.SelectedIndexChanged += new System.EventHandler(this.cboLoaiVe_SelectedIndexChanged);

            btnChonGhe = new Button
            {
                Text = "🪑 Chọn ghế",
                Location = new Point(150, 130),
                Size = new Size(130, 36),
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnChonGhe.Click += new System.EventHandler(this.btnChonGhe_Click);

            labelGhe = new Label { Text = "Ghế đã chọn:", Location = new Point(20, 180), AutoSize = true };
            txtGhe = new TextBox { Location = new Point(150, 175), Width = 320, ReadOnly = true };

            groupVe.Controls.AddRange(new Control[] { labelLichChieu, cboLichChieu, labelLoaiVe, cboLoaiVe, btnChonGhe, labelGhe, txtGhe });

            // ---------- Group 3: Đồ ăn ----------
            var groupDoAn = new GroupBox
            {
                Text = "🍿 Mua đồ ăn",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.Teal,
                Location = new Point(20, 600), // Shifted down
                Size = new Size(500, 80)
            };

            btnMuaDoAn = new Button
            {
                Text = "🍔 Mua đồ ăn",
                Location = new Point(170, 30),
                Size = new Size(160, 36),
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnMuaDoAn.Click += new System.EventHandler(this.btnMuaDoAn_Click);

            groupDoAn.Controls.Add(btnMuaDoAn);

            // ---------- Group 4: Thanh toán ----------
            var groupThanhToan = new GroupBox
            {
                Text = "💵 Thanh toán",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.Teal,
                Location = new Point(540, 70), // Shifted down
                Size = new Size(620, 610)
            };

            labelHoTen = new Label { Text = "👤 Họ tên:", Location = new Point(20, 40), AutoSize = true };
            txtHoTen = new TextBox { Location = new Point(150, 35), Width = 420, ReadOnly = true };

            labelTongTien = new Label { Text = "💰 Tổng tiền:", Location = new Point(20, 90), AutoSize = true };
            txtTongTien = new TextBox { Location = new Point(150, 85), Width = 420, ReadOnly = true };

            btnThanhToan = new Button
            {
                Text = "💳 Thanh toán",
                Location = new Point(150, 130),
                Size = new Size(160, 36),
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

            btnInHoaDon = new Button
            {
                Text = "🧾 In hóa đơn",
                Location = new Point(320, 130),
                Size = new Size(160, 36),
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);

            labelHoaDon = new Label { Text = "📝 Chi tiết hóa đơn:", Location = new Point(20, 180), AutoSize = true };
            txtHoaDon = new TextBox
            {
                Location = new Point(20, 210),
                Size = new Size(570, 370),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Courier New", 10F)
            };

            groupThanhToan.Controls.AddRange(new Control[]
            {
                labelHoTen, txtHoTen,
                labelTongTien, txtTongTien,
                btnThanhToan, btnInHoaDon,
                labelHoaDon, txtHoaDon
            });

            // Add all controls to form
            this.Controls.AddRange(new Control[]
            {
                pnlNavbar,
                groupChonPhim,
                groupVe,
                groupDoAn,
                groupThanhToan
            });
        }

        private Label labelHoTen, labelTimKiem, labelTheLoai, labelLichChieu, labelLoaiVe, labelGhe, labelTongTien, labelHoaDon;
        private TextBox txtHoTen, txtTimKiem, txtGhe, txtTongTien, txtHoaDon;
        private ComboBox cboTheLoai, cboLichChieu, cboLoaiVe;
        private ListView lstPhim;
        private Button btnChonGhe, btnMuaDoAn, btnThanhToan, btnInHoaDon, btnViewProfile, btnLichSuMuaVe, btnDangXuat;
    }
}