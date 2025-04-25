using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmVe : Form
    {
        private Dictionary<string, Button> gheButtons = new Dictionary<string, Button>();
        private string selectedGhe = null;

        public frmVe()
        {
            InitializeComponent();
            LoadData();
            CustomizeGridView();
            cboLichChieu.SelectedIndexChanged += CboLichChieu_SelectedIndexChanged;
            cboLoaiVe.SelectedIndexChanged += CboLoaiVe_SelectedIndexChanged;
            dgvVe.SelectionChanged += DgvVe_SelectionChanged;
        }

        private void LoadData()
        {
            // Load danh sách vé
            var veList = VeBUS.LayTatCa();
            dgvVe.DataSource = veList;

            // Load lịch chiếu
            var lichChieuList = LichChieuBUS.LayTatCa();
            cboLichChieu.DataSource = lichChieuList;
            cboLichChieu.DisplayMember = "MaLichChieu";
            cboLichChieu.ValueMember = "MaLichChieu";

            // Load loại vé
            var loaiVeList = LoaiVeBUS.LayTatCa();
            cboLoaiVe.DataSource = loaiVeList;
            cboLoaiVe.DisplayMember = "TenLoaiVe";
            cboLoaiVe.ValueMember = "MaLoaiVe";

            // Load khách hàng
            var khachHangList = KhachHangBUS.LayTatCa();
            cboKhachHang.DataSource = khachHangList;
            cboKhachHang.DisplayMember = "HoTen";
            cboKhachHang.ValueMember = "MaKhachHang";

            // Reset form
            ResetForm();
        }

        private void CustomizeGridView()
        {
            dgvVe.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 166, 154);
            dgvVe.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvVe.EnableHeadersVisualStyles = false;
            dgvVe.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvVe.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
        }

        private void ResetForm()
        {
            txtMaVe.Clear();
            cboLichChieu.SelectedIndex = -1;
            cboLoaiVe.SelectedIndex = -1;
            cboKhachHang.SelectedIndex = -1;
            txtSoGhe.Clear();
            txtGiaVe.Clear();
            txtNgayDat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txtMaVe.Enabled = true;
            selectedGhe = null;
            tblGhe.Controls.Clear();
            gheButtons.Clear();
            dgvVe.ClearSelection();
        }

        private void DgvVe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVe.SelectedRows.Count > 0)
            {
                var row = dgvVe.SelectedRows[0];
                txtMaVe.Text = row.Cells["MaVe"].Value.ToString();
                cboLichChieu.SelectedValue = row.Cells["MaLichChieu"].Value.ToString();
                cboLoaiVe.SelectedValue = row.Cells["MaLoaiVe"].Value.ToString();
                cboKhachHang.SelectedValue = row.Cells["MaKhachHang"].Value.ToString();
                txtSoGhe.Text = row.Cells["SoGhe"].Value.ToString();
                var ngayDat = (DateTime)row.Cells["NgayDat"].Value;
                txtNgayDat.Text = ngayDat == default(DateTime)
                    ? string.Empty
                    : ngayDat.ToString("dd/MM/yyyy HH:mm:ss");
                txtMaVe.Enabled = false;
                LoadSoDoGhe();
                TinhGiaVe();
            }
        }

        private void CboLichChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLichChieu.SelectedValue != null)
            {
                LoadSoDoGhe();
                TinhGiaVe();
            }
        }

        private void CboLoaiVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhGiaVe();
        }

        private void LoadSoDoGhe()
        {
            if (cboLichChieu.SelectedValue == null) return;

            tblGhe.Controls.Clear();
            gheButtons.Clear();

            // Lấy thông tin phòng chiếu từ lịch chiếu
            var lichChieu = LichChieuBUS.LayTatCa().FirstOrDefault(lc => lc.MaLichChieu == cboLichChieu.SelectedValue.ToString());
            if (lichChieu == null) return;

            var phongChieu = PhongChieuBUS.LayTatCa().FirstOrDefault(pc => pc.MaPhong == lichChieu.MaPhong);
            if (phongChieu == null) return;

            int soLuongGhe = phongChieu.SoLuongGhe;
            int soHang = (int)Math.Ceiling(Math.Sqrt(soLuongGhe));
            int soCot = (int)Math.Ceiling((double)soLuongGhe / soHang);

            tblGhe.RowCount = soHang;
            tblGhe.ColumnCount = soCot;
            for (int i = 0; i < soHang; i++)
            {
                tblGhe.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / soHang));
                for (int j = 0; j < soCot; j++)
                {
                    if (i * soCot + j >= soLuongGhe) break;
                    if (i == 0) tblGhe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / soCot));

                    string soGhe = $"{(char)('A' + i)}{j + 1}";
                    Button btnGhe = new Button
                    {
                        Text = soGhe,
                        Size = new Size(50, 50),
                        Font = new Font("Segoe UI", 10F),
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 1 }
                    };

                    // Kiểm tra trạng thái ghế
                    var veList = VeBUS.LayTheoLichChieu(lichChieu.MaLichChieu);
                    if (veList.Any(v => v.SoGhe == soGhe))
                        btnGhe.BackColor = Color.FromArgb(211, 47, 47); // Đã đặt
                    else
                        btnGhe.BackColor = Color.FromArgb(26, 166, 154); // Chưa đặt

                    btnGhe.Click += (s, e) =>
                    {
                        if (btnGhe.BackColor == Color.FromArgb(211, 47, 47)) return; // Ghế đã đặt
                        if (selectedGhe != null && gheButtons.ContainsKey(selectedGhe))
                            gheButtons[selectedGhe].BackColor = Color.FromArgb(26, 166, 154); // Reset ghế cũ
                        selectedGhe = soGhe;
                        btnGhe.BackColor = Color.Yellow; // Ghế đang chọn
                        txtSoGhe.Text = soGhe;
                    };

                    tblGhe.Controls.Add(btnGhe, j, i);
                    gheButtons[soGhe] = btnGhe;
                }
            }
        }

        private void TinhGiaVe()
        {
            if (cboLichChieu.SelectedValue == null || cboLoaiVe.SelectedValue == null) return;

            decimal giaVe = VeBUS.TinhGiaVe(cboLichChieu.SelectedValue.ToString(), cboLoaiVe.SelectedValue.ToString());
            txtGiaVe.Text = giaVe.ToString("N0");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Ve ve = new Ve
            {
                MaVe = txtMaVe.Text.Trim(),
                MaLichChieu = cboLichChieu.SelectedValue.ToString(),
                MaLoaiVe = cboLoaiVe.SelectedValue.ToString(),
                MaKhachHang = cboKhachHang.SelectedValue.ToString(),
                SoGhe = txtSoGhe.Text,
                NgayDat = DateTime.ParseExact(txtNgayDat.Text, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
            };

            try
            {
                VeBUS.Them(ve);
                MessageBox.Show("Thêm vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvVe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maVe = txtMaVe.Text.Trim();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa vé {maVe}?", "Xác nhận",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    VeBUS.Xoa(maVe);
                    MessageBox.Show("Xóa vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            var veList = VeBUS.LayTatCa();
            var displayList = veList
                .Where(v => v.MaVe.ToLower().Contains(tuKhoa) ||
                            v.MaLichChieu.ToLower().Contains(tuKhoa) ||
                            v.SoGhe.ToLower().Contains(tuKhoa))
                .ToList();
            dgvVe.DataSource = displayList;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtMaVe.Text.Trim()))
            {
                MessageBox.Show("Mã vé không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboLichChieu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn lịch chiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboLoaiVe.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại vé!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboKhachHang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtSoGhe.Text))
            {
                MessageBox.Show("Vui lòng chọn ghế!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtNgayDat.Text))
            {
                MessageBox.Show("Ngày đặt không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackColor = Color.FromArgb(77, 182, 172); // Sáng hơn khi hover
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn == btnXoa)
                btn.BackColor = Color.FromArgb(211, 47, 47);
            else if (btn == btnLamMoi || btn == btnHuy)
                btn.BackColor = Color.FromArgb(120, 120, 120);
            else
                btn.BackColor = Color.FromArgb(26, 166, 154);
        }
    }
}