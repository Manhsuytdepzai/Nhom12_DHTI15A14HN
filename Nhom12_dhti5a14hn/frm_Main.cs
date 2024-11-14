using System;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show(); // Display Form2
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show(); // Di
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show(); // Display Form7
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmPhieuNhap frmPhieuNhap = new FrmPhieuNhap();
            frmPhieuNhap.Show();
            this.Hide();
        }
    }
}