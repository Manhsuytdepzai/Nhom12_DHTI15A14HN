using Nhom12_dhti5a14hn.Connect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class ChiTietPhieuNhap
    {
        connect Connect;
        public ChiTietPhieuNhap()
        {
            Connect = new connect();
        }

        public DataTable GetAllCTPN()
        {
            string sql = "select * from ChiTietPhieuNhap";
            return Connect.readData(sql);
        }
        public void InsertChiTietPhieuNhap(int soLuong, decimal donGia, int idThuoc, int idPhieuNhap)
        {
            try
            {
                // Kiểm tra xem mã thuốc đã tồn tại trong bảng Thuoc chưa
                string checkThuocSql = "SELECT COUNT(*) FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlParameter[] checkThuocParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = idThuoc }
                };

                int count = Convert.ToInt32(Connect.readData(checkThuocSql, checkThuocParameters).Rows[0][0]);

                if (count == 0)
                {
                    // Nếu mã thuốc không tồn tại, hiển thị thông báo và yêu cầu chuyển đến trang quản lý thuốc
                    DialogResult result = MessageBox.Show("Mã thuốc không tồn tại trong kho. Bạn có muốn chuyển đến trang quản lý thuốc để thêm mới không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Chuyển đến trang quản lý thuốc (Form2)
                        Form2 form2 = new Form2();
                        form2.Show();
                    }
                    return; // Dừng phương thức nếu mã thuốc không tồn tại
                }

                // Nếu mã thuốc tồn tại, lấy giá nhập của thuốc từ bảng Thuoc
                string getDonGiaSql = "SELECT GiaNhap FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlParameter[] getDonGiaParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = idThuoc }
                };

                decimal giaNhap = Convert.ToDecimal(Connect.readData(getDonGiaSql, getDonGiaParameters).Rows[0]["GiaNhap"]);

                // Kiểm tra nếu donGia nhập vào khác với giaNhap
                if (donGia != giaNhap)
                {
                    // Thông báo người dùng về sự thay đổi giá trị thuốc
                    DialogResult result = MessageBox.Show("Giá nhập vào khác với giá hiện tại của thuốc trong kho. Vui lòng chuyển đến trang quản lý thuốc để tạo mã thuốc mới.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Chuyển đến trang quản lý thuốc (Form2)
                        Form2 form2 = new Form2();
                        form2.Show();
                    }
                    return; // Dừng phương thức nếu giá nhập vào khác với giá hiện tại
                }

                // Nếu mã thuốc tồn tại và giá nhập khớp, tiếp tục với việc thêm chi tiết phiếu nhập
                donGia = giaNhap; // Cập nhật lại donGia bằng giaNhap lấy từ bảng Thuoc

                // Tính tổng tiền của chi tiết phiếu nhập
                decimal tongTienChiTiet = soLuong * donGia;

                // Câu lệnh SQL để thêm chi tiết phiếu nhập
                string insertChiTietSql = @"
                                            INSERT INTO ChiTietPhieuNhap (SoLuong, DonGia, NgayNhap, ID_Thuoc, ID_PhieuNhap) 
                                            VALUES (@SoLuong, @DonGia, @NgayNhap, @ID_Thuoc, @ID_PhieuNhap)";

                SqlParameter[] chiTietParameters = new SqlParameter[]
                {
                    new SqlParameter("@SoLuong", SqlDbType.Int) { Value = soLuong },
                    new SqlParameter("@DonGia", SqlDbType.Decimal) { Value = donGia },
                    new SqlParameter("@NgayNhap", SqlDbType.Date) { Value = DateTime.Now },
                    new SqlParameter("@ID_Thuoc", SqlDbType.Int) { Value = idThuoc },
                    new SqlParameter("@ID_PhieuNhap", SqlDbType.Int) { Value = idPhieuNhap }
                };

                Connect.NoneQuery(insertChiTietSql, chiTietParameters);

                // Cập nhật tổng tiền của phiếu nhập tương ứng
                string updatePhieuNhapSql = @"
                                                UPDATE PhieuNhap 
                                                SET TongTien = TongTien + @TongTienChiTiet 
                                                WHERE ID_PhieuNhap = @ID_PhieuNhap";

                SqlParameter[] updatePhieuNhapParameters = new SqlParameter[]
                {
                    new SqlParameter("@TongTienChiTiet", SqlDbType.Decimal) { Value = tongTienChiTiet },
                    new SqlParameter("@ID_PhieuNhap", SqlDbType.Int) { Value = idPhieuNhap }
                };

                // Thực hiện cập nhật tổng tiền cho phiếu nhập
                Connect.NoneQuery(updatePhieuNhapSql, updatePhieuNhapParameters);

                MessageBox.Show("Thêm chi tiết phiếu nhập thành công và cập nhật tổng tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public (string TenThuoc, decimal GiaBan) GetTenThuocByMaThuoc(int maThuoc)
        {
            string tenThuoc = string.Empty;
            decimal giaBan = 0;
            string sql = "SELECT TenThuoc, GiaNhap FROM Thuoc WHERE MaThuoc = @MaThuoc";

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
                    giaBan = Convert.ToDecimal(dt.Rows[0]["GiaNhap"]);
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
        public void UpdateChiTietPhieuNhap(int idChiTietPhieuNhap, int soLuong, int idThuoc, int idPhieuNhap, decimal donGia)
        {
            try
            {
                // Kiểm tra xem mã thuốc có tồn tại trong bảng Thuoc không
                string checkThuocSql = "SELECT COUNT(*) FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlParameter[] checkThuocParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = idThuoc }
                };

                int count = Convert.ToInt32(Connect.readData(checkThuocSql, checkThuocParameters).Rows[0][0]);

                if (count == 0)
                {
                    // Nếu mã thuốc không tồn tại, hiển thị thông báo và yêu cầu chuyển đến trang quản lý thuốc
                    DialogResult result = MessageBox.Show("Mã thuốc không tồn tại trong kho. Bạn có muốn chuyển đến trang quản lý thuốc để thêm mới không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Chuyển đến trang quản lý thuốc (Form2)
                        Form2 form2 = new Form2();
                        form2.Show();
                    }
                    return; // Dừng phương thức nếu mã thuốc không tồn tại
                }

                // Lấy giá nhập của thuốc mới từ bảng Thuoc
                string getDonGiaSql = "SELECT GiaNhap FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlParameter[] getDonGiaParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = idThuoc }
                };

                decimal giaNhap = Convert.ToDecimal(Connect.readData(getDonGiaSql, getDonGiaParameters).Rows[0]["GiaNhap"]);

                // Nếu giá nhập vào không bằng giá nhập trong kho, thông báo cho người dùng
                if (donGia != giaNhap)
                {
                    DialogResult result = MessageBox.Show("Giá nhập vào khác với giá hiện tại của thuốc trong kho. Bạn có muốn tiếp tục không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return; // Dừng phương thức nếu người dùng không muốn tiếp tục
                    }
                }

                // Cập nhật lại giá trị DonGia nếu cần
                donGia = giaNhap; // Cập nhật lại DonGia bằng giá nhập từ bảng Thuoc nếu cần

                // Tính tổng tiền cho chi tiết phiếu nhập
                decimal tongTienChiTiet = soLuong * donGia;

                // Cập nhật chi tiết phiếu nhập
                string updateChiTietSql = @"
                                            UPDATE ChiTietPhieuNhap 
                                            SET SoLuong = @SoLuong, 
                                                ID_Thuoc = @ID_Thuoc, 
                                                DonGia = @DonGia 
                                            WHERE ID_ChiTietPhieuNhap = @ID_ChiTietPhieuNhap";

                SqlParameter[] updateChiTietParameters = new SqlParameter[]
                {
                    new SqlParameter("@SoLuong", SqlDbType.Int) { Value = soLuong },
                    new SqlParameter("@ID_Thuoc", SqlDbType.Int) { Value = idThuoc },
                    new SqlParameter("@DonGia", SqlDbType.Decimal) { Value = donGia },
                    new SqlParameter("@ID_ChiTietPhieuNhap", SqlDbType.Int) { Value = idChiTietPhieuNhap }
                };

                Connect.NoneQuery(updateChiTietSql, updateChiTietParameters);

                // Cập nhật tổng tiền cho phiếu nhập
                string updatePhieuNhapSql = @"
                                                UPDATE PhieuNhap 
                                                SET TongTien = TongTien + @TongTienChiTiet 
                                                WHERE ID_PhieuNhap = @ID_PhieuNhap";

                SqlParameter[] updatePhieuNhapParameters = new SqlParameter[]
                {
                    new SqlParameter("@TongTienChiTiet", SqlDbType.Decimal) { Value = tongTienChiTiet },
                    new SqlParameter("@ID_PhieuNhap", SqlDbType.Int) { Value = idPhieuNhap }
                };

                // Thực hiện cập nhật tổng tiền cho phiếu nhập
                Connect.NoneQuery(updatePhieuNhapSql, updatePhieuNhapParameters);

                MessageBox.Show("Cập nhật chi tiết phiếu nhập thành công và cập nhật tổng tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chi tiết phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DeleteChiTietPhieuNhap(int idChiTietPhieuNhap, int idPhieuNhap)
        {
            try
            {
                string getChiTietSql = "SELECT SoLuong, DonGia FROM ChiTietPhieuNhap WHERE ID_ChiTietPhieuNhap = @ID_ChiTietPhieuNhap";
                SqlParameter[] getChiTietParameters = new SqlParameter[]
                {
            new SqlParameter("@ID_ChiTietPhieuNhap", SqlDbType.Int) { Value = idChiTietPhieuNhap }
                };

                DataTable dt = Connect.readData(getChiTietSql, getChiTietParameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy chi tiết phiếu nhập để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy số lượng và đơn giá từ chi tiết phiếu nhập
                int soLuong = Convert.ToInt32(dt.Rows[0]["SoLuong"]);
                decimal donGia = Convert.ToDecimal(dt.Rows[0]["DonGia"]);

                // Tính tổng tiền của chi tiết phiếu nhập cần xóa
                decimal tongTienChiTiet = soLuong * donGia;

                // Xóa chi tiết phiếu nhập
                string deleteChiTietSql = "DELETE FROM ChiTietPhieuNhap WHERE ID_ChiTietPhieuNhap = @ID_ChiTietPhieuNhap";
                SqlParameter[] deleteChiTietParameters = new SqlParameter[]
                {
            new SqlParameter("@ID_ChiTietPhieuNhap", SqlDbType.Int) { Value = idChiTietPhieuNhap }
                };

                Connect.NoneQuery(deleteChiTietSql, deleteChiTietParameters);

                // Cập nhật lại tổng tiền của phiếu nhập sau khi xóa chi tiết
                string updatePhieuNhapSql = @"
            UPDATE PhieuNhap 
            SET TongTien = TongTien - @TongTienChiTiet 
            WHERE ID_PhieuNhap = @ID_PhieuNhap";

                SqlParameter[] updatePhieuNhapParameters = new SqlParameter[]
                {
            new SqlParameter("@TongTienChiTiet", SqlDbType.Decimal) { Value = tongTienChiTiet },
            new SqlParameter("@ID_PhieuNhap", SqlDbType.Int) { Value = idPhieuNhap }
                };

                // Thực hiện cập nhật tổng tiền cho phiếu nhập
                Connect.NoneQuery(updatePhieuNhapSql, updatePhieuNhapParameters);

                MessageBox.Show("Xóa chi tiết phiếu nhập thành công và cập nhật tổng tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable TkCTPN(int maCTPN)
        {
            string sql = "SELECT * FROM ChiTietPhieuNhap WHERE ID_ChiTietPhieuNhap = @MaCTPN";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaCTPN", SqlDbType.Int) { Value = maCTPN }
            };

            DataTable dt = Connect.readData(sql, parameters);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Chi tiết phiếu nhập không tồn tại.");
            }

            return dt;
        }

    }
}
