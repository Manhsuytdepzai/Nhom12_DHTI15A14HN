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
    public partial class Form6 : Form
    {
        BaoCao bc = new BaoCao();
        public Form6()
        {
            InitializeComponent();
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
    }
}
