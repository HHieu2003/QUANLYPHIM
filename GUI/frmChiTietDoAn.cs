using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace GUI
{
    public partial class frmChiTietDoAn : Form
    {
        public frmChiTietDoAn()
        {
            InitializeComponent();
            TaiLai();
            LoadComboBoxMaDoAn();
        }

        private void TaiLai()
        {
            try
            {
                var ds = ChiTietDoAnBUS.LayTatCa();
                dgvChiTietDoAn.DataSource = ds.Select(c => new
                {
                    c.MaChiTiet,
                    c.MaDonHang,
                    c.MaDoAn,
                    c.SoLuong,
                    c.Gia,
                    c.ThanhTien
                }).ToList();
                txtTimKiem.Clear();
                dtpTuNgay.Value = DateTime.Now.AddDays(-30); // Default to last 30 days
                dtpDenNgay.Value = DateTime.Now;
                cboMaDoAn.SelectedIndex = -1;
                dgvChiTietDoAn.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải chi tiết đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxMaDoAn()
        {
            try
            {
                var doAnList = DoAnBUS.LayTatCa(); // Assuming DoAnBUS exists to fetch food items
                cboMaDoAn.DataSource = doAnList;
                cboMaDoAn.DisplayMember = "MaDoAn";
                cboMaDoAn.ValueMember = "MaDoAn";
                cboMaDoAn.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách đồ ăn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TaiLai();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTietDoAn.SelectedRows.Count > 0)
            {
                var maChiTiet = dgvChiTietDoAn.SelectedRows[0].Cells["MaChiTiet"].Value.ToString();
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa chi tiết {maChiTiet}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        ChiTietDoAnBUS.Xoa(maChiTiet);
                        TaiLai();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi xóa chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chi tiết để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                var tuKhoa = txtTimKiem.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    var ds = ChiTietDoAnBUS.LayTatCa();
                    var filtered = ds.Where(c =>
                        c.MaChiTiet.ToLower().Contains(tuKhoa) ||
                        c.MaDoAn.ToLower().Contains(tuKhoa))
                        .Select(c => new
                        {
                            c.MaChiTiet,
                            c.MaDonHang,
                            c.MaDoAn,
                            c.SoLuong,
                            c.Gia,
                            c.ThanhTien
                        }).ToList();
                    dgvChiTietDoAn.DataSource = filtered;
                    if (filtered.Count == 0)
                        MessageBox.Show("Không tìm thấy chi tiết đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    TaiLai();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocThoiGian_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1); // End of the day
                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var donHangList = DonHangBUS.LayTatCa()
                    .Where(dh => dh.NgayTao >= tuNgay && dh.NgayTao <= denNgay)
                    .ToList();
                var maDonHangList = donHangList.Select(dh => dh.MaDonHang).ToList();
                var chiTietList = ChiTietDoAnBUS.LayTatCa()
                    .Where(ct => maDonHangList.Contains(ct.MaDonHang))
                    .Select(c => new
                    {
                        c.MaChiTiet,
                        c.MaDonHang,
                        c.MaDoAn,
                        c.SoLuong,
                        c.Gia,
                        c.ThanhTien
                    }).ToList();
                dgvChiTietDoAn.DataSource = chiTietList;

                if (chiTietList.Count == 0)
                    MessageBox.Show("Không tìm thấy chi tiết đơn hàng trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lọc thời gian: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocMaDoAn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMaDoAn.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn món ăn để lọc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maDoAn = cboMaDoAn.SelectedValue.ToString();
                var chiTietList = ChiTietDoAnBUS.LayTatCa()
                    .Where(ct => ct.MaDoAn == maDoAn)
                    .Select(c => new
                    {
                        c.MaChiTiet,
                        c.MaDonHang,
                        c.MaDoAn,
                        c.SoLuong,
                        c.Gia,
                        c.ThanhTien
                    }).ToList();
                dgvChiTietDoAn.DataSource = chiTietList;

                if (chiTietList.Count == 0)
                    MessageBox.Show("Không tìm thấy chi tiết đơn hàng cho món ăn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lọc món ăn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInPDF_Click(object sender, EventArgs e)
        {
            if (dgvChiTietDoAn.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                Title = "Lưu Báo Cáo Chi Tiết Đơn Hàng",
                FileName = $"ChiTietDoAn_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.Yes)
            {
                try
                {
                    Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Add title
                    Font titleFont = FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD);
                    Paragraph title = new Paragraph("BÁO CÁO CHI TIẾT ĐƠN HÀNG ĐỒ ĂN", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20
                    };
                    document.Add(title);

                    // Add date range if filtered
                    if (dtpTuNgay.Value != DateTime.Now.AddDays(-30) || dtpDenNgay.Value != DateTime.Now)
                    {
                        Font filterFont = FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD);
                        Paragraph filterInfo = new Paragraph(
                            $"Từ ngày: {dtpTuNgay.Value:dd/MM/yyyy} - Đến ngày: {dtpDenNgay.Value:dd/MM/yyyy}",
                            filterFont
                        )
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 10
                        };
                        document.Add(filterInfo);
                    }

                    // Add food item filter if applied
                    if (cboMaDoAn.SelectedIndex != -1)
                    {
                        Font filterFont = FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD);
                        Paragraph maDoAnInfo = new Paragraph(
                            $"Món ăn: {cboMaDoAn.SelectedValue}",
                            filterFont
                        )
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 20
                        };
                        document.Add(maDoAnInfo);
                    }

                    // Create table
                    PdfPTable table = new PdfPTable(dgvChiTietDoAn.Columns.Count)
                    {
                        WidthPercentage = 100,
                        SpacingBefore = 10f,
                        SpacingAfter = 10f
                    };

                    // Set column widths
                    float[] widths = new float[dgvChiTietDoAn.Columns.Count];
                    for (int i = 0; i < dgvChiTietDoAn.Columns.Count; i++)
                        widths[i] = 1f;
                    table.SetWidths(widths);

                    // Add headers
                    Font headerFont = FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD  );
                    BaseColor headerColor = new BaseColor(26, 166, 154);
                    foreach (DataGridViewColumn column in dgvChiTietDoAn.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont))
                        {
                            BackgroundColor = headerColor,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 5
                        };
                        table.AddCell(cell);
                    }

                    // Add rows
                    Font cellFont = FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD);
                    foreach (DataGridViewRow row in dgvChiTietDoAn.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string cellValue = cell.Value?.ToString() ?? "";
                            PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue, cellFont))
                            {
                                HorizontalAlignment = Element.ALIGN_LEFT,
                                Padding = 5
                            };
                            table.AddCell(pdfCell);
                        }
                    }

                    document.Add(table);

                    // Add footer with generation date
                    Font footerFont = FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD);
                    Paragraph footer = new Paragraph($"Báo cáo được tạo vào: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", footerFont)
                    {
                        Alignment = Element.ALIGN_RIGHT,
                        SpacingBefore = 20
                    };
                    document.Add(footer);

                    document.Close();
                    MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}