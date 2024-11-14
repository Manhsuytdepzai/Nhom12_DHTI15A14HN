using Nhom12_dhti5a14hn.Connect;
using Nhom12_dhti5a14hn.Controller;
using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    public partial class Form3 : Form
    {
        private DonHang dh = new DonHang();

        public Form3()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void dtp_ngaylaphd_ValueChanged(object sender, EventArgs e)
        {
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dtp_ngaylaphd.Value = DateTime.Now;
            dtp_ngaylaphd.Enabled = false;
            display_qldh.DataSource = dh.GetAllBill();
            display_dh.DataSource = dh.GetAll();
            txt_giaban.Enabled = false;
            txt_tenthuoc.Enabled = false;
            HighlightDonHang();
        }

        private void HighlightDonHang()
        {
            foreach (DataGridViewRow row in display_dh.Rows)
            {
                bool isPaid = dh.IsOrderPaid(Convert.ToInt32(row.Cells["ID_DonHang"].Value));

                if (isPaid)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btn_themvao_Click(object sender, EventArgs e)
        {
            try
            {
                string inputMaDonHang = txt_madhthem.Text.Trim();
                if (!int.TryParse(inputMaDonHang, out int maDonHang))
                {
                    MessageBox.Show("Mã đơn hàng không hợp lệ. Vui lòng nhập số hợp lệ.");
                    return;
                }

                DateTime ngayDatHang = dtp_ngaylaphd.Value;
                string soDienThoai = txt_sdt.Text;
                string tenKhachHang = txt_tenkh.Text;

                dh.UpdateDonHang(maDonHang, ngayDatHang, soDienThoai, tenKhachHang);

                display_dh.DataSource = dh.GetAll();
                HighlightDonHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đơn hàng: " + ex.Message);
            }
        }

        private void txt_mathuoc_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txt_mathuoc.Text, out int maThuoc))
            {
                var (tenThuoc, giaBan) = dh.GetTenThuocByMaThuoc(maThuoc);

                if (!string.IsNullOrEmpty(tenThuoc) && tenThuoc != "Không tìm thấy thuốc")
                {
                    txt_tenthuoc.Text = tenThuoc;
                    txt_giaban.Text = giaBan.ToString();
                }
                else
                {
                    txt_tenthuoc.Text = tenThuoc;
                    txt_giaban.Clear();
                }
            }
            else
            {
                txt_tenthuoc.Clear();
                txt_giaban.Clear();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txt_madh.Text, out int madh))
                {
                    MessageBox.Show("Mã đơn hàng không hợp lệ.");
                    return;
                }

                if (!int.TryParse(txt_mathuoc.Text, out int math))
                {
                    MessageBox.Show("Mã thuốc không hợp lệ.");
                    return;
                }

                string tenth = txt_tenthuoc.Text;
                if (string.IsNullOrWhiteSpace(tenth))
                {
                    MessageBox.Show("Tên thuốc không được để trống.");
                    return;
                }

                if (!decimal.TryParse(txt_giaban.Text, out decimal gia))
                {
                    MessageBox.Show("Giá bán không hợp lệ.");
                    return;
                }

                if (!float.TryParse(txt_sl.Text, out float soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ.");
                    return;
                }

                dh.CreateDH(madh, math, tenth, gia, soLuong);

                display_qldh.DataSource = dh.GetAllBill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            display_dh.DataSource = dh.GetAll();
            HighlightDonHang();
        }

        private void display_qldh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = display_qldh.Rows[e.RowIndex];

                    txt_madh.Text = row.Cells["ID_DonHang"].Value.ToString();
                    txt_mathuoc.Text = row.Cells["ID_Thuoc"].Value.ToString();
                    txt_tenthuoc.Text = row.Cells["TenThuoc"].Value.ToString();
                    txt_giaban.Text = row.Cells["GiaBan"].Value.ToString();
                    txt_sl.Text = row.Cells["Soluong"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private void display_dh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void display_dh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = display_dh.Rows[e.RowIndex];
                    txt_madhthem.Text = row.Cells["ID_DonHang"].Value.ToString();
                    txt_tenkh.Text = row.Cells["TenKhachHang"].Value.ToString();
                    txt_sdt.Text = row.Cells["SoDienThoai"].Value.ToString();
                    int maDonHang = Convert.ToInt32(row.Cells["ID_DonHang"].Value);

                    LoadChiTietDonHang(maDonHang);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private void LoadChiTietDonHang(int maDonHang)
        {
            string sql = "SELECT * FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
            };

            connect kn = new connect();
            DataTable dt = kn.readData(sql, parameters);

            display_qldh.DataSource = null;
            display_qldh.DataSource = dt;
        }

        private void display_qldh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void reset_Click(object sender, EventArgs e)
        {
            txt_giaban.Clear();
            txt_madhthem.Clear();
            txt_madh.Clear();
            txt_sdt.Clear();
            txt_tenkh.Clear();
            txt_tenthuoc.Clear();
            txt_mathuoc.Clear();
            txt_sl.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btn_suact_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txt_madh.Text, out int madh))
                {
                    MessageBox.Show("Mã đơn hàng không hợp lệ.");
                    return;
                }
                if (!int.TryParse(txt_mathuoc.Text, out int math))
                {
                    MessageBox.Show("Mã thuốc không hợp lệ.");
                    return;
                }

                string tenth = txt_tenthuoc.Text;
                if (string.IsNullOrWhiteSpace(tenth))
                {
                    MessageBox.Show("Tên thuốc không được để trống.");
                    return;
                }

                if (!decimal.TryParse(txt_giaban.Text, out decimal gia))
                {
                    MessageBox.Show("Giá bán không hợp lệ.");
                    return;
                }

                if (!float.TryParse(txt_sl.Text, out float sl))
                {
                    MessageBox.Show("Mã đơn hàng không hợp lệ.");
                    return;
                }
                dh.UpdateChiTietDonHang(madh, math, tenth, gia, sl);
                display_qldh.DataSource = dh.GetAllBill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                string inputMaDonHang = txt_madhthem.Text.Trim();
                if (!int.TryParse(inputMaDonHang, out int maDonHang))
                {
                    MessageBox.Show("Mã đơn hàng không hợp lệ. Vui lòng nhập số hợp lệ.");
                    return;
                }

                DateTime ngayDatHang = dtp_ngaylaphd.Value;
                string soDienThoai = txt_sdt.Text;
                string tenKhachHang = txt_tenkh.Text;

                dh.UpdateDonHangtt(maDonHang, ngayDatHang, soDienThoai, tenKhachHang);

                display_dh.DataSource = dh.GetAll();
                HighlightDonHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa đơn hàng: " + ex.Message);
            }
        }

        private void display_dh_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int madh = int.Parse(txt_madhthem.Text);
            dh.DeleteDonHang(madh);
            display_dh.DataSource = dh.GetAll();
            display_qldh.DataSource = dh.GetAllBill();
            txt_giaban.Clear();
            txt_madhthem.Clear();
            txt_madh.Clear();
            txt_sdt.Clear();
            txt_tenkh.Clear();
            txt_tenthuoc.Clear();
            txt_mathuoc.Clear();
            txt_sl.Clear();
            HighlightDonHang();
        }

        private void btn_xoact_Click(object sender, EventArgs e)
        {
            int madh = int.Parse(txt_madh.Text);
            dh.DeleteChiTietDonHang(madh);
            display_dh.DataSource = dh.GetAll();
            display_qldh.DataSource = dh.GetAllBill();
            txt_giaban.Clear();
            txt_madhthem.Clear();
            txt_madh.Clear();
            txt_sdt.Clear();
            txt_tenkh.Clear();
            txt_tenthuoc.Clear();
            txt_mathuoc.Clear();
            txt_sl.Clear();
        }

        private void btn_ktra_Click(object sender, EventArgs e)
        {
            int madh = int.Parse(txt_tk.Text);
            display_dh.DataSource = dh.GetDonHangByMaDonHang(madh);
            txt_giaban.Clear();
            txt_madhthem.Clear();
            txt_madh.Clear();
            txt_sdt.Clear();
            txt_tenkh.Clear();
            txt_tenthuoc.Clear();
            txt_mathuoc.Clear();
            txt_sl.Clear();
        }

        private void xuat_Click(object sender, EventArgs e)
        {
            try
            {
                string madonhang = txt_madh.Text;
                DataTable dtDonHang = dh.GetDonHangByMa(madonhang);
                DataTable dtChiTietDonHang = dh.GetChiTietDonHangByMa(madonhang);

                if (dtDonHang == null || dtDonHang.Rows.Count == 0 ||
                    dtChiTietDonHang == null || dtChiTietDonHang.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất ra file Excel.");
                    return;
                }

                using (var package = new OfficeOpenXml.ExcelPackage())
                {
                    var worksheet1 = package.Workbook.Worksheets.Add("Đơn hàng");
                    worksheet1.Cells["B1"].Value = "Đơn hàng";
                    worksheet1.Cells["B2"].Value = "Mã đơn hàng: " + madonhang;
                    worksheet1.Cells["B3"].Value = "Ngày đặt hàng: " + ((DateTime)dtDonHang.Rows[0]["NgayDatHang"]).ToString("dd/MM/yyyy");
                    worksheet1.Cells["B4:F4"].Style.Font.Bold = true;
                    worksheet1.Cells["A5"].LoadFromDataTable(dtDonHang, true);
                    worksheet1.DeleteColumn(1);

                    var worksheet2 = package.Workbook.Worksheets.Add("Chi tiết đơn hàng");
                    worksheet2.Cells["A1:E1"].Style.Font.Bold = true;
                    worksheet2.Cells["A2"].LoadFromDataTable(dtChiTietDonHang, true);

                    ExportInvoice(package, madonhang);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = $"DonHang_{madonhang}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                        MessageBox.Show("Xuất file Excel thành công!");

                        txt_madh.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message);
            }
        }

        private void ExportInvoice(ExcelPackage package, string madonhang)
        {
            DataTable dtChiTietDonHang = dh.GetChiTietDonHangByMa(madonhang);

            var invoiceSheet = package.Workbook.Worksheets.Add("Hóa đơn");

            invoiceSheet.Cells["A1"].Value = "Hóa đơn";
            invoiceSheet.Cells["A2"].Value = "Mã đơn hàng: " + madonhang;

            invoiceSheet.Cells["A4"].Value = "Tên Thuốc";
            invoiceSheet.Cells["B4"].Value = "Giá Bán";
            invoiceSheet.Cells["C4"].Value = "Số Lượng";
            invoiceSheet.Cells["D4"].Value = "Thành Tiền";

            invoiceSheet.Cells["A4:D4"].Style.Font.Bold = true;

            int row = 5;

            foreach (DataRow dr in dtChiTietDonHang.Rows)
            {
                invoiceSheet.Cells[row, 1].Value = dr["TenThuoc"].ToString();

                if (dr["GiaBan"] != DBNull.Value)
                {
                    decimal giaBan = Convert.ToDecimal(dr["GiaBan"]);
                    invoiceSheet.Cells[row, 2].Value = giaBan;
                }
                else
                {
                    invoiceSheet.Cells[row, 2].Value = 0;
                }

                if (dr["Soluong"] != DBNull.Value)
                {
                    decimal giaBan = Convert.ToDecimal(dr["GiaBan"]);
                    double soLuong = Convert.ToDouble(dr["Soluong"]);
                    invoiceSheet.Cells[row, 3].Value = soLuong;
                    decimal thanhTien = giaBan * (decimal)soLuong;
                    invoiceSheet.Cells[row, 4].Value = thanhTien;
                }
                else
                {
                    invoiceSheet.Cells[row, 3].Value = 0;
                    invoiceSheet.Cells[row, 4].Value = 0;
                }

                row++;
            }

            invoiceSheet.Cells[row, 3].Value = "Tổng hoá đơn:";
            invoiceSheet.Cells[row, 3].Style.Font.Bold = true;
            invoiceSheet.Cells[row, 4].Formula = $"SUM(D5:D{row - 1})";
            invoiceSheet.Cells[row, 4].Style.Font.Bold = true;
            invoiceSheet.Cells[$"D5:D{row}"].Style.Numberformat.Format = "#,##0.00";
            invoiceSheet.Cells.AutoFitColumns();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            frm_Main fm = new frm_Main();
            fm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (display_dh.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng.");
                return;
            }
            int maDonHang = GetSelectedOrderId();
            dh.MarkOrderAsPaid(maDonHang);
            HighlightDonHang();
        }

        private int GetSelectedOrderId()
        {
            DataGridViewRow selectedRow = display_dh.SelectedRows[0];
            int maDonHang = Convert.ToInt32(selectedRow.Cells["ID_DonHang"].Value);

            return maDonHang;
        }

        private void fix_Click(object sender, EventArgs e)
        {
            if (display_dh.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng.");
                return;
            }
            int maDonHang = GetSelectedOrderId();
            dh.MarkOrderAsUnpaid(maDonHang);
            HighlightDonHang();
        }
    }
}