using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmBanDoAn : Form
    {
        private string maKhachHang;
        private List<DoAn> doAnList; // Danh sách đồ ăn
        private Dictionary<string, int> selectedDoAnDict = new Dictionary<string, int>(); // Danh sách đồ ăn được chọn (MaDoAn, SoLuong)
        private decimal tongTien = 0;
        public string MaDonHang { get; private set; }
        public frmBanDoAn(string maKhachHang)
        {
            InitializeComponent();
            this.maKhachHang = maKhachHang;
        }

        private void frmBanDoAn_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Load đồ ăn
            doAnList = DoAnBUS.LayTatCa();
            if (doAnList == null || doAnList.Count == 0)
            {
                MessageBox.Show("Không có đồ ăn nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            dgvDoAn.DataSource = doAnList;
            dgvDoAn.Columns["MaDoAn"].Visible = false;
            dgvDoAn.Columns["MoTa"].Visible = false;
            dgvDoAn.Columns["TenDoAn"].HeaderText = "Tên Đồ Ăn";
            dgvDoAn.Columns["Gia"].HeaderText = "Giá (VND)";

            // Thêm cột số lượng
            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn
            {
                Name = "SoLuong",
                HeaderText = "Số Lượng",
                DataPropertyName = "SoLuong"
            };
            dgvDoAn.Columns.Add(colSoLuong);

            // Đăng ký sự kiện CellValueChanged
            dgvDoAn.CellValueChanged -= dgvDoAn_CellValueChanged;
            dgvDoAn.CellValueChanged += dgvDoAn_CellValueChanged;

            // Reset tổng tiền
            txtTongTien.Text = "0";
        }

        private void TinhTongTien()
        {
            tongTien = 0;
            selectedDoAnDict.Clear();

            foreach (DataGridViewRow row in dgvDoAn.Rows)
            {
                if (row.Cells["SoLuong"].Value != null && int.TryParse(row.Cells["SoLuong"].Value.ToString(), out int soLuong) && soLuong > 0)
                {
                    string maDoAn = row.Cells["MaDoAn"].Value.ToString();
                    decimal gia = Convert.ToDecimal(row.Cells["Gia"].Value);
                    tongTien += gia * soLuong;
                    selectedDoAnDict[maDoAn] = soLuong;
                }
            }

            txtTongTien.Text = tongTien.ToString("N0");
        }

        private void dgvDoAn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDoAn.Columns.Contains("SoLuong") && e.ColumnIndex == dgvDoAn.Columns["SoLuong"].Index)
            {
                TinhTongTien();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (selectedDoAnDict.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một món đồ ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đơn hàng
            string maDonHang = Guid.NewGuid().ToString().Substring(0,10);
            DonHang donHang = new DonHang
            {
                MaDonHang = maDonHang,
                MaKhachHang = maKhachHang,
                NgayTao = DateTime.Now,
                TongTien = tongTien
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

            // Tạo chi tiết đơn hàng
            foreach (var item in selectedDoAnDict)
            {
                var doAn = doAnList.FirstOrDefault(da => da.MaDoAn == item.Key);
                if (doAn != null)
                {
                    ChiTietDoAn chiTiet = new ChiTietDoAn
                    {
                        MaChiTiet = Guid.NewGuid().ToString().Substring(0,10),
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

            MessageBox.Show("Đặt hàng đồ ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}