using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmLichSuMuaVe : Form
    {
        private string maKhachHang;
        public frmLichSuMuaVe(string maKhachHang)
        {
            this.maKhachHang = maKhachHang;
            InitializeComponent();
            LoadData();
         
        }


        private void LoadData()
        {
            // Xóa các cột hiện tại (nếu có)
            dgvLichSuMuaVe.Columns.Clear();

            // Thêm các cột
            dgvLichSuMuaVe.Columns.AddRange(new DataGridViewColumn[]
            {
            new DataGridViewTextBoxColumn { HeaderText = "Tên Phim", Name = "TenPhim", FillWeight = 150 },
            new DataGridViewTextBoxColumn { HeaderText = "Giờ Chiếu", Name = "GioChieu", FillWeight = 120 },
            new DataGridViewTextBoxColumn { HeaderText = "Số Ghế", Name = "SoGhe", FillWeight = 80 },
            new DataGridViewTextBoxColumn { HeaderText = "Loại Vé", Name = "LoaiVe", FillWeight = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "Ngày Đặt", Name = "NgayDat", FillWeight = 120 },
            new DataGridViewTextBoxColumn { HeaderText = "Mã Giao Dịch", Name = "MaGiaoDich", FillWeight = 150 }
            });

            // Định dạng cột "Ngày Đặt" để chỉ hiển thị ngày
            dgvLichSuMuaVe.Columns["NgayDat"].DefaultCellStyle.Format = "dd/MM/yyyy"; 
            // Thêm các cột vào DataGridView
            dgvLichSuMuaVe.Columns.Clear();
            dgvLichSuMuaVe.Columns.Add("TenPhim", "Tên Phim");
            dgvLichSuMuaVe.Columns.Add("GioChieu", "Giờ Chiếu");
            dgvLichSuMuaVe.Columns.Add("SoGhe", "Số Ghế");
            dgvLichSuMuaVe.Columns.Add("LoaiVe", "Loại Vé");
            dgvLichSuMuaVe.Columns.Add("NgayDat", "Ngày Đặt");
            dgvLichSuMuaVe.Columns.Add("MaGiaoDich", "Mã Giao Dịch");

            // Đảm bảo cột MaGiaoDich hiển thị
            dgvLichSuMuaVe.Columns["MaGiaoDich"].Visible = true;

            // Lấy danh sách vé và hiển thị
            var veList = VeBUS.LayTatCa().Where(v => v.MaKhachHang == maKhachHang).ToList();
            dgvLichSuMuaVe.Rows.Clear();

            foreach (var ve in veList)
            {
                var lichChieu = LichChieuBUS.LayTatCa().FirstOrDefault(lc => lc.MaLichChieu == ve.MaLichChieu);
                var phim = lichChieu != null ? PhimBUS.LayTatCa().FirstOrDefault(p => p.MaPhim == lichChieu.MaPhim) : null;
                var loaiVe = LoaiVeBUS.LayTatCa().FirstOrDefault(lv => lv.MaLoaiVe == ve.MaLoaiVe);

                // Kiểm tra giá trị MaGiaoDich
                string maGiaoDich = ve.MaGiaoDich ?? "N/A";

                dgvLichSuMuaVe.Rows.Add(
                    phim?.TenPhim ?? "N/A",
                    lichChieu?.GioBatDau.ToString("dd/MM/yyyy HH:mm") ?? "N/A",
                    ve.SoGhe,
                    loaiVe?.TenLoaiVe ?? "N/A",
                    ve.NgayDat.ToString("dd/MM/yyyy HH:mm"),
                    maGiaoDich
                );
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}