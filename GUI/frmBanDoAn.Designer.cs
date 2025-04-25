namespace GUI
{
    partial class frmBanDoAn
    {
        private System.ComponentModel.IContainer components = null; private System.Windows.Forms.Panel pnlHeader; private System.Windows.Forms.Label lblTitle; private System.Windows.Forms.Panel pnlMain; private System.Windows.Forms.Label lblMaNhanVien; private System.Windows.Forms.TextBox txtMaNhanVien; private System.Windows.Forms.Label lblHoTenNhanVien; private System.Windows.Forms.TextBox txtHoTenNhanVien; private System.Windows.Forms.Label lblDoAn; private System.Windows.Forms.DataGridView dgvDoAn; private System.Windows.Forms.Label lblTongTien; private System.Windows.Forms.TextBox txtTongTien; private System.Windows.Forms.TextBox txtHoaDon; private System.Windows.Forms.Button btnThanhToan; private System.Windows.Forms.Button btnInHoaDon;
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblMaNhanVien = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.lblHoTenNhanVien = new System.Windows.Forms.Label();
            this.txtHoTenNhanVien = new System.Windows.Forms.TextBox();
            this.lblDoAn = new System.Windows.Forms.Label();
            this.dgvDoAn = new System.Windows.Forms.DataGridView();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtHoaDon = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoAn)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(966, 39);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(966, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bán Đồ Ăn";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlMain
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.Controls.Add(this.lblMaNhanVien);
            this.pnlMain.Controls.Add(this.txtMaNhanVien);
            this.pnlMain.Controls.Add(this.lblHoTenNhanVien);
            this.pnlMain.Controls.Add(this.txtHoTenNhanVien);
            this.pnlMain.Controls.Add(this.lblDoAn);
            this.pnlMain.Controls.Add(this.dgvDoAn);
            this.pnlMain.Controls.Add(this.lblTongTien);
            this.pnlMain.Controls.Add(this.txtTongTien);
            this.pnlMain.Controls.Add(this.txtHoaDon);
            this.pnlMain.Controls.Add(this.btnThanhToan);
            this.pnlMain.Controls.Add(this.btnInHoaDon);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 39);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(966, 530);
            this.pnlMain.TabIndex = 1;

            // lblMaNhanVien
            this.lblMaNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblMaNhanVien.Location = new System.Drawing.Point(12, 13);
            this.lblMaNhanVien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(151, 20);
            this.lblMaNhanVien.TabIndex = 0;
            this.lblMaNhanVien.Text = "Mã nhân viên:";

            // txtMaNhanVien
            this.txtMaNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaNhanVien.Location = new System.Drawing.Point(167, 13);
            this.txtMaNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.ReadOnly = true;
            this.txtMaNhanVien.Size = new System.Drawing.Size(150, 29);
            this.txtMaNhanVien.TabIndex = 1;

            // lblHoTenNhanVien
            this.lblHoTenNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHoTenNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblHoTenNhanVien.Location = new System.Drawing.Point(12, 46);
            this.lblHoTenNhanVien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHoTenNhanVien.Name = "lblHoTenNhanVien";
            this.lblHoTenNhanVien.Size = new System.Drawing.Size(151, 20);
            this.lblHoTenNhanVien.TabIndex = 2;
            this.lblHoTenNhanVien.Text = "Họ tên nhân viên:";

            // txtHoTenNhanVien
            this.txtHoTenNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoTenNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtHoTenNhanVien.Location = new System.Drawing.Point(167, 46);
            this.txtHoTenNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoTenNhanVien.Name = "txtHoTenNhanVien";
            this.txtHoTenNhanVien.ReadOnly = true;
            this.txtHoTenNhanVien.Size = new System.Drawing.Size(150, 29);
            this.txtHoTenNhanVien.TabIndex = 3;

            // lblDoAn
            this.lblDoAn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoAn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblDoAn.Location = new System.Drawing.Point(12, 80);
            this.lblDoAn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoAn.Name = "lblDoAn";
            this.lblDoAn.Size = new System.Drawing.Size(105, 20);
            this.lblDoAn.TabIndex = 4;
            this.lblDoAn.Text = "Chọn đồ ăn:";

            // dgvDoAn
            this.dgvDoAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoAn.Location = new System.Drawing.Point(121, 80);
            this.dgvDoAn.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDoAn.Name = "dgvDoAn";
            this.dgvDoAn.RowHeadersVisible = false;
            this.dgvDoAn.Size = new System.Drawing.Size(350, 200);
            this.dgvDoAn.TabIndex = 5;

            // lblTongTien
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblTongTien.Location = new System.Drawing.Point(12, 290);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(120, 20);
            this.lblTongTien.TabIndex = 6;
            this.lblTongTien.Text = "Tổng tiền:";

            // txtTongTien
            this.txtTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTongTien.Location = new System.Drawing.Point(167, 290);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(150, 29);
            this.txtTongTien.TabIndex = 7;

            // txtHoaDon
            this.txtHoaDon.Font = new System.Drawing.Font("Courier New", 10F);
            this.txtHoaDon.Location = new System.Drawing.Point(487, 13);
            this.txtHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoaDon.Multiline = true;
            this.txtHoaDon.Name = "txtHoaDon";
            this.txtHoaDon.ReadOnly = true;
            this.txtHoaDon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHoaDon.Size = new System.Drawing.Size(467, 500);
            this.txtHoaDon.TabIndex = 8;

            // btnThanhToan
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(121, 325);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(100, 30);
            this.btnThanhToan.TabIndex = 9;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            this.btnThanhToan.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnThanhToan.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            // btnInHoaDon
            this.btnInHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnInHoaDon.Enabled = false;
            this.btnInHoaDon.FlatAppearance.BorderSize = 0;
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnInHoaDon.Location = new System.Drawing.Point(225, 325);
            this.btnInHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(100, 30);
            this.btnInHoaDon.TabIndex = 10;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = false;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            this.btnInHoaDon.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnInHoaDon.MouseLeave += new System.EventHandler(this.btn_MouseLeave);

            // frmBanDoAn
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 569);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmBanDoAn";
            this.Text = "Bán Đồ Ăn";
            this.pnlHeader.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoAn)).EndInit();
            this.ResumeLayout(false);
        }
    }
}