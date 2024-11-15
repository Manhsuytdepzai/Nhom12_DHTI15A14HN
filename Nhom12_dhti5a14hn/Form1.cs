using System;
using System.Windows.Forms;
using static Nhom12_dhti5a14hn.Login;

namespace Nhom12_dhti5a14hn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User user = new User();
            if (user.Login(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!");
                frm_Main form = new frm_Main();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            }
        }
    }
}