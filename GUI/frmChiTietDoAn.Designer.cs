using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmChiTietDoAn
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private TableLayoutPanel tblLayout;
        private Panel pnlContent;
        private DataGridView dgvChiTietDoAn;

        // Controls for search
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;

        // Controls for time filter
        private Label lblTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnLocThoiGian;

        // Controls for food item filter
        private Label lblMaDoAn;
        private ComboBox cboMaDoAn;
        private Button btnLocMaDoAn;

        // Action buttons
        private Button btnInPDF;
        private Button btnTaiLai;
        private Button btnXoa;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnLocThoiGian = new System.Windows.Forms.Button();
            this.lblMaDoAn = new System.Windows.Forms.Label();
            this.cboMaDoAn = new System.Windows.Forms.ComboBox();
            this.btnLocMaDoAn = new System.Windows.Forms.Button();
            this.btnInPDF = new System.Windows.Forms.Button();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvChiTietDoAn = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.tblLayout.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDoAn)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 50);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1000, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ CHI TIẾT ĐƠN HÀNG ĐỒ ĂN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblLayout
            // 
            this.tblLayout.ColumnCount = 1;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Controls.Add(this.pnlContent, 0, 0);
            this.tblLayout.Controls.Add(this.dgvChiTietDoAn, 0, 1);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.Location = new System.Drawing.Point(0, 50);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 2;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(1000, 550);
            this.tblLayout.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.Controls.Add(this.lblTimKiem);
            this.pnlContent.Controls.Add(this.txtTimKiem);
            this.pnlContent.Controls.Add(this.btnTim);
            this.pnlContent.Controls.Add(this.lblTuNgay);
            this.pnlContent.Controls.Add(this.dtpTuNgay);
            this.pnlContent.Controls.Add(this.lblDenNgay);
            this.pnlContent.Controls.Add(this.dtpDenNgay);
            this.pnlContent.Controls.Add(this.btnLocThoiGian);
            this.pnlContent.Controls.Add(this.lblMaDoAn);
            this.pnlContent.Controls.Add(this.cboMaDoAn);
            this.pnlContent.Controls.Add(this.btnLocMaDoAn);
            this.pnlContent.Controls.Add(this.btnInPDF);
            this.pnlContent.Controls.Add(this.btnTaiLai);
            this.pnlContent.Controls.Add(this.btnXoa);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(3, 3);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(10);
            this.pnlContent.Size = new System.Drawing.Size(994, 94);
            this.pnlContent.TabIndex = 0;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblTimKiem.Location = new System.Drawing.Point(10, 10);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(78, 20);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTimKiem.Location = new System.Drawing.Point(100, 10);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(150, 27);
            this.txtTimKiem.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(260, 10);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(80, 27);
            this.btnTim.TabIndex = 3;
            this.btnTim.Text = "🔍 Tìm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTuNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblTuNgay.Location = new System.Drawing.Point(10, 50);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(70, 20);
            this.lblTuNgay.TabIndex = 4;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(100, 50);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 27);
            this.dtpTuNgay.TabIndex = 5;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDenNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblDenNgay.Location = new System.Drawing.Point(260, 50);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(79, 20);
            this.lblDenNgay.TabIndex = 6;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(350, 50);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 27);
            this.dtpDenNgay.TabIndex = 7;
            // 
            // btnLocThoiGian
            // 
            this.btnLocThoiGian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnLocThoiGian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocThoiGian.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLocThoiGian.ForeColor = System.Drawing.Color.White;
            this.btnLocThoiGian.Location = new System.Drawing.Point(510, 50);
            this.btnLocThoiGian.Name = "btnLocThoiGian";
            this.btnLocThoiGian.Size = new System.Drawing.Size(80, 27);
            this.btnLocThoiGian.TabIndex = 8;
            this.btnLocThoiGian.Text = "⏳ Lọc";
            this.btnLocThoiGian.UseVisualStyleBackColor = false;
            this.btnLocThoiGian.Click += new System.EventHandler(this.btnLocThoiGian_Click);
            // 
            // lblMaDoAn
            // 
            this.lblMaDoAn.AutoSize = true;
            this.lblMaDoAn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaDoAn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblMaDoAn.Location = new System.Drawing.Point(610, 50);
            this.lblMaDoAn.Name = "lblMaDoAn";
            this.lblMaDoAn.Size = new System.Drawing.Size(100, 20);
            this.lblMaDoAn.TabIndex = 9;
            this.lblMaDoAn.Text = "Món ăn:";
            // 
            // cboMaDoAn
            // 
            this.cboMaDoAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaDoAn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboMaDoAn.Location = new System.Drawing.Point(710, 50);
            this.cboMaDoAn.Name = "cboMaDoAn";
            this.cboMaDoAn.Size = new System.Drawing.Size(150, 28);
            this.cboMaDoAn.TabIndex = 10;
            // 
            // btnLocMaDoAn
            // 
            this.btnLocMaDoAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnLocMaDoAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocMaDoAn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLocMaDoAn.ForeColor = System.Drawing.Color.White;
            this.btnLocMaDoAn.Location = new System.Drawing.Point(870, 50);
            this.btnLocMaDoAn.Name = "btnLocMaDoAn";
            this.btnLocMaDoAn.Size = new System.Drawing.Size(80, 28);
            this.btnLocMaDoAn.TabIndex = 11;
            this.btnLocMaDoAn.Text = "🍔 Lọc";
            this.btnLocMaDoAn.UseVisualStyleBackColor = false;
            this.btnLocMaDoAn.Click += new System.EventHandler(this.btnLocMaDoAn_Click);
            // 
            // btnInPDF
            // 
            this.btnInPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnInPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInPDF.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnInPDF.ForeColor = System.Drawing.Color.White;
            this.btnInPDF.Location = new System.Drawing.Point(350, 10);
            this.btnInPDF.Name = "btnInPDF";
            this.btnInPDF.Size = new System.Drawing.Size(100, 27);
            this.btnInPDF.TabIndex = 12;
            this.btnInPDF.Text = "🖨 In PDF";
            this.btnInPDF.UseVisualStyleBackColor = false;
            this.btnInPDF.Click += new System.EventHandler(this.btnInPDF_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnTaiLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiLai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTaiLai.ForeColor = System.Drawing.Color.White;
            this.btnTaiLai.Location = new System.Drawing.Point(460, 10);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(100, 27);
            this.btnTaiLai.TabIndex = 13;
            this.btnTaiLai.Text = "🔄 Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = false;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(570, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 27);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "🗑 Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dgvChiTietDoAn
            // 
            this.dgvChiTietDoAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietDoAn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTietDoAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietDoAn.EnableHeadersVisualStyles = false;
            this.dgvChiTietDoAn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgvChiTietDoAn.Location = new System.Drawing.Point(3, 103);
            this.dgvChiTietDoAn.Name = "dgvChiTietDoAn";
            this.dgvChiTietDoAn.ReadOnly = true;
            this.dgvChiTietDoAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietDoAn.Size = new System.Drawing.Size(994, 444);
            this.dgvChiTietDoAn.TabIndex = 1;
            // 
            // frmChiTietDoAn
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tblLayout);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmChiTietDoAn";
            this.Text = "Quản lý chi tiết đồ ăn";
            this.pnlHeader.ResumeLayout(false);
            this.tblLayout.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDoAn)).EndInit();
            this.ResumeLayout(false);
        }
    }
}