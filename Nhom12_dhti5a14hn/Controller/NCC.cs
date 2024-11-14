using Nhom12_dhti5a14hn.Connect;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class NCC
    {
        private connect Connect;

        public NCC()
        {
            Connect = new connect();
        }

        public DataTable getAllNcc()
        {
            string sql = "select * from NCC";
            return Connect.readData(sql);
        }

        public void AddNCC(string tenNhaCungCap, string diaChi)
        {
            string sql = "INSERT INTO [dbo].[NCC] (TenNhaCungCap, DiaChi) VALUES (@TenNhaCungCap, @DiaChi)";
            SqlParameter[] para = new SqlParameter[]
            {
        new SqlParameter("@TenNhaCungCap", SqlDbType.VarChar, 100) { Value = tenNhaCungCap },
        new SqlParameter("@DiaChi", SqlDbType.VarChar, 255) { Value = diaChi }
            };

            try
            {
                Connect.NoneQuery(sql, para);
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateNCC(int idNhaCungCap, string tenNhaCungCap, string diaChi)
        {
            string sql = "UPDATE [dbo].[NCC] SET TenNhaCungCap = @TenNhaCungCap, DiaChi = @DiaChi WHERE ID_NhaCungCap = @ID_NhaCungCap";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TenNhaCungCap", SqlDbType.VarChar, 100) { Value = tenNhaCungCap },
                new SqlParameter("@DiaChi", SqlDbType.VarChar, 255) { Value = diaChi },
                new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = idNhaCungCap }
            };

            try
            {
                Connect.NoneQuery(sql, para);
                MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteNCC(int idNhaCungCap)
        {
            string deleteDetailsSql = "DELETE FROM [dbo].[ChiTietPhieuNhap] WHERE ID_PhieuNhap IN (SELECT ID_PhieuNhap FROM [dbo].[PhieuNhap] WHERE ID_NhaCungCap = @ID_NhaCungCap)";
            SqlParameter[] paraDeleteDetails = new SqlParameter[]
            {
                new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = idNhaCungCap }
            };

            string deletePhieuNhapSql = "DELETE FROM [dbo].[PhieuNhap] WHERE ID_NhaCungCap = @ID_NhaCungCap";
            SqlParameter[] paraDeletePhieuNhap = new SqlParameter[]
            {
                new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = idNhaCungCap }
            };

            string deleteNCCSql = "DELETE FROM [dbo].[NCC] WHERE ID_NhaCungCap = @ID_NhaCungCap";
            SqlParameter[] paraDeleteNCC = new SqlParameter[]
            {
                new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = idNhaCungCap }
            };

            try
            {
                Connect.NoneQuery(deleteDetailsSql, paraDeleteDetails);

                Connect.NoneQuery(deletePhieuNhapSql, paraDeletePhieuNhap);

                Connect.NoneQuery(deleteNCCSql, paraDeleteNCC);

                MessageBox.Show("Xoá nhà cung cấp và các phiếu nhập liên quan thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable SearchNCC(string tenNhaCungCap)
        {
            string sql = "SELECT * FROM [dbo].[NCC] WHERE TenNhaCungCap LIKE @TenNhaCungCap";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TenNhaCungCap", SqlDbType.VarChar, 100) { Value = "%" + tenNhaCungCap + "%" }
            };

            return Connect.readData(sql, para);
        }
    }
}