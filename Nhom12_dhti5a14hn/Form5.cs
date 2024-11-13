using Nhom12_dhti5a14hn.Connect;
using Nhom12_dhti5a14hn.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    public partial class Form5 : Form
    {
        KhachHang kh = new KhachHang();
        public Form5()
        {
            InitializeComponent();
            Display_kh.DataSource = kh.GetAllKH();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            HighlightRowsWithoutOrders();
        }
        private void HighlightRowsWithoutOrders()
        {
            foreach (DataGridViewRow row in Display_kh.Rows)
            {
                string phoneNumber = row.Cells["SoDienThoai"].Value?.ToString();

                if (string.IsNullOrEmpty(phoneNumber))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    bool hasOrder = kh.IsPhoneNumberExistInOrder(phoneNumber);

                    if (!hasOrder)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }
        private void Display_kh_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void Display_kh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Display_kh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = Display_kh.Rows[e.RowIndex];
                    txtmakh.Text = row.Cells["ID_KhachHang"].Value.ToString();
                    txthoten.Text = row.Cells["TenKhachHang"].Value.ToString();
                    txtdienthoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private void sua_Click(object sender, EventArgs e)
        {
            try
            {
                // Chuyển đổi giá trị từ TextBox thành kiểu dữ liệu phù hợp
                int idKhachHang = int.Parse(txtmakh.Text); // Chắc chắn rằng txtmakh.Text là giá trị hợp lệ
                string newTenKhachHang = txthoten.Text;
                string newSoDienThoai = txtdienthoai.Text;

                // Cập nhật thông tin khách hàng
                kh.UpdateKhachHangAndDonhang(idKhachHang, newTenKhachHang, newSoDienThoai);

                // Cập nhật lại danh sách khách hàng trong DataGridView
                Display_kh.DataSource = kh.GetAllKH();

                // Kiểm tra và đánh dấu những khách hàng không có đơn hàng
                HighlightRowsWithoutOrders();
                txtmakh.Clear();
                txthoten.Clear();
                txtdienthoai.Clear();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string newSoDienThoai = txtdienthoai.Text;

                // Cập nhật thông tin khách hàng
                kh.DeleteCustomerIfNoOrders(newSoDienThoai);
                Display_kh.DataSource = kh.GetAllKH();
                HighlightRowsWithoutOrders();
                txtmakh.Clear();
                txthoten.Clear();
                txtdienthoai.Clear();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
