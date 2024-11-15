using Nhom12_dhti5a14hn.Connect;
using System.Data;
using System.Data.SqlClient;

namespace Nhom12_dhti5a14hn
{
    internal class Login
    {
        public class User
        {
            private connect ketnoi;

            public User()
            {
                ketnoi = new connect();
            }

            public bool Login(string username, string password)
            {
                string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhap", username),
                    new SqlParameter("@MatKhau", password)
                };

                DataTable dt = ketnoi.readData(sql, parameters);

                if (dt != null && dt.Rows.Count > 0 && (int)dt.Rows[0][0] > 0)
                {
                    return true;
                }

                return false;
            }
        }
    }
}