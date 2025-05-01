using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmNguoiDung
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private TableLayoutPanel tblLayout;
        private Panel pnlInput;

        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;
        private DataGridView dgvNguoiDung;

        private Label lblMaNguoiDung;
        private TextBox txtMaNguoiDung;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblVaiTro;
        private ComboBox cboVaiTro;

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
            dgvNguoiDung = new DataGridView();
            lblMaNguoiDung = new Label();
            txtMaNguoiDung = new TextBox();
            lblTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            lblVaiTro = new Label();
            cboVaiTro = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnHuy = new Button();

            // ======= Header =======
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 50;
            pnlHeader.BackColor = Color.FromArgb(0, 150, 136);
            lblTitle.Text = "Quản lý người dùng";
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            pnlHeader.Controls.Add(lblTitle);

            // ======= Table Layout =======
            tblLayout.Dock = DockStyle.Fill;
            tblLayout.ColumnCount = 2;
            tblLayout.RowCount = 1;
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // ======= Left Panel (Input) =======
            pnlInput.Dock = DockStyle.Fill;
            pnlInput.BackColor = Color.WhiteSmoke;
            pnlInput.Padding = new Padding(20);

            lblTimKiem.Text = "Tìm kiếm:";
            lblTimKiem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTimKiem.ForeColor = Color.FromArgb(26, 166, 154);
            lblTimKiem.Location = new Point(5, 15);
            lblTimKiem.AutoSize = true;

            txtTimKiem.Font = new Font("Segoe UI", 12F);
            txtTimKiem.Location = new Point(150, 12);
            txtTimKiem.Width = 160;

            btnTim.Text = "🔍 Tìm";
            btnTim.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTim.ForeColor = Color.White;
            btnTim.BackColor = Color.FromArgb(26, 166, 154);
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Location = new Point(320, 12);
            btnTim.Size = new Size(60, 30);
            btnTim.Click += new System.EventHandler(this.btnTim_Click);

            // ======= Form Fields =======
            int labelX = 5, inputX = 150, width = 230;
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

            SetLabel(lblMaNguoiDung, "Mã người dùng:");
            pnlInput.Controls.Add(lblMaNguoiDung);
            SetTextBox(txtMaNguoiDung);
            pnlInput.Controls.Add(txtMaNguoiDung);
            y += yOffset;

            SetLabel(lblTenDangNhap, "Tên đăng nhập:");
            pnlInput.Controls.Add(lblTenDangNhap);
            SetTextBox(txtTenDangNhap);
            pnlInput.Controls.Add(txtTenDangNhap);
            y += yOffset;

            SetLabel(lblMatKhau, "Mật khẩu:");
            pnlInput.Controls.Add(lblMatKhau);
            SetTextBox(txtMatKhau);
            pnlInput.Controls.Add(txtMatKhau);
            y += yOffset;

            SetLabel(lblVaiTro, "Vai trò:");
            lblVaiTro.Location = new Point(labelX, y);
            cboVaiTro.Font = new Font("Segoe UI", 12F);
            cboVaiTro.Location = new Point(inputX, y);
            cboVaiTro.Width = width;
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            pnlInput.Controls.Add(lblVaiTro);
            pnlInput.Controls.Add(cboVaiTro);
            y += yOffset;

            // ======= Buttons =======
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

            btnThem.Click += new System.EventHandler(this.btnThem_Click);
            btnSua.Click += new System.EventHandler(this.btnSua_Click);
            btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            pnlInput.Controls.AddRange(new Control[] { lblTimKiem, txtTimKiem, btnTim });

            // ======= Right Panel (DataGridView) =======
            dgvNguoiDung.Dock = DockStyle.Fill;
            dgvNguoiDung.Font = new Font("Segoe UI", 11F);
            dgvNguoiDung.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgvNguoiDung.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvNguoiDung.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 166, 154);
            dgvNguoiDung.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNguoiDung.EnableHeadersVisualStyles = false;
            dgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNguoiDung.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNguoiDung.ReadOnly = true;

            // ======= Add to Layout =======
            tblLayout.Controls.Add(pnlInput, 0, 0);
            tblLayout.Controls.Add(dgvNguoiDung, 1, 0);

            // ======= Add to Form =======
            this.Text = "Quản lý người dùng";
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(tblLayout);
            this.Controls.Add(pnlHeader);
            this.ResumeLayout(false);
        }
    }
}
