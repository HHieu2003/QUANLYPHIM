using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmLichSuMuaVe
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private GroupBox groupLichSu;
        private DataGridView dgvLichSuMuaVe;
        private Button btnClose;

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
            this.ClientSize = new Size(1000, 600);
            this.Text = "Lịch Sử Mua Vé";
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
                Text = "LỊCH SỬ MUA VÉ",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlHeader.Controls.Add(lblTitle);

            // GroupBox: Lịch sử mua vé
            groupLichSu = new GroupBox
            {
                Text = "Danh Sách Vé Đã Mua",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136), // Màu Teal
                Location = new Point(10, 70), // Giảm khoảng cách để sát viền
                Size = new Size(980, 480), // Tăng kích thước để lấp đầy không gian
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White
            };

            // DataGridView: Lịch sử mua vé
            dgvLichSuMuaVe = new DataGridView
            {
                Location = new Point(10, 40),
                Size = new Size(960, 430), // Tăng kích thước để lấp đầy GroupBox
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(224, 224, 224), // Màu đường lưới nhạt
                RowHeadersVisible = false // Ẩn cột tiêu đề hàng
            };

            // Tùy chỉnh phong cách cho DataGridView
            dgvLichSuMuaVe.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 136); // Header màu Teal
            dgvLichSuMuaVe.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLichSuMuaVe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvLichSuMuaVe.EnableHeadersVisualStyles = false;
            dgvLichSuMuaVe.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Màu xen kẽ hàng
            dgvLichSuMuaVe.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgvLichSuMuaVe.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 182, 172); // Màu chọn hàng
            dgvLichSuMuaVe.DefaultCellStyle.SelectionForeColor = Color.White;

            groupLichSu.Controls.Add(dgvLichSuMuaVe);

            // Button: Close
            btnClose = new Button
            {
                Text = "🚪 Đóng",
                Location = new Point(850, 560), // Đặt sát góc dưới bên phải
                Size = new Size(140, 40),
                BackColor = Color.FromArgb(0, 150, 136), // Màu Teal
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(77, 182, 172); // Hiệu ứng hover
            btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // Add controls to form
            this.Controls.AddRange(new Control[] { groupLichSu, btnClose, pnlHeader });
        }
    }
}