using Nhom12_dhti5a14hn.Controller;
using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    public partial class Form6 : Form
    {
        private BaoCao bc = new BaoCao();

        public Form6()
        {
            InitializeComponent();
            display.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            display_baocao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void thongke_Click(object sender, EventArgs e)
        {
            display_baocao.DataSource = bc.GetAllnow();
        }

        private void btn_tkall_Click(object sender, EventArgs e)
        {
            display_baocao.DataSource = bc.GetAllBill();
        }

        private void tuoctn_Click(object sender, EventArgs e)
        {
            try
            {
                display.DataSource = bc.tkthuocnow();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị báo cáo: " + ex.Message);
            }
        }

        private void thuocall_Click(object sender, EventArgs e)
        {
            try
            {
                display.DataSource = bc.GetAllThuoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị báo cáo: " + ex.Message);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            frm_Main fm = new frm_Main();
            fm.Show();
            this.Close();
        }

        private void display_baocao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void xuathoadon_Click(object sender, EventArgs e)
        {
            DataTable Donhantoday = bc.GetAllBill();
            DataTable thuocyoday = bc.GetAllThuoc();

            try
            {
                if (Donhantoday == null || Donhantoday.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu đơn hàng trong ngày để xuất.");
                    return;
                }

                if (thuocyoday == null || thuocyoday.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu thuốc bán trong ngày để xuất.");
                    return;
                }

                using (var package = new OfficeOpenXml.ExcelPackage())
                {
                    var worksheet1 = package.Workbook.Worksheets.Add("Tất Cả Đơn Hàng");
                    worksheet1.Cells["A1"].Value = "Báo Cáo Đơn Hàng";
                    worksheet1.Cells["A1"].Style.Font.Bold = true;

                    worksheet1.Cells["A4"].LoadFromDataTable(Donhantoday, true);
                    worksheet1.Cells[worksheet1.Dimension.Address].AutoFitColumns();

                    using (var range = worksheet1.Cells["A4:D4"])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }
                    var cellB4 = worksheet1.Cells["B5:B50"];
                    cellB4.Style.Numberformat.Format = "dd/MM/yyyy";
                    // Tạo Worksheet cho Thuốc Bán Trong Ngày
                    var worksheet2 = package.Workbook.Worksheets.Add("Thuốc Bán Ra");
                    worksheet2.Cells["A1"].Value = "Thuốc Bán Ra";
                    worksheet2.Cells["A1"].Style.Font.Bold = true;

                    worksheet2.Cells["A4"].LoadFromDataTable(thuocyoday, true);
                    worksheet2.Cells[worksheet2.Dimension.Address].AutoFitColumns();

                    using (var range = worksheet2.Cells["A4:D4"])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }

                    // Hộp thoại lưu file
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                        saveFileDialog.FileName = $"BaoCao_Ngay_{DateTime.Now:yyyyMMdd}.xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                            MessageBox.Show("Xuất file Excel thành công!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}");
            }
        }

        private void xuatthuoc_Click(object sender, EventArgs e)
        {
            DataTable Donhantoday = bc.XuatAllnow();
            DataTable thuocyoday = bc.tkthuocnow();

            try
            {
                if (Donhantoday == null || Donhantoday.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu đơn hàng trong ngày để xuất.");
                    return;
                }

                if (thuocyoday == null || thuocyoday.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu thuốc bán trong ngày để xuất.");
                    return;
                }

                using (var package = new OfficeOpenXml.ExcelPackage())
                {
                    var worksheet1 = package.Workbook.Worksheets.Add("Đơn Hàng Trong Ngày");
                    worksheet1.Cells["A1"].Value = "Báo Cáo Đơn Hàng Trong Ngày";
                    worksheet1.Cells["A2"].Value = $"Ngày: {DateTime.Now:dd/MM/yyyy}";
                    worksheet1.Cells["A1:A2"].Style.Font.Bold = true;

                    worksheet1.Cells["A4"].LoadFromDataTable(Donhantoday, true);
                    worksheet1.Cells[worksheet1.Dimension.Address].AutoFitColumns();

                    using (var range = worksheet1.Cells["A4:B4"])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }

                    // Tạo Worksheet cho Thuốc Bán Trong Ngày
                    var worksheet2 = package.Workbook.Worksheets.Add("Thuốc Bán Trong Ngày");
                    worksheet2.Cells["A1"].Value = "Báo Cáo Thuốc Bán Trong Ngày";
                    worksheet2.Cells["A2"].Value = $"Ngày: {DateTime.Now:dd/MM/yyyy}";
                    worksheet2.Cells["A1:A2"].Style.Font.Bold = true;

                    worksheet2.Cells["A4"].LoadFromDataTable(thuocyoday, true);
                    worksheet2.Cells[worksheet2.Dimension.Address].AutoFitColumns();

                    using (var range = worksheet2.Cells["A4:B4"])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                        saveFileDialog.FileName = $"BaoCao_Ngay_{DateTime.Now:yyyyMMdd}.xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                            MessageBox.Show("Xuất file Excel thành công!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}");
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}