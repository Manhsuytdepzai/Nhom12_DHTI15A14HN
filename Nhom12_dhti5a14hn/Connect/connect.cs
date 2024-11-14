using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn.Connect
{
    internal class connect : IDisposable
    {
        private SqlConnection conn;

        // Khởi tạo kết nối cơ sở dữ liệu
        public connect()
        {
            string kn = "Server=DESKTOP-09OL4KM;Database=QuanLyNhaThuoc;Integrated Security = True";
            conn = new SqlConnection(kn);
        }

        // Mở kết nối
        public void openConnect()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        // Đóng kết nối
        public void closeConnect()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        // Đọc dữ liệu từ cơ sở dữ liệu
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

        // Thực thi câu lệnh không trả về kết quả
        // Thực thi câu lệnh không trả về kết quả
        // Thực thi câu lệnh không trả về kết quả
        public void NoneQuery(string sql, SqlParameter[] para)
        {
            try
            {
                openConnect();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (para != null)
                    {
                        // Tạo bản sao của các tham số để tránh lỗi "SqlParameter is already contained by another SqlParameterCollection"
                        foreach (var p in para)
                        {
                            cmd.Parameters.Add(new SqlParameter(p.ParameterName, p.SqlDbType) { Value = p.Value });
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thực thi câu lệnh SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chung khi thực thi câu lệnh: " + ex.Message);
            }
            finally
            {
                closeConnect();
            }
        }

        // Implement IDisposable interface to ensure proper cleanup
        public void Dispose()
        {
            // Giải phóng tài nguyên kết nối khi không sử dụng
            closeConnect();
            conn.Dispose();
        }
    }
}