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
        private Button btnTheLoaiPhim, btnPhongChieu, btnDoAn, btnDonHang, btnChiTietDoAn, btnBanVe;
        private Button btnThoat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnPhim = new System.Windows.Forms.Button();
            this.btnTheLoaiPhim = new System.Windows.Forms.Button();
            this.btnLichChieu = new System.Windows.Forms.Button();
            this.btnPhongChieu = new System.Windows.Forms.Button();
            this.btnVe = new System.Windows.Forms.Button();
            this.btnDonHang = new System.Windows.Forms.Button();
            this.btnDoAn = new System.Windows.Forms.Button();
            this.btnChiTietDoAn = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnNguoiDung = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnBanVe = new System.Windows.Forms.Button();
            this.welcomeTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlMenu.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlMenu.Controls.Add(this.btnPhim);
            this.pnlMenu.Controls.Add(this.btnTheLoaiPhim);
            this.pnlMenu.Controls.Add(this.btnLichChieu);
            this.pnlMenu.Controls.Add(this.btnPhongChieu);
            this.pnlMenu.Controls.Add(this.btnVe);
            this.pnlMenu.Controls.Add(this.btnDonHang);
            this.pnlMenu.Controls.Add(this.btnDoAn);
            this.pnlMenu.Controls.Add(this.btnChiTietDoAn);
            this.pnlMenu.Controls.Add(this.btnKhachHang);
            this.pnlMenu.Controls.Add(this.btnNguoiDung);
            this.pnlMenu.Controls.Add(this.btnBaoCao);
            this.pnlMenu.Controls.Add(this.pnlFooter);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(225, 487);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnPhim
            // 
            this.btnPhim.Location = new System.Drawing.Point(0, 0);
            this.btnPhim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPhim.Name = "btnPhim";
            this.btnPhim.Size = new System.Drawing.Size(225, 40);
            this.btnPhim.TabIndex = 0;
            this.btnPhim.Click += new System.EventHandler(this.btnPhim_Click);
            // 
            // btnTheLoaiPhim
            // 
            this.btnTheLoaiPhim.Location = new System.Drawing.Point(0, 0);
            this.btnTheLoaiPhim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTheLoaiPhim.Name = "btnTheLoaiPhim";
            this.btnTheLoaiPhim.Size = new System.Drawing.Size(56, 15);
            this.btnTheLoaiPhim.TabIndex = 1;
            this.btnTheLoaiPhim.Click += new System.EventHandler(this.btnTheLoaiPhim_Click);
            // 
            // btnLichChieu
            // 
            this.btnLichChieu.Location = new System.Drawing.Point(0, 0);
            this.btnLichChieu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLichChieu.Name = "btnLichChieu";
            this.btnLichChieu.Size = new System.Drawing.Size(56, 15);
            this.btnLichChieu.TabIndex = 2;
            this.btnLichChieu.Click += new System.EventHandler(this.btnLichChieu_Click);
            // 
            // btnPhongChieu
            // 
            this.btnPhongChieu.Location = new System.Drawing.Point(0, 0);
            this.btnPhongChieu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPhongChieu.Name = "btnPhongChieu";
            this.btnPhongChieu.Size = new System.Drawing.Size(56, 15);
            this.btnPhongChieu.TabIndex = 3;
            this.btnPhongChieu.Click += new System.EventHandler(this.btnPhongChieu_Click);
            // 
            // btnVe
            // 
            this.btnVe.Location = new System.Drawing.Point(0, 0);
            this.btnVe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVe.Name = "btnVe";
            this.btnVe.Size = new System.Drawing.Size(56, 15);
            this.btnVe.TabIndex = 4;
            this.btnVe.Click += new System.EventHandler(this.btnVe_Click);
            // 
            // btnDonHang
            // 
            this.btnDonHang.Location = new System.Drawing.Point(0, 0);
            this.btnDonHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.Size = new System.Drawing.Size(56, 15);
            this.btnDonHang.TabIndex = 5;
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);
            // 
            // btnDoAn
            // 
            this.btnDoAn.Location = new System.Drawing.Point(0, 0);
            this.btnDoAn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDoAn.Name = "btnDoAn";
            this.btnDoAn.Size = new System.Drawing.Size(56, 15);
            this.btnDoAn.TabIndex = 6;
            this.btnDoAn.Click += new System.EventHandler(this.btnDoAn_Click);
            // 
            // btnChiTietDoAn
            // 
            this.btnChiTietDoAn.Location = new System.Drawing.Point(0, 0);
            this.btnChiTietDoAn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChiTietDoAn.Name = "btnChiTietDoAn";
            this.btnChiTietDoAn.Size = new System.Drawing.Size(56, 15);
            this.btnChiTietDoAn.TabIndex = 7;
            this.btnChiTietDoAn.Click += new System.EventHandler(this.btnChiTietDoAn_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Location = new System.Drawing.Point(0, 0);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(56, 15);
            this.btnKhachHang.TabIndex = 8;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnNguoiDung
            // 
            this.btnNguoiDung.Location = new System.Drawing.Point(0, 0);
            this.btnNguoiDung.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNguoiDung.Name = "btnNguoiDung";
            this.btnNguoiDung.Size = new System.Drawing.Size(56, 15);
            this.btnNguoiDung.TabIndex = 9;
            this.btnNguoiDung.Click += new System.EventHandler(this.btnNguoiDung_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(0, 0);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(56, 15);
            this.btnBaoCao.TabIndex = 10;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlFooter.Controls.Add(this.btnThoat);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 438);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(225, 49);
            this.pnlFooter.TabIndex = 11;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.DarkRed;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(0, 0);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThoat.Size = new System.Drawing.Size(225, 49);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "🚪  Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Teal;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(225, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(803, 59);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(801, 57);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🎥 HỆ THỐNG QUẢN LÝ RẠP CHIẾU PHIM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.Controls.Add(this.lblWelcome);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(225, 59);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(803, 428);
            this.pnlContent.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.Teal;
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(803, 428);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "👋 Xin chào, chúc bạn một ngày làm việc hiệu quả!";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBanVe
            // 
            this.btnBanVe.Location = new System.Drawing.Point(0, 0);
            this.btnBanVe.Name = "btnBanVe";
            this.btnBanVe.Size = new System.Drawing.Size(75, 23);
            this.btnBanVe.TabIndex = 0;
            // 
            // welcomeTimer
            // 
            this.welcomeTimer.Interval = 2500;
            this.welcomeTimer.Tick += new System.EventHandler(this.WelcomeTimer_Tick);
            // 
            // MainFormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 487);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlMenu);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(1027, 492);
            this.Name = "MainFormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý rạp chiếu phim";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMenu.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
