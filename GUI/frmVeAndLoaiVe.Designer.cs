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
        private TabPage tabVe;
        private TabPage tabLoaiVe;

        // Quản lý vé
        private Panel pnlVe;
        private DataGridView dgvVe;
        private Label lblTimKiemVe, lblMaVe;
        private TextBox txtTimKiemVe, txtMaVe;
        private Button btnTimKiemVe, btnXoaVe;

        // Quản lý loại vé
        private Panel pnlLoaiVe;
        private DataGridView dgvLoaiVe;
        private Label lblMaLoaiVe, lblTenLoaiVe, lblPhuThu;
        private TextBox txtMaLoaiVe, txtTenLoaiVe, txtPhuThu;
        private Button btnThemLoaiVe, btnXoaLoaiVe, btnSuaLoaiVe, btnLamMoiLoaiVe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabVe = new System.Windows.Forms.TabPage();
            this.pnlVe = new System.Windows.Forms.Panel();
            this.lblTimKiemVe = new System.Windows.Forms.Label();
            this.txtTimKiemVe = new System.Windows.Forms.TextBox();
            this.btnTimKiemVe = new System.Windows.Forms.Button();
            this.lblMaVe = new System.Windows.Forms.Label();
            this.txtMaVe = new System.Windows.Forms.TextBox();
            this.btnXoaVe = new System.Windows.Forms.Button();
            this.dgvVe = new System.Windows.Forms.DataGridView();
            this.tabLoaiVe = new System.Windows.Forms.TabPage();
            this.pnlLoaiVe = new System.Windows.Forms.Panel();
            this.lblMaLoaiVe = new System.Windows.Forms.Label();
            this.txtMaLoaiVe = new System.Windows.Forms.TextBox();
            this.lblTenLoaiVe = new System.Windows.Forms.Label();
            this.txtTenLoaiVe = new System.Windows.Forms.TextBox();
            this.lblPhuThu = new System.Windows.Forms.Label();
            this.txtPhuThu = new System.Windows.Forms.TextBox();
            this.btnThemLoaiVe = new System.Windows.Forms.Button();
            this.btnXoaLoaiVe = new System.Windows.Forms.Button();
            this.btnSuaLoaiVe = new System.Windows.Forms.Button();
            this.btnLamMoiLoaiVe = new System.Windows.Forms.Button();
            this.dgvLoaiVe = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabVe.SuspendLayout();
            this.pnlVe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
            this.tabLoaiVe.SuspendLayout();
            this.pnlLoaiVe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiVe)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
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
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(960, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý vé và loại vé";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabVe);
            this.tabControl.Controls.Add(this.tabLoaiVe);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tabControl.Location = new System.Drawing.Point(0, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(960, 429);
            this.tabControl.TabIndex = 0;
            // 
            // tabVe
            // 
            this.tabVe.Controls.Add(this.pnlVe);
            this.tabVe.Controls.Add(this.dgvVe);
            this.tabVe.Location = new System.Drawing.Point(4, 30);
            this.tabVe.Name = "tabVe";
            this.tabVe.Size = new System.Drawing.Size(952, 395);
            this.tabVe.TabIndex = 0;
            this.tabVe.Text = "Quản lý vé";
            // 
            // pnlVe
            // 
            this.pnlVe.BackColor = System.Drawing.Color.White;
            this.pnlVe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVe.Controls.Add(this.lblTimKiemVe);
            this.pnlVe.Controls.Add(this.txtTimKiemVe);
            this.pnlVe.Controls.Add(this.btnTimKiemVe);
            this.pnlVe.Controls.Add(this.lblMaVe);
            this.pnlVe.Controls.Add(this.txtMaVe);
            this.pnlVe.Controls.Add(this.btnXoaVe);
            this.pnlVe.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlVe.Location = new System.Drawing.Point(0, 0);
            this.pnlVe.Name = "pnlVe";
            this.pnlVe.Padding = new System.Windows.Forms.Padding(15, 13, 15, 13);
            this.pnlVe.Size = new System.Drawing.Size(324, 395);
            this.pnlVe.TabIndex = 0;
            // 
            // lblTimKiemVe
            // 
            this.lblTimKiemVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTimKiemVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblTimKiemVe.Location = new System.Drawing.Point(22, 13);
            this.lblTimKiemVe.Name = "lblTimKiemVe";
            this.lblTimKiemVe.Size = new System.Drawing.Size(75, 20);
            this.lblTimKiemVe.TabIndex = 0;
            this.lblTimKiemVe.Text = "Tìm kiếm:";
            // 
            // txtTimKiemVe
            // 
            this.txtTimKiemVe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiemVe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimKiemVe.Location = new System.Drawing.Point(98, 13);
            this.txtTimKiemVe.Name = "txtTimKiemVe";
            this.txtTimKiemVe.Size = new System.Drawing.Size(150, 29);
            this.txtTimKiemVe.TabIndex = 1;
            // 
            // btnTimKiemVe
            // 
            this.btnTimKiemVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnTimKiemVe.FlatAppearance.BorderSize = 0;
            this.btnTimKiemVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTimKiemVe.ForeColor = System.Drawing.Color.White;
            this.btnTimKiemVe.Location = new System.Drawing.Point(255, 13);
            this.btnTimKiemVe.Name = "btnTimKiemVe";
            this.btnTimKiemVe.Size = new System.Drawing.Size(69, 20);
            this.btnTimKiemVe.TabIndex = 2;
            this.btnTimKiemVe.Text = "🔍 Tìm";
            this.btnTimKiemVe.UseVisualStyleBackColor = false;
            this.btnTimKiemVe.Click += new System.EventHandler(this.btnTimKiemVe_Click);
            this.btnTimKiemVe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnTimKiemVe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // lblMaVe
            // 
            this.lblMaVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblMaVe.Location = new System.Drawing.Point(22, 46);
            this.lblMaVe.Name = "lblMaVe";
            this.lblMaVe.Size = new System.Drawing.Size(75, 20);
            this.lblMaVe.TabIndex = 3;
            this.lblMaVe.Text = "Mã vé:";
            // 
            // txtMaVe
            // 
            this.txtMaVe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaVe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaVe.Location = new System.Drawing.Point(26, 69);
            this.txtMaVe.Name = "txtMaVe";
            this.txtMaVe.ReadOnly = true;
            this.txtMaVe.Size = new System.Drawing.Size(215, 29);
            this.txtMaVe.TabIndex = 4;
            // 
            // btnXoaVe
            // 
            this.btnXoaVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnXoaVe.FlatAppearance.BorderSize = 0;
            this.btnXoaVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoaVe.ForeColor = System.Drawing.Color.White;
            this.btnXoaVe.Location = new System.Drawing.Point(26, 104);
            this.btnXoaVe.Name = "btnXoaVe";
            this.btnXoaVe.Size = new System.Drawing.Size(60, 26);
            this.btnXoaVe.TabIndex = 5;
            this.btnXoaVe.Text = "Xóa";
            this.btnXoaVe.UseVisualStyleBackColor = false;
            this.btnXoaVe.Click += new System.EventHandler(this.btnXoaVe_Click);
            this.btnXoaVe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnXoaVe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // dgvVe
            // 
            this.dgvVe.AllowUserToAddRows = false;
            this.dgvVe.AllowUserToDeleteRows = false;
            this.dgvVe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVe.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVe.Location = new System.Drawing.Point(0, 0);
            this.dgvVe.Name = "dgvVe";
            this.dgvVe.ReadOnly = true;
            this.dgvVe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVe.Size = new System.Drawing.Size(952, 395);
            this.dgvVe.TabIndex = 1;
            this.dgvVe.SelectionChanged += new System.EventHandler(this.DgvVe_SelectionChanged);
            // 
            // tabLoaiVe
            // 
            this.tabLoaiVe.Controls.Add(this.pnlLoaiVe);
            this.tabLoaiVe.Controls.Add(this.dgvLoaiVe);
            this.tabLoaiVe.Location = new System.Drawing.Point(4, 30);
            this.tabLoaiVe.Name = "tabLoaiVe";
            this.tabLoaiVe.Size = new System.Drawing.Size(952, 395);
            this.tabLoaiVe.TabIndex = 1;
            this.tabLoaiVe.Text = "Quản lý loại vé";
            // 
            // pnlLoaiVe
            // 
            this.pnlLoaiVe.BackColor = System.Drawing.Color.White;
            this.pnlLoaiVe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoaiVe.Controls.Add(this.lblMaLoaiVe);
            this.pnlLoaiVe.Controls.Add(this.txtMaLoaiVe);
            this.pnlLoaiVe.Controls.Add(this.lblTenLoaiVe);
            this.pnlLoaiVe.Controls.Add(this.txtTenLoaiVe);
            this.pnlLoaiVe.Controls.Add(this.lblPhuThu);
            this.pnlLoaiVe.Controls.Add(this.txtPhuThu);
            this.pnlLoaiVe.Controls.Add(this.btnThemLoaiVe);
            this.pnlLoaiVe.Controls.Add(this.btnXoaLoaiVe);
            this.pnlLoaiVe.Controls.Add(this.btnSuaLoaiVe);
            this.pnlLoaiVe.Controls.Add(this.btnLamMoiLoaiVe);
            this.pnlLoaiVe.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLoaiVe.Location = new System.Drawing.Point(0, 0);
            this.pnlLoaiVe.Name = "pnlLoaiVe";
            this.pnlLoaiVe.Padding = new System.Windows.Forms.Padding(15, 13, 15, 13);
            this.pnlLoaiVe.Size = new System.Drawing.Size(376, 395);
            this.pnlLoaiVe.TabIndex = 0;
            // 
            // lblMaLoaiVe
            // 
            this.lblMaLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaLoaiVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblMaLoaiVe.Location = new System.Drawing.Point(22, 13);
            this.lblMaLoaiVe.Name = "lblMaLoaiVe";
            this.lblMaLoaiVe.Size = new System.Drawing.Size(75, 20);
            this.lblMaLoaiVe.TabIndex = 0;
            this.lblMaLoaiVe.Text = "Mã loại vé:";
            // 
            // txtMaLoaiVe
            // 
            this.txtMaLoaiVe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaLoaiVe.Location = new System.Drawing.Point(98, 13);
            this.txtMaLoaiVe.Name = "txtMaLoaiVe";
            this.txtMaLoaiVe.Size = new System.Drawing.Size(226, 29);
            this.txtMaLoaiVe.TabIndex = 1;
            // 
            // lblTenLoaiVe
            // 
            this.lblTenLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenLoaiVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblTenLoaiVe.Location = new System.Drawing.Point(22, 46);
            this.lblTenLoaiVe.Name = "lblTenLoaiVe";
            this.lblTenLoaiVe.Size = new System.Drawing.Size(75, 20);
            this.lblTenLoaiVe.TabIndex = 2;
            this.lblTenLoaiVe.Text = "Tên loại vé:";
            // 
            // txtTenLoaiVe
            // 
            this.txtTenLoaiVe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTenLoaiVe.Location = new System.Drawing.Point(98, 46);
            this.txtTenLoaiVe.Name = "txtTenLoaiVe";
            this.txtTenLoaiVe.Size = new System.Drawing.Size(226, 29);
            this.txtTenLoaiVe.TabIndex = 3;
            // 
            // lblPhuThu
            // 
            this.lblPhuThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPhuThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.lblPhuThu.Location = new System.Drawing.Point(22, 78);
            this.lblPhuThu.Name = "lblPhuThu";
            this.lblPhuThu.Size = new System.Drawing.Size(75, 20);
            this.lblPhuThu.TabIndex = 4;
            this.lblPhuThu.Text = "Phụ thu:";
            // 
            // txtPhuThu
            // 
            this.txtPhuThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhuThu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPhuThu.Location = new System.Drawing.Point(98, 78);
            this.txtPhuThu.Name = "txtPhuThu";
            this.txtPhuThu.Size = new System.Drawing.Size(226, 29);
            this.txtPhuThu.TabIndex = 5;
            // 
            // btnThemLoaiVe
            // 
            this.btnThemLoaiVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnThemLoaiVe.FlatAppearance.BorderSize = 0;
            this.btnThemLoaiVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThemLoaiVe.ForeColor = System.Drawing.Color.White;
            this.btnThemLoaiVe.Location = new System.Drawing.Point(98, 110);
            this.btnThemLoaiVe.Name = "btnThemLoaiVe";
            this.btnThemLoaiVe.Size = new System.Drawing.Size(60, 26);
            this.btnThemLoaiVe.TabIndex = 6;
            this.btnThemLoaiVe.Text = "Thêm";
            this.btnThemLoaiVe.UseVisualStyleBackColor = false;
            this.btnThemLoaiVe.Click += new System.EventHandler(this.btnThemLoaiVe_Click);
            this.btnThemLoaiVe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnThemLoaiVe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnXoaLoaiVe
            // 
            this.btnXoaLoaiVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnXoaLoaiVe.FlatAppearance.BorderSize = 0;
            this.btnXoaLoaiVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoaLoaiVe.ForeColor = System.Drawing.Color.White;
            this.btnXoaLoaiVe.Location = new System.Drawing.Point(165, 110);
            this.btnXoaLoaiVe.Name = "btnXoaLoaiVe";
            this.btnXoaLoaiVe.Size = new System.Drawing.Size(60, 26);
            this.btnXoaLoaiVe.TabIndex = 7;
            this.btnXoaLoaiVe.Text = "Xóa";
            this.btnXoaLoaiVe.UseVisualStyleBackColor = false;
            this.btnXoaLoaiVe.Click += new System.EventHandler(this.btnXoaLoaiVe_Click);
            this.btnXoaLoaiVe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnXoaLoaiVe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnSuaLoaiVe
            // 
            this.btnSuaLoaiVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnSuaLoaiVe.FlatAppearance.BorderSize = 0;
            this.btnSuaLoaiVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSuaLoaiVe.ForeColor = System.Drawing.Color.White;
            this.btnSuaLoaiVe.Location = new System.Drawing.Point(232, 110);
            this.btnSuaLoaiVe.Name = "btnSuaLoaiVe";
            this.btnSuaLoaiVe.Size = new System.Drawing.Size(60, 26);
            this.btnSuaLoaiVe.TabIndex = 8;
            this.btnSuaLoaiVe.Text = "Sửa";
            this.btnSuaLoaiVe.UseVisualStyleBackColor = false;
            this.btnSuaLoaiVe.Click += new System.EventHandler(this.btnSuaLoaiVe_Click);
            this.btnSuaLoaiVe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnSuaLoaiVe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnLamMoiLoaiVe
            // 
            this.btnLamMoiLoaiVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnLamMoiLoaiVe.FlatAppearance.BorderSize = 0;
            this.btnLamMoiLoaiVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiLoaiVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLamMoiLoaiVe.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiLoaiVe.Location = new System.Drawing.Point(98, 143);
            this.btnLamMoiLoaiVe.Name = "btnLamMoiLoaiVe";
            this.btnLamMoiLoaiVe.Size = new System.Drawing.Size(60, 26);
            this.btnLamMoiLoaiVe.TabIndex = 9;
            this.btnLamMoiLoaiVe.Text = "Làm mới";
            this.btnLamMoiLoaiVe.UseVisualStyleBackColor = false;
            this.btnLamMoiLoaiVe.Click += new System.EventHandler(this.btnLamMoiLoaiVe_Click);
            this.btnLamMoiLoaiVe.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnLamMoiLoaiVe.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // dgvLoaiVe
            // 
            this.dgvLoaiVe.AllowUserToAddRows = false;
            this.dgvLoaiVe.AllowUserToDeleteRows = false;
            this.dgvLoaiVe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoaiVe.Location = new System.Drawing.Point(0, 0);
            this.dgvLoaiVe.Name = "dgvLoaiVe";
            this.dgvLoaiVe.ReadOnly = true;
            this.dgvLoaiVe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiVe.Size = new System.Drawing.Size(952, 395);
            this.dgvLoaiVe.TabIndex = 1;
            this.dgvLoaiVe.SelectionChanged += new System.EventHandler(this.DgvLoaiVe_SelectionChanged);
            // 
            // frmVeAndLoaiVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(960, 468);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmVeAndLoaiVe";
            this.Text = "Quản lý vé và loại vé";
            this.pnlHeader.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabVe.ResumeLayout(false);
            this.pnlVe.ResumeLayout(false);
            this.pnlVe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            this.tabLoaiVe.ResumeLayout(false);
            this.pnlLoaiVe.ResumeLayout(false);
            this.pnlLoaiVe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiVe)).EndInit();
            this.ResumeLayout(false);

        }
    }
}