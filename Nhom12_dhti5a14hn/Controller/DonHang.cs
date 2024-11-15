using Nhom12_dhti5a14hn.Connect;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class DonHang
    {
        private connect Connect;

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
            string checkCustomerSql = "SELECT COUNT(*) FROM KhachHang WHERE SoDienThoai = @SoDienThoai";
            SqlParameter[] checkCustomerParameters = new SqlParameter[]
            {
                new SqlParameter("@SoDienThoai", SqlDbType.VarChar, 20) { Value = soDienThoai }
            };

            DataTable customerDt = Connect.readData(checkCustomerSql, checkCustomerParameters);
            if (customerDt.Rows.Count > 0 && Convert.ToInt32(customerDt.Rows[0][0]) == 0)
            {
                string insertCustomerSql = "INSERT INTO KhachHang (TenKhachHang, SoDienThoai) VALUES (@TenKhachHang, @SoDienThoai)";
                SqlParameter[] insertCustomerParameters = new SqlParameter[]
                {
            new SqlParameter("@TenKhachHang", SqlDbType.VarChar, 100) { Value = tenKhachHang },
            new SqlParameter("@SoDienThoai", SqlDbType.VarChar, 20) { Value = soDienThoai }
                };

                Connect.NoneQuery(insertCustomerSql, insertCustomerParameters);
                MessageBox.Show("Khách hàng mới đã được thêm thành công!");
            }
            string checkSql = "SELECT COUNT(*) FROM Donhang WHERE ID_DonHang = @MaDonHang";
            SqlParameter[] checkParameters = new SqlParameter[]
            {
        new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
            };

            DataTable dt = Connect.readData(checkSql, checkParameters);

            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                MessageBox.Show("Mã đơn hàng này đã tồn tại. Vui lòng chọn mã khác.");
            }
            else
            {
                string sql = "INSERT INTO Donhang (ID_DonHang, NgayDatHang, TongTien, SoDienThoai, TenKhachHang) " +
                             "VALUES (@MaDonHang, @NgayDatHang, 0, @SoDienThoai, @TenKhachHang)";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang },
            new SqlParameter("@NgayDatHang", SqlDbType.Date) { Value = ngayDatHang },
            new SqlParameter("@SoDienThoai", SqlDbType.VarChar, 20) { Value = soDienThoai },
            new SqlParameter("@TenKhachHang", SqlDbType.VarChar, 100) { Value = tenKhachHang }
                };

                Connect.NoneQuery(sql, parameters);
                MessageBox.Show("Đơn hàng đã được thêm thành công!");
            }
        }

        public void CreateDH(int maDonHang, int maThuoc, string tenThuoc, decimal giaBan, float soLuong)
        {
            try
            {
                if (IsOrderPaid(maDonHang))
                {
                    MessageBox.Show("Đơn hàng đã được thanh toán, không thể thêm chi tiết.");
                    return;
                }
                string checkHoaDonSql = "SELECT COUNT(*) FROM Donhang WHERE ID_DonHang = @MaDonHang";
                SqlParameter[] checkHoaDonParams = new SqlParameter[]
                {
                    new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                };

                DataTable checkHoaDonResult = Connect.readData(checkHoaDonSql, checkHoaDonParams);
                if (Convert.ToInt32(checkHoaDonResult.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Mã đơn hàng không tồn tại trong bảng Donhang.");
                    return;
                }

                string checkThuocSql = "SELECT SoLuong FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlParameter[] checkThuocParams = new SqlParameter[]
                {
                    new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc }
                };

                DataTable thuocData = Connect.readData(checkThuocSql, checkThuocParams);
                if (thuocData.Rows.Count > 0)
                {
                    float soLuongTrongKho = Convert.ToSingle(thuocData.Rows[0]["SoLuong"]);

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

                string sqlUpdateTongTien = "UPDATE Donhang SET TongTien = (SELECT SUM(GiaBan * Soluong) FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang) " +
                                           "WHERE ID_DonHang = @MaDonHang";

                SqlParameter[] updateParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                };

                Connect.NoneQuery(sqlUpdateTongTien, updateParameters);

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
                if (IsOrderPaid(maDonHang))
                {
                    MessageBox.Show("Đơn hàng đã được thanh toán, không thể thêm chi tiết.");
                    return;
                }

                // Check quantity in stock
                string checkThuocSql = "SELECT SoLuong FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlParameter[] checkThuocParams = new SqlParameter[]
                {
                    new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc }
                };

                DataTable thuocData = Connect.readData(checkThuocSql, checkThuocParams);
                float soLuongTrongKho = thuocData.Rows.Count > 0 && thuocData.Rows[0]["SoLuong"] != DBNull.Value
                    ? Convert.ToSingle(thuocData.Rows[0]["SoLuong"])
                    : 0;

                if (soLuongMoi > soLuongTrongKho)
                {
                    MessageBox.Show("Số lượng thuốc yêu cầu vượt quá số lượng hiện có trong kho.");
                    return;
                }

                // Check if order item already exists
                string checkSql = "SELECT Soluong FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang AND ID_Thuoc = @MaThuoc";
                SqlParameter[] checkParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang },
                    new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc }
                };

                DataTable dt = Connect.readData(checkSql, checkParameters);
                float soLuongCu = dt.Rows.Count > 0 && dt.Rows[0]["Soluong"] != DBNull.Value
                    ? Convert.ToSingle(dt.Rows[0]["Soluong"])
                    : 0;

                if (dt.Rows.Count > 0)
                {
                    // Update existing order item
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

                    // Adjust stock quantity based on difference
                    float chenhLechSoLuong = soLuongCu - soLuongMoi;
                    string updateThuocSql = "UPDATE Thuoc SET SoLuong = SoLuong + @ChenhLechSoLuong WHERE MaThuoc = @MaThuoc";

                    SqlParameter[] updateThuocParams = new SqlParameter[]
                    {
                        new SqlParameter("@ChenhLechSoLuong", SqlDbType.Float) { Value = -chenhLechSoLuong },
                        new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc }
                    };

                    Connect.NoneQuery(updateThuocSql, updateThuocParams);

                    // Update total price in Donhang table
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
                string checkSql = "SELECT COUNT(*) FROM Donhang WHERE ID_DonHang = @MaDonHang";
                SqlParameter[] checkParameters = new SqlParameter[]
                {
            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                };

                DataTable dt = Connect.readData(checkSql, checkParameters);

                if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
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
                string checkSql = "SELECT COUNT(*) FROM Donhang WHERE ID_DonHang = @MaDonHang";
                SqlParameter[] checkParameters = new SqlParameter[]
                {
            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                };

                DataTable dt = Connect.readData(checkSql, checkParameters);

                if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    string checkPhanHoiSql = "SELECT COUNT(*) FROM PhanHoi WHERE ID_DonHang = @MaDonHang";
                    SqlParameter[] checkPhanHoiParameters = new SqlParameter[]
                    {
                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                    };

                    DataTable phanHoiDt = Connect.readData(checkPhanHoiSql, checkPhanHoiParameters);

                    if (Convert.ToInt32(phanHoiDt.Rows[0][0]) > 0)
                    {
                        DialogResult result = MessageBox.Show(
                            "Đơn hàng này đã thanh toán và có thông tin phản hồi. Bạn có muốn xóa cả thông tin phản hồi không?",
                            "Xác nhận xóa thông tin phản hồi",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            string deletePhanHoiSql = "DELETE FROM PhanHoi WHERE ID_DonHang = @MaDonHang";
                            SqlParameter[] deletePhanHoiParameters = new SqlParameter[]
                            {
                            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                            };

                            Connect.NoneQuery(deletePhanHoiSql, deletePhanHoiParameters);
                            string deleteDetailSql = "DELETE FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang";

                            SqlParameter[] deleteDetailParameters = new SqlParameter[]
                            {
                                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                            };

                            Connect.NoneQuery(deleteDetailSql, deleteDetailParameters);

                            string deleteOrderSql = "DELETE FROM Donhang WHERE ID_DonHang = @MaDonHang";
                            SqlParameter[] deleteOrderParameters = new SqlParameter[]
                            {
                                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                            };

                            Connect.NoneQuery(deleteOrderSql, deleteOrderParameters);

                            MessageBox.Show("Đơn hàng và chi tiết đơn hàng đã được xóa thành công.");
                        }
                    }
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
                if (IsOrderPaid(maDonHang))
                {
                    MessageBox.Show("Đơn hàng đã được thanh toán, không thể xoá chi tiết.");
                    return;
                }

                string getChiTietSql = "SELECT TOP 1 ID FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang";
                SqlParameter[] getChiTietParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                };

                DataTable dt = Connect.readData(getChiTietSql, getChiTietParameters);

                if (dt.Rows.Count > 0)
                {
                    int maChiTiet = Convert.ToInt32(dt.Rows[0]["ID"]);

                    string checkSql = "SELECT COUNT(*) FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang AND ID = @MaChiTiet";
                    SqlParameter[] checkParameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang },
                        new SqlParameter("@MaChiTiet", SqlDbType.Int) { Value = maChiTiet }
                    };

                    DataTable checkData = Connect.readData(checkSql, checkParameters);

                    if (checkData.Rows.Count > 0 && Convert.ToInt32(checkData.Rows[0][0]) > 0)
                    {
                        string getDetailSql = "SELECT SoLuong, GiaBan FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang AND ID = @MaChiTiet";
                        SqlParameter[] getDetailParameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang },
                            new SqlParameter("@MaChiTiet", SqlDbType.Int) { Value = maChiTiet }
                        };

                        DataTable detailData = Connect.readData(getDetailSql, getDetailParameters);

                        int soLuong = Convert.ToInt32(detailData.Rows[0]["SoLuong"]);
                        decimal giaTien = Convert.ToDecimal(detailData.Rows[0]["GiaBan"]);
                        decimal totalAmount = soLuong * giaTien;

                        string deleteDetailSql = "DELETE FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang AND ID = @MaChiTiet";
                        Connect.NoneQuery(deleteDetailSql, getDetailParameters);

                        string getTotalAmountSql = "SELECT SUM(SoLuong * GiaBan) FROM ChiTietDonHang WHERE ID_DonHang = @MaDonHang";
                        SqlParameter[] getTotalAmountParameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                        };

                        decimal newTotalAmount = Convert.ToDecimal(Connect.readData(getTotalAmountSql, getTotalAmountParameters).Rows[0][0]);

                        string updateDonHangSql = "UPDATE Donhang SET TongTien = @TongTien WHERE ID_DonHang = @MaDonHang";
                        SqlParameter[] updateParameters = new SqlParameter[]
                        {
                            new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = newTotalAmount },
                            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                        };

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
                    MessageBox.Show("Không tìm thấy chi tiết đơn hàng trong bảng Chi tiết đơn hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết đơn hàng: " + ex.Message);
            }
        }

        public DataTable GetDonHangByMaDonHang(int maDonHang)
        {
            string sql = "SELECT * FROM Donhang WHERE ID_DonHang = @MaDonHang";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
            };

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

        public void MarkOrderAsPaid(int maDonHang)
        {
            try
            {
                string sql = "UPDATE Donhang SET TrangThaiThanhToan = 1 WHERE ID_DonHang = @MaDonHang";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                };

                Connect.NoneQuery(sql, parameters);
                MessageBox.Show("Đơn hàng đã được đánh dấu là đã thanh toán.");

                GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đánh dấu đơn hàng là đã thanh toán: " + ex.Message);
            }
        }

        public void MarkOrderAsUnpaid(int maDonHang)
        {
            try
            {
                string sql = "UPDATE Donhang SET TrangThaiThanhToan = 0 WHERE ID_DonHang = @MaDonHang";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
                };

                Connect.NoneQuery(sql, parameters);
                MessageBox.Show("Đơn hàng đã được đánh dấu là chưa thanh toán.");

                GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đánh dấu đơn hàng là chưa thanh toán: " + ex.Message);
            }
        }

        public bool IsOrderPaid(int maDonHang)
        {
            string sql = @"
                            SELECT
                                CASE
                                    WHEN TrangThaiThanhToan = 1 OR EXISTS (SELECT 1 FROM PhanHoi WHERE ID_DonHang = @MaDonHang)
                                    THEN 1
                                    ELSE 0
                                END AS IsPaid
                            FROM Donhang
                            WHERE ID_DonHang = @MaDonHang";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaDonHang", SqlDbType.Int) { Value = maDonHang }
            };

            DataTable dt = Connect.readData(sql, parameters);
            return dt.Rows.Count > 0 && Convert.ToBoolean(dt.Rows[0]["IsPaid"]);
        }
    }
}