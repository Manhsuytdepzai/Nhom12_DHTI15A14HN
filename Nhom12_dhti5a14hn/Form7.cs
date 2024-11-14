using Nhom12_dhti5a14hn.Controller;
using System;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    public partial class Form7 : Form
    {
        private PhanHoi ph = new PhanHoi();

        public Form7()
        {
            InitializeComponent();
            display_ph.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            display_ph.DataSource = ph.getAllph();
        }

        private void display_ph_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = display_ph.Rows[e.RowIndex];
                    txt_iddh.Text = row.Cells["ID_DonHang"].Value.ToString();
                    txt_idkh.Text = row.Cells["ID_KhachHang"].Value.ToString();
                    txt_idph.Text = row.Cells["ID_PhanHoi"].Value.ToString();
                    txt_ngaygui.Text = row.Cells["NgayPhanHoi"].Value.ToString();
                    txt_nd.Text = row.Cells["NoiDung"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private void display_ph_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            frm_Main fm = new frm_Main();
            fm.Show();
            this.Close();
        }
    }
}