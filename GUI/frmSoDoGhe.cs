using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmSoDoGhe : Form
    {
        private List<string> selectedGheList = new List<string>(); // Danh sách ghế được chọn
        private Dictionary<string, Button> gheButtons = new Dictionary<string, Button>();
        private string maLichChieu;
        public List<string> SelectedGheList => selectedGheList; // Thuộc tính trả về danh sách ghế đã chọn

        public frmSoDoGhe(string maLichChieu)
        {
            InitializeComponent();
            this.maLichChieu = maLichChieu;
            LoadSoDoGhe();
        }

        private void LoadSoDoGhe()
        {
            tblGhe.Controls.Clear();
            gheButtons.Clear();
            selectedGheList.Clear();

            var lichChieu = LichChieuBUS.LayTatCa().FirstOrDefault(lc => lc.MaLichChieu == maLichChieu);
            if (lichChieu == null)
            {
                MessageBox.Show("Không tìm thấy lịch chiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var phongChieu = PhongChieuBUS.LayTatCa().FirstOrDefault(pc => pc.MaPhong == lichChieu.MaPhong);
            if (phongChieu == null)
            {
                MessageBox.Show("Không tìm thấy phòng chiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

                    var veList = VeBUS.LayTheoLichChieu(lichChieu.MaLichChieu);
                    if (veList.Any(v => v.SoGhe == soGhe))
                        btnGhe.BackColor = Color.FromArgb(211, 47, 47); // Ghế đã đặt
                    else
                        btnGhe.BackColor = Color.FromArgb(26, 166, 154); // Ghế còn trống

                    btnGhe.Click += (s, e) =>
                    {
                        if (btnGhe.BackColor == Color.FromArgb(211, 47, 47)) return;

                        if (selectedGheList.Contains(soGhe))
                        {
                            selectedGheList.Remove(soGhe);
                            btnGhe.BackColor = Color.FromArgb(26, 166, 154);
                        }
                        else
                        {
                            selectedGheList.Add(soGhe);
                            btnGhe.BackColor = Color.Yellow;
                        }
                    };

                    tblGhe.Controls.Add(btnGhe, j, i);
                    gheButtons[soGhe] = btnGhe;
                }
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (selectedGheList.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK; // Đóng form và trả về kết quả
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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