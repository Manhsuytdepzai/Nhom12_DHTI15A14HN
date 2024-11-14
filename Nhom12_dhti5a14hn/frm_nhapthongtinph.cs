using Nhom12_dhti5a14hn.Controller;
using System;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    public partial class frm_nhapthongtinph : Form
    {
        private PhanHoi ph = new PhanHoi();

        public frm_nhapthongtinph()
        {
            InitializeComponent();
            ngaygui.Value = DateTime.Now;
            ngaygui.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void frm_nhapthongtinph_Load(object sender, EventArgs e)
        {
        }

        private void gui_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txt_iddh.Text, out int idDonHang))
            {
                string noiDung = txt_nd.Text.Trim();

                if (!string.IsNullOrEmpty(noiDung))
                {
                    ph.AddFeedback(idDonHang, noiDung);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập nội dung phản hồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID Đơn Hàng hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}