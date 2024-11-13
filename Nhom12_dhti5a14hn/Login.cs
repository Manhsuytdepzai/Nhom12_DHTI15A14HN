using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    internal class Login
    {
        public class User
        {
            private KetNoi ketNoi = new KetNoi();

            public bool Login(string username, string password)
            {
                string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhap", username),
                    new SqlParameter("MatKhau", password)
                };
                DataTable dt = new DataTable();
                dt = ketNoi.ReadData(sql, parameters);
                if(dt != null)
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                    return true;
                }
                MessageBox.Show(" Sai mật khẩu hoặc tên đăng nhập");

                return false;
            }
        }
    }
}
