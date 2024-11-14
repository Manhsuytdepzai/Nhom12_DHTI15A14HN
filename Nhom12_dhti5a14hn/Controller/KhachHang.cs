using Nhom12_dhti5a14hn.Connect;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class KhachHang
    {
        private connect kn;

        public KhachHang()
        {
            kn = new connect();
        }

        public DataTable GetAllKH()
        {
            string sql = "select * from KhachHang";
            return kn.readData(sql);
        }

        public bool IsCustomerExistInOrder(int idKhachHang)
        {
            string sql = "SELECT COUNT(*) FROM Donhang WHERE ID_KhachHang = @ID_KhachHang";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ID_KhachHang", SqlDbType.Int) { Value = idKhachHang }
            };

            DataTable dt = kn.readData(sql, para);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        public void UpdateKhachHangAndDonhang(int idKhachHang, string tenKhachHang, string soDienThoai)
        {
            string sqlUpdateKhachHang = "UPDATE KhachHang SET TenKhachHang = @TenKhachHang, SoDienThoai = @SoDienThoai WHERE ID_KhachHang = @ID_KhachHang";

            string sqlUpdateDonhang = "UPDATE Donhang SET TenKhachHang = @TenKhachHang, SoDienThoai = @SoDienThoai WHERE ID_KhachHang = @ID_KhachHang";

            SqlParameter[] parametersKhachHang = new SqlParameter[]
            {
                new SqlParameter("@ID_KhachHang", SqlDbType.Int) { Value = idKhachHang },
                new SqlParameter("@TenKhachHang", SqlDbType.NVarChar) { Value = tenKhachHang },
                new SqlParameter("@SoDienThoai", SqlDbType.NVarChar) { Value = soDienThoai }
            };

            SqlParameter[] parametersDonhang = new SqlParameter[]
            {
                new SqlParameter("@ID_KhachHang", SqlDbType.Int) { Value = idKhachHang },
                new SqlParameter("@TenKhachHang", SqlDbType.NVarChar) { Value = tenKhachHang },
                new SqlParameter("@SoDienThoai", SqlDbType.NVarChar) { Value = soDienThoai }
            };

            try
            {
                kn.NoneQuery(sqlUpdateKhachHang, parametersKhachHang);

                kn.NoneQuery(sqlUpdateDonhang, parametersDonhang);

                MessageBox.Show("Cập nhật khách hàng và đơn hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteCustomerIfNoOrders(int idKhachHang)
        {
            using (var kn = new connect())
            {
                if (IsCustomerExistInOrder(idKhachHang))
                {
                    MessageBox.Show("Không thể xóa vì khách hàng này có hóa đơn mua hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string sqlDeleteKhachHang = "DELETE FROM KhachHang WHERE ID_KhachHang = @ID_KhachHang";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@ID_KhachHang", SqlDbType.Int) { Value = idKhachHang }
                    };

                    try
                    {
                        kn.NoneQuery(sqlDeleteKhachHang, parameters);

                        MessageBox.Show("Xóa khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Có lỗi SQL xảy ra khi xóa: {ex.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public DataTable SearchCustomerByPhone(string phoneNumber)
        {
            string sql = "SELECT * FROM KhachHang WHERE SoDienThoai = @SoDienThoai";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoDienThoai", SqlDbType.VarChar) { Value = phoneNumber }
            };

            return kn.readData(sql, parameters);
        }
    }
}