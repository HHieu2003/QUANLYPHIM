using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class MainFormAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMenu, pnlHeader, pnlContent, pnlFooter;
        private Label lblTitle;
        private Label lblWelcome;
        private Timer welcomeTimer;
        private Button btnPhim, btnLichChieu, btnVe, btnKhachHang, btnNguoiDung, btnBaoCao;
        private Button btnTheLoaiPhim, btnPhongChieu, btnDoAn, btnDonHang, btnChiTietDoAn;
        private Button btnThoat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMenu = new Panel();
            this.pnlHeader = new Panel();
            this.pnlContent = new Panel();
            this.pnlFooter = new Panel();
            this.lblTitle = new Label();

            // Khởi tạo các nút
            this.btnPhim = new Button();
            this.btnLichChieu = new Button();
            this.btnVe = new Button();
            this.btnKhachHang = new Button();
            this.btnNguoiDung = new Button();
            this.btnBaoCao = new Button();
            this.btnTheLoaiPhim = new Button();
            this.btnPhongChieu = new Button();
            this.btnDoAn = new Button();
            this.btnDonHang = new Button();
            this.btnChiTietDoAn = new Button();
            this.btnThoat = new Button();

            this.pnlMenu.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // frmMain
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1920, 1080);
            this.Name = "frmMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1440, 900);
            this.Text = "Hệ thống quản lý rạp chiếu phim";

            // pnlMenu
            this.pnlMenu.BackColor = Color.FromArgb(30, 30, 30);
            this.pnlMenu.Dock = DockStyle.Left;
            this.pnlMenu.Width = 300;
            this.pnlMenu.Controls.AddRange(new Control[] {
                btnPhim, btnTheLoaiPhim, btnLichChieu, btnPhongChieu,
                btnVe, btnDonHang,
                btnDoAn, btnChiTietDoAn,
                btnKhachHang, btnNguoiDung,
                btnBaoCao,
                pnlFooter
            });

            // pnlFooter
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Height = 75;
            this.pnlFooter.BackColor = Color.FromArgb(30, 30, 30);
            this.pnlFooter.Controls.Add(this.btnThoat);

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

            // pnlContent
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.BackColor = Color.WhiteSmoke;

            // lblWelcome
            this.lblWelcome = new Label();
            this.lblWelcome.Text = "👋 Xin chào, chúc bạn một ngày làm việc hiệu quả!";
            this.lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.Teal;
            this.lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            this.lblWelcome.Dock = DockStyle.Fill;
            this.pnlContent.Controls.Add(this.lblWelcome);

            // welcomeTimer
            this.welcomeTimer = new Timer();
            this.welcomeTimer.Interval = 2500; // 2.5 giây
            this.welcomeTimer.Tick += new System.EventHandler(this.WelcomeTimer_Tick);


 

            // btnThoat
            this.btnThoat.Text = "🚪  Thoát";
            this.btnThoat.Dock = DockStyle.Fill;
            this.btnThoat.FlatStyle = FlatStyle.Flat;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.BackColor = Color.DarkRed;
            this.btnThoat.ForeColor = Color.White;
            this.btnThoat.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnThoat.TextAlign = ContentAlignment.MiddleLeft;
            this.btnThoat.Padding = new Padding(20, 0, 0, 0);

            // Gắn sự kiện
            this.btnPhim.Click += new System.EventHandler(this.btnPhim_Click);
            this.btnLichChieu.Click += new System.EventHandler(this.btnLichChieu_Click);
            this.btnVe.Click += new System.EventHandler(this.btnVe_Click);
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            this.btnNguoiDung.Click += new System.EventHandler(this.btnNguoiDung_Click);
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            this.btnTheLoaiPhim.Click += new System.EventHandler(this.btnTheLoaiPhim_Click);
            this.btnPhongChieu.Click += new System.EventHandler(this.btnPhongChieu_Click);
            this.btnDoAn.Click += new System.EventHandler(this.btnDoAn_Click);
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);
            this.btnChiTietDoAn.Click += new System.EventHandler(this.btnChiTietDoAn_Click);

            // Thêm panel
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlMenu);

            this.pnlMenu.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
