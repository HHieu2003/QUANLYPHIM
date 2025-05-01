// File: frmBanVe.Designer.cs - Reorganized layout for better UI clarity
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmBanVe
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel layoutMain;
        private GroupBox groupNhanVien, groupChonPhim, groupVe, groupDoAn, groupHoaDon;

        private Label lblMaNhanVien, lblHoTenNhanVien, lblPhim, lblLichChieu, lblLoaiVe, lblTongTien, lblDoAn;
        private TextBox txtMaNhanVien, txtHoTenNhanVien, txtTongTien, txtHoaDon;
        private ComboBox cboPhim, cboLichChieu, cboLoaiVe;
        private Button btnChonGhe, btnThanhToan, btnInHoaDon, btnOnline;
        private DataGridView dgvDoAn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Text = "Bán Vé";
            this.ClientSize = new Size(1000, 620);
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            layoutMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(10),
                ColumnStyles = {
                    new ColumnStyle(SizeType.Percent, 45F),
                    new ColumnStyle(SizeType.Percent, 55F)
                }
            };

            // Group: Nhân viên
            groupNhanVien = new GroupBox { Text = "Thông tin nhân viên", ForeColor = Color.Teal, Dock = DockStyle.Top, Height = 100 };
            lblMaNhanVien = new Label { Text = "Mã NV:", Location = new Point(10, 25), AutoSize = true };
            txtMaNhanVien = new TextBox { Location = new Point(100, 22), Width = 150, ReadOnly = true };
            lblHoTenNhanVien = new Label { Text = "Họ tên:", Location = new Point(10, 55), AutoSize = true };
            txtHoTenNhanVien = new TextBox { Location = new Point(100, 52), Width = 150, ReadOnly = true };
            btnOnline = new Button { Text = "Vé Online", Location = new Point(270, 22), Width = 100 };
            btnOnline.Click += new System.EventHandler(this.button2_Click);
            groupNhanVien.Controls.AddRange(new Control[] { lblMaNhanVien, txtMaNhanVien, lblHoTenNhanVien, txtHoTenNhanVien, btnOnline });

            // Group: Chọn phim
            groupChonPhim = new GroupBox { Text = "Bước 1: Chọn phim", ForeColor = Color.Teal, Dock = DockStyle.Top, Height = 110 };
            lblPhim = new Label { Text = "Phim:", Location = new Point(10, 30), AutoSize = true };
            cboPhim = new ComboBox { Location = new Point(100, 27), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cboPhim.SelectedIndexChanged += new System.EventHandler(this.cboPhim_SelectedIndexChanged);
            lblLichChieu = new Label { Text = "Lịch chiếu:", Location = new Point(10, 65), AutoSize = true };
            cboLichChieu = new ComboBox { Location = new Point(100, 62), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            groupChonPhim.Controls.AddRange(new Control[] { lblPhim, cboPhim, lblLichChieu, cboLichChieu });

            // Group: Vé
            groupVe = new GroupBox { Text = "Bước 2: Vé", ForeColor = Color.Teal, Dock = DockStyle.Top, Height = 120 };
            lblLoaiVe = new Label { Text = "Loại vé:", Location = new Point(10, 30), AutoSize = true };
            cboLoaiVe = new ComboBox { Location = new Point(100, 27), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cboLoaiVe.SelectedIndexChanged += new System.EventHandler(this.cboLoaiVe_SelectedIndexChanged);
            btnChonGhe = new Button { Text = "Chọn ghế", Location = new Point(270, 25), Width = 100 };
            btnChonGhe.Click += new System.EventHandler(this.btnChonGhe_Click);
            lblTongTien = new Label { Text = "Tổng tiền:", Location = new Point(10, 70), AutoSize = true };
            txtTongTien = new TextBox { Location = new Point(100, 67), Width = 150, ReadOnly = true };
            groupVe.Controls.AddRange(new Control[] { lblLoaiVe, cboLoaiVe, btnChonGhe, lblTongTien, txtTongTien });

            // Group: Đồ ăn
            groupDoAn = new GroupBox { Text = "Bước 3: Chọn đồ ăn", ForeColor = Color.Teal, Dock = DockStyle.Fill };
            dgvDoAn = new DataGridView { Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            dgvDoAn.CellValueChanged += new DataGridViewCellEventHandler(this.dgvDoAn_CellValueChanged);
            groupDoAn.Controls.Add(dgvDoAn);

            // Left panel (stacked)
            var leftPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 0, 10, 0) };
            leftPanel.Controls.AddRange(new Control[] { groupDoAn, groupVe, groupChonPhim, groupNhanVien });

            // Group: Hóa đơn
            groupHoaDon = new GroupBox { Text = "Chi tiết hóa đơn", ForeColor = Color.Teal, Dock = DockStyle.Fill };
            txtHoaDon = new TextBox { Multiline = true, ReadOnly = true, Dock = DockStyle.Fill, ScrollBars = ScrollBars.Vertical };
            groupHoaDon.Controls.Add(txtHoaDon);

            btnThanhToan = new Button { Text = "Thanh toán", BackColor = Color.SeaGreen, ForeColor = Color.White, Height = 35, Dock = DockStyle.Bottom };
            btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            btnInHoaDon = new Button { Text = "In hóa đơn", BackColor = Color.Teal, ForeColor = Color.White, Height = 35, Dock = DockStyle.Bottom };
            btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            var rightPanel = new Panel { Dock = DockStyle.Fill };
            rightPanel.Controls.AddRange(new Control[] { groupHoaDon, btnInHoaDon, btnThanhToan });

            layoutMain.Controls.Add(leftPanel, 0, 0);
            layoutMain.Controls.Add(rightPanel, 1, 0);

            this.Controls.Add(layoutMain);
        }
    }
}