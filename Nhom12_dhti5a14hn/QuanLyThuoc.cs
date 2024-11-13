using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom12_dhti5a14hn
{
    internal class QuanLyThuoc
    {
        KetNoi kn;
        public QuanLyThuoc()
        {
            kn = new KetNoi();
        }
        // lấy toàn bộ dữ liệu bảng book
        public DataTable GetAllThuoc()
        {
            string sql = "select * from Thuoc";
            return kn.ReadData(sql);
        }

        public void CreateQuanLyThuoc(string maThuoc, string tenThuoc, string maNCC, string loaiThuoc, int giaNhap, int giaBan, System.DateTime ngaySanXuat, System.DateTime hanSuDung, int soLuong)
        {
            string sql = "insert into Thuoc(TenThuoc, ID_NhaCungCap, LoaiThuoc, GiaNhap, GiaBan, NgaySanXuat, HanSuDung, SoLuong) values ( @tenthuoc, @mancc, @loaithuoc, @nhap, @ban, @nsx, @hsd, @sl)";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@mathuoc",maThuoc),
                new SqlParameter("@tenthuoc",tenThuoc),
                new SqlParameter("@mancc",maNCC),
                new SqlParameter("@loaithuoc",loaiThuoc),
                new SqlParameter("@nhap",giaNhap),
                new SqlParameter("@ban",giaBan),
                new SqlParameter("@nsx",ngaySanXuat),
                new SqlParameter("@hsd",hanSuDung),
                new SqlParameter("@sl",soLuong)
            };
            kn.CreateUpdateDelete(sql, sqlParameters);
        }

        public void UpdateQuanLyThuoc(string maThuoc, string tenThuoc, string maNCC, string loaiThuoc, int giaNhap, int giaBan, System.DateTime ngaySanXuat, System.DateTime hanSuDung, int soLuong)
        {
            string sql = "UPDATE Thuoc SET TenThuoc = @tenthuoc, ID_NhaCungCap = @mancc, LoaiThuoc = @loaithuoc, GiaNhap = @nhap, GiaBan = @ban, NgaySanXuat = @nsx, HanSuDung = @hsd, SoLuong = @sl WHERE MaThuoc = @mt";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@mt", maThuoc),
                new SqlParameter("@tenthuoc", tenThuoc),
                new SqlParameter("@mancc", maNCC),
                new SqlParameter("@loaithuoc", loaiThuoc),
                new SqlParameter("@nhap", giaNhap),
                new SqlParameter("@ban", giaBan),
                new SqlParameter("@nsx", ngaySanXuat),
                new SqlParameter("@hsd", hanSuDung),
                new SqlParameter("@sl", soLuong)
                };
            kn.CreateUpdateDelete(sql, sqlParameters);
        }

        public void DeleteQuanLyThuoc(string maThuoc)
        {
            string sql = "DELETE FROM Thuoc WHERE MaThuoc = @mt";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@mt", maThuoc)
            };
            kn.CreateUpdateDelete(sql, sqlParameters);
        }

        public DataTable SearchThuoc(string tenThuoc, string loaiThuoc)
        {
            KetNoi ketNoi = new KetNoi();
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

            return ketNoi.ReadData(sql, parameters.ToArray());
        }
    }
}
