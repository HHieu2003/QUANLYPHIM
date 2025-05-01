using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainFormNhanVien : Form
    {
        private string maNhanVien;
        private string hoTenNhanVien;

        private void InitializeSidebarButtons()
        {
            // Main buttons (excluding the ones to be grouped)
            Button[] mainButtons = {
                btnQuanLyPhim, // This will be the parent button for the submenu
                btnVeAndLoaiVe,
                btnKhachHang,
                btnNguoiDung,
                btnDoAn,
                btnDonHang,
                btnChiTietDoAn,
                btnBanDoAn,
                btnBanVeTaiQuay,
                btnThoat // Add btnThoat to mainButtons since pnlFooter is removed
            };

            string[] mainTexts = {
                "🎬  Quản lý phim",
                "🎫  Vé và loại vé",
                "👤  Khách hàng",
                "👨‍💼  Người dùng",
                "🍿  Quản lý đồ ăn",
                "🧾  Đơn hàng",
                "📦  Chi tiết đồ ăn",
                "🍽️  Bán đồ ăn",
                "🎟️  Bán vé",
                "🚪  Thoát"
            };

            // Style the main buttons
            for (int i = 0; i < mainButtons.Length; i++)
            {
                mainButtons[i].Text = mainTexts[i];
                mainButtons[i].Dock = DockStyle.Top;
                mainButtons[i].Height = 50;
                mainButtons[i].FlatStyle = FlatStyle.Flat;
                mainButtons[i].FlatAppearance.BorderSize = 0;
                mainButtons[i].BackColor = (i == mainButtons.Length - 1) ? Color.DarkRed : Color.FromArgb(45, 45, 48); // Special color for "Thoát"
                mainButtons[i].ForeColor = Color.White;
                mainButtons[i].Font = new Font("Segoe UI", (i == mainButtons.Length - 1) ? 13F : 12.5F, FontStyle.Bold);
                mainButtons[i].TextAlign = ContentAlignment.MiddleLeft;
                mainButtons[i].Padding = new Padding(20, 0, 0, 0);
            }

            // Submenu buttons under "Quản lý phim"
            Button[] subMenuButtons = {
                btnPhim,
                btnPhongChieu,
                btnLichChieu,
                btnTheLoaiPhim
            };

            string[] subMenuTexts = {
                "🎬  Quản lý phim",
                "🏢  Phòng chiếu",
                "📺  Lịch chiếu",
                "🎞️  Thể loại phim"
            };

            // Style the submenu buttons
            for (int i = 0; i < subMenuButtons.Length; i++)
            {
                subMenuButtons[i].Text = subMenuTexts[i];
                subMenuButtons[i].Width = 140;
                subMenuButtons[i].Height = 45;
                subMenuButtons[i].FlatStyle = FlatStyle.Flat;
                subMenuButtons[i].FlatAppearance.BorderSize = 0;
                subMenuButtons[i].BackColor = Color.FromArgb(60, 60, 63);
                subMenuButtons[i].ForeColor = Color.White;
                subMenuButtons[i].Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                subMenuButtons[i].TextAlign = ContentAlignment.MiddleCenter;
            }

            // Use FlowLayoutPanel to arrange submenu buttons horizontally
            flowLayoutPanelSubMenu.Controls.AddRange(subMenuButtons);

            // Initially hide the submenu
            pnlSubMenuQuanLyPhim.Visible = false;

            // Position the submenu panel to the right of the sidebar
            pnlSubMenuQuanLyPhim.Width = subMenuButtons.Length * 150;
            pnlSubMenuQuanLyPhim.Height = 45;
        }

        public MainFormNhanVien(string maNhanVien = "ADMIN", string hoTenNhanVien = "Quản trị viên")
        {
            this.maNhanVien = maNhanVien;
            this.hoTenNhanVien = hoTenNhanVien;
            InitializeComponent();
            welcomeTimer.Start();
            InitializeSidebarButtons();
            this.Resize += new EventHandler(MainFormNhanVien_Resize);
        }

        private void MainFormNhanVien_Resize(object sender, EventArgs e)
        {
            pnlMenu.Height = this.ClientSize.Height - pnlHeader.Height; // No pnlFooter, so span to bottom
            pnlContent.Location = new Point(pnlMenu.Width, pnlHeader.Height);
            pnlContent.Width = this.ClientSize.Width - pnlMenu.Width;
            pnlContent.Height = this.ClientSize.Height - pnlHeader.Height;
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

        // Show submenu on hover
        private void btnQuanLyPhim_MouseEnter(object sender, EventArgs e)
        {
            Point btnLocation = btnQuanLyPhim.PointToScreen(Point.Empty);
            Point formLocation = this.PointToScreen(Point.Empty);
            int x = pnlMenu.Width;
            int y = btnLocation.Y - formLocation.Y;
            pnlSubMenuQuanLyPhim.Location = new Point(x, y);
            pnlSubMenuQuanLyPhim.Visible = true;
            pnlSubMenuQuanLyPhim.BringToFront();
        }

        // Hide submenu when leaving the parent button or submenu
        private void btnQuanLyPhim_MouseLeave(object sender, EventArgs e)
        {
            Point mousePosition = this.PointToClient(MousePosition);
            if (!pnlSubMenuQuanLyPhim.Bounds.Contains(mousePosition))
            {
                pnlSubMenuQuanLyPhim.Visible = false;
            }
        }

        private void pnlSubMenuQuanLyPhim_MouseLeave(object sender, EventArgs e)
        {
            Point mousePosition = this.PointToClient(MousePosition);
            if (!pnlSubMenuQuanLyPhim.Bounds.Contains(mousePosition) &&
                !btnQuanLyPhim.Bounds.Contains(mousePosition))
            {
                pnlSubMenuQuanLyPhim.Visible = false;
            }
        }

        // Submenu button click handlers
        private void btnPhim_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmPhim());
            pnlSubMenuQuanLyPhim.Visible = false;
        }

        private void btnLichChieu_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmLichChieu());
            pnlSubMenuQuanLyPhim.Visible = false;
        }

        private void btnTheLoaiPhim_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmTheLoaiPhim());
            pnlSubMenuQuanLyPhim.Visible = false;
        }

        private void btnPhongChieu_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmPhongChieu());
            pnlSubMenuQuanLyPhim.Visible = false;
        }

        private void btnVeAndLoaiVe_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmVeAndLoaiVe());
        }

        private void btnBanDoAn_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmBanDoAn(maNhanVien, hoTenNhanVien));
        }

        private void btnBanVeTaiQuay_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmBanVe(maNhanVien, hoTenNhanVien));
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmKhachHang());
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmNguoiDung());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            /*  DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (result == DialogResult.Yes)
              {
                  Application.Exit();
              }*/
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Login loginForm = new Login();
                loginForm.Show();
            }
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