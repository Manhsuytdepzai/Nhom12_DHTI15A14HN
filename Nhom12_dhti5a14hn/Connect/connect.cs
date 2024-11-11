using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn.Connect
{
    internal class connect
    {
        SqlConnection conn;

        public void openConnect()
        {
            string kn = "Server=DESKTOP-09OL4KM;Database=QuanLyNhaThuoc;Integrated Security = True";
            conn = new SqlConnection(kn);
            conn.Open();
        }
        public void closeConnect()
        {
            conn.Close();
        }

        public DataTable readData(string sql, SqlParameter[] para = null)
        {
            DataTable dt = new DataTable();
            try
            {
                openConnect();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (para != null) { cmd.Parameters.AddRange(para); }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnect();
            }
            return dt;
        }

        public void NoneQuery(string sql, SqlParameter[] para)
        {
            try
            {
                openConnect();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (para != null)
                    {
                        cmd.Parameters.AddRange(para);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
            finally
            {
                closeConnect();
            }
        }
    }
}
