using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmPhongChieu
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private TableLayoutPanel tblLayout;
        private Panel pnlInput;
        private DataGridView dgvPhongChieu;
        private Label lblMaPhong, lblTenPhong, lblSoLuongGhe, lblTrangThai, lblTimKiem;
        private TextBox txtMaPhong, txtTenPhong, txtSoLuongGhe, txtTimKiem;
        private ComboBox cboTrangThai;
        private Button btnThem, btnSua, btnXoa, btnLamMoi, btnHuy, btnTimKiem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.tblLayout = new TableLayoutPanel();
            this.pnlInput = new Panel();
            this.dgvPhongChieu = new DataGridView();
            this.lblMaPhong = new Label();
            this.lblTenPhong = new Label();
            this.lblSoLuongGhe = new Label();
            this.lblTrangThai = new Label();
            this.lblTimKiem = new Label();
            this.txtMaPhong = new TextBox();
            this.txtTenPhong = new TextBox();
            this.txtSoLuongGhe = new TextBox();
            this.txtTimKiem = new TextBox();
            this.cboTrangThai = new ComboBox();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnXoa = new Button();
            this.btnLamMoi = new Button();
            this.btnHuy = new Button();
            this.btnTimKiem = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongChieu)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.tblLayout.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 60;
            this.pnlHeader.BackColor = Color.FromArgb(26, 166, 154);
            this.pnlHeader.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Text = "Quản lý phòng chiếu";
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;

            // tblLayout
            this.tblLayout.ColumnCount = 2;
            this.tblLayout.RowCount = 1;
            this.tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            this.tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            this.tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tblLayout.Dock = DockStyle.Fill;
            this.tblLayout.Controls.Add(this.pnlInput, 0, 0);
            this.tblLayout.Controls.Add(this.dgvPhongChieu, 1, 0);

            // dgvPhongChieu
            this.dgvPhongChieu.AllowUserToAddRows = false;
            this.dgvPhongChieu.AllowUserToDeleteRows = false;
            this.dgvPhongChieu.ReadOnly = true;
            this.dgvPhongChieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhongChieu.Dock = DockStyle.Fill;
            this.dgvPhongChieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhongChieu.Margin = new Padding(20);

            // pnlInput
            this.pnlInput.BackColor = Color.White;
            this.pnlInput.BorderStyle = BorderStyle.FixedSingle;
            this.pnlInput.Padding = new Padding(20);
            this.pnlInput.Dock = DockStyle.Fill;
            this.pnlInput.Controls.AddRange(new Control[] {
                this.lblMaPhong, this.txtMaPhong,
                this.lblTenPhong, this.txtTenPhong,
                this.lblSoLuongGhe, this.txtSoLuongGhe,
                this.lblTrangThai, this.cboTrangThai,
                this.btnThem, this.btnSua, this.btnXoa, this.btnLamMoi, this.btnHuy,
                this.lblTimKiem, this.txtTimKiem, this.btnTimKiem
            });

            // lblTimKiem
            this.lblTimKiem.Text = "Tìm kiếm:";
            this.lblTimKiem.Location = new System.Drawing.Point(30, 20);
            this.lblTimKiem.Size = new System.Drawing.Size(100, 30);
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor = Color.FromArgb(26, 166, 154);

            // txtTimKiem
            this.txtTimKiem.Location = new System.Drawing.Point(130, 20);
            this.txtTimKiem.Size = new System.Drawing.Size(200, 30);
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimKiem.BorderStyle = BorderStyle.FixedSingle;

            // btnTimKiem
            this.btnTimKiem.Text = "🔍 Tìm";
            this.btnTimKiem.Location = new System.Drawing.Point(340, 20);
            this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.BackColor = Color.FromArgb(26, 166, 154);
            this.btnTimKiem.ForeColor = Color.White;
            this.btnTimKiem.FlatStyle = FlatStyle.Flat;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            this.btnTimKiem.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnTimKiem.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            // lblMaPhong
            this.lblMaPhong.Text = "Mã phòng chiếu:";
            this.lblMaPhong.Location = new System.Drawing.Point(30, 70);
            this.lblMaPhong.Size = new System.Drawing.Size(100, 30);
            this.lblMaPhong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaPhong.ForeColor = Color.FromArgb(26, 166, 154);

            // txtMaPhong
            this.txtMaPhong.Location = new System.Drawing.Point(130, 70);
            this.txtMaPhong.Size = new System.Drawing.Size(300, 30);
            this.txtMaPhong.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaPhong.BorderStyle = BorderStyle.FixedSingle;

            // lblTenPhong
            this.lblTenPhong.Text = "Tên phòng chiếu:";
            this.lblTenPhong.Location = new System.Drawing.Point(30, 120);
            this.lblTenPhong.Size = new System.Drawing.Size(100, 30);
            this.lblTenPhong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenPhong.ForeColor = Color.FromArgb(26, 166, 154);

            // txtTenPhong
            this.txtTenPhong.Location = new System.Drawing.Point(130, 120);
            this.txtTenPhong.Size = new System.Drawing.Size(300, 30);
            this.txtTenPhong.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTenPhong.BorderStyle = BorderStyle.FixedSingle;

            // lblSoLuongGhe
            this.lblSoLuongGhe.Text = "Số lượng ghế:";
            this.lblSoLuongGhe.Location = new System.Drawing.Point(30, 170);
            this.lblSoLuongGhe.Size = new System.Drawing.Size(100, 30);
            this.lblSoLuongGhe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSoLuongGhe.ForeColor = Color.FromArgb(26, 166, 154);

            // txtSoLuongGhe
            this.txtSoLuongGhe.Location = new System.Drawing.Point(130, 170);
            this.txtSoLuongGhe.Size = new System.Drawing.Size(300, 30);
            this.txtSoLuongGhe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSoLuongGhe.BorderStyle = BorderStyle.FixedSingle;

            // lblTrangThai
            this.lblTrangThai.Text = "Trạng thái:";
            this.lblTrangThai.Location = new System.Drawing.Point(30, 220);
            this.lblTrangThai.Size = new System.Drawing.Size(100, 30);
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.ForeColor = Color.FromArgb(26, 166, 154);

            // cboTrangThai
            this.cboTrangThai.Location = new System.Drawing.Point(130, 220);
            this.cboTrangThai.Size = new System.Drawing.Size(300, 30);
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

            // btnThem
            this.btnThem.Text = "Thêm";
            this.btnThem.Location = new System.Drawing.Point(130, 270);
            this.btnThem.Size = new System.Drawing.Size(100, 40);
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThem.BackColor = Color.FromArgb(26, 166, 154);
            this.btnThem.ForeColor = Color.White;
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnThem.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnThem.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            // btnSua
            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new System.Drawing.Point(240, 270);
            this.btnSua.Size = new System.Drawing.Size(100, 40);
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSua.BackColor = Color.FromArgb(26, 166, 154);
            this.btnSua.ForeColor = Color.White;
            this.btnSua.FlatStyle = FlatStyle.Flat;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnSua.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnSua.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            // btnXoa
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(130, 320);
            this.btnXoa.Size = new System.Drawing.Size(100, 40);
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoa.BackColor = Color.FromArgb(211, 47, 47);
            this.btnXoa.ForeColor = Color.White;
            this.btnXoa.FlatStyle = FlatStyle.Flat;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnXoa.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnXoa.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            // btnLamMoi
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new System.Drawing.Point(240, 320);
            this.btnLamMoi.Size = new System.Drawing.Size(100, 40);
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.BackColor = Color.FromArgb(120, 120, 120);
            this.btnLamMoi.ForeColor = Color.White;
            this.btnLamMoi.FlatStyle = FlatStyle.Flat;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            this.btnLamMoi.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnLamMoi.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            // btnHuy
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Location = new System.Drawing.Point(350, 320);
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHuy.BackColor = Color.FromArgb(120, 120, 120);
            this.btnHuy.ForeColor = Color.White;
            this.btnHuy.FlatStyle = FlatStyle.Flat;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.btnHuy.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnHuy.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            // frmPhongChieu
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tblLayout);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmPhongChieu";
            this.Text = "Quản lý phòng chiếu";

            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongChieu)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.tblLayout.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}