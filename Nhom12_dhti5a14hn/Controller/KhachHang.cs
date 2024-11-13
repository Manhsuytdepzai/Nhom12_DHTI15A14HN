using Nhom12_dhti5a14hn.Connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class KhachHang
    {
        connect kn;

        public KhachHang()
        {
            kn = new connect();
        }

        public DataTable GetAllKH()
        {
            string sql = "select * from KhachHang";
            return kn.readData(sql);
        }
        public bool IsPhoneNumberExistInOrder(string phoneNumber)
        {
            string sql = "SELECT COUNT(*) FROM Donhang WHERE SoDienThoai = @SoDienThoai";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@SoDienThoai", SqlDbType.NVarChar) { Value = phoneNumber }
            };

            DataTable dt = kn.readData(sql, para);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }
        public void UpdateKhachHangAndDonhang(int idKhachHang, string tenKhachHang, string soDienThoai)
        {
            // Câu lệnh SQL cập nhật bảng KhachHang
            string sqlUpdateKhachHang = "UPDATE KhachHang SET TenKhachHang = @TenKhachHang, SoDienThoai = @SoDienThoai WHERE ID_KhachHang = @ID_KhachHang";

            // Câu lệnh SQL cập nhật bảng Donhang
            string sqlUpdateDonhang = "UPDATE Donhang SET TenKhachHang = @TenKhachHang, SoDienThoai = @SoDienThoai WHERE ID_KhachHang = @ID_KhachHang";

            // Các tham số cho câu lệnh SQL
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
                // Thực thi câu lệnh cập nhật KhachHang
                kn.NoneQuery(sqlUpdateKhachHang, parametersKhachHang);

                // Thực thi câu lệnh cập nhật Donhang
                kn.NoneQuery(sqlUpdateDonhang, parametersDonhang);

                // Thông báo thành công
                MessageBox.Show("Cập nhật khách hàng và đơn hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu có
                MessageBox.Show($"Có lỗi xảy ra khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DeleteCustomerIfNoOrders(string phoneNumber)
        {
            // Kiểm tra xem số điện thoại có trong bảng Donhang không
            if (IsPhoneNumberExistInOrder(phoneNumber))
            {
                // Hiển thị thông báo nếu khách hàng có tồn tại hóa đơn mua hàng
                MessageBox.Show("Không thể xóa vì khách hàng này có hóa đơn mua hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Câu lệnh SQL xóa khách hàng
                string sqlDeleteKhachHang = "DELETE FROM KhachHang WHERE SoDienThoai = @SoDienThoai";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@SoDienThoai", SqlDbType.Int) { Value = phoneNumber }
                };

                try
                {
                    // Thực thi câu lệnh xóa khách hàng thông qua phương thức NoneQuery đã có
                    kn.NoneQuery(sqlDeleteKhachHang, parameters);

                    // Thông báo thành công
                    MessageBox.Show("Xóa khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Thông báo lỗi nếu xảy ra
                    MessageBox.Show($"Có lỗi xảy ra khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
