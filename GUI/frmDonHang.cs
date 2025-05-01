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
    public partial class frmDonHang : Form
    {
        public frmDonHang()
        {
            InitializeComponent();
            TaiLai();
            LoadComboBoxNguoiTao();
        }

        private void TaiLai()
        {
            try
            {
                dgvDonHang.DataSource = DonHangBUS.LayTatCa();
                txtTimKiem.Clear();
                dtpTuNgay.Value = DateTime.Now.AddDays(-30); // Default to last 30 days
                dtpDenNgay.Value = DateTime.Now;
                cboNguoiTao.SelectedIndex = -1;
                dgvDonHang.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxNguoiTao()
        {
            try
            {
                var khachHangList = KhachHangBUS.LayTatCa();
                cboNguoiTao.DataSource = khachHangList;
                cboNguoiTao.DisplayMember = "MaKhachHang";
                cboNguoiTao.ValueMember = "MaKhachHang";
                cboNguoiTao.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TaiLai();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count > 0)
            {
                var ma = dgvDonHang.SelectedRows[0].Cells["MaDonHang"].Value.ToString();
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa đơn hàng {ma}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        DonHangBUS.Xoa(ma);
                        TaiLai();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi xóa đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtTimKiem.Text.Trim();
                if (!string.IsNullOrEmpty(ma))
                {
                    var dh = DonHangBUS.LayTheoMa(ma);
                    if (dh != null)
                    {
                        List<DonHang> list = new List<DonHang> { dh };
                        dgvDonHang.DataSource = list;
                    }
                    else
                        MessageBox.Show("Không tìm thấy đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dgvDonHang.DataSource = donHangList;

                if (donHangList.Count == 0)
                    MessageBox.Show("Không tìm thấy đơn hàng trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lọc thời gian: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocNguoiTao_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboNguoiTao.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để lọc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maKhachHang = cboNguoiTao.SelectedValue.ToString();
                var donHangList = DonHangBUS.LayTatCa()
                    .Where(dh => dh.MaKhachHang == maKhachHang)
                    .ToList();
                dgvDonHang.DataSource = donHangList;

                if (donHangList.Count == 0)
                    MessageBox.Show("Không tìm thấy đơn hàng của khách hàng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lọc khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInPDF_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                Title = "Lưu Báo Cáo Đơn Hàng",
                FileName = $"DonHang_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Add title
                    Font titleFont = FontFactory.GetFont("Helvetica", 12f, iTextSharp.text.Font.BOLD);
                    Paragraph title = new Paragraph("BÁO CÁO ĐƠN HÀNG", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20
                    };
                    document.Add(title);

                    // Add date range if filtered
                    if (dtpTuNgay.Value != DateTime.Now.AddDays(-30) || dtpDenNgay.Value != DateTime.Now)
                    {
                        Font filterFont = FontFactory.GetFont("Helvetica", 12f, iTextSharp.text.Font.NORMAL);
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

                    // Add customer filter if applied
                    if (cboNguoiTao.SelectedIndex != -1)
                    {
                        Font filterFont = FontFactory.GetFont("Helvetica", 12f, iTextSharp.text.Font.NORMAL);
                        Paragraph customerInfo = new Paragraph(
                            $"Khách hàng: {cboNguoiTao.SelectedValue}",
                            filterFont
                        )
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 20
                        };
                        document.Add(customerInfo);
                    }

                    // Create table
                    PdfPTable table = new PdfPTable(dgvDonHang.Columns.Count)
                    {
                        WidthPercentage = 100,
                        SpacingBefore = 10f,
                        SpacingAfter = 10f
                    };

                    // Set column widths
                    float[] widths = new float[dgvDonHang.Columns.Count];
                    for (int i = 0; i < dgvDonHang.Columns.Count; i++)
                        widths[i] = 1f;
                    table.SetWidths(widths);

                    // Add headers
                    Font headerFont = FontFactory.GetFont("Helvetica", 12f, iTextSharp.text.Font.BOLD);
                    BaseColor headerColor = new BaseColor(26, 166, 154);
                    foreach (DataGridViewColumn column in dgvDonHang.Columns)
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
                    Font cellFont = FontFactory.GetFont("Helvetica", 12f, iTextSharp.text.Font.NORMAL);
                    foreach (DataGridViewRow row in dgvDonHang.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string cellValue = cell.Value?.ToString() ?? "";
                            if (cell.OwningColumn.Name == "NgayTao" && DateTime.TryParse(cellValue, out DateTime date))
                                cellValue = date.ToString("dd/MM/yyyy HH:mm:ss");

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
                    Font footerFont = FontFactory.GetFont("Helvetica", 12f, iTextSharp.text.Font.ITALIC);
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