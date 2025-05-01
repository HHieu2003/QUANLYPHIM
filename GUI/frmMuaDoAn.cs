using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;
using iTextSharp.text;

namespace GUI
{
    public partial class frmMuaDoAn : Form
    {
        private string maKhachHang; private string hoTenKhachHang;
        private List<DoAn> doAnList; private Dictionary<string, int> selectedDoAnDict = new Dictionary<string, int>(); private decimal tongTienDoAn = 0; private string maDonHang;
        public Dictionary<string, int> SelectedDoAnDict => selectedDoAnDict;
        public decimal TongTienDoAn => tongTienDoAn;
        public string MaDonHang => maDonHang;

        public frmMuaDoAn(string maKhachHang, string hoTenKhachHang)
        {
            this.maKhachHang = maKhachHang;
            this.hoTenKhachHang = hoTenKhachHang;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            txtHoTen.Text = hoTenKhachHang;
            doAnList = DoAnBUS.LayTatCa();
            if (doAnList == null || doAnList.Count == 0)
            {
                MessageBox.Show("Không có đồ ăn nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
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

            dgvDoAn.CellValueChanged += new DataGridViewCellEventHandler(dgvDoAn_CellValueChanged);
            TinhTongTien();
        }

        private void dgvDoAn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDoAn.Columns.Contains("SoLuong") && e.ColumnIndex == dgvDoAn.Columns["SoLuong"].Index)
            {
                TinhTongTien();
            }
        }

        private void TinhTongTien()
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

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (selectedDoAnDict.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một món đồ ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            maDonHang = Guid.NewGuid().ToString().Substring(0, 10);
            DonHang donHang = new DonHang
            {
                MaDonHang = maDonHang,
                MaKhachHang = maKhachHang,
                NgayTao = DateTime.Now,
                TongTien = tongTienDoAn
            };

            try
            {
                DonHangBUS.Them(donHang);
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
                        ChiTietDoAnBUS.Them(chiTiet);
                    }
                }
                MessageBox.Show("Đã xác nhận đơn hàng đồ ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}