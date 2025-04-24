using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmBanVe
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlMain;

        // Thông tin khách hàng
        private Label lblMaKhachHang, lblHoTen, lblSoDienThoai, lblEmail;
        private TextBox txtMaKhachHang, txtHoTen, txtSoDienThoai, txtEmail;
        private Button btnTraCuuKhachHang;

        // Chọn phim và lịch chiếu
        private Label lblPhim, lblLichChieu;
        private ComboBox cboPhim, cboLichChieu;

        // Chọn ghế
        private Button btnChonGhe;

        // Chọn loại vé và tính tiền
        private Label lblLoaiVe, lblTongTien;
        private ComboBox cboLoaiVe;
        private TextBox txtTongTien;

        // Chọn đồ ăn
        private Label lblDoAn;
        private DataGridView dgvDoAn;

        // Thanh toán và in hóa đơn
        private Button btnThanhToan, btnInHoaDon;
        private TextBox txtHoaDon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblMaKhachHang = new System.Windows.Forms.Label();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnTraCuuKhachHang = new System.Windows.Forms.Button();
            this.lblPhim = new System.Windows.Forms.Label();
            this.cboPhim = new System.Windows.Forms.ComboBox();
            this.lblLichChieu = new System.Windows.Forms.Label();
            this.cboLichChieu = new System.Windows.Forms.ComboBox();
            this.btnChonGhe = new System.Windows.Forms.Button();
            this.lblLoaiVe = new System.Windows.Forms.Label();
            this.cboLoaiVe = new System.Windows.Forms.ComboBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblDoAn = new System.Windows.Forms.Label();
            this.dgvDoAn = new System.Windows.Forms.DataGridView();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.txtHoaDon = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoAn)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(966, 39);
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
            this.lblTitle.Size = new System.Drawing.Size(966, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bán Vé";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.Controls.Add(this.lblMaKhachHang);
            this.pnlMain.Controls.Add(this.txtMaKhachHang);
            this.pnlMain.Controls.Add(this.lblHoTen);
            this.pnlMain.Controls.Add(this.txtHoTen);
            this.pnlMain.Controls.Add(this.lblSoDienThoai);
            this.pnlMain.Controls.Add(this.txtSoDienThoai);
            this.pnlMain.Controls.Add(this.lblEmail);
            this.pnlMain.Controls.Add(this.txtEmail);
            this.pnlMain.Controls.Add(this.btnTraCuuKhachHang);
            this.pnlMain.Controls.Add(this.lblPhim);
            this.pnlMain.Controls.Add(this.cboPhim);
            this.pnlMain.Controls.Add(this.lblLichChieu);
            this.pnlMain.Controls.Add(this.cboLichChieu);
            this.pnlMain.Controls.Add(this.btnChonGhe);
            this.pnlMain.Controls.Add(this.lblLoaiVe);
            this.pnlMain.Controls.Add(this.cboLoaiVe);
            this.pnlMain.Controls.Add(this.lblTongTien);
            this.pnlMain.Controls.Add(this.txtTongTien);
            this.pnlMain.Controls.Add(this.lblDoAn);
            this.pnlMain.Controls.Add(this.dgvDoAn);
            this.pnlMain.Controls.Add(this.btnThanhToan);
            this.pnlMain.Controls.Add(this.btnInHoaDon);
            this.pnlMain.Controls.Add(this.txtHoaDon);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 39);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(966, 530);
            this.pnlMain.TabIndex = 0;
            // 
            // lblMaKhachHang
            // 
            this.lblMaKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblMaKhachHang.Location = new System.Drawing.Point(3, 13);
            this.lblMaKhachHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaKhachHang.Name = "lblMaKhachHang";
            this.lblMaKhachHang.Size = new System.Drawing.Size(151, 20);
            this.lblMaKhachHang.TabIndex = 0;
            this.lblMaKhachHang.Text = "Mã khách hàng:";
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaKhachHang.Location = new System.Drawing.Point(158, 13);
            this.txtMaKhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(150, 29);
            this.txtMaKhachHang.TabIndex = 1;
            // 
            // lblHoTen
            // 
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblHoTen.Location = new System.Drawing.Point(3, 46);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(151, 20);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtHoTen.Location = new System.Drawing.Point(158, 46);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(150, 29);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSoDienThoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblSoDienThoai.Location = new System.Drawing.Point(3, 78);
            this.lblSoDienThoai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(151, 20);
            this.lblSoDienThoai.TabIndex = 4;
            this.lblSoDienThoai.Text = "Số điện thoại:";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSoDienThoai.Location = new System.Drawing.Point(158, 78);
            this.txtSoDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(150, 29);
            this.txtSoDienThoai.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblEmail.Location = new System.Drawing.Point(3, 110);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(151, 20);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.Location = new System.Drawing.Point(158, 110);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 29);
            this.txtEmail.TabIndex = 7;
            // 
            // btnTraCuuKhachHang
            // 
            this.btnTraCuuKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnTraCuuKhachHang.FlatAppearance.BorderSize = 0;
            this.btnTraCuuKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraCuuKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTraCuuKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnTraCuuKhachHang.Location = new System.Drawing.Point(224, 143);
            this.btnTraCuuKhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.btnTraCuuKhachHang.Name = "btnTraCuuKhachHang";
            this.btnTraCuuKhachHang.Size = new System.Drawing.Size(85, 29);
            this.btnTraCuuKhachHang.TabIndex = 10;
            this.btnTraCuuKhachHang.Text = "Tra cứu";
            this.btnTraCuuKhachHang.UseVisualStyleBackColor = false;
            this.btnTraCuuKhachHang.Click += new System.EventHandler(this.btnTraCuuKhachHang_Click);
            this.btnTraCuuKhachHang.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnTraCuuKhachHang.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // lblPhim
            // 
            this.lblPhim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPhim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblPhim.Location = new System.Drawing.Point(3, 176);
            this.lblPhim.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhim.Name = "lblPhim";
            this.lblPhim.Size = new System.Drawing.Size(151, 20);
            this.lblPhim.TabIndex = 12;
            this.lblPhim.Text = "Chọn phim:";
            // 
            // cboPhim
            // 
            this.cboPhim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhim.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboPhim.Location = new System.Drawing.Point(158, 176);
            this.cboPhim.Margin = new System.Windows.Forms.Padding(2);
            this.cboPhim.Name = "cboPhim";
            this.cboPhim.Size = new System.Drawing.Size(151, 29);
            this.cboPhim.TabIndex = 13;
            this.cboPhim.SelectedIndexChanged += new System.EventHandler(this.cboPhim_SelectedIndexChanged);
            // 
            // lblLichChieu
            // 
            this.lblLichChieu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLichChieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblLichChieu.Location = new System.Drawing.Point(3, 208);
            this.lblLichChieu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLichChieu.Name = "lblLichChieu";
            this.lblLichChieu.Size = new System.Drawing.Size(151, 20);
            this.lblLichChieu.TabIndex = 14;
            this.lblLichChieu.Text = "Chọn lịch chiếu:";
            // 
            // cboLichChieu
            // 
            this.cboLichChieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLichChieu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboLichChieu.Location = new System.Drawing.Point(158, 208);
            this.cboLichChieu.Margin = new System.Windows.Forms.Padding(2);
            this.cboLichChieu.Name = "cboLichChieu";
            this.cboLichChieu.Size = new System.Drawing.Size(151, 29);
            this.cboLichChieu.TabIndex = 15;
            // 
            // btnChonGhe
            // 
            this.btnChonGhe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnChonGhe.FlatAppearance.BorderSize = 0;
            this.btnChonGhe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonGhe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnChonGhe.ForeColor = System.Drawing.Color.White;
            this.btnChonGhe.Location = new System.Drawing.Point(224, 241);
            this.btnChonGhe.Margin = new System.Windows.Forms.Padding(2);
            this.btnChonGhe.Name = "btnChonGhe";
            this.btnChonGhe.Size = new System.Drawing.Size(85, 28);
            this.btnChonGhe.TabIndex = 18;
            this.btnChonGhe.Text = "Chọn ghế";
            this.btnChonGhe.UseVisualStyleBackColor = false;
            this.btnChonGhe.Click += new System.EventHandler(this.btnChonGhe_Click);
            this.btnChonGhe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnChonGhe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // lblLoaiVe
            // 
            this.lblLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoaiVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblLoaiVe.Location = new System.Drawing.Point(3, 279);
            this.lblLoaiVe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoaiVe.Name = "lblLoaiVe";
            this.lblLoaiVe.Size = new System.Drawing.Size(151, 20);
            this.lblLoaiVe.TabIndex = 19;
            this.lblLoaiVe.Text = "Loại vé:";
            // 
            // cboLoaiVe
            // 
            this.cboLoaiVe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboLoaiVe.Location = new System.Drawing.Point(158, 279);
            this.cboLoaiVe.Margin = new System.Windows.Forms.Padding(2);
            this.cboLoaiVe.Name = "cboLoaiVe";
            this.cboLoaiVe.Size = new System.Drawing.Size(151, 29);
            this.cboLoaiVe.TabIndex = 20;
            this.cboLoaiVe.SelectedIndexChanged += new System.EventHandler(this.cboLoaiVe_SelectedIndexChanged);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblTongTien.Location = new System.Drawing.Point(3, 312);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(120, 20);
            this.lblTongTien.TabIndex = 21;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTongTien.Location = new System.Drawing.Point(158, 312);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(150, 29);
            this.txtTongTien.TabIndex = 22;
            // 
            // lblDoAn
            // 
            this.lblDoAn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoAn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblDoAn.Location = new System.Drawing.Point(3, 345);
            this.lblDoAn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoAn.Name = "lblDoAn";
            this.lblDoAn.Size = new System.Drawing.Size(105, 20);
            this.lblDoAn.TabIndex = 26;
            this.lblDoAn.Text = "Chọn đồ ăn:";
            // 
            // dgvDoAn
            // 
            this.dgvDoAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoAn.Location = new System.Drawing.Point(112, 345);
            this.dgvDoAn.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDoAn.Name = "dgvDoAn";
            this.dgvDoAn.RowHeadersVisible = false;
            this.dgvDoAn.Size = new System.Drawing.Size(259, 100);
            this.dgvDoAn.TabIndex = 27;
            this.dgvDoAn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoAn_CellValueChanged);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(112, 449);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(75, 26);
            this.btnThanhToan.TabIndex = 23;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            this.btnThanhToan.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnThanhToan.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnInHoaDon.Enabled = false;
            this.btnInHoaDon.FlatAppearance.BorderSize = 0;
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnInHoaDon.Location = new System.Drawing.Point(195, 449);
            this.btnInHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(75, 26);
            this.btnInHoaDon.TabIndex = 24;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = false;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            this.btnInHoaDon.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnInHoaDon.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // txtHoaDon
            // 
            this.txtHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtHoaDon.Location = new System.Drawing.Point(416, 4);
            this.txtHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoaDon.Multiline = true;
            this.txtHoaDon.Name = "txtHoaDon";
            this.txtHoaDon.ReadOnly = true;
            this.txtHoaDon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHoaDon.Size = new System.Drawing.Size(526, 424);
            this.txtHoaDon.TabIndex = 25;
            // 
            // frmBanVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 569);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmBanVe";
            this.Text = "Bán Vé";
            this.pnlHeader.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoAn)).EndInit();
            this.ResumeLayout(false);

        }
    }
}