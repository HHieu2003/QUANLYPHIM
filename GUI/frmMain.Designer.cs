namespace GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.labelTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.labelTheLoai = new System.Windows.Forms.Label();
            this.cboTheLoai = new System.Windows.Forms.ComboBox();
            this.labelPhim = new System.Windows.Forms.Label();
            this.lstPhim = new System.Windows.Forms.ListView();
            this.labelLichChieu = new System.Windows.Forms.Label();
            this.cboLichChieu = new System.Windows.Forms.ComboBox();
            this.labelLoaiVe = new System.Windows.Forms.Label();
            this.cboLoaiVe = new System.Windows.Forms.ComboBox();
            this.btnChonGhe = new System.Windows.Forms.Button();
            this.labelGhe = new System.Windows.Forms.Label();
            this.txtGhe = new System.Windows.Forms.TextBox();
            this.btnMuaDoAn = new System.Windows.Forms.Button();
            this.labelTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.labelHoaDon = new System.Windows.Forms.Label();
            this.txtHoaDon = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // labelHoTen
            this.labelHoTen.AutoSize = true;
            this.labelHoTen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelHoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.labelHoTen.Location = new System.Drawing.Point(12, 20);
            this.labelHoTen.Name = "labelHoTen";
            this.labelHoTen.Size = new System.Drawing.Size(60, 21);
            this.labelHoTen.TabIndex = 0;
            this.labelHoTen.Text = "Họ tên:";

            // txtHoTen
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtHoTen.Location = new System.Drawing.Point(120, 17);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(200, 29);
            this.txtHoTen.TabIndex = 1;

            // labelTimKiem
            this.labelTimKiem.AutoSize = true;
            this.labelTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.labelTimKiem.Location = new System.Drawing.Point(12, 60);
            this.labelTimKiem.Name = "labelTimKiem";
            this.labelTimKiem.Size = new System.Drawing.Size(80, 21);
            this.labelTimKiem.TabIndex = 2;
            this.labelTimKiem.Text = "Tìm kiếm:";

            // txtTimKiem
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimKiem.Location = new System.Drawing.Point(120, 57);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 29);
            this.txtTimKiem.TabIndex = 3;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            // labelTheLoai
            this.labelTheLoai.AutoSize = true;
            this.labelTheLoai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelTheLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.labelTheLoai.Location = new System.Drawing.Point(12, 100);
            this.labelTheLoai.Name = "labelTheLoai";
            this.labelTheLoai.Size = new System.Drawing.Size(80, 21);
            this.labelTheLoai.TabIndex = 4;
            this.labelTheLoai.Text = "Thể loại:";

            // cboTheLoai
            this.cboTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheLoai.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboTheLoai.Location = new System.Drawing.Point(120, 97);
            this.cboTheLoai.Name = "cboTheLoai";
            this.cboTheLoai.Size = new System.Drawing.Size(200, 29);
            this.cboTheLoai.TabIndex = 5;
            this.cboTheLoai.SelectedIndexChanged += new System.EventHandler(this.cboTheLoai_SelectedIndexChanged);

            // labelPhim
            this.labelPhim.AutoSize = true;
            this.labelPhim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelPhim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.labelPhim.Location = new System.Drawing.Point(12, 140);
            this.labelPhim.Name = "labelPhim";
            this.labelPhim.Size = new System.Drawing.Size(40, 21);
            this.labelPhim.TabIndex = 6;
            this.labelPhim.Text = "Phim:";

            // lstPhim
            this.lstPhim.Columns.Add("Tên phim", 150);
            this.lstPhim.Columns.Add("Mô tả", 300);
            this.lstPhim.FullRowSelect = true;
            this.lstPhim.Location = new System.Drawing.Point(120, 137);
            this.lstPhim.Name = "lstPhim";
            this.lstPhim.Size = new System.Drawing.Size(450, 150);
            this.lstPhim.TabIndex = 7;
            this.lstPhim.View = System.Windows.Forms.View.Details;
            this.lstPhim.SelectedIndexChanged += new System.EventHandler(this.lstPhim_SelectedIndexChanged);

            // labelLichChieu
            this.labelLichChieu.AutoSize = true;
            this.labelLichChieu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelLichChieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.labelLichChieu.Location = new System.Drawing.Point(12, 300);
            this.labelLichChieu.Name = "labelLichChieu";
            this.labelLichChieu.Size = new System.Drawing.Size(80, 21);
            this.labelLichChieu.TabIndex = 8;
            this.labelLichChieu.Text = "Lịch chiếu:";

            // cboLichChieu
            this.cboLichChieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLichChieu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboLichChieu.Location = new System.Drawing.Point(120, 297);
            this.cboLichChieu.Name = "cboLichChieu";
            this.cboLichChieu.Size = new System.Drawing.Size(200, 29);
            this.cboLichChieu.TabIndex = 9;

            // labelLoaiVe
            this.labelLoaiVe.AutoSize = true;
            this.labelLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelLoaiVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.labelLoaiVe.Location = new System.Drawing.Point(12, 340);
            this.labelLoaiVe.Name = "labelLoaiVe";
            this.labelLoaiVe.Size = new System.Drawing.Size(60, 21);
            this.labelLoaiVe.TabIndex = 10;
            this.labelLoaiVe.Text = "Loại vé:";

            // cboLoaiVe
            this.cboLoaiVe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboLoaiVe.Location = new System.Drawing.Point(120, 337);
            this.cboLoaiVe.Name = "cboLoaiVe";
            this.cboLoaiVe.Size = new System.Drawing.Size(200, 29);
            this.cboLoaiVe.TabIndex = 11;
            this.cboLoaiVe.SelectedIndexChanged += new System.EventHandler(this.cboLoaiVe_SelectedIndexChanged);

            // btnChonGhe
            this.btnChonGhe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnChonGhe.Enabled = false;
            this.btnChonGhe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonGhe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnChonGhe.ForeColor = System.Drawing.Color.White;
            this.btnChonGhe.Location = new System.Drawing.Point(120, 377);
            this.btnChonGhe.Name = "btnChonGhe";
            this.btnChonGhe.Size = new System.Drawing.Size(100, 30);
            this.btnChonGhe.TabIndex = 12;
            this.btnChonGhe.Text = "Chọn ghế";
            this.btnChonGhe.UseVisualStyleBackColor = false;
            this.btnChonGhe.Click += new System.EventHandler(this.btnChonGhe_Click);

            // labelGhe
            this.labelGhe.AutoSize = true;
            this.labelGhe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelGhe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.labelGhe.Location = new System.Drawing.Point(12, 420);
            this.labelGhe.Name = "labelGhe";
            this.labelGhe.Size = new System.Drawing.Size(40, 21);
            this.labelGhe.TabIndex = 13;
            this.labelGhe.Text = "Ghế:";

            // txtGhe
            this.txtGhe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtGhe.Location = new System.Drawing.Point(120, 417);
            this.txtGhe.Name = "txtGhe";
            this.txtGhe.ReadOnly = true;
            this.txtGhe.Size = new System.Drawing.Size(200, 29);
            this.txtGhe.TabIndex = 14;

            // btnMuaDoAn
            this.btnMuaDoAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnMuaDoAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuaDoAn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMuaDoAn.ForeColor = System.Drawing.Color.White;
            this.btnMuaDoAn.Location = new System.Drawing.Point(230, 377);
            this.btnMuaDoAn.Name = "btnMuaDoAn";
            this.btnMuaDoAn.Size = new System.Drawing.Size(100, 30);
            this.btnMuaDoAn.TabIndex = 15;
            this.btnMuaDoAn.Text = "Mua đồ ăn";
            this.btnMuaDoAn.UseVisualStyleBackColor = false;
            this.btnMuaDoAn.Click += new System.EventHandler(this.btnMuaDoAn_Click);

            // labelTongTien
            this.labelTongTien.AutoSize = true;
            this.labelTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.labelTongTien.Location = new System.Drawing.Point(12, 460);
            this.labelTongTien.Name = "labelTongTien";
            this.labelTongTien.Size = new System.Drawing.Size(80, 21);
            this.labelTongTien.TabIndex = 16;
            this.labelTongTien.Text = "Tổng tiền:";

            // txtTongTien
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTongTien.Location = new System.Drawing.Point(120, 457);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(200, 29);
            this.txtTongTien.TabIndex = 17;

            // btnThanhToan
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnThanhToan.Enabled = false;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(120, 497);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(100, 30);
            this.btnThanhToan.TabIndex = 18;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

            // btnInHoaDon
            this.btnInHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnInHoaDon.Enabled = false;
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnInHoaDon.Location = new System.Drawing.Point(230, 497);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(100, 30);
            this.btnInHoaDon.TabIndex = 19;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = false;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);

            // labelHoaDon
            this.labelHoaDon.AutoSize = true;
            this.labelHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.labelHoaDon.Location = new System.Drawing.Point(350, 20);
            this.labelHoaDon.Name = "labelHoaDon";
            this.labelHoaDon.Size = new System.Drawing.Size(70, 21);
            this.labelHoaDon.TabIndex = 20;
            this.labelHoaDon.Text = "Hóa đơn:";

            // txtHoaDon
            this.txtHoaDon.Font = new System.Drawing.Font("Courier New", 10F);
            this.txtHoaDon.Location = new System.Drawing.Point(350, 50);
            this.txtHoaDon.Multiline = true;
            this.txtHoaDon.Name = "txtHoaDon";
            this.txtHoaDon.ReadOnly = true;
            this.txtHoaDon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHoaDon.Size = new System.Drawing.Size(300, 477);
            this.txtHoaDon.TabIndex = 21;

            // frmMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 540);
            this.Controls.Add(this.txtHoaDon);
            this.Controls.Add(this.labelHoaDon);
            this.Controls.Add(this.btnInHoaDon);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.labelTongTien);
            this.Controls.Add(this.btnMuaDoAn);
            this.Controls.Add(this.txtGhe);
            this.Controls.Add(this.labelGhe);
            this.Controls.Add(this.btnChonGhe);
            this.Controls.Add(this.cboLoaiVe);
            this.Controls.Add(this.labelLoaiVe);
            this.Controls.Add(this.cboLichChieu);
            this.Controls.Add(this.labelLichChieu);
            this.Controls.Add(this.lstPhim);
            this.Controls.Add(this.labelPhim);
            this.Controls.Add(this.cboTheLoai);
            this.Controls.Add(this.labelTheLoai);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.labelTimKiem);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.labelHoTen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Mua Vé Xem Phim";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label labelTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label labelTheLoai;
        private System.Windows.Forms.ComboBox cboTheLoai;
        private System.Windows.Forms.Label labelPhim;
        private System.Windows.Forms.ListView lstPhim;
        private System.Windows.Forms.Label labelLichChieu;
        private System.Windows.Forms.ComboBox cboLichChieu;
        private System.Windows.Forms.Label labelLoaiVe;
        private System.Windows.Forms.ComboBox cboLoaiVe;
        private System.Windows.Forms.Button btnChonGhe;
        private System.Windows.Forms.Label labelGhe;
        private System.Windows.Forms.TextBox txtGhe;
        private System.Windows.Forms.Button btnMuaDoAn;
        private System.Windows.Forms.Label labelTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.Label labelHoaDon;
        private System.Windows.Forms.TextBox txtHoaDon;
    }
}