using Nhom12_dhti5a14hn.Connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class BaoCao
    {
        connect kn;
        public BaoCao()
        {
            kn = new connect();
        }
        public DataTable GetAllnow()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd"); // Lấy ngày hiện tại theo định dạng yyyy-MM-dd

            string sql = "SELECT d.ID_DonHang, d.NgayDatHang, d.TongTien " +
                         "FROM Donhang d " +
                         "WHERE CAST(d.NgayDatHang AS DATE) = @CurrentDate";  // Lọc theo ngày hiện tại

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@CurrentDate", SqlDbType.Date) { Value = currentDate }
            };

            // Thực thi câu lệnh truy vấn và trả về kết quả dưới dạng DataTable
            return kn.readData(sql, parameters);
        }

        public DataTable GetAllBill()
        {
            string sql = "SELECT d.ID_DonHang, d.NgayDatHang, d.TongTien " +
                         "FROM Donhang d";  // Lấy ID_DonHang, NgayDatHang và TongTien từ bảng Donhang

            // Thực thi câu lệnh truy vấn và trả về kết quả dưới dạng DataTable
            return kn.readData(sql, null);
        }


        public DataTable tkthuocnow()
        {
            string sql = @"
    SELECT 
        t.ID_Thuoc, 
        t.TenThuoc,
        ISNULL(SUM(c.Soluong), 0) AS TongSoluong
    FROM Thuoc t
    LEFT JOIN ChiTietDonHang c ON t.ID_Thuoc = c.ID_Thuoc
    GROUP BY t.ID_Thuoc, t.TenThuoc;
    ";

            // Thực thi câu lệnh truy vấn và trả về kết quả dưới dạng DataTable
            return kn.readData(sql);
        }


    }
}
