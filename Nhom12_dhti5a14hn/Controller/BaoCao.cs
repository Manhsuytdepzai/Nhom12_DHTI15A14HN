using Nhom12_dhti5a14hn.Connect;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class BaoCao
    {
        private connect kn;

        public BaoCao()
        {
            kn = new connect();
        }

        public DataTable GetAllnow()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            string sql = "SELECT d.ID_DonHang, d.NgayDatHang, d.TongTien " +
                         "FROM Donhang d " +
                         "WHERE CAST(d.NgayDatHang AS DATE) = @CurrentDate";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CurrentDate", SqlDbType.Date) { Value = currentDate }
            };

            return kn.readData(sql, parameters);
        }

        public DataTable XuatAllnow()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            string sql = "SELECT d.ID_DonHang, d.TongTien " +
                         "FROM Donhang d " +
                         "WHERE CAST(d.NgayDatHang AS DATE) = @CurrentDate";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CurrentDate", SqlDbType.Date) { Value = currentDate }
            };

            return kn.readData(sql, parameters);
        }

        public DataTable GetAllBill()
        {
            string sql = "SELECT d.ID_DonHang, d.NgayDatHang, d.TongTien " +
                         "FROM Donhang d";
            return kn.readData(sql, null);
        }

        public DataTable tkthuocnow()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            string sql = @"
                            SELECT
                                t.MaThuoc,
                                t.TenThuoc,
                                ISNULL(SUM(CASE WHEN CAST(d.NgayDatHang AS DATE) = @CurrentDate THEN c.Soluong ELSE 0 END), 0) AS TongSoluong
                            FROM Thuoc t
                            LEFT JOIN ChiTietDonHang c ON t.MaThuoc = c.ID_Thuoc
                            LEFT JOIN Donhang d ON c.ID_DonHang = d.ID_DonHang
                            GROUP BY t.MaThuoc, t.TenThuoc;
                            ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CurrentDate", SqlDbType.Date) { Value = currentDate }
            };

            return kn.readData(sql, parameters);
        }

        public DataTable GetAllThuoc()
        {
            string sql = @"
                        SELECT
                            t.MaThuoc,
                            t.TenThuoc,
                            ISNULL(SUM(c.Soluong), 0) AS TongSoluong
                        FROM Thuoc t
                        LEFT JOIN ChiTietDonHang c ON t.MaThuoc = c.ID_Thuoc
                        GROUP BY t.MaThuoc, t.TenThuoc;
                        ";
            return kn.readData(sql);
        }
    }
}