using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmLichChieu : Form
    {
        public frmLichChieu()
        {
            InitializeComponent();
            LoadData();
            CustomizeGridView();
            dgvLichChieu.SelectionChanged += DgvLichChieu_SelectionChanged;
        }

        private void LoadData()
        {
            // Load danh sách lịch chiếu
            var lichChieuList = LichChieuBUS.LayTatCa();
            var phimList = PhimBUS.LayTatCa();
            var phongList = PhongChieuBUS.LayTatCa();
            var displayList = lichChieuList.Select(lc => new
            {
                lc.MaLichChieu,
                TenPhim = phimList.FirstOrDefault(p => p.MaPhim == lc.MaPhim)?.TenPhim,
                TenPhong = phongList.FirstOrDefault(p => p.MaPhong == lc.MaPhong)?.TenPhong,
                lc.GioBatDau,
                lc.GiaVe
            }).ToList();
            dgvLichChieu.DataSource = displayList;

            // Load danh sách phim vào ComboBox
            cboPhim.DataSource = phimList;
            cboPhim.DisplayMember = "TenPhim";
            cboPhim.ValueMember = "MaPhim";

            // Load danh sách phòng chiếu có trạng thái "hoatdong" vào ComboBox
            var phongHoatDongList = phongList.Where(p => p.TrangThai == "hoatdong").ToList();
            cboPhong.DataSource = phongHoatDongList;
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
            // Reset form
            ResetForm();
        }

        private void CustomizeGridView()
        {
            dgvLichChieu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 166, 154);
            dgvLichChieu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLichChieu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvLichChieu.EnableHeadersVisualStyles = false;
            dgvLichChieu.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvLichChieu.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
        }

        private void ResetForm()
        {
            txtMaLichChieu.Clear();
            txtTimKiem.Clear();
            txtGiaVe.Clear();
            cboPhim.SelectedIndex = -1;
            cboPhong.SelectedIndex = -1;
            dtpGioBatDau.Value = DateTime.Now;
            txtMaLichChieu.Enabled = true;
            dgvLichChieu.ClearSelection();
        }

        private void DgvLichChieu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLichChieu.SelectedRows.Count > 0)
            {
                var row = dgvLichChieu.SelectedRows[0];
                txtMaLichChieu.Text = row.Cells["MaLichChieu"].Value.ToString();
                // Handle potential null value for TenPhim
                var tenPhim = row.Cells["TenPhim"].Value?.ToString();
                if (!string.IsNullOrEmpty(tenPhim))
                {
                    cboPhim.SelectedValue = PhimBUS.LayTatCa().FirstOrDefault(p => p.TenPhim == tenPhim)?.MaPhim;
                }
                else
                {
                    cboPhim.SelectedIndex = -1; // Reset ComboBox if no matching movie
                }

                // Handle potential null value for TenPhong
                var tenPhong = row.Cells["TenPhong"].Value?.ToString();
                if (!string.IsNullOrEmpty(tenPhong))
                {
                    cboPhong.SelectedValue = PhongChieuBUS.LayTatCa().FirstOrDefault(p => p.TenPhong == tenPhong)?.MaPhong;
                }
                else
                {
                    cboPhong.SelectedIndex = -1; // Reset ComboBox if no matching room
                }
                dtpGioBatDau.Value = (DateTime)row.Cells["GioBatDau"].Value;
                txtGiaVe.Text = row.Cells["GiaVe"].Value.ToString();
                txtMaLichChieu.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            LichChieu lichChieu = new LichChieu
            {
                MaLichChieu = txtMaLichChieu.Text.Trim(),
                MaPhim = cboPhim.SelectedValue.ToString(),
                MaPhong = cboPhong.SelectedValue.ToString(),
                GioBatDau = dtpGioBatDau.Value,
                GiaVe = decimal.Parse(txtGiaVe.Text.Trim())
            };

            try
            {
                // Kiểm tra trùng lịch chiếu
                if (LichChieuBUS.KiemTraTrungLich(lichChieu))
                    throw new Exception("Phòng chiếu đã có lịch chiếu trong khoảng thời gian này!");

                LichChieuBUS.Them(lichChieu);
                MessageBox.Show("Thêm lịch chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            LichChieu lichChieu = new LichChieu
            {
                MaLichChieu = txtMaLichChieu.Text.Trim(),
                MaPhim = cboPhim.SelectedValue.ToString(),
                MaPhong = cboPhong.SelectedValue.ToString(),
                GioBatDau = dtpGioBatDau.Value,
                GiaVe = decimal.Parse(txtGiaVe.Text.Trim())
            };

            try
            {
                // Kiểm tra trùng lịch chiếu (trừ lịch hiện tại)
                if (LichChieuBUS.KiemTraTrungLich(lichChieu, lichChieu.MaLichChieu))
                    throw new Exception("Phòng chiếu đã có lịch chiếu trong khoảng thời gian này!");

                LichChieuBUS.CapNhat(lichChieu);
                MessageBox.Show("Cập nhật lịch chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLichChieu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch chiếu để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maLichChieu = txtMaLichChieu.Text.Trim();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa lịch chiếu {maLichChieu}?", "Xác nhận",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    LichChieuBUS.Xoa(maLichChieu);
                    MessageBox.Show("Xóa lịch chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var lichChieuList = LichChieuBUS.LayTatCa();
            var phimList = PhimBUS.LayTatCa();
            var phongList = PhongChieuBUS.LayTatCa();
            var displayList = lichChieuList
                .Where(lc => phimList.Any(p => p.MaPhim == lc.MaPhim && p.TenPhim.ToLower().Contains(tuKhoa)) ||
                             phongList.Any(p => p.MaPhong == lc.MaPhong && p.TenPhong.ToLower().Contains(tuKhoa)) ||
                             lc.GioBatDau.ToString("dd/MM/yyyy HH:mm").Contains(tuKhoa) ||
                             lc.GiaVe.ToString().Contains(tuKhoa))
                .Select(lc => new
                {
                    lc.MaLichChieu,
                    TenPhim = phimList.FirstOrDefault(p => p.MaPhim == lc.MaPhim)?.TenPhim,
                    TenPhong = phongList.FirstOrDefault(p => p.MaPhong == lc.MaPhong)?.TenPhong,
                    lc.GioBatDau,
                    lc.GiaVe
                }).ToList();
            dgvLichChieu.DataSource = displayList;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtMaLichChieu.Text.Trim()))
            {
                MessageBox.Show("Mã lịch chiếu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboPhim.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phim!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng chiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtpGioBatDau.Value < DateTime.Now)
            {
                MessageBox.Show("Thời gian bắt đầu phải từ hiện tại trở đi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtGiaVe.Text.Trim(), out decimal giaVe) || giaVe <= 0)
            {
                MessageBox.Show("Giá vé phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
         
            else
                btn.BackColor = Color.FromArgb(26, 166, 154);
        }
    }
}