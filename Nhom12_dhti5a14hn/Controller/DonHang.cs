using Nhom12_dhti5a14hn.Connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class DonHang
    {
        connect Connect;

        public DonHang()
        {
            Connect = new connect();
        }

        public DataTable GetAllBill()
        {
            string sql = "SELECT ID_DonHang, ID_Thuoc, TenThuoc, GiaBan, Soluong, (GiaBan * Soluong) AS ThanhTien " +
                 "FROM ChiTietDonHang";
            return Connect.readData(sql);
        }
        public DataTable GetAll()
        {
            string sql = "SELECT * FROM [dbo].[Donhang]";
            return Connect.readData(sql);
        }
        public void UpdateDonHang(int maDonHang, DateTime ngayDatHang, string soDienThoai, string tenKhachHang)
        {
            // Kiểm tra xem khách hàng đã có trong bảng KhachHang chưa
            string checkCustomerSql = "SELECT COUNT(*) FROM KhachHang WHERE SoDienThoai = @SoDienThoai";
            SqlParameter[] checkCustomerParameters = new SqlParameter[]
            {
                new SqlParameter("@SoDienThoai", SqlDbType.VarChar, 20) { Value = soDienThoai }
            };

            // Lấy kết quả trả về từ câu lệnh kiểm tra khách hàng
            DataTable customerDt = Connect.readData(checkCustomerSql, checkCustomerParameters);

            // Nếu khách hàng chưa tồn tại, thêm khách hàng mới vào bảng KhachHang
            if (customerDt.Rows.Count > 0 && Convert.ToInt32(customerDt.Rows[0][0]) == 0)
            {
                string insertCustomerSql = "INSERT INTO KhachHang (TenKhachHang, SoDienThoai) VALUES (@TenKhachHang, @SoDienThoai)";
                SqlParameter[] insertCustomerParameters = new SqlParameter[]
                {
            new SqlParameter("@TenKhachHang", SqlDbType.VarChar, 100) { Value = tenKhachHang },
            new SqlParameter("@SoDienThoai", SqlDbType.VarChar, 20) { Value = soDienThoai }
                };

                // Thực hiện câu lệnh thêm khách hàng vào bảng KhachHang
                Connect.NoneQuery(insertCustomerSql, insertCustomerParameters);
                MessageBox.Show("Khách hàng mới đã được thêm thành công!");
            }

            // Kiểm tra xem mã đơn hàng có tồn tại trong bảng Donhang không
            string checkSql = "SELECT COUNT(*) FROM Donhang WHERE ID_DonHang = @MaDonHang";
            SqlParameter[] checkParameters = new SqlParameter[]
            {
        new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
            };

            // Lấy kết quả trả về từ câu lệnh kiểm tra
            DataTable dt = Connect.readData(checkSql, checkParameters);

            // Kiểm tra xem có dữ liệu trả về không và xử lý
            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                // Nếu mã đơn hàng đã tồn tại, thông báo cho người dùng
                MessageBox.Show("Mã đơn hàng này đã tồn tại. Vui lòng chọn mã khác.");
            }
            else
            {
                // Nếu mã đơn hàng chưa tồn tại, tiến hành thêm mới đơn hàng
                string sql = "INSERT INTO Donhang (ID_DonHang, NgayDatHang, TongTien, SoDienThoai, TenKhachHang) " +
                             "VALUES (@MaDonHang, @NgayDatHang, 0, @SoDienThoai, @TenKhachHang)";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang },
            new SqlParameter("@NgayDatHang", SqlDbType.Date) { Value = ngayDatHang },
            new SqlParameter("@SoDienThoai", SqlDbType.VarChar, 20) { Value = soDienThoai },
            new SqlParameter("@TenKhachHang", SqlDbType.VarChar, 100) { Value = tenKhachHang }
                };

                // Gọi phương thức NoneQuery để thực hiện câu lệnh
                Connect.NoneQuery(sql, parameters);
                MessageBox.Show("Đơn hàng đã được thêm thành công!");
            }
        }



        public void CreateDH(int maDonHang, int maThuoc, string tenThuoc, decimal giaBan, float soLuong)
        {
            try
            {
                // Bước 1: Kiểm tra mã đơn hàng có tồn tại trong bảng HoaDon hay không
                string checkHoaDonSql = "SELECT COUNT(*) FROM Donhang WHERE ID_DonHang = @MaDonHang";
                SqlParameter[] checkHoaDonParams = new SqlParameter[]
                {
            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                };

                // Kiểm tra kết quả
                DataTable checkHoaDonResult = Connect.readData(checkHoaDonSql, checkHoaDonParams);
                if (Convert.ToInt32(checkHoaDonResult.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Mã đơn hàng không tồn tại trong bảng Donhang.");
                    return;
                }

                // Bước 2: Kiểm tra số lượng thuốc trong kho
                string checkThuocSql = "SELECT SoLuong FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlParameter[] checkThuocParams = new SqlParameter[]
                {
            new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc }
                };

                DataTable thuocData = Connect.readData(checkThuocSql, checkThuocParams);
                if (thuocData.Rows.Count > 0)
                {
                    float soLuongTrongKho = Convert.ToSingle(thuocData.Rows[0]["SoLuong"]);

                    // Nếu số lượng yêu cầu lớn hơn số lượng trong kho, trả thông báo và dừng lại
                    if (soLuong > soLuongTrongKho)
                    {
                        MessageBox.Show("Số lượng thuốc yêu cầu vượt quá số lượng hiện có trong kho.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Thuốc không tồn tại trong kho.");
                    return;
                }

                // Bước 3: Thêm một hàng mới vào ChiTietDonHang với Soluong
                string sqlInsert = "INSERT INTO ChiTietDonHang (ID_DonHang, ID_Thuoc, TenThuoc, GiaBan, Soluong) " +
                                   "VALUES (@MaDonHang, @MaThuoc, @TenThuoc, @GiaBan, @Soluong)";

                SqlParameter[] insertParameters = new SqlParameter[]
                {
            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang },
            new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc },
            new SqlParameter("@TenThuoc", SqlDbType.VarChar, 255) { Value = tenThuoc },
            new SqlParameter("@GiaBan", SqlDbType.Decimal) { Value = giaBan },
            new SqlParameter("@Soluong", SqlDbType.Float) { Value = soLuong }
                };

                Connect.NoneQuery(sqlInsert, insertParameters);

                // Bước 4: Cập nhật TongTien trong bảng Donhang dựa trên GiaBan * Soluong
                string sqlUpdateTongTien = "UPDATE Donhang SET TongTien = (SELECT SUM(GiaBan * Soluong) FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang) " +
                                           "WHERE ID_DonHang = @MaDonHang";

                SqlParameter[] updateParameters = new SqlParameter[]
                {
            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                };

                Connect.NoneQuery(sqlUpdateTongTien, updateParameters);

                // Bước 5: Cập nhật số lượng thuốc trong bảng Thuoc, trừ đi số lượng đã đặt
                string sqlUpdateThuoc = "UPDATE Thuoc SET SoLuong = SoLuong - @SoLuong WHERE MaThuoc = @MaThuoc";
                SqlParameter[] updateThuocParams = new SqlParameter[]
                {
            new SqlParameter("@SoLuong", SqlDbType.Float) { Value = soLuong },
            new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc }
                };

                Connect.NoneQuery(sqlUpdateThuoc, updateThuocParams);

                GetAll();
                MessageBox.Show("Chi tiết đơn hàng đã được thêm thành công, tổng tiền và số lượng thuốc đã được cập nhật.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết đơn hàng: " + ex.Message);
            }
        }

        public (string TenThuoc, decimal GiaBan) GetTenThuocByMaThuoc(int maThuoc)
        {
            string tenThuoc = string.Empty;
            decimal giaBan = 0;
            string sql = "SELECT TenThuoc, GiaBan FROM Thuoc WHERE MaThuoc = @MaThuoc";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc },
                };

                DataTable dt = Connect.readData(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    tenThuoc = dt.Rows[0]["TenThuoc"].ToString();
                    giaBan = Convert.ToDecimal(dt.Rows[0]["GiaBan"]);
                }
                else
                {
                    tenThuoc = "Không tìm thấy thuốc";
                }
            }
            catch (Exception ex)
            {
                tenThuoc = "Lỗi khi lấy thông tin thuốc: " + ex.Message;
            }

            return (tenThuoc, giaBan);
        }
        public void UpdateChiTietDonHang(int maDonHang, int maThuoc, string tenThuoc, decimal giaBan, float soLuongMoi)
        {
            try
            {
                // Bước 1: Kiểm tra số lượng thuốc hiện có trong kho
                string checkThuocSql = "SELECT SoLuong FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlParameter[] checkThuocParams = new SqlParameter[]
                {
            new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc }
                };

                DataTable thuocData = Connect.readData(checkThuocSql, checkThuocParams);
                if (thuocData.Rows.Count > 0)
                {
                    float soLuongTrongKho = Convert.ToSingle(thuocData.Rows[0]["SoLuong"]);

                    // Nếu số lượng yêu cầu lớn hơn số lượng trong kho, trả thông báo và dừng lại
                    if (soLuongMoi > soLuongTrongKho)
                    {
                        MessageBox.Show("Số lượng thuốc yêu cầu vượt quá số lượng hiện có trong kho.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Thuốc không tồn tại trong kho.");
                    return;
                }

                // Bước 2: Lấy số lượng cũ trong ChiTietDonHang để tính chênh lệch
                string checkSql = "SELECT Soluong FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang AND ID_Thuoc = @MaThuoc";
                SqlParameter[] checkParameters = new SqlParameter[]
                {
            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang },
            new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc }
                };

                DataTable dt = Connect.readData(checkSql, checkParameters);

                if (dt.Rows.Count > 0)
                {
                    float soLuongCu = Convert.ToSingle(dt.Rows[0]["Soluong"]);

                    // Bước 3: Cập nhật thông tin chi tiết đơn hàng
                    string updateSql = "UPDATE ChiTietDonHang SET TenThuoc = @TenThuoc, GiaBan = @GiaBan, Soluong = @SoLuongMoi " +
                                       "WHERE ID_DonHang = @MaDonHang AND ID_Thuoc = @MaThuoc";

                    SqlParameter[] updateParameters = new SqlParameter[]
                    {
                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang },
                new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc },
                new SqlParameter("@TenThuoc", SqlDbType.VarChar, 255) { Value = tenThuoc },
                new SqlParameter("@GiaBan", SqlDbType.Decimal) { Value = giaBan },
                new SqlParameter("@SoLuongMoi", SqlDbType.Float) { Value = soLuongMoi }
                    };

                    Connect.NoneQuery(updateSql, updateParameters);

                    // Bước 4: Cập nhật số lượng thuốc trong bảng Thuoc dựa trên sự thay đổi số lượng
                    float chenhLechSoLuong = soLuongCu - soLuongMoi;
                    string updateThuocSql = "UPDATE Thuoc SET SoLuong = SoLuong + @ChenhLechSoLuong WHERE ID_Thuoc = @MaThuoc";

                    SqlParameter[] updateThuocParams = new SqlParameter[]
                    {
                new SqlParameter("@ChenhLechSoLuong", SqlDbType.Float) { Value = -chenhLechSoLuong },
                new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc }
                    };

                    Connect.NoneQuery(updateThuocSql, updateThuocParams);

                    // Bước 5: Cập nhật lại tổng tiền trong bảng Donhang
                    string sqlUpdateTongTien = "UPDATE Donhang SET TongTien = " +
                                               "(SELECT ISNULL(SUM(GiaBan * Soluong), 0) FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang) " +
                                               "WHERE ID_DonHang = @MaDonHang";

                    SqlParameter[] updateTongTienParams = new SqlParameter[]
                    {
                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                    };

                    Connect.NoneQuery(sqlUpdateTongTien, updateTongTienParams);

                    MessageBox.Show("Chi tiết đơn hàng đã được cập nhật thành công, tổng tiền và số lượng thuốc đã được điều chỉnh.");
                }
                else
                {
                    MessageBox.Show("Mã đơn hàng hoặc thuốc không tồn tại trong chi tiết đơn hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chi tiết đơn hàng: " + ex.Message);
            }
        }



        public void UpdateDonHangtt(int maDonHang, DateTime ngayDatHang, string soDienThoai, string tenKhachHang)
        {
            try
            {
                // Kiểm tra xem mã đơn hàng có tồn tại không
                string checkSql = "SELECT COUNT(*) FROM Donhang WHERE ID_DonHang = @MaDonHang";
                SqlParameter[] checkParameters = new SqlParameter[]
                {
            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                };

                DataTable dt = Connect.readData(checkSql, checkParameters);

                if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    // Lấy tổng tiền từ bảng ChiTietDonHang
                    string sqlGetTongTien = "SELECT SUM(GiaBan) FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang";
                    SqlParameter[] totalParameters = new SqlParameter[]
                    {
                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                    };

                    DataTable totalDt = Connect.readData(sqlGetTongTien, totalParameters);
                    decimal tongTien = 0;

                    // Kiểm tra và lấy tổng tiền
                    if (totalDt.Rows.Count > 0 && totalDt.Rows[0][0] != DBNull.Value)
                    {
                        tongTien = Convert.ToDecimal(totalDt.Rows[0][0]);
                    }

                    // Cập nhật tổng tiền vào bảng Donhang
                    string sqlUpdateTongTien = "UPDATE Donhang SET TongTien = @TongTien WHERE ID_DonHang = @MaDonHang";
                    SqlParameter[] updateTongTienParameters = new SqlParameter[]
                    {
                new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = tongTien },
                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                    };

                    Connect.NoneQuery(sqlUpdateTongTien, updateTongTienParameters);

                    // Cập nhật các thông tin khác của đơn hàng
                    string updateSql = "UPDATE Donhang SET NgayDatHang = @NgayDatHang, SoDienThoai = @SoDienThoai, " +
                                       "TenKhachHang = @TenKhachHang WHERE ID_DonHang = @MaDonHang";

                    SqlParameter[] updateParameters = new SqlParameter[]
                    {
                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang },
                new SqlParameter("@NgayDatHang", SqlDbType.Date) { Value = ngayDatHang },
                new SqlParameter("@SoDienThoai", SqlDbType.VarChar, 20) { Value = soDienThoai },
                new SqlParameter("@TenKhachHang", SqlDbType.VarChar, 100) { Value = tenKhachHang }
                    };

                    // Thực hiện câu lệnh Update
                    Connect.NoneQuery(updateSql, updateParameters);
                    MessageBox.Show("Thông tin đơn hàng đã được cập nhật thành công.");
                }
                else
                {
                    MessageBox.Show("Mã đơn hàng không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin đơn hàng: " + ex.Message);
            }
        }

        public void DeleteDonHang(int maDonHang)
        {
            try
            {
                // Kiểm tra xem mã đơn hàng có tồn tại trong bảng Donhang không
                string checkSql = "SELECT COUNT(*) FROM Donhang WHERE ID_DonHang = @MaDonHang";
                SqlParameter[] checkParameters = new SqlParameter[]
                {
            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                };

                DataTable dt = Connect.readData(checkSql, checkParameters);

                // Kiểm tra xem đơn hàng có tồn tại không
                if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    // Bước 1: Xóa chi tiết đơn hàng trong bảng ChiTietDonHang
                    string deleteDetailSql = "DELETE FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang";
                    SqlParameter[] deleteDetailParameters = new SqlParameter[]
                    {
                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                    };

                    Connect.NoneQuery(deleteDetailSql, deleteDetailParameters);

                    // Bước 2: Xóa đơn hàng trong bảng Donhang
                    string deleteOrderSql = "DELETE FROM Donhang WHERE ID_DonHang = @MaDonHang";
                    SqlParameter[] deleteOrderParameters = new SqlParameter[]
                    {
                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                    };

                    Connect.NoneQuery(deleteOrderSql, deleteOrderParameters);

                    MessageBox.Show("Đơn hàng và chi tiết đơn hàng đã được xóa thành công.");
                }
                else
                {
                    MessageBox.Show("Mã đơn hàng không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đơn hàng: " + ex.Message);
            }
        }
        public void DeleteChiTietDonHang(int maDonHang)
        {
            try
            {
                // Bước 1: Lấy mã chi tiết đơn hàng từ cột đầu tiên trong bảng display_qldh
                string getChiTietSql = "SELECT TOP 1 ID_ChiTiet FROM display_qldh WHERE ID_DonHang = @MaDonHang";
                SqlParameter[] getChiTietParameters = new SqlParameter[]
                {
            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                };

                DataTable dt = Connect.readData(getChiTietSql, getChiTietParameters);

                if (dt.Rows.Count > 0)
                {
                    // Lấy mã chi tiết đầu tiên
                    int maChiTiet = Convert.ToInt32(dt.Rows[0]["ID_ChiTiet"]);

                    // Bước 2: Kiểm tra chi tiết đơn hàng có tồn tại không
                    string checkSql = "SELECT COUNT(*) FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang AND ID_ChiTiet = @MaChiTiet";
                    SqlParameter[] checkParameters = new SqlParameter[]
                    {
                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang },
                new SqlParameter("@MaChiTiet", SqlDbType.Int) { Value = maChiTiet }
                    };

                    DataTable checkData = Connect.readData(checkSql, checkParameters);

                    // Nếu chi tiết đơn hàng tồn tại, thực hiện xóa
                    if (checkData.Rows.Count > 0 && Convert.ToInt32(checkData.Rows[0][0]) > 0)
                    {
                        // Bước 3: Lấy số lượng và giá tiền của chi tiết đơn hàng để tính toán tổng tiền
                        string getDetailSql = "SELECT SoLuong, GiaTien FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang AND ID_ChiTiet = @MaChiTiet";
                        DataTable detailData = Connect.readData(getDetailSql, checkParameters);

                        int soLuong = Convert.ToInt32(detailData.Rows[0]["SoLuong"]);
                        decimal giaTien = Convert.ToDecimal(detailData.Rows[0]["GiaTien"]);
                        decimal totalAmount = soLuong * giaTien;

                        // Bước 4: Xóa chi tiết đơn hàng
                        string deleteDetailSql = "DELETE FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang AND ID_ChiTiet = @MaChiTiet";
                        Connect.NoneQuery(deleteDetailSql, checkParameters);

                        // Bước 5: Cập nhật lại tổng tiền của đơn hàng sau khi xóa chi tiết
                        string getTotalAmountSql = "SELECT SUM(SoLuong * GiaTien) FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang";
                        decimal newTotalAmount = Convert.ToDecimal(Connect.readData(getTotalAmountSql, new SqlParameter[] { new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang } }).Rows[0][0]);

                        string updateDonHangSql = "UPDATE Donhang SET TongTien = @TongTien WHERE ID_DonHang = @MaDonHang";
                        SqlParameter[] updateParameters = new SqlParameter[]
                        {
                    new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = newTotalAmount },
                    new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                        };

                        // Cập nhật tổng tiền cho đơn hàng
                        Connect.NoneQuery(updateDonHangSql, updateParameters);

                        MessageBox.Show("Chi tiết đơn hàng đã được xóa và tổng tiền của đơn hàng đã được cập nhật.");
                    }
                    else
                    {
                        MessageBox.Show("Chi tiết đơn hàng không tồn tại.");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chi tiết đơn hàng trong bảng display_qldh.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết đơn hàng: " + ex.Message);
            }
        }

        public DataTable GetDonHangByMaDonHang(int maDonHang)
        {
            // Câu lệnh SQL để tìm kiếm đơn hàng theo mã đơn hàng
            string sql = "SELECT * FROM Donhang WHERE ID_DonHang = @MaDonHang";

            // Các tham số để thay thế trong câu lệnh SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
            };

            // Thực hiện câu lệnh truy vấn và trả về kết quả dưới dạng DataTable
            DataTable dt = Connect.readData(sql, parameters);

            return dt;
        }

        public DataTable GetDonHangByMa(string maDonHang)
        {
            string sql = "SELECT NgayDatHang, TongTien, SoDienThoai, TenKhachHang FROM Donhang WHERE ID_DonHang = @MaDonHang";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDonHang", SqlDbType.VarChar, 50) { Value = maDonHang }
            };

            return Connect.readData(sql, parameters);
        }

        public DataTable GetChiTietDonHangByMa(string maDonHang)
        {
            string sql = "SELECT ID_DonHang, TenThuoc, Soluong, GiaBan FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaDonHang", SqlDbType.VarChar, 50) { Value = maDonHang }
            };

            return Connect.readData(sql, parameters);
        }

    }
}
