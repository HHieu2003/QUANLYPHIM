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
        private string maLichChieu;
        private List<string> selectedGheList = new List<string>(); // Danh sách ghế được chọn
        private List<string> bookedGheList = new List<string>(); // Danh sách ghế đã đặt trước
        private Dictionary<string, Button> gheButtons = new Dictionary<string, Button>(); // Lưu các nút ghế

        public List<string> SelectedGheList
        {
            get { return selectedGheList; }
        }

        public frmSoDoGhe(string maLichChieu)
        {
            InitializeComponent();
            this.maLichChieu = maLichChieu;
        }

        private void frmSoDoGhe_Load(object sender, EventArgs e)
        {
            LoadGheDaDat();
            TaoSoDoGhe();
        }

        private void LoadGheDaDat()
        {
            // Lấy danh sách ghế đã đặt trước từ bảng Ve dựa trên MaLichChieu
            var veList = VeBUS.LayTatCa().Where(v => v.MaLichChieu == maLichChieu).ToList();
            bookedGheList = veList.Select(v => v.SoGhe).ToList();
        }

        private void TaoSoDoGhe()
        {
            // Tạo sơ đồ ghế: 10 hàng (A-J), 10 cột (1-10)
            string[] hang = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            int buttonSize = 40; // Kích thước nút ghế
            int spacing = 5; // Khoảng cách giữa các nút

            // Tạo ghế cho cột bên trái (cột 1-2)
            for (int row = 0; row < hang.Length; row++)
            {
                for (int col = 0; col < 2; col++) // Cột 1-2
                {
                    string soGhe = $"{hang[row]}{col + 1}";
                    Button btnGhe = new Button
                    {
                        Text = soGhe,
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(col * (buttonSize + spacing), row * (buttonSize + spacing)),
                        FlatStyle = FlatStyle.Flat,
                        Tag = soGhe // Lưu số ghế vào Tag
                    };

                    // Thiết lập màu sắc
                    if (bookedGheList.Contains(soGhe))
                    {
                        btnGhe.BackColor = Color.Red; // Ghế đã đặt
                        btnGhe.Enabled = false; // Không cho phép chọn
                    }
                    else
                    {
                        btnGhe.BackColor = Color.Teal; // Ghế trống
                        btnGhe.Click += BtnGhe_Click; // Đăng ký sự kiện click
                    }

                    panelLeft.Controls.Add(btnGhe);
                    gheButtons[soGhe] = btnGhe;
                }
            }

            // Tạo ghế cho cột ở giữa (cột 3-8)
            for (int row = 0; row < hang.Length; row++)
            {
                for (int col = 2; col < 8; col++) // Cột 3-8
                {
                    string soGhe = $"{hang[row]}{col + 1}";
                    Button btnGhe = new Button
                    {
                        Text = soGhe,
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point((col - 2) * (buttonSize + spacing), row * (buttonSize + spacing)),
                        FlatStyle = FlatStyle.Flat,
                        Tag = soGhe // Lưu số ghế vào Tag
                    };

                    // Thiết lập màu sắc
                    if (bookedGheList.Contains(soGhe))
                    {
                        btnGhe.BackColor = Color.Red; // Ghế đã đặt
                        btnGhe.Enabled = false; // Không cho phép chọn
                    }
                    else
                    {
                        btnGhe.BackColor = Color.Teal; // Ghế trống
                        btnGhe.Click += BtnGhe_Click; // Đăng ký sự kiện click
                    }

                    panelCenter.Controls.Add(btnGhe);
                    gheButtons[soGhe] = btnGhe;
                }
            }

            // Tạo ghế cho cột bên phải (cột 9-10)
            for (int row = 0; row < hang.Length; row++)
            {
                for (int col = 8; col < 10; col++) // Cột 9-10
                {
                    string soGhe = $"{hang[row]}{col + 1}";
                    Button btnGhe = new Button
                    {
                        Text = soGhe,
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point((col - 8) * (buttonSize + spacing), row * (buttonSize + spacing)),
                        FlatStyle = FlatStyle.Flat,
                        Tag = soGhe // Lưu số ghế vào Tag
                    };

                    // Thiết lập màu sắc
                    if (bookedGheList.Contains(soGhe))
                    {
                        btnGhe.BackColor = Color.Red; // Ghế đã đặt
                        btnGhe.Enabled = false; // Không cho phép chọn
                    }
                    else
                    {
                        btnGhe.BackColor = Color.Teal; // Ghế trống
                        btnGhe.Click += BtnGhe_Click; // Đăng ký sự kiện click
                    }

                    panelRight.Controls.Add(btnGhe);
                    gheButtons[soGhe] = btnGhe;
                }
            }
        }

        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string soGhe = btn.Tag.ToString();

            if (selectedGheList.Contains(soGhe))
            {
                // Nếu ghế đã được chọn, hủy chọn
                selectedGheList.Remove(soGhe);
                btn.BackColor = Color.Teal; // Trả lại màu ghế trống
            }
            else
            {
                // Chọn ghế
                selectedGheList.Add(soGhe);
                btn.BackColor = Color.Yellow; // Tô màu vàng để biểu thị ghế đang được chọn
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (selectedGheList.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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