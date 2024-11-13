using Nhom12_dhti5a14hn.Connect;
using Nhom12_dhti5a14hn.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    public partial class Form3 : Form
    {
        DonHang dh = new DonHang();
        public Form3()
        {
            InitializeComponent();
            
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
                // Validate Mã đơn hàng (Order ID)
                if (!int.TryParse(txt_madh.Text, out int madh))
                {
                    MessageBox.Show("Mã đơn hàng không hợp lệ.");
                    return;
                }

                // Validate Mã thuốc (Medicine ID)
                if (!int.TryParse(txt_mathuoc.Text, out int math))
                {
                    MessageBox.Show("Mã thuốc không hợp lệ.");
                    return;
                }

                // Validate Tên thuốc (Medicine Name)
                string tenth = txt_tenthuoc.Text;
                if (string.IsNullOrWhiteSpace(tenth))
                {
                    MessageBox.Show("Tên thuốc không được để trống.");
                    return;
                }

                // Validate Giá bán (Price)
                if (!decimal.TryParse(txt_giaban.Text, out decimal gia))
                {
                    MessageBox.Show("Giá bán không hợp lệ.");
                    return;
                }

                // Validate Số lượng (Quantity)
                if (!float.TryParse(txt_sl.Text, out float soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ.");
                    return;
                }

                // Call CreatDH with the additional soLuong parameter
                dh.CreatDH(madh, math, tenth, gia, soLuong);

                // Display updated order data
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
                dh.UpdateChiTietDonHang(madh, math, tenth, gia);
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
    }
}
