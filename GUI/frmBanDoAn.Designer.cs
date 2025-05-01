// File: frmBanDoAn.Designer.cs - Giao diện tối ưu đẹp mắt
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmBanDoAn
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel layoutMain;
        private GroupBox groupNhanVien, groupDoAn, groupHoaDon;
        private Label lblMaNhanVien, lblHoTenNhanVien, lblTongTien;
        private TextBox txtMaNhanVien, txtHoTenNhanVien, txtTongTien, txtHoaDon;
        private DataGridView dgvDoAn;
        private Button btnThanhToan, btnInHoaDon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "Bán Đồ Ăn";
            this.ClientSize = new Size(980, 580);
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            layoutMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                Padding = new Padding(10),
                ColumnStyles = {
                    new ColumnStyle(SizeType.Percent, 45),
                    new ColumnStyle(SizeType.Percent, 55)
                }
            };

            // Group thông tin nhân viên
            groupNhanVien = new GroupBox
            {
                Text = "Thông tin nhân viên",
                Dock = DockStyle.Top,
                Height = 100,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Teal
            };
            lblMaNhanVien = new Label { Text = "Mã NV:", Location = new Point(20, 30), AutoSize = true };
            txtMaNhanVien = new TextBox { Location = new Point(100, 27), Width = 180, ReadOnly = true };
            lblHoTenNhanVien = new Label { Text = "Họ tên:", Location = new Point(20, 60), AutoSize = true };
            txtHoTenNhanVien = new TextBox { Location = new Point(100, 57), Width = 180, ReadOnly = true };
            groupNhanVien.Controls.AddRange(new Control[] { lblMaNhanVien, txtMaNhanVien, lblHoTenNhanVien, txtHoTenNhanVien });

            // Group chọn đồ ăn
            groupDoAn = new GroupBox
            {
                Text = "Chọn đồ ăn",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Teal
            };
            dgvDoAn = new DataGridView
            {
                Dock = DockStyle.Fill,
                RowTemplate = { Height = 30 },
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                GridColor = Color.LightGray,
                BackgroundColor = Color.White
            };
            dgvDoAn.CellValueChanged += new DataGridViewCellEventHandler(this.dgvDoAn_CellValueChanged);
            groupDoAn.Controls.Add(dgvDoAn);

            // Panel tổng tiền + nút (dùng FlowLayoutPanel để bố cục đều)
            var panelBottomLeft = new Panel { Dock = DockStyle.Bottom, Height = 70 };
            var layoutBottom = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                AutoSize = false
            };

            lblTongTien = new Label
            {
                Text = "Tổng tiền:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(5, 12, 5, 0)
            };

            txtTongTien = new TextBox
            {
                Width = 120,
                ReadOnly = true,
                Margin = new Padding(0, 10, 20, 0),
                TextAlign = HorizontalAlignment.Right
            };

            btnThanhToan = new Button
            {
                Text = "Thanh toán",
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 110,
                Height = 35,
                Margin = new Padding(10, 8, 10, 0)
            };
            btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

            btnInHoaDon = new Button
            {
                Text = "In hóa đơn",
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 110,
                Height = 35,
                Margin = new Padding(0, 8, 0, 0),
                Enabled = false
            };
            btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);

            layoutBottom.Controls.AddRange(new Control[] { lblTongTien, txtTongTien, btnThanhToan, btnInHoaDon });
            panelBottomLeft.Controls.Add(layoutBottom);

            // Gộp các panel bên trái
            var leftPanel = new Panel { Dock = DockStyle.Fill };
            leftPanel.Controls.AddRange(new Control[] { panelBottomLeft, groupDoAn, groupNhanVien });

            // Group hóa đơn
            groupHoaDon = new GroupBox
            {
                Text = "Chi tiết hóa đơn",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Teal
            };
            txtHoaDon = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Courier New", 10),
                BackColor = Color.White
            };
            groupHoaDon.Controls.Add(txtHoaDon);

            layoutMain.Controls.Add(leftPanel, 0, 0);
            layoutMain.Controls.Add(groupHoaDon, 1, 0);

            this.Controls.Add(layoutMain);
        }
    }
}
