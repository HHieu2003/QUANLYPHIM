using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmVeAndLoaiVe
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private TabControl tabControl;
        private TabPage tabVe, tabLoaiVe, tabGiaoDich; // Added tab for GiaoDich
        private TableLayoutPanel layoutVe, layoutLoaiVe, layoutGiaoDich;
        private GroupBox groupVeForm, groupVeGrid, groupLoaiVeForm, groupLoaiVeGrid, groupGiaoDichForm, groupGiaoDichGrid;
        private DataGridView dgvVe, dgvLoaiVe, dgvGiaoDich;
        private Label lblTimKiemVe, lblMaVe, lblMaLoaiVe, lblTenLoaiVe, lblPhuThu;
        private Label lblMaGiaoDich, lblMaXacNhan, lblTrangThai; // Labels for GiaoDich
        private TextBox txtTimKiemVe, txtMaVe, txtMaLoaiVe, txtTenLoaiVe, txtPhuThu;
        private TextBox txtMaGiaoDich, txtMaXacNhan; // Textboxes for GiaoDich
        private ComboBox cboTrangThai; // ComboBox for TrangThai
        private Button btnTimKiemVe, btnXoaVe, btnThemLoaiVe, btnXoaLoaiVe, btnSuaLoaiVe, btnLamMoiLoaiVe;
        private Button btnXoaGiaoDich, btnSuaGiaoDich;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "Quản lý vé và loại vé";
            this.ClientSize = new Size(1000, 600);
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            pnlHeader = new Panel
            {
                BackColor = Color.FromArgb(26, 166, 154),
                Dock = DockStyle.Top,
                Height = 50
            };
            lblTitle = new Label
            {
                Text = "Quản lý vé và loại vé",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            pnlHeader.Controls.Add(lblTitle);

            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12F)
            };

            // Tab: Quản lý vé
            tabVe = new TabPage("Quản lý vé") { Padding = new Padding(10) };
            layoutVe = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                ColumnStyles = { new ColumnStyle(SizeType.Absolute, 300), new ColumnStyle(SizeType.Percent, 100) },
                Padding = new Padding(5)
            };
            groupVeForm = new GroupBox { Text = "Thông tin vé", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.Teal };
            groupVeGrid = new GroupBox { Text = "Danh sách vé", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.Teal };

            lblTimKiemVe = new Label { Text = "Tìm kiếm:", Location = new Point(20, 30), Width = 250 };
            txtTimKiemVe = new TextBox { Width = 240, Location = new Point(20, 55) };
            btnTimKiemVe = new Button
            {
                Text = "🔍 Tìm",
                Width = 240,
                Height = 35,
                BackColor = Color.Teal,
                ForeColor = Color.White,
                Location = new Point(20, 95),
                FlatStyle = FlatStyle.Flat
            };
            btnTimKiemVe.Click += new System.EventHandler(this.btnTimKiemVe_Click);
            btnTimKiemVe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            btnTimKiemVe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            lblMaVe = new Label { Text = "Mã vé:", Location = new Point(20, 145), Width = 250 };
            txtMaVe = new TextBox { ReadOnly = true, Width = 240, Location = new Point(20, 170) };
            btnXoaVe = new Button
            {
                Text = "🗑️ Xóa",
                Width = 240,
                Height = 35,
                BackColor = Color.FromArgb(211, 47, 47),
                ForeColor = Color.White,
                Location = new Point(20, 210),
                FlatStyle = FlatStyle.Flat
            };
            btnXoaVe.Click += new System.EventHandler(this.btnXoaVe_Click);
            btnXoaVe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            btnXoaVe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            groupVeForm.Controls.AddRange(new Control[] { lblTimKiemVe, txtTimKiemVe, btnTimKiemVe, lblMaVe, txtMaVe, btnXoaVe });
            dgvVe = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            dgvVe.SelectionChanged += new System.EventHandler(this.DgvVe_SelectionChanged);

            groupVeGrid.Controls.Add(dgvVe);
            layoutVe.Controls.Add(groupVeForm, 0, 0);
            layoutVe.Controls.Add(groupVeGrid, 1, 0);
            tabVe.Controls.Add(layoutVe);

            // Tab: Quản lý loại vé
            tabLoaiVe = new TabPage("Quản lý loại vé") { Padding = new Padding(10) };
            layoutLoaiVe = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                ColumnStyles = { new ColumnStyle(SizeType.Absolute, 380), new ColumnStyle(SizeType.Percent, 100) },
                Padding = new Padding(5)
            };
            groupLoaiVeForm = new GroupBox { Text = "Thông tin loại vé", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.Teal };
            groupLoaiVeGrid = new GroupBox { Text = "Danh sách loại vé", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.Teal };

            lblMaLoaiVe = new Label { Text = "Mã loại vé:", Location = new Point(20, 30), Width = 100 };
            txtMaLoaiVe = new TextBox { Width = 220, Location = new Point(120, 25) };
            lblTenLoaiVe = new Label { Text = "Tên loại vé:", Location = new Point(20, 70), Width = 100 };
            txtTenLoaiVe = new TextBox { Width = 220, Location = new Point(120, 65) };
            lblPhuThu = new Label { Text = "Phụ thu:", Location = new Point(20, 110), Width = 100 };
            txtPhuThu = new TextBox { Width = 220, Location = new Point(120, 105) };
            btnThemLoaiVe = new Button
            {
                Text = "➕ Thêm",
                Width = 80,
                Height = 35,
                Location = new Point(120, 145),
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnThemLoaiVe.Click += new System.EventHandler(this.btnThemLoaiVe_Click);
            btnThemLoaiVe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            btnThemLoaiVe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            btnXoaLoaiVe = new Button
            {
                Text = "🗑️ Xóa",
                Width = 80,
                Height = 35,
                Location = new Point(210, 145),
                BackColor = Color.FromArgb(211, 47, 47),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnXoaLoaiVe.Click += new System.EventHandler(this.btnXoaLoaiVe_Click);
            btnXoaLoaiVe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            btnXoaLoaiVe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            btnSuaLoaiVe = new Button
            {
                Text = "✏️ Sửa",
                Width = 80,
                Height = 35,
                Location = new Point(300, 145),
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSuaLoaiVe.Click += new System.EventHandler(this.btnSuaLoaiVe_Click);
            btnSuaLoaiVe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            btnSuaLoaiVe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            btnLamMoiLoaiVe = new Button
            {
                Text = "🔄 Làm mới",
                Width = 260,
                Height = 35,
                Location = new Point(120, 190),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnLamMoiLoaiVe.Click += new System.EventHandler(this.btnLamMoiLoaiVe_Click);
            btnLamMoiLoaiVe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            btnLamMoiLoaiVe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            groupLoaiVeForm.Controls.AddRange(new Control[]
            {
                lblMaLoaiVe, txtMaLoaiVe,
                lblTenLoaiVe, txtTenLoaiVe,
                lblPhuThu, txtPhuThu,
                btnThemLoaiVe, btnXoaLoaiVe, btnSuaLoaiVe, btnLamMoiLoaiVe
            });
            dgvLoaiVe = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            dgvLoaiVe.SelectionChanged += new System.EventHandler(this.DgvLoaiVe_SelectionChanged);

            groupLoaiVeGrid.Controls.Add(dgvLoaiVe);
            layoutLoaiVe.Controls.Add(groupLoaiVeForm, 0, 0);
            layoutLoaiVe.Controls.Add(groupLoaiVeGrid, 1, 0);
            tabLoaiVe.Controls.Add(layoutLoaiVe);

            // Tab: Quản lý vé online (GiaoDich)
            tabGiaoDich = new TabPage("Quản lý vé online") { Padding = new Padding(10) };
            layoutGiaoDich = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                ColumnStyles = { new ColumnStyle(SizeType.Absolute, 300), new ColumnStyle(SizeType.Percent, 100) },
                Padding = new Padding(5)
            };
            groupGiaoDichForm = new GroupBox { Text = "Thông tin giao dịch", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.Teal };
            groupGiaoDichGrid = new GroupBox { Text = "Danh sách giao dịch", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.Teal };

            lblMaGiaoDich = new Label { Text = "Mã giao dịch:", Location = new Point(20, 30), Width = 100 };
            txtMaGiaoDich = new TextBox { Width = 220, Location = new Point(120, 25), ReadOnly = true };
            lblMaXacNhan = new Label { Text = "Mã xác nhận:", Location = new Point(20, 70), Width = 100 };
            txtMaXacNhan = new TextBox { Width = 220, Location = new Point(120, 65), ReadOnly = true };
            lblTrangThai = new Label { Text = "Trạng thái:", Location = new Point(20, 110), Width = 100 };
            cboTrangThai = new ComboBox
            {
                Width = 220,
                Location = new Point(120, 105),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Items = { "ChuaXuLy", "DaXuLy" }
            };
            btnXoaGiaoDich = new Button
            {
                Text = "🗑️ Xóa",
                Width = 80,
                Height = 35,
                Location = new Point(120, 145),
                BackColor = Color.FromArgb(211, 47, 47),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnXoaGiaoDich.Click += new System.EventHandler(this.btnXoaGiaoDich_Click);
            btnXoaGiaoDich.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            btnXoaGiaoDich.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            btnSuaGiaoDich = new Button
            {
                Text = "✏️ Sửa",
                Width = 80,
                Height = 35,
                Location = new Point(210, 145),
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSuaGiaoDich.Click += new System.EventHandler(this.btnSuaGiaoDich_Click);
            btnSuaGiaoDich.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            btnSuaGiaoDich.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            groupGiaoDichForm.Controls.AddRange(new Control[]
            {
                lblMaGiaoDich, txtMaGiaoDich,
                lblMaXacNhan, txtMaXacNhan,
                lblTrangThai, cboTrangThai,
                btnXoaGiaoDich, btnSuaGiaoDich
            });
            dgvGiaoDich = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            dgvGiaoDich.SelectionChanged += new System.EventHandler(this.DgvGiaoDich_SelectionChanged);

            groupGiaoDichGrid.Controls.Add(dgvGiaoDich);
            layoutGiaoDich.Controls.Add(groupGiaoDichForm, 0, 0);
            layoutGiaoDich.Controls.Add(groupGiaoDichGrid, 1, 0);
            tabGiaoDich.Controls.Add(layoutGiaoDich);

            tabControl.Controls.AddRange(new TabPage[] { tabVe, tabLoaiVe, tabGiaoDich });

            this.Controls.Add(tabControl);
            this.Controls.Add(pnlHeader);
        }
    }
}