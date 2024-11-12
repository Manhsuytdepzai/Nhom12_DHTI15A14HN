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
    internal class PhieuNhap
    {
        connect Connect;

        public PhieuNhap()
        {
            Connect = new connect();
        }

        public DataTable GetAllPn()
        {
            string sql = "select * from PhieuNhap";
            return Connect.readData(sql);
        }
        public void InsertPhieuNhap(int? idNhaCungCap, decimal tongTien = 0)
        {
            try
            {
                // Kiểm tra xem nhà cung cấp có tồn tại trong bảng NCC không
                string checkSupplierSql = "SELECT COUNT(*) FROM NCC WHERE ID_NhaCungCap = @ID_NhaCungCap";
                SqlParameter[] checkSupplierParameters = new SqlParameter[]
                {
            new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = idNhaCungCap.HasValue ? idNhaCungCap.Value : (object)DBNull.Value }
                };

                DataTable supplierDt = Connect.readData(checkSupplierSql, checkSupplierParameters);

                // Nếu không tìm thấy nhà cung cấp, hiển thị thông báo lỗi và không thực hiện thêm phiếu nhập
                if (supplierDt.Rows.Count == 0 || Convert.ToInt32(supplierDt.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Nhà cung cấp không tồn tại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  // Dừng thực thi nếu nhà cung cấp không tồn tại
                }

                // Nếu nhà cung cấp tồn tại, thực hiện thêm phiếu nhập vào bảng PhieuNhap
                string insertPhieuNhapSql = "INSERT INTO PhieuNhap (ID_NhaCungCap, TongTien) VALUES (@ID_NhaCungCap, @TongTien)";
                SqlParameter[] insertPhieuNhapParameters = new SqlParameter[]
                {
            new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = idNhaCungCap.HasValue ? idNhaCungCap.Value : (object)DBNull.Value },
            new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = tongTien }
                };

                // Thực hiện câu lệnh thêm phiếu nhập
                Connect.NoneQuery(insertPhieuNhapSql, insertPhieuNhapParameters);
                MessageBox.Show("Thêm phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void UpdatePhieuNhap(int idNhaCungCap, decimal tongTien, int idPhieuNhap)
        {
            try
            {
                // Kiểm tra xem nhà cung cấp có tồn tại trong bảng NCC không
                string checkSupplierSql = "SELECT COUNT(*) FROM NCC WHERE ID_NhaCungCap = @ID_NhaCungCap";
                SqlParameter[] checkSupplierParameters = new SqlParameter[]
                {
            new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = idNhaCungCap }
                };

                // Thực hiện truy vấn kiểm tra nhà cung cấp
                DataTable supplierDt = Connect.readData(checkSupplierSql, checkSupplierParameters);

                // Nếu không tìm thấy nhà cung cấp, hiển thị thông báo lỗi và không thực hiện cập nhật phiếu nhập
                if (supplierDt.Rows.Count == 0 || Convert.ToInt32(supplierDt.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Nhà cung cấp không tồn tại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  // Dừng thực thi nếu nhà cung cấp không tồn tại
                }

                // Cập nhật thông tin phiếu nhập
                string updateSql = "UPDATE PhieuNhap SET ID_NhaCungCap = @ID_NhaCungCap, TongTien = @TongTien WHERE ID_PhieuNhap = @ID_PhieuNhap";

                SqlParameter[] updateParameters = new SqlParameter[]
                {
            new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = idNhaCungCap },
            new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = tongTien },
            new SqlParameter("@ID_PhieuNhap", SqlDbType.Int) { Value = idPhieuNhap }
                };

                // Thực hiện câu lệnh cập nhật
                Connect.NoneQuery(updateSql, updateParameters);

                // Thông báo thành công
                MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Lỗi khi cập nhật phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletePhieuNhap(int idPhieuNhap)
        {
            try
            {
                // Xóa tất cả chi tiết phiếu nhập liên quan đến ID_PhieuNhap
                string deleteDetailsSql = "DELETE FROM ChiTietPhieuNhap WHERE ID_PhieuNhap = @ID_PhieuNhap";
                SqlParameter[] deleteDetailsParams = new SqlParameter[]
                {
            new SqlParameter("@ID_PhieuNhap", SqlDbType.Int) { Value = idPhieuNhap }
                };

                // Thực hiện câu lệnh xóa chi tiết phiếu nhập
                Connect.NoneQuery(deleteDetailsSql, deleteDetailsParams);

                // Xóa phiếu nhập sau khi đã xóa chi tiết phiếu nhập
                string deletePhieuNhapSql = "DELETE FROM PhieuNhap WHERE ID_PhieuNhap = @ID_PhieuNhap";
                SqlParameter[] deletePhieuNhapParams = new SqlParameter[]
                {
            new SqlParameter("@ID_PhieuNhap", SqlDbType.Int) { Value = idPhieuNhap }
                };

                // Thực hiện câu lệnh xóa phiếu nhập
                Connect.NoneQuery(deletePhieuNhapSql, deletePhieuNhapParams);

                // Thông báo thành công
                MessageBox.Show("Xóa phiếu nhập và các chi tiết phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Lỗi khi xóa phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
