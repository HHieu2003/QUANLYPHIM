using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BUS;
using DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GUI
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
            TaiLaiBaoCao();
        }

        private void TaiLaiBaoCao()
        {
            try
            {
                var danhSach = BaoCaoBUS.LayTatCa();
                dgvBaoCao.DataSource = danhSach;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TaiLaiBaoCao();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.SelectedRows.Count > 0)
            {
                var ma = dgvBaoCao.SelectedRows[0].Cells["MaBaoCao"].Value.ToString();
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa báo cáo này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        BaoCaoBUS.Xoa(ma);
                        TaiLaiBaoCao();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
        }

        private void btnInPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = "BaoCao.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        // Tiêu đề
                        var titleFont = FontFactory.GetFont("Helvetica", 18f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        var title = new Paragraph("BÁO CÁO TỔNG HỢP", titleFont)
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 20f
                        };
                        doc.Add(title);

                        // Bảng dữ liệu
                        PdfPTable table = new PdfPTable(dgvBaoCao.Columns.Count)
                        {
                            WidthPercentage = 100
                        };

                        // Header
                        var headerFont = FontFactory.GetFont("Helvetica", 12f, iTextSharp.text.Font.BOLD);
                        foreach (DataGridViewColumn column in dgvBaoCao.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                            cell.BackgroundColor = new BaseColor(230, 230, 230);
                            table.AddCell(cell);
                        }

                        // Data rows
                        foreach (DataGridViewRow row in dgvBaoCao.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    table.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
                                }
                            }
                        }

                        doc.Add(table);
                        doc.Close();
                    }

                    MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message);
            }
        }
    }
}
