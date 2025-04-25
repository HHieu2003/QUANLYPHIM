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
        private Panel pnlInput;

        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;
        private DataGridView dgvChiTietDoAn;

        private Label lblMaChiTiet;
        private TextBox txtMaChiTiet;
        private Label lblMaDonHang;
        private TextBox txtMaDonHang;
        private Label lblMaDoAn;
        private TextBox txtMaDoAn;
        private Label lblSoLuong;
        private TextBox txtSoLuong;
        private Label lblGia;
        private TextBox txtGia;
        private Label lblThanhTien;
        private TextBox txtThanhTien;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnHuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            tblLayout = new TableLayoutPanel();
            pnlInput = new Panel();

            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTim = new Button();
            dgvChiTietDoAn = new DataGridView();

            lblMaChiTiet = new Label();
            txtMaChiTiet = new TextBox();
            lblMaDonHang = new Label();
            txtMaDonHang = new TextBox();
            lblMaDoAn = new Label();
            txtMaDoAn = new TextBox();
            lblSoLuong = new Label();
            txtSoLuong = new TextBox();
            lblGia = new Label();
            txtGia = new TextBox();
            lblThanhTien = new Label();
            txtThanhTien = new TextBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnHuy = new Button();

            // Header
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 50;
            pnlHeader.BackColor = Color.FromArgb(0, 150, 136);
            lblTitle.Text = "Quản lý chi tiết đồ ăn";
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            pnlHeader.Controls.Add(lblTitle);

            // Layout
            tblLayout.Dock = DockStyle.Fill;
            tblLayout.ColumnCount = 2;
            tblLayout.RowCount = 1;
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Panel Input
            pnlInput.Dock = DockStyle.Fill;
            pnlInput.BackColor = Color.WhiteSmoke;
            pnlInput.Padding = new Padding(20);

            lblTimKiem.Text = "Tìm kiếm:";
            lblTimKiem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTimKiem.ForeColor = Color.FromArgb(26, 166, 154);
            lblTimKiem.Location = new Point(5, 15);
            lblTimKiem.AutoSize = true;

            txtTimKiem.Font = new Font("Segoe UI", 12F);
            txtTimKiem.Location = new Point(110, 12);
            txtTimKiem.Width = 160;

            btnTim.Text = "🔍 Tìm";
            btnTim.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTim.ForeColor = Color.White;
            btnTim.BackColor = Color.FromArgb(26, 166, 154);
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Location = new Point(280, 12);
            btnTim.Size = new Size(60, 30);
            btnTim.Click += new System.EventHandler(this.btnTim_Click);

            int labelX = 5, inputX = 110, width = 230;
            int y = 60, yOffset = 40;

            void SetLabel(Label lbl, string text)
            {
                lbl.Text = text;
                lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(26, 166, 154);
                lbl.Location = new Point(labelX, y);
                lbl.AutoSize = true;
            }

            void SetTextBox(TextBox txt)
            {
                txt.Font = new Font("Segoe UI", 12F);
                txt.Location = new Point(inputX, y);
                txt.Width = width;
            }

            SetLabel(lblMaChiTiet, "Mã chi tiết:"); pnlInput.Controls.Add(lblMaChiTiet);
            SetTextBox(txtMaChiTiet); pnlInput.Controls.Add(txtMaChiTiet); y += yOffset;

            SetLabel(lblMaDonHang, "Mã đơn hàng:"); pnlInput.Controls.Add(lblMaDonHang);
            SetTextBox(txtMaDonHang); pnlInput.Controls.Add(txtMaDonHang); y += yOffset;

            SetLabel(lblMaDoAn, "Mã đồ ăn:"); pnlInput.Controls.Add(lblMaDoAn);
            SetTextBox(txtMaDoAn); pnlInput.Controls.Add(txtMaDoAn); y += yOffset;

            SetLabel(lblSoLuong, "Số lượng:"); pnlInput.Controls.Add(lblSoLuong);
            SetTextBox(txtSoLuong); pnlInput.Controls.Add(txtSoLuong); y += yOffset;

            SetLabel(lblGia, "Giá:"); pnlInput.Controls.Add(lblGia);
            SetTextBox(txtGia); pnlInput.Controls.Add(txtGia); y += yOffset;

            SetLabel(lblThanhTien, "Thành tiền:"); pnlInput.Controls.Add(lblThanhTien);
            SetTextBox(txtThanhTien); pnlInput.Controls.Add(txtThanhTien); y += yOffset;

            void SetButton(Button btn, string text, Color color, int offsetX)
            {
                btn.Text = text;
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btn.ForeColor = Color.White;
                btn.BackColor = color;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Size = new Size(85, 36);
                btn.Location = new Point(offsetX, y);
                pnlInput.Controls.Add(btn);
            }

            SetButton(btnThem, "Thêm", Color.FromArgb(0, 150, 136), 10);
            SetButton(btnSua, "Sửa", Color.FromArgb(0, 150, 136), 105);
            SetButton(btnXoa, "Xóa", Color.FromArgb(211, 47, 47), 200);
            SetButton(btnLamMoi, "Làm mới", Color.FromArgb(120, 120, 120), 295);
            SetButton(btnHuy, "Hủy", Color.Gray, 390);

            btnThem.Click += new System.EventHandler(this.btnThem_Click);
            btnSua.Click += new System.EventHandler(this.btnSua_Click);
            btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            pnlInput.Controls.AddRange(new Control[] { lblTimKiem, txtTimKiem, btnTim });

            // DataGridView
            dgvChiTietDoAn.Dock = DockStyle.Fill;
            dgvChiTietDoAn.Font = new Font("Segoe UI", 11F);
            dgvChiTietDoAn.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgvChiTietDoAn.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvChiTietDoAn.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 166, 154);
            dgvChiTietDoAn.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChiTietDoAn.EnableHeadersVisualStyles = false;
            dgvChiTietDoAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietDoAn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietDoAn.ReadOnly = true;

            tblLayout.Controls.Add(pnlInput, 0, 0);
            tblLayout.Controls.Add(dgvChiTietDoAn, 1, 0);

            this.Text = "Quản lý chi tiết đồ ăn";
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(tblLayout);
            this.Controls.Add(pnlHeader);
            this.ResumeLayout(false);
        }
    }
}
