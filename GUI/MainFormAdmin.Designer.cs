using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class MainFormAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMenu, pnlHeader, pnlContent;
        private Label lblTitle;
        private Label lblWelcome;
        private Timer welcomeTimer;
        private Button btnQuanLyPhim;
        private Panel pnlSubMenuQuanLyPhim;
        private FlowLayoutPanel flowLayoutPanelSubMenu;
        private Button btnPhim, btnLichChieu, btnTheLoaiPhim, btnPhongChieu;
        private Button btnVeAndLoaiVe, btnKhachHang, btnNguoiDung;
        private Button btnDoAn, btnDonHang, btnChiTietDoAn;
        private Button btnBanDoAn, btnBanVeTaiQuay;
        private Button btnThoat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new Panel();
            this.pnlMenu = new Panel();
            this.pnlContent = new Panel();
            this.lblTitle = new Label();
            this.lblWelcome = new Label();
            this.welcomeTimer = new Timer(this.components);
            this.btnQuanLyPhim = new Button();
            this.pnlSubMenuQuanLyPhim = new Panel();
            this.flowLayoutPanelSubMenu = new FlowLayoutPanel();
            this.btnPhim = new Button();
            this.btnTheLoaiPhim = new Button();
            this.btnLichChieu = new Button();
            this.btnPhongChieu = new Button();
            this.btnVeAndLoaiVe = new Button();
            this.btnDonHang = new Button();
            this.btnDoAn = new Button();
            this.btnChiTietDoAn = new Button();
            this.btnKhachHang = new Button();
            this.btnNguoiDung = new Button();
            this.btnBanDoAn = new Button();
            this.btnBanVeTaiQuay = new Button();
            this.btnThoat = new Button();

            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlSubMenuQuanLyPhim.SuspendLayout();
            this.flowLayoutPanelSubMenu.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 90;
            this.pnlHeader.BackColor = Color.Teal;
            this.pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Text = "🎥 HỆ THỐNG QUẢN LÝ RẠP CHIẾU PHIM";
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;

            // pnlMenu
            this.pnlMenu.BackColor = Color.FromArgb(30, 30, 30);
            this.pnlMenu.Location = new Point(0, 90);
            this.pnlMenu.Width = 300;
            this.pnlMenu.Height = this.ClientSize.Height - 90; // Span to bottom of form
            this.pnlMenu.Controls.AddRange(new Control[] {
                btnThoat, // Add btnThoat directly to pnlMenu, docked at bottom
                btnDonHang,
                btnChiTietDoAn,
                btnBanDoAn,
                btnBanVeTaiQuay,
                btnVeAndLoaiVe,
                btnDoAn,
                btnNguoiDung,
                btnKhachHang,
                btnQuanLyPhim
            });

            // pnlContent
            this.pnlContent.Location = new Point(300, 90);
            this.pnlContent.Width = this.ClientSize.Width - 300;
            this.pnlContent.Height = this.ClientSize.Height - 90;
            this.pnlContent.BackColor = Color.WhiteSmoke;
            this.pnlContent.Controls.Add(this.lblWelcome);

            // lblWelcome
            this.lblWelcome.Text = "👋 Xin chào, chúc bạn một ngày làm việc hiệu quả!";
            this.lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.Teal;
            this.lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            this.lblWelcome.Dock = DockStyle.Fill;

            // welcomeTimer
            this.welcomeTimer.Interval = 2500;
            this.welcomeTimer.Tick += new System.EventHandler(this.WelcomeTimer_Tick);

            // btnQuanLyPhim (Parent button for submenu)
            this.btnQuanLyPhim.Dock = DockStyle.Top;
            this.btnQuanLyPhim.Height = 55;
            this.btnQuanLyPhim.FlatStyle = FlatStyle.Flat;
            this.btnQuanLyPhim.FlatAppearance.BorderSize = 0;
            this.btnQuanLyPhim.BackColor = Color.FromArgb(45, 45, 48);
            this.btnQuanLyPhim.ForeColor = Color.White;
            this.btnQuanLyPhim.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            this.btnQuanLyPhim.TextAlign = ContentAlignment.MiddleLeft;
            this.btnQuanLyPhim.Padding = new Padding(20, 0, 0, 0);
            this.btnQuanLyPhim.MouseEnter += new EventHandler(this.btnQuanLyPhim_MouseEnter);
            this.btnQuanLyPhim.MouseLeave += new EventHandler(this.btnQuanLyPhim_MouseLeave);

            // pnlSubMenuQuanLyPhim (Submenu panel)
            this.pnlSubMenuQuanLyPhim.Location = new Point(300, 100);
            this.pnlSubMenuQuanLyPhim.Width = 560;
            this.pnlSubMenuQuanLyPhim.Height = 45;
            this.pnlSubMenuQuanLyPhim.BackColor = Color.FromArgb(60, 60, 63);
            this.pnlSubMenuQuanLyPhim.Visible = false;
            this.pnlSubMenuQuanLyPhim.Controls.Add(this.flowLayoutPanelSubMenu);
            this.pnlSubMenuQuanLyPhim.MouseLeave += new EventHandler(this.pnlSubMenuQuanLyPhim_MouseLeave);

            // flowLayoutPanelSubMenu (To arrange submenu buttons horizontally)
            this.flowLayoutPanelSubMenu.Dock = DockStyle.Fill;
            this.flowLayoutPanelSubMenu.FlowDirection = FlowDirection.LeftToRight;
            this.flowLayoutPanelSubMenu.WrapContents = false;

            // btnPhim
            this.btnPhim.Width = 140;
            this.btnPhim.Height = 45;
            this.btnPhim.FlatStyle = FlatStyle.Flat;
            this.btnPhim.FlatAppearance.BorderSize = 0;
            this.btnPhim.BackColor = Color.FromArgb(60, 60, 63);
            this.btnPhim.ForeColor = Color.White;
            this.btnPhim.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            this.btnPhim.TextAlign = ContentAlignment.MiddleCenter;
            this.btnPhim.Click += new System.EventHandler(this.btnPhim_Click);

            // btnTheLoaiPhim
            this.btnTheLoaiPhim.Width = 140;
            this.btnTheLoaiPhim.Height = 45;
            this.btnTheLoaiPhim.FlatStyle = FlatStyle.Flat;
            this.btnTheLoaiPhim.FlatAppearance.BorderSize = 0;
            this.btnTheLoaiPhim.BackColor = Color.FromArgb(60, 60, 63);
            this.btnTheLoaiPhim.ForeColor = Color.White;
            this.btnTheLoaiPhim.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            this.btnTheLoaiPhim.TextAlign = ContentAlignment.MiddleCenter;
            this.btnTheLoaiPhim.Click += new System.EventHandler(this.btnTheLoaiPhim_Click);

            // btnLichChieu
            this.btnLichChieu.Width = 140;
            this.btnLichChieu.Height = 45;
            this.btnLichChieu.FlatStyle = FlatStyle.Flat;
            this.btnLichChieu.FlatAppearance.BorderSize = 0;
            this.btnLichChieu.BackColor = Color.FromArgb(60, 60, 63);
            this.btnLichChieu.ForeColor = Color.White;
            this.btnLichChieu.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            this.btnLichChieu.TextAlign = ContentAlignment.MiddleCenter;
            this.btnLichChieu.Click += new System.EventHandler(this.btnLichChieu_Click);

            // btnPhongChieu
            this.btnPhongChieu.Width = 140;
            this.btnPhongChieu.Height = 45;
            this.btnPhongChieu.FlatStyle = FlatStyle.Flat;
            this.btnPhongChieu.FlatAppearance.BorderSize = 0;
            this.btnPhongChieu.BackColor = Color.FromArgb(60, 60, 63);
            this.btnPhongChieu.ForeColor = Color.White;
            this.btnPhongChieu.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            this.btnPhongChieu.TextAlign = ContentAlignment.MiddleCenter;
            this.btnPhongChieu.Click += new System.EventHandler(this.btnPhongChieu_Click);

            // btnVeAndLoaiVe
            this.btnVeAndLoaiVe.Dock = DockStyle.Top;
            this.btnVeAndLoaiVe.Height = 55;
            this.btnVeAndLoaiVe.FlatStyle = FlatStyle.Flat;
            this.btnVeAndLoaiVe.FlatAppearance.BorderSize = 0;
            this.btnVeAndLoaiVe.BackColor = Color.FromArgb(45, 45, 48);
            this.btnVeAndLoaiVe.ForeColor = Color.White;
            this.btnVeAndLoaiVe.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            this.btnVeAndLoaiVe.TextAlign = ContentAlignment.MiddleLeft;
            this.btnVeAndLoaiVe.Padding = new Padding(20, 0, 0, 0);
            this.btnVeAndLoaiVe.Click += new System.EventHandler(this.btnVeAndLoaiVe_Click);

            // btnDonHang
            this.btnDonHang.Dock = DockStyle.Top;
            this.btnDonHang.Height = 55;
            this.btnDonHang.FlatStyle = FlatStyle.Flat;
            this.btnDonHang.FlatAppearance.BorderSize = 0;
            this.btnDonHang.BackColor = Color.FromArgb(45, 45, 48);
            this.btnDonHang.ForeColor = Color.White;
            this.btnDonHang.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            this.btnDonHang.TextAlign = ContentAlignment.MiddleLeft;
            this.btnDonHang.Padding = new Padding(20, 0, 0, 0);
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);

            // btnDoAn
            this.btnDoAn.Dock = DockStyle.Top;
            this.btnDoAn.Height = 55;
            this.btnDoAn.FlatStyle = FlatStyle.Flat;
            this.btnDoAn.FlatAppearance.BorderSize = 0;
            this.btnDoAn.BackColor = Color.FromArgb(45, 45, 48);
            this.btnDoAn.ForeColor = Color.White;
            this.btnDoAn.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            this.btnDoAn.TextAlign = ContentAlignment.MiddleLeft;
            this.btnDoAn.Padding = new Padding(20, 0, 0, 0);
            this.btnDoAn.Click += new System.EventHandler(this.btnDoAn_Click);

            // btnChiTietDoAn
            this.btnChiTietDoAn.Dock = DockStyle.Top;
            this.btnChiTietDoAn.Height = 55;
            this.btnChiTietDoAn.FlatStyle = FlatStyle.Flat;
            this.btnChiTietDoAn.FlatAppearance.BorderSize = 0;
            this.btnChiTietDoAn.BackColor = Color.FromArgb(45, 45, 48);
            this.btnChiTietDoAn.ForeColor = Color.White;
            this.btnChiTietDoAn.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            this.btnChiTietDoAn.TextAlign = ContentAlignment.MiddleLeft;
            this.btnChiTietDoAn.Padding = new Padding(20, 0, 0, 0);
            this.btnChiTietDoAn.Click += new System.EventHandler(this.btnChiTietDoAn_Click);

            // btnKhachHang
            this.btnKhachHang.Dock = DockStyle.Top;
            this.btnKhachHang.Height = 55;
            this.btnKhachHang.FlatStyle = FlatStyle.Flat;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.BackColor = Color.FromArgb(45, 45, 48);
            this.btnKhachHang.ForeColor = Color.White;
            this.btnKhachHang.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            this.btnKhachHang.TextAlign = ContentAlignment.MiddleLeft;
            this.btnKhachHang.Padding = new Padding(20, 0, 0, 0);
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);

            // btnNguoiDung
            this.btnNguoiDung.Dock = DockStyle.Top;
            this.btnNguoiDung.Height = 55;
            this.btnNguoiDung.FlatStyle = FlatStyle.Flat;
            this.btnNguoiDung.FlatAppearance.BorderSize = 0;
            this.btnNguoiDung.BackColor = Color.FromArgb(45, 45, 48);
            this.btnNguoiDung.ForeColor = Color.White;
            this.btnNguoiDung.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            this.btnNguoiDung.TextAlign = ContentAlignment.MiddleLeft;
            this.btnNguoiDung.Padding = new Padding(20, 0, 0, 0);
            this.btnNguoiDung.Click += new System.EventHandler(this.btnNguoiDung_Click);

            // btnBanDoAn
            this.btnBanDoAn.Dock = DockStyle.Top;
            this.btnBanDoAn.Height = 55;
            this.btnBanDoAn.FlatStyle = FlatStyle.Flat;
            this.btnBanDoAn.FlatAppearance.BorderSize = 0;
            this.btnBanDoAn.BackColor = Color.FromArgb(45, 45, 48);
            this.btnBanDoAn.ForeColor = Color.White;
            this.btnBanDoAn.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            this.btnBanDoAn.TextAlign = ContentAlignment.MiddleLeft;
            this.btnBanDoAn.Padding = new Padding(20, 0, 0, 0);
            this.btnBanDoAn.Click += new System.EventHandler(this.btnBanDoAn_Click);

            // btnBanVeTaiQuay
            this.btnBanVeTaiQuay.Dock = DockStyle.Top;
            this.btnBanVeTaiQuay.Height = 55;
            this.btnBanVeTaiQuay.FlatStyle = FlatStyle.Flat;
            this.btnBanVeTaiQuay.FlatAppearance.BorderSize = 0;
            this.btnBanVeTaiQuay.BackColor = Color.FromArgb(45, 45, 48);
            this.btnBanVeTaiQuay.ForeColor = Color.White;
            this.btnBanVeTaiQuay.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            this.btnBanVeTaiQuay.TextAlign = ContentAlignment.MiddleLeft;
            this.btnBanVeTaiQuay.Padding = new Padding(20, 0, 0, 0);
            this.btnBanVeTaiQuay.Click += new System.EventHandler(this.btnBanVeTaiQuay_Click);

            // btnThoat
            this.btnThoat.Text = "🚪  Thoát";
            this.btnThoat.Dock = DockStyle.Top; // Now docked to top like other buttons, but appears at bottom due to order
            this.btnThoat.Height = 55;
            this.btnThoat.FlatStyle = FlatStyle.Flat;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.BackColor = Color.DarkRed;
            this.btnThoat.ForeColor = Color.White;
            this.btnThoat.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnThoat.TextAlign = ContentAlignment.MiddleLeft;
            this.btnThoat.Padding = new Padding(20, 0, 0, 0);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // MainFormAdmin
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1920, 1080);
            this.Controls.Add(this.pnlSubMenuQuanLyPhim);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.Name = "MainFormAdmin";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1440, 900);
            this.Text = "Hệ thống quản lý rạp chiếu phim";

            this.pnlHeader.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlSubMenuQuanLyPhim.ResumeLayout(false);
            this.flowLayoutPanelSubMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}