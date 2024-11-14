using Nhom12_dhti5a14hn.Connect;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class PhieuNhap
    {
        private connect Connect;

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
                string checkSupplierSql = "SELECT COUNT(*) FROM NCC WHERE ID_NhaCungCap = @ID_NhaCungCap";
                SqlParameter[] checkSupplierParameters = new SqlParameter[]
                {
            new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = idNhaCungCap.HasValue ? idNhaCungCap.Value : (object)DBNull.Value }
                };

                DataTable supplierDt = Connect.readData(checkSupplierSql, checkSupplierParameters);

                if (supplierDt.Rows.Count == 0 || Convert.ToInt32(supplierDt.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Nhà cung cấp không tồn tại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string insertPhieuNhapSql = "INSERT INTO PhieuNhap (ID_NhaCungCap, TongTien) VALUES (@ID_NhaCungCap, @TongTien)";
                SqlParameter[] insertPhieuNhapParameters = new SqlParameter[]
                {
            new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = idNhaCungCap.HasValue ? idNhaCungCap.Value : (object)DBNull.Value },
            new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = tongTien }
                };

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
                string checkSupplierSql = "SELECT COUNT(*) FROM NCC WHERE ID_NhaCungCap = @ID_NhaCungCap";
                SqlParameter[] checkSupplierParameters = new SqlParameter[]
                {
            new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = idNhaCungCap }
                };

                DataTable supplierDt = Connect.readData(checkSupplierSql, checkSupplierParameters);

                if (supplierDt.Rows.Count == 0 || Convert.ToInt32(supplierDt.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Nhà cung cấp không tồn tại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string updateSql = "UPDATE PhieuNhap SET ID_NhaCungCap = @ID_NhaCungCap, TongTien = @TongTien WHERE ID_PhieuNhap = @ID_PhieuNhap";

                SqlParameter[] updateParameters = new SqlParameter[]
                {
            new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = idNhaCungCap },
            new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = tongTien },
            new SqlParameter("@ID_PhieuNhap", SqlDbType.Int) { Value = idPhieuNhap }
                };

                Connect.NoneQuery(updateSql, updateParameters);

                MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletePhieuNhap(int idPhieuNhap)
        {
            try
            {
                string deleteDetailsSql = "DELETE FROM ChiTietPhieuNhap WHERE ID_PhieuNhap = @ID_PhieuNhap";
                SqlParameter[] deleteDetailsParams = new SqlParameter[]
                {
            new SqlParameter("@ID_PhieuNhap", SqlDbType.Int) { Value = idPhieuNhap }
                };

                Connect.NoneQuery(deleteDetailsSql, deleteDetailsParams);

                string deletePhieuNhapSql = "DELETE FROM PhieuNhap WHERE ID_PhieuNhap = @ID_PhieuNhap";
                SqlParameter[] deletePhieuNhapParams = new SqlParameter[]
                {
            new SqlParameter("@ID_PhieuNhap", SqlDbType.Int) { Value = idPhieuNhap }
                };

                Connect.NoneQuery(deletePhieuNhapSql, deletePhieuNhapParams);

                MessageBox.Show("Xóa phiếu nhập và các chi tiết phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable TkPN(int maPN)
        {
            string sql = "SELECT * FROM PhieuNhap WHERE ID_PhieuNhap = @MaPN";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaPN", SqlDbType.Int) { Value = maPN }
            };

            DataTable dt = Connect.readData(sql, parameters);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("ID_PhieuNhap không tồn tại trong bảng PhieuNhap.");
            }

            return dt;
        }
    }
}