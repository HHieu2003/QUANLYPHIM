using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmBanDoAn : Form
    {
        private string maNhanVien;
        private string hoTenNhanVien;
        private List<DoAn> doAnList;
        private Dictionary<string, int> selectedDoAnDict = new Dictionary<string, int>(); private decimal tongTienDoAn = 0;
        public frmBanDoAn(string maNhanVien, string hoTenNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
            this.hoTenNhanVien = hoTenNhanVien;
            txtMaNhanVien.Text = maNhanVien;
            txtHoTenNhanVien.Text = hoTenNhanVien;
            LoadData();
            txtHoaDon.Multiline = true;
            txtHoaDon.WordWrap = true;
            txtHoaDon.Font = new Font("Courier New", 10);
            txtHoaDon.ScrollBars = ScrollBars.Vertical;
        }

        private void LoadData()
        {
            doAnList = DoAnBUS.LayTatCa();
            if (doAnList == null || doAnList.Count == 0)
            {
                MessageBox.Show("Không có đồ ăn nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvDoAn.DataSource = doAnList;
            dgvDoAn.Columns["MaDoAn"].Visible = false;
            dgvDoAn.Columns["MoTa"].Visible = false;
            dgvDoAn.Columns["TenDoAn"].HeaderText = "Tên Đồ Ăn";
            dgvDoAn.Columns["Gia"].HeaderText = "Giá (VND)";
            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn
            {
                Name = "SoLuong",
                HeaderText = "Số Lượng",
                DataPropertyName = "SoLuong"
            };
            dgvDoAn.Columns.Add(colSoLuong);

            dgvDoAn.CellValueChanged -= dgvDoAn_CellValueChanged;
            dgvDoAn.CellValueChanged += dgvDoAn_CellValueChanged;

            ResetForm();
        }

        private void ResetForm()
        {
            txtTongTien.Text = "0";
            txtHoaDon.Clear();
            btnThanhToan.Enabled = true;
            btnInHoaDon.Enabled = false;
            tongTienDoAn = 0;
            selectedDoAnDict.Clear();
            foreach (DataGridViewRow row in dgvDoAn.Rows)
            {
                row.Cells["SoLuong"].Value = null;
            }
        }

        private void TinhTongTienDoAn()
        {
            tongTienDoAn = 0;
            selectedDoAnDict.Clear();

            foreach (DataGridViewRow row in dgvDoAn.Rows)
            {
                if (row.Cells["SoLuong"].Value != null && int.TryParse(row.Cells["SoLuong"].Value.ToString(), out int soLuong) && soLuong > 0)
                {
                    string maDoAn = row.Cells["MaDoAn"].Value.ToString();
                    decimal gia = Convert.ToDecimal(row.Cells["Gia"].Value);
                    tongTienDoAn += gia * soLuong;
                    selectedDoAnDict[maDoAn] = soLuong;
                }
            }

            txtTongTien.Text = tongTienDoAn.ToString("N0");
        }

        private void dgvDoAn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDoAn.Columns.Contains("SoLuong") && e.ColumnIndex == dgvDoAn.Columns["SoLuong"].Index)
            {
                TinhTongTienDoAn();
            }
        }

        private string TaoMaXacNhan()
        {
            Random random = new Random();
            string maXacNhan = "XN-" + random.Next(100000, 999999).ToString();
            return maXacNhan;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedDoAnDict.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một món đồ ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          /*  string maKhachHang = "KH" + Guid.NewGuid().ToString().Substring(0, 8);
            KhachHang khachHangMoi = new KhachHang
            {
                MaKhachHang = maKhachHang,
                HoTen = "KhachHangMacDinh",
                SoDienThoai = "0000000000",
                Email = "khachhang@macdinh.com"
            };
            try
            {
                KhachHangBUS.Them(khachHangMoi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khách hàng mặc định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            string maDonHang = Guid.NewGuid().ToString().Substring(0, 10);
            DonHang donHang = new DonHang
            {
                MaDonHang = maDonHang,
                MaKhachHang = maNhanVien,
                NgayTao = DateTime.Now,
                TongTien = tongTienDoAn
            };
            try
            {
                DonHangBUS.Them(donHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var item in selectedDoAnDict)
            {
                var doAn = doAnList.FirstOrDefault(da => da.MaDoAn == item.Key);
                if (doAn != null)
                {
                    ChiTietDoAn chiTiet = new ChiTietDoAn
                    {
                        MaChiTiet = Guid.NewGuid().ToString().Substring(0, 10),
                        MaDonHang = maDonHang,
                        MaDoAn = item.Key,
                        SoLuong = item.Value,
                        Gia = doAn.Gia,
                        ThanhTien = doAn.Gia * item.Value
                    };
                    try
                    {
                        ChiTietDoAnBUS.Them(chiTiet);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm chi tiết đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            try
            {
                string maXacNhan = TaoMaXacNhan();
                GiaoDich giaoDich = new GiaoDich
                {
                    MaGiaoDich = "GD-" + Guid.NewGuid().ToString().Substring(0, 8),
                    MaXacNhan = maXacNhan,
                    MaKhachHang = maNhanVien,
                    MaDonHang = maDonHang,
                    NgayGiaoDich = DateTime.Now,
                    TongTien = tongTienDoAn
                };
                GiaoDichBUS.Them(giaoDich);

                MessageBox.Show($"Thanh toán thành công! Đã tạo đơn hàng.\nMã xác nhận của bạn: {maXacNhan}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiHoaDon(maDonHang, maXacNhan);
                btnThanhToan.Enabled = false;
                btnInHoaDon.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo giao dịch: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiHoaDon(string maDonHang, string maXacNhan)
        {
            string hoaDon = $"----- HÓA ĐƠN BÁN ĐỒ ĂN -----\n\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"Mã xác nhận: {maXacNhan}\n\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"Nhân viên: {hoTenNhanVien} (Mã: {maNhanVien})\n\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"----- CHI TIẾT ĐỒ ĂN -----\n\n{Environment.NewLine}{Environment.NewLine}";

            var chiTietDoAnList = ChiTietDoAnBUS.LayTheoDon(maDonHang);
            if (chiTietDoAnList != null && chiTietDoAnList.Count > 0)
            {
                foreach (var chiTiet in chiTietDoAnList)
                {
                    var doAn = doAnList.FirstOrDefault(da => da.MaDoAn == chiTiet.MaDoAn);
                    if (doAn != null)
                    {
                        hoaDon += $"{doAn.TenDoAn}: {chiTiet.SoLuong} x {chiTiet.Gia:N0} = {chiTiet.ThanhTien:N0} VND\n\n";
                    }
                }
            }

            hoaDon += $"{Environment.NewLine}{Environment.NewLine}Tổng tiền: {tongTienDoAn:N0} VND\n\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"Ngày đặt: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n\n{Environment.NewLine}{Environment.NewLine}";
            hoaDon += $"Cảm ơn quý khách đã sử dụng dịch vụ!\n\n{Environment.NewLine}{Environment.NewLine}";

            txtHoaDon.Text = hoaDon;
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hóa đơn đã được in thành công!\n\n" + txtHoaDon.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackColor = Color.FromArgb(77, 182, 172);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackColor = Color.FromArgb(26, 166, 154);
        }
    }
}