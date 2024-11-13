using Nhom12_dhti5a14hn.Connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    internal class QuanLyThuoc
    {
        connect kn;
        public QuanLyThuoc()
        {
            kn = new connect();
        }
        // lấy toàn bộ dữ liệu bảng book
        public DataTable GetAllThuoc()
        {
            string sql = "select * from Thuoc";
            return kn.readData(sql);
        }

        public void CreateQuanLyThuoc(string tenThuoc, string maNCC, string loaiThuoc, decimal giaNhap, decimal giaBan, DateTime ngaySanXuat, DateTime hanSuDung, int soLuong)
        {
            try
            {
                string sql = @"
            INSERT INTO Thuoc (TenThuoc, ID_NhaCungCap, LoaiThuoc, GiaNhap, GiaBan, NgaySanXuat, HanSuDung, SoLuong) 
            VALUES (@tenthuoc, @mancc, @loaithuoc, @nhap, @ban, @nsx, @hsd, @sl);
        ";

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@tenthuoc", tenThuoc),
            new SqlParameter("@mancc", maNCC),
            new SqlParameter("@loaithuoc", loaiThuoc),
            new SqlParameter("@nhap", giaNhap),
            new SqlParameter("@ban", giaBan),
            new SqlParameter("@nsx", ngaySanXuat),
            new SqlParameter("@hsd", hanSuDung),
            new SqlParameter("@sl", soLuong)
                };

                kn.NoneQuery(sql, sqlParameters);  // Thực thi câu lệnh SQL

            }
            catch (SqlException sqlEx)
            {
                // Lỗi liên quan đến cơ sở dữ liệu
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Lỗi chung khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


        public void UpdateQuanLyThuoc(int maThuoc, string tenThuoc, string maNCC, string loaiThuoc, decimal giaNhap, decimal giaBan, System.DateTime ngaySanXuat, System.DateTime hanSuDung, int soLuong)
        {
            // Cập nhật thông tin thuốc trong cơ sở dữ liệu
            string sql = "UPDATE Thuoc SET TenThuoc = @tenthuoc, ID_NhaCungCap = @mancc, LoaiThuoc = @loaithuoc, GiaNhap = @nhap, GiaBan = @ban, NgaySanXuat = @nsx, HanSuDung = @hsd, SoLuong = @sl WHERE MaThuoc = @mt";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@mt", maThuoc),               // Mã thuốc
                new SqlParameter("@tenthuoc", tenThuoc),         // Tên thuốc
                new SqlParameter("@mancc", maNCC),               // Mã nhà cung cấp
                new SqlParameter("@loaithuoc", loaiThuoc),       // Loại thuốc
                new SqlParameter("@nhap", giaNhap),              // Giá nhập
                new SqlParameter("@ban", giaBan),                // Giá bán (được tính từ giá nhập + 15%)
                new SqlParameter("@nsx", ngaySanXuat),           // Ngày sản xuất
                new SqlParameter("@hsd", hanSuDung),             // Hạn sử dụng
                new SqlParameter("@sl", soLuong)                 // Số lượng
            };
            kn.NoneQuery(sql, sqlParameters);  // Thực thi câu lệnh SQL cập nhật
        }


        public void DeleteQuanLyThuoc(int maThuoc)
        {
            string sql = "DELETE FROM Thuoc WHERE MaThuoc = @mt";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@mt", maThuoc)
            };
            kn.NoneQuery(sql, sqlParameters);
        }

        public DataTable SearchThuoc(string tenThuoc, string loaiThuoc)
        {
            string sql = "SELECT * FROM Thuoc WHERE 1=1";

            // Tạo điều kiện tìm kiếm nếu có giá trị
            if (!string.IsNullOrEmpty(tenThuoc))
                sql += " AND TenThuoc LIKE @tenThuoc";

            if (!string.IsNullOrEmpty(loaiThuoc))
                sql += " AND LoaiThuoc LIKE @loaiThuoc";

            // Tạo danh sách tham số
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(tenThuoc))
                parameters.Add(new SqlParameter("@tenThuoc", "%" + tenThuoc + "%"));
            if (!string.IsNullOrEmpty(loaiThuoc))
                parameters.Add(new SqlParameter("@loaiThuoc", "%" + loaiThuoc + "%"));

            return kn.readData(sql, parameters.ToArray());
        }
    }
}
