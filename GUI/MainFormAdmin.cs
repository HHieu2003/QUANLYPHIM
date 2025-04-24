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
    public partial class MainFormAdmin : Form
    {

        private void InitializeSidebarButtons()
        {
            Button[] buttons = {
                btnLichChieu, 
                btnVe, 
                btnKhachHang,
                btnNguoiDung,
                btnPhim, 
                btnBaoCao,
                btnTheLoaiPhim,
                btnPhongChieu, 
                btnDoAn,
                btnDonHang,
                btnChiTietDoAn
             };

            string[] texts = {
                "📺  Lịch chiếu", 
                "🎫  Vé & loại vé", 
                "👤  Khách hàng", 
                "👨‍💼  Người dùng",
                "🎬  Quản lý phim",
                "📊  Báo cáo", 
                "🎞️  Thể loại phim", 
                "🏢  Phòng chiếu", 
                "🍿  Quản lý đồ ăn", 
                "🧾  Đơn hàng", 
                "📦  Chi tiết đồ ăn"
               };

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = texts[i];
                buttons[i].Dock = DockStyle.Top;
                buttons[i].Height = 55;
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].FlatAppearance.BorderSize = 0;
                buttons[i].BackColor = Color.FromArgb(45, 45, 48);
                buttons[i].ForeColor = Color.White;
                buttons[i].Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
                buttons[i].TextAlign = ContentAlignment.MiddleLeft;
                buttons[i].Padding = new Padding(20, 0, 0, 0);
            }
        }

        public MainFormAdmin()
        {
            InitializeComponent();
            welcomeTimer.Start();
            InitializeSidebarButtons();
        }

        private void LoadFormToPanel(Form form)
        {
            pnlContent.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(form);
            form.Show();
        }

        private void WelcomeTimer_Tick(object sender, EventArgs e)
        {
            welcomeTimer.Stop();
            pnlContent.Controls.Remove(lblWelcome);
        }

        private void btnPhim_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmPhim());
        }

        private void btnLichChieu_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmLichChieu());
        }

        private void btnVe_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmBanVe());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmKhachHang());
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmNguoiDung());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmBaoCao());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTheLoaiPhim_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmTheLoaiPhim());
        }

        private void btnPhongChieu_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmPhongChieu());
        }

        private void btnDoAn_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmDoAn());
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmDonHang());
        }

        private void btnChiTietDoAn_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmChiTietDoAn());
        }
    }
}
