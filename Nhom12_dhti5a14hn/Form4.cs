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
    public partial class Form4 : Form
    {
        NCC ncc = new NCC();
        public Form4()
        {
            InitializeComponent();
            txt_mancc.Enabled = false;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string tenncc = txt_tenncc.Text;
            string dchi = txt_dchi.Text;

            // Kiểm tra nếu các trường thông tin không trống
            if (string.IsNullOrWhiteSpace(tenncc) || string.IsNullOrWhiteSpace(dchi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm nhà cung cấp mới
            ncc.AddNCC(tenncc, dchi);

            // Cập nhật lại DataGridView
            display_ncc.DataSource = ncc.getAllNcc();

            // Xóa dữ liệu trong các TextBox sau khi thêm thành công
            txt_tenncc.Clear();
            txt_dchi.Clear();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            display_ncc.DataSource = ncc.getAllNcc();
        }

        private void btn_suact_Click(object sender, EventArgs e)
        {
            string tenncc = txt_tenncc.Text;
            string dchi = txt_dchi.Text;
            int mancc = int.Parse(txt_mancc.Text);

            if (string.IsNullOrWhiteSpace(tenncc) || string.IsNullOrWhiteSpace(dchi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ncc.UpdateNCC(mancc,tenncc, dchi);

            display_ncc.DataSource = ncc.getAllNcc();

            txt_tenncc.Clear();
            txt_dchi.Clear();
            txt_mancc.Clear();
        }

        private void display_ncc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = display_ncc.Rows[e.RowIndex];
                    txt_mancc.Text = row.Cells["ID_NhaCungCap"].Value.ToString();
                    txt_tenncc.Text = row.Cells["TenNhaCungCap"].Value.ToString();
                    txt_dchi.Text = row.Cells["DiaChi"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            txt_tenncc.Clear();
            txt_dchi.Clear();
            txt_mancc.Clear();
        }

        private void btn_xoact_Click(object sender, EventArgs e)
        {
            int mancc = int.Parse(txt_mancc.Text);
            ncc.DeleteNCC(mancc);
            txt_tenncc.Clear();
            txt_dchi.Clear();
            txt_mancc.Clear();
            display_ncc.DataSource = ncc.getAllNcc();
        }
    }
}
