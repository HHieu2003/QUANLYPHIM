using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private TableLayoutPanel tblLayout;
        private Panel pnlContent;
        private DataGridView dgvBaoCao;
        private Button btnTaiLai;
        private Button btnXoa;
        private Button btnInPDF;

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
            components = new System.ComponentModel.Container();
            pnlHeader = new Panel();
            lblTitle = new Label();
            tblLayout = new TableLayoutPanel();
            pnlContent = new Panel();
            dgvBaoCao = new DataGridView();
            btnTaiLai = new Button();
            btnXoa = new Button();
            btnInPDF = new Button();

            // Header
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 50;
            pnlHeader.BackColor = Color.FromArgb(0, 150, 136);

            lblTitle.Text = "BÁO CÁO TỔNG HỢP";
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            pnlHeader.Controls.Add(lblTitle);

            // Layout
            tblLayout.Dock = DockStyle.Fill;
            tblLayout.ColumnCount = 1;
            tblLayout.RowCount = 2;
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Panel content
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Padding = new Padding(10);

            // Buttons
            btnInPDF.Text = "🖨 In PDF";
            btnInPDF.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnInPDF.BackColor = Color.FromArgb(26, 166, 154);
            btnInPDF.ForeColor = Color.White;
            btnInPDF.FlatStyle = FlatStyle.Flat;
            btnInPDF.Size = new Size(100, 36);
            btnInPDF.Location = new Point(10, 10);
            btnInPDF.Click += new System.EventHandler(this.btnInPDF_Click);

            btnTaiLai.Text = "🔄 Tải lại";
            btnTaiLai.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnTaiLai.BackColor = Color.FromArgb(120, 120, 120);
            btnTaiLai.ForeColor = Color.White;
            btnTaiLai.FlatStyle = FlatStyle.Flat;
            btnTaiLai.Size = new Size(100, 36);
            btnTaiLai.Location = new Point(120, 10);
            btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);

            btnXoa.Text = "🗑 Xóa";
            btnXoa.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnXoa.BackColor = Color.FromArgb(211, 47, 47);
            btnXoa.ForeColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Size = new Size(100, 36);
            btnXoa.Location = new Point(230, 10);
            btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            pnlContent.Controls.Add(btnInPDF);
            pnlContent.Controls.Add(btnTaiLai);
            pnlContent.Controls.Add(btnXoa);

            // DataGridView
            dgvBaoCao.Dock = DockStyle.Fill;
            dgvBaoCao.Font = new Font("Segoe UI", 11F);
            dgvBaoCao.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgvBaoCao.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvBaoCao.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 166, 154);
            dgvBaoCao.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBaoCao.EnableHeadersVisualStyles = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.ReadOnly = true;

            // Add controls to layout
            tblLayout.Controls.Add(pnlContent, 0, 0);
            tblLayout.Controls.Add(dgvBaoCao, 0, 1);

            // Form settings
            this.Text = "Báo cáo tổng hợp";
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(tblLayout);
            this.Controls.Add(pnlHeader);
            this.ResumeLayout(false);
        }
    }
}
