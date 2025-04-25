namespace GUI
{
    partial class frmNhanVienXuLy
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
            this.labelMaXacNhan = new System.Windows.Forms.Label();
            this.txtMaXacNhan = new System.Windows.Forms.TextBox();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.labelThongTin = new System.Windows.Forms.Label();
            this.txtThongTin = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.labelMaXacNhan.AutoSize = true;
            this.labelMaXacNhan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelMaXacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.labelMaXacNhan.Location = new System.Drawing.Point(12, 20);
            this.labelMaXacNhan.Name = "labelMaXacNhan";
            this.labelMaXacNhan.Size = new System.Drawing.Size(100, 21);
            this.labelMaXacNhan.TabIndex = 0;
            this.labelMaXacNhan.Text = "Mã xác nhận:";

            this.txtMaXacNhan.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaXacNhan.Location = new System.Drawing.Point(120, 17);
            this.txtMaXacNhan.Name = "txtMaXacNhan";
            this.txtMaXacNhan.Size = new System.Drawing.Size(200, 29);
            this.txtMaXacNhan.TabIndex = 1;

            this.btnKiemTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnKiemTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiemTra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnKiemTra.ForeColor = System.Drawing.Color.White;
            this.btnKiemTra.Location = new System.Drawing.Point(330, 17);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(100, 30);
            this.btnKiemTra.TabIndex = 2;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = false;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);

            this.labelThongTin.AutoSize = true;
            this.labelThongTin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.labelThongTin.Location = new System.Drawing.Point(12, 60);
            this.labelThongTin.Name = "labelThongTin";
            this.labelThongTin.Size = new System.Drawing.Size(90, 21);
            this.labelThongTin.TabIndex = 3;
            this.labelThongTin.Text = "Thông tin:";

            this.txtThongTin.Font = new System.Drawing.Font("Courier New", 10F);
            this.txtThongTin.Location = new System.Drawing.Point(12, 90);
            this.txtThongTin.Multiline = true;
            this.txtThongTin.Name = "txtThongTin";
            this.txtThongTin.ReadOnly = true;
            this.txtThongTin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtThongTin.Size = new System.Drawing.Size(418, 300);
            this.txtThongTin.TabIndex = 4;

            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnXacNhan.Enabled = false;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(330, 400);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(100, 30);
            this.btnXacNhan.TabIndex = 5;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 440);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtThongTin);
            this.Controls.Add(this.labelThongTin);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.txtMaXacNhan);
            this.Controls.Add(this.labelMaXacNhan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmNhanVienXuLy";
            this.Text = "Xử Lý Giao Dịch - Nhân Viên";
            this.Load += new System.EventHandler(this.frmNhanVienXuLy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelMaXacNhan;
        private System.Windows.Forms.TextBox txtMaXacNhan;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Label labelThongTin;
        private System.Windows.Forms.TextBox txtThongTin;
        private System.Windows.Forms.Button btnXacNhan;
    }
}