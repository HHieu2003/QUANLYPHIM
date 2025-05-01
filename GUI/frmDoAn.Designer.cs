using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmDoAn
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private TableLayoutPanel tblLayout;
        private Panel pnlInput;

        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;
        private DataGridView dgvDoAn;

        private Label lblMaDoAn;
        private TextBox txtMaDoAn;
        private Label lblTenDoAn;
        private TextBox txtTenDoAn;
        private Label lblGia;
        private TextBox txtGia;
        private Label lblMoTa;
        private TextBox txtMoTa;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

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
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvDoAn = new System.Windows.Forms.DataGridView();
            this.lblMaDoAn = new System.Windows.Forms.Label();
            this.txtMaDoAn = new System.Windows.Forms.TextBox();
            this.lblTenDoAn = new System.Windows.Forms.Label();
            this.txtTenDoAn = new System.Windows.Forms.TextBox();
            this.lblGia = new System.Windows.Forms.Label();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.tblLayout.SuspendLayout();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoAn)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(26, 166, 154);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1047, 39);
            this.pnlHeader.TabIndex = 1;

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1047, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý đồ ăn";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // tblLayout
            this.tblLayout.ColumnCount = 2;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.9064F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.0936F));
            this.tblLayout.Controls.Add(this.pnlInput, 0, 0);
            this.tblLayout.Controls.Add(this.dgvDoAn, 1, 0);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.Location = new System.Drawing.Point(0, 39);
            this.tblLayout.Margin = new System.Windows.Forms.Padding(2);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 1;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(1047, 515);
            this.tblLayout.TabIndex = 0;

            // pnlInput
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInput.Controls.Add(this.lblMaDoAn);
            this.pnlInput.Controls.Add(this.txtMaDoAn);
            this.pnlInput.Controls.Add(this.lblTenDoAn);
            this.pnlInput.Controls.Add(this.txtTenDoAn);
            this.pnlInput.Controls.Add(this.lblGia);
            this.pnlInput.Controls.Add(this.txtGia);
            this.pnlInput.Controls.Add(this.lblMoTa);
            this.pnlInput.Controls.Add(this.txtMoTa);
            this.pnlInput.Controls.Add(this.btnThem);
            this.pnlInput.Controls.Add(this.btnSua);
            this.pnlInput.Controls.Add(this.btnXoa);
            this.pnlInput.Controls.Add(this.btnLamMoi);
            this.pnlInput.Controls.Add(this.lblTimKiem);
            this.pnlInput.Controls.Add(this.txtTimKiem);
            this.pnlInput.Controls.Add(this.btnTim);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInput.Location = new System.Drawing.Point(2, 2);
            this.pnlInput.Margin = new System.Windows.Forms.Padding(2);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(15, 13, 15, 13);
            this.pnlInput.Size = new System.Drawing.Size(351, 511);
            this.pnlInput.TabIndex = 0;

            // lblTimKiem
            this.lblTimKiem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor = System.Drawing.Color.FromArgb(26, 166, 154);
            this.lblTimKiem.Location = new System.Drawing.Point(0, 17);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(110, 20);
            this.lblTimKiem.TabIndex = 15;
            this.lblTimKiem.Text = "Tìm kiếm:";

            // txtTimKiem
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimKiem.Location = new System.Drawing.Point(114, 17);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(231, 29);
            this.txtTimKiem.TabIndex = 16;

            // btnTim
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(26, 166, 154);
            this.btnTim.FlatAppearance.BorderSize = 0;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(114, 50);
            this.btnTim.Margin = new System.Windows.Forms.Padding(2);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(107, 29);
            this.btnTim.TabIndex = 17;
            this.btnTim.Text = "🔍 Tìm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);

            // lblMaDoAn
            this.lblMaDoAn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaDoAn.ForeColor = System.Drawing.Color.FromArgb(26, 166, 154);
            this.lblMaDoAn.Location = new System.Drawing.Point(0, 90);
            this.lblMaDoAn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaDoAn.Name = "lblMaDoAn";
            this.lblMaDoAn.Size = new System.Drawing.Size(110, 20);
            this.lblMaDoAn.TabIndex = 0;
            this.lblMaDoAn.Text = "Mã đồ ăn:";

            // txtMaDoAn
            this.txtMaDoAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaDoAn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaDoAn.Location = new System.Drawing.Point(114, 90);
            this.txtMaDoAn.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaDoAn.Name = "txtMaDoAn";
            this.txtMaDoAn.Size = new System.Drawing.Size(231, 29);
            this.txtMaDoAn.TabIndex = 1;

            // lblTenDoAn
            this.lblTenDoAn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenDoAn.ForeColor = System.Drawing.Color.FromArgb(26, 166, 154);
            this.lblTenDoAn.Location = new System.Drawing.Point(0, 132);
            this.lblTenDoAn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenDoAn.Name = "lblTenDoAn";
            this.lblTenDoAn.Size = new System.Drawing.Size(110, 20);
            this.lblTenDoAn.TabIndex = 2;
            this.lblTenDoAn.Text = "Tên đồ ăn:";

            // txtTenDoAn
            this.txtTenDoAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenDoAn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTenDoAn.Location = new System.Drawing.Point(114, 132);
            this.txtTenDoAn.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenDoAn.Name = "txtTenDoAn";
            this.txtTenDoAn.Size = new System.Drawing.Size(231, 29);
            this.txtTenDoAn.TabIndex = 3;

            // lblGia
            this.lblGia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblGia.ForeColor = System.Drawing.Color.FromArgb(26, 166, 154);
            this.lblGia.Location = new System.Drawing.Point(0, 175);
            this.lblGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(110, 20);
            this.lblGia.TabIndex = 4;
            this.lblGia.Text = "Giá:";

            // txtGia
            this.txtGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGia.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtGia.Location = new System.Drawing.Point(114, 175);
            this.txtGia.Margin = new System.Windows.Forms.Padding(2);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(231, 29);
            this.txtGia.TabIndex = 5;

            // lblMoTa
            this.lblMoTa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(26, 166, 154);
            this.lblMoTa.Location = new System.Drawing.Point(0, 217);
            this.lblMoTa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(110, 20);
            this.lblMoTa.TabIndex = 6;
            this.lblMoTa.Text = "Mô tả:";

            // txtMoTa
            this.txtMoTa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMoTa.Location = new System.Drawing.Point(114, 217);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(2);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(231, 139);
            this.txtMoTa.TabIndex = 7;

            // btnThem
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(26, 166, 154);
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(17, 422);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(89, 34);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // btnSua
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(26, 166, 154);
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(132, 422);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(89, 34);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // btnXoa
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(211, 47, 47);
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(243, 422);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(89, 34);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // btnLamMoi
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(17, 467);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(89, 34);
            this.btnLamMoi.TabIndex = 11;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // dgvDoAn
            this.dgvDoAn.AllowUserToAddRows = false;
            this.dgvDoAn.AllowUserToDeleteRows = false;
            this.dgvDoAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoAn.Location = new System.Drawing.Point(370, 13);
            this.dgvDoAn.Margin = new System.Windows.Forms.Padding(15, 13, 15, 13);
            this.dgvDoAn.Name = "dgvDoAn";
            this.dgvDoAn.ReadOnly = true;
            this.dgvDoAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoAn.Size = new System.Drawing.Size(662, 489);
            this.dgvDoAn.TabIndex = 1;

            // frmDoAn
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1047, 554);
            this.Controls.Add(this.tblLayout);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDoAn";
            this.Text = "Quản lý đồ ăn";
            this.pnlHeader.ResumeLayout(false);
            this.tblLayout.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoAn)).EndInit();
            this.ResumeLayout(false);
        }
    }
}