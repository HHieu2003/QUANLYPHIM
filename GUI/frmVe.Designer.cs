using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmVe
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private TableLayoutPanel tblLayout;
        private Panel pnlInput;
        private DataGridView dgvVe;
        private Label lblMaVe, lblLichChieu, lblLoaiVe, lblKhachHang, lblSoGhe, lblGiaVe, lblNgayDat, lblTimKiem, lblSoDoGhe;
        private TextBox txtMaVe, txtSoGhe, txtGiaVe, txtNgayDat, txtTimKiem;
        private ComboBox cboLichChieu, cboLoaiVe, cboKhachHang;
        private TableLayoutPanel tblGhe;
        private Button btnThem, btnXoa, btnLamMoi, btnHuy, btnTimKiem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblMaVe = new System.Windows.Forms.Label();
            this.txtMaVe = new System.Windows.Forms.TextBox();
            this.lblLichChieu = new System.Windows.Forms.Label();
            this.cboLichChieu = new System.Windows.Forms.ComboBox();
            this.lblLoaiVe = new System.Windows.Forms.Label();
            this.cboLoaiVe = new System.Windows.Forms.ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblSoDoGhe = new System.Windows.Forms.Label();
            this.tblGhe = new System.Windows.Forms.TableLayoutPanel();
            this.lblSoGhe = new System.Windows.Forms.Label();
            this.txtSoGhe = new System.Windows.Forms.TextBox();
            this.lblGiaVe = new System.Windows.Forms.Label();
            this.txtGiaVe = new System.Windows.Forms.TextBox();
            this.lblNgayDat = new System.Windows.Forms.Label();
            this.txtNgayDat = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvVe = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.tblLayout.SuspendLayout();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(960, 39);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(960, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý vé";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblLayout
            // 
            this.tblLayout.ColumnCount = 2;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.25F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.75F));
            this.tblLayout.Controls.Add(this.pnlInput, 0, 0);
            this.tblLayout.Controls.Add(this.dgvVe, 1, 0);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.Location = new System.Drawing.Point(0, 39);
            this.tblLayout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 1;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(960, 429);
            this.tblLayout.TabIndex = 0;
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInput.Controls.Add(this.lblMaVe);
            this.pnlInput.Controls.Add(this.txtMaVe);
            this.pnlInput.Controls.Add(this.lblLichChieu);
            this.pnlInput.Controls.Add(this.cboLichChieu);
            this.pnlInput.Controls.Add(this.lblLoaiVe);
            this.pnlInput.Controls.Add(this.cboLoaiVe);
            this.pnlInput.Controls.Add(this.lblKhachHang);
            this.pnlInput.Controls.Add(this.cboKhachHang);
            this.pnlInput.Controls.Add(this.lblSoDoGhe);
            this.pnlInput.Controls.Add(this.tblGhe);
            this.pnlInput.Controls.Add(this.lblSoGhe);
            this.pnlInput.Controls.Add(this.txtSoGhe);
            this.pnlInput.Controls.Add(this.lblGiaVe);
            this.pnlInput.Controls.Add(this.txtGiaVe);
            this.pnlInput.Controls.Add(this.lblNgayDat);
            this.pnlInput.Controls.Add(this.txtNgayDat);
            this.pnlInput.Controls.Add(this.btnThem);
            this.pnlInput.Controls.Add(this.btnXoa);
            this.pnlInput.Controls.Add(this.btnLamMoi);
            this.pnlInput.Controls.Add(this.btnHuy);
            this.pnlInput.Controls.Add(this.lblTimKiem);
            this.pnlInput.Controls.Add(this.txtTimKiem);
            this.pnlInput.Controls.Add(this.btnTimKiem);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInput.Location = new System.Drawing.Point(2, 2);
            this.pnlInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(15, 13, 15, 13);
            this.pnlInput.Size = new System.Drawing.Size(728, 425);
            this.pnlInput.TabIndex = 0;
            // 
            // lblMaVe
            // 
            this.lblMaVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblMaVe.Location = new System.Drawing.Point(22, 46);
            this.lblMaVe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaVe.Name = "lblMaVe";
            this.lblMaVe.Size = new System.Drawing.Size(75, 20);
            this.lblMaVe.TabIndex = 0;
            this.lblMaVe.Text = "Mã vé:";
            // 
            // txtMaVe
            // 
            this.txtMaVe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaVe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaVe.Location = new System.Drawing.Point(98, 46);
            this.txtMaVe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaVe.Name = "txtMaVe";
            this.txtMaVe.Size = new System.Drawing.Size(226, 29);
            this.txtMaVe.TabIndex = 1;
            // 
            // lblLichChieu
            // 
            this.lblLichChieu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLichChieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblLichChieu.Location = new System.Drawing.Point(22, 78);
            this.lblLichChieu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLichChieu.Name = "lblLichChieu";
            this.lblLichChieu.Size = new System.Drawing.Size(75, 20);
            this.lblLichChieu.TabIndex = 2;
            this.lblLichChieu.Text = "Lịch chiếu:";
            // 
            // cboLichChieu
            // 
            this.cboLichChieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLichChieu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboLichChieu.Location = new System.Drawing.Point(98, 78);
            this.cboLichChieu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboLichChieu.Name = "cboLichChieu";
            this.cboLichChieu.Size = new System.Drawing.Size(226, 29);
            this.cboLichChieu.TabIndex = 3;
            this.cboLichChieu.SelectedIndexChanged += new System.EventHandler(this.CboLichChieu_SelectedIndexChanged);
            // 
            // lblLoaiVe
            // 
            this.lblLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoaiVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblLoaiVe.Location = new System.Drawing.Point(22, 110);
            this.lblLoaiVe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoaiVe.Name = "lblLoaiVe";
            this.lblLoaiVe.Size = new System.Drawing.Size(75, 20);
            this.lblLoaiVe.TabIndex = 4;
            this.lblLoaiVe.Text = "Loại vé:";
            // 
            // cboLoaiVe
            // 
            this.cboLoaiVe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboLoaiVe.Location = new System.Drawing.Point(98, 110);
            this.cboLoaiVe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboLoaiVe.Name = "cboLoaiVe";
            this.cboLoaiVe.Size = new System.Drawing.Size(226, 29);
            this.cboLoaiVe.TabIndex = 5;
            this.cboLoaiVe.SelectedIndexChanged += new System.EventHandler(this.CboLoaiVe_SelectedIndexChanged);
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblKhachHang.Location = new System.Drawing.Point(22, 143);
            this.lblKhachHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(75, 20);
            this.lblKhachHang.TabIndex = 6;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboKhachHang.Location = new System.Drawing.Point(98, 143);
            this.cboKhachHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(226, 29);
            this.cboKhachHang.TabIndex = 7;
            // 
            // lblSoDoGhe
            // 
            this.lblSoDoGhe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSoDoGhe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblSoDoGhe.Location = new System.Drawing.Point(22, 176);
            this.lblSoDoGhe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoDoGhe.Name = "lblSoDoGhe";
            this.lblSoDoGhe.Size = new System.Drawing.Size(75, 20);
            this.lblSoDoGhe.TabIndex = 8;
            this.lblSoDoGhe.Text = "Sơ đồ ghế:";
            // 
            // tblGhe
            // 
            this.tblGhe.AutoSize = true;
            this.tblGhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblGhe.Location = new System.Drawing.Point(98, 176);
            this.tblGhe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tblGhe.Name = "tblGhe";
            this.tblGhe.Size = new System.Drawing.Size(225, 98);
            this.tblGhe.TabIndex = 9;
            // 
            // lblSoGhe
            // 
            this.lblSoGhe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSoGhe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblSoGhe.Location = new System.Drawing.Point(375, 10);
            this.lblSoGhe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoGhe.Name = "lblSoGhe";
            this.lblSoGhe.Size = new System.Drawing.Size(75, 20);
            this.lblSoGhe.TabIndex = 10;
            this.lblSoGhe.Text = "Số ghế:";
            // 
            // txtSoGhe
            // 
            this.txtSoGhe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoGhe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSoGhe.Location = new System.Drawing.Point(451, 10);
            this.txtSoGhe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSoGhe.Name = "txtSoGhe";
            this.txtSoGhe.ReadOnly = true;
            this.txtSoGhe.Size = new System.Drawing.Size(226, 29);
            this.txtSoGhe.TabIndex = 11;
            // 
            // lblGiaVe
            // 
            this.lblGiaVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGiaVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblGiaVe.Location = new System.Drawing.Point(375, 42);
            this.lblGiaVe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGiaVe.Name = "lblGiaVe";
            this.lblGiaVe.Size = new System.Drawing.Size(75, 20);
            this.lblGiaVe.TabIndex = 12;
            this.lblGiaVe.Text = "Giá vé:";
            // 
            // txtGiaVe
            // 
            this.txtGiaVe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGiaVe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtGiaVe.Location = new System.Drawing.Point(451, 42);
            this.txtGiaVe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGiaVe.Name = "txtGiaVe";
            this.txtGiaVe.ReadOnly = true;
            this.txtGiaVe.Size = new System.Drawing.Size(226, 29);
            this.txtGiaVe.TabIndex = 13;
            // 
            // lblNgayDat
            // 
            this.lblNgayDat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNgayDat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblNgayDat.Location = new System.Drawing.Point(375, 74);
            this.lblNgayDat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayDat.Name = "lblNgayDat";
            this.lblNgayDat.Size = new System.Drawing.Size(75, 20);
            this.lblNgayDat.TabIndex = 14;
            this.lblNgayDat.Text = "Ngày đặt:";
            // 
            // txtNgayDat
            // 
            this.txtNgayDat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayDat.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNgayDat.Location = new System.Drawing.Point(451, 74);
            this.txtNgayDat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNgayDat.Name = "txtNgayDat";
            this.txtNgayDat.ReadOnly = true;
            this.txtNgayDat.Size = new System.Drawing.Size(226, 29);
            this.txtNgayDat.TabIndex = 15;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(451, 107);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 26);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnThem.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnThem.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(533, 107);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 26);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnXoa.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnXoa.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(435, 143);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 26);
            this.btnLamMoi.TabIndex = 18;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            this.btnLamMoi.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnLamMoi.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(517, 143);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 26);
            this.btnHuy.TabIndex = 19;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.btnHuy.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnHuy.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblTimKiem.Location = new System.Drawing.Point(22, 13);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(75, 20);
            this.lblTimKiem.TabIndex = 20;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimKiem.Location = new System.Drawing.Point(98, 13);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(150, 29);
            this.txtTimKiem.TabIndex = 21;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(255, 13);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 20);
            this.btnTimKiem.TabIndex = 22;
            this.btnTimKiem.Text = "🔍 Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            this.btnTimKiem.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnTimKiem.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // dgvVe
            // 
            this.dgvVe.AllowUserToAddRows = false;
            this.dgvVe.AllowUserToDeleteRows = false;
            this.dgvVe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVe.Location = new System.Drawing.Point(747, 13);
            this.dgvVe.Margin = new System.Windows.Forms.Padding(15, 13, 15, 13);
            this.dgvVe.Name = "dgvVe";
            this.dgvVe.ReadOnly = true;
            this.dgvVe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVe.Size = new System.Drawing.Size(198, 403);
            this.dgvVe.TabIndex = 1;
            // 
            // frmVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(960, 468);
            this.Controls.Add(this.tblLayout);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmVe";
            this.Text = "Quản lý vé";
            this.pnlHeader.ResumeLayout(false);
            this.tblLayout.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            this.ResumeLayout(false);

        }
    }
}