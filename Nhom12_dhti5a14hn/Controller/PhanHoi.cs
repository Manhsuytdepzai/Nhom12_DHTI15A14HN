using Nhom12_dhti5a14hn.Connect;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class PhanHoi
    {
        private connect kn;

        public PhanHoi()
        {
            kn = new connect();
        }

        public DataTable getAllph()
        {
            string sql = "select * from PhanHoi";
            return kn.readData(sql);
        }

        public void AddFeedback(int idDonHang, string noiDung)
        {
            string sqlGetCustomerId = "SELECT ID_KhachHang FROM Donhang WHERE ID_DonHang = @ID_DonHang";
            SqlParameter[] parametersGetCustomerId = new SqlParameter[]
            {
                new SqlParameter("@ID_DonHang", SqlDbType.Int) { Value = idDonHang }
            };

            DataTable result = kn.readData(sqlGetCustomerId, parametersGetCustomerId);

            if (result.Rows.Count > 0)
            {
                int idKhachHang = Convert.ToInt32(result.Rows[0]["ID_KhachHang"]);
                DateTime ngayPhanHoi = DateTime.Now;

                string sqlInsertFeedback = @"
                                            INSERT INTO PhanHoi (ID_DonHang, ID_KhachHang, NoiDung, NgayPhanHoi)
                                            VALUES (@ID_DonHang, @ID_KhachHang, @NoiDung, @NgayPhanHoi)";

                SqlParameter[] parametersInsertFeedback = new SqlParameter[]
                {
                    new SqlParameter("@ID_DonHang", SqlDbType.Int) { Value = idDonHang },
                    new SqlParameter("@ID_KhachHang", SqlDbType.Int) { Value = idKhachHang },
                    new SqlParameter("@NoiDung", SqlDbType.Text) { Value = noiDung },
                    new SqlParameter("@NgayPhanHoi", SqlDbType.Date) { Value = ngayPhanHoi }
                };

                kn.NoneQuery(sqlInsertFeedback, parametersInsertFeedback);
                MessageBox.Show("Thêm phản hồi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy ID_KhachHang tương ứng với ID_DonHang.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}