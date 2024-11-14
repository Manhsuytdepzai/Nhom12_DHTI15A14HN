using Nhom12_dhti5a14hn.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    public partial class Form5 : Form
    {
        private KhachHang kh = new KhachHang();

        public Form5()
        {
            InitializeComponent();
            Display_kh.DataSource = kh.GetAllKH();
            Display_kh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            HighlightRowsWithoutOrders();
        }

        private void HighlightRowsWithoutOrders()
        {
            foreach (DataGridViewRow row in Display_kh.Rows)
            {
                if (row.Cells["ID_KhachHang"].Value != null && int.TryParse(row.Cells["ID_KhachHang"].Value.ToString(), out int makh))
                {
                    bool hasOrder = kh.IsCustomerExistInOrder(makh);

                    if (!hasOrder)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
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
                int idKhachHang = int.Parse(txtmakh.Text);
                string newTenKhachHang = txthoten.Text;
                string newSoDienThoai = txtdienthoai.Text;

                kh.UpdateKhachHangAndDonhang(idKhachHang, newTenKhachHang, newSoDienThoai);

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

        private void xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int idKhachHang = int.Parse(txtmakh.Text);
                kh.DeleteCustomerIfNoOrders(idKhachHang);
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

        public void DisplayCustomerByPhone(string phoneNumber)
        {
            DataTable customerData = kh.SearchCustomerByPhone(phoneNumber);

            if (customerData.Rows.Count > 0)
            {
                Display_kh.DataSource = customerData;
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Display_kh.DataSource = null;
            }
        }

        private void Tk_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text.Trim();

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                DisplayCustomerByPhone(phoneNumber);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số điện thoại để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            frm_Main fm = new frm_Main();
            fm.Show();
            this.Close();
        }

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }
    }
}