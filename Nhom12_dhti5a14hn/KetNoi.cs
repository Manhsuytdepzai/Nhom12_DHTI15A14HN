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
    public class KetNoi
    {
        public SqlConnection conn;

        public void MoKetNoi()
        {
            string kn = "Server=MAIANHVU\\SQLEXPRESS;Database=QuanLyNhaThuoc;Integrated Security=True";
            conn = new SqlConnection(kn);
            conn.Open();
        }

        public void DongKetNoi()
        {
            conn.Close();
        }

        public DataTable ReadData(string sql, SqlParameter[] para = null )
        {
            DataTable dt = new DataTable();
            try
            {
                MoKetNoi();
                using (SqlCommand cmd1 = new SqlCommand(sql, conn))
                {
                    if(para != null) { 
                        cmd1.Parameters.AddRange(para);
                    }
                    using (SqlDataReader reader = cmd1.ExecuteReader())
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
                DongKetNoi();
            }
            return dt;
        }

        public void CreateUpdateDelete(string sql, SqlParameter[] sqlParameters = null)
        {
            try
            {
                MoKetNoi();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (sqlParameters != null)
                        cmd.Parameters.AddRange(sqlParameters);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

    }
}
