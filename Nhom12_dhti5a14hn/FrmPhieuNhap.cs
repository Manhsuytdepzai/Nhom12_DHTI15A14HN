using Nhom12_dhti5a14hn.Connect;
using Nhom12_dhti5a14hn.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    public partial class FrmPhieuNhap : Form
    {
        PhieuNhap pn = new PhieuNhap();
        ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
        public FrmPhieuNhap()
        {
            InitializeComponent();
            txt_tt.Enabled = false;
            txt_mapn.Enabled = false;
            
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                int? mancc = null;
                if (!string.IsNullOrEmpty(txt_mancc.Text))
                {
                    mancc = int.Parse(txt_mancc.Text);
                }
                pn.InsertPhieuNhap(mancc);
                display_pn.DataSource = pn.GetAllPn();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu nhập: " + ex.Message);
            }
        }

        private void FrmPhieuNhap_Load(object sender, EventArgs e)
        {
            display_pn.DataSource = pn.GetAllPn();
            display_ctpn.DataSource = ctpn.GetAllCTPN();
        }

        private void display_pn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = display_pn.Rows[e.RowIndex];
                    txt_mapn.Text = row.Cells["ID_PhieuNhap"].Value.ToString();
                    txt_mancc.Text = row.Cells["ID_NhaCungCap"].Value.ToString();
                    txt_tt.Text = row.Cells["TongTien"].Value.ToString();
                    int maPN = Convert.ToInt32(row.Cells["ID_PhieuNhap"].Value);

                    LoadChiTietPhieuNhap(maPN);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private void btn_suact_Click(object sender, EventArgs e)
        {
            try
            {
                int idNhaCungCap = int.Parse(txt_mancc.Text);
                decimal tongTien = decimal.Parse(txt_tt.Text);
                int idPhieuNhap = int.Parse(txt_mapn.Text);
                pn.UpdatePhieuNhap(idNhaCungCap, tongTien, idPhieuNhap);
                display_pn.DataSource = pn.GetAllPn();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa phiếu nhập: " + ex.Message);
            }
        }
        public void Clear()
        {
            txt_mapn.Clear();
            txt_mancc.Clear();
            txt_tt.Clear();
        }
        private void btn_xoact_Click(object sender, EventArgs e)
        {
            try
            {
                int idPhieuNhap = int.Parse(txt_mapn.Text);
                pn.DeletePhieuNhap(idPhieuNhap);
                display_pn.DataSource = pn.GetAllPn();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa phiếu nhập: " + ex.Message);
            }
        }

        private void themct_Click(object sender, EventArgs e)
        {
            try
            {
                int soLuong = int.Parse(txtSoLuong.Text);
                decimal donGia = decimal.Parse(txtDonGia.Text);
                int idThuoc = int.Parse(txtMaThuoc.Text);
                int idPhieuNhap = int.Parse(txt_idpn.Text);
                ctpn.InsertChiTietPhieuNhap(soLuong, donGia, idThuoc, idPhieuNhap);
                display_ctpn.DataSource = ctpn.GetAllCTPN();
                display_pn.DataSource = pn.GetAllPn();
                // Xóa các trường nhập sau khi thêm thành công
                txtSoLuong.Clear();
                txtDonGia.Clear();
                txtMaThuoc.Clear();
                txtMactpn.Clear();
                txt_idpn.Clear();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Lỗi định dạng: Vui lòng nhập đúng dữ liệu cho các trường. " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadChiTietPhieuNhap(int maPN)
        {
            string sql = "SELECT * FROM ChiTietPhieuNhap WHERE ID_PhieuNhap = @MaPN";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@MaPN", SqlDbType.Int) { Value = maPN }
            };

            connect kn = new connect();
            DataTable dt = kn.readData(sql, parameters);

            display_ctpn.DataSource = null;
            display_ctpn.DataSource = dt;
        }

        private void txtMaThuoc_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaThuoc.Text, out int maThuoc))
            {
                var (tenThuoc, giaBan) = ctpn.GetTenThuocByMaThuoc(maThuoc);

                if (!string.IsNullOrEmpty(tenThuoc) && tenThuoc != "Không tìm thấy thuốc")
                {
                    txtDonGia.Text = giaBan.ToString();
                }
                else
                {
                    txtDonGia.Clear();
                }
            }
            else
            {
                txtDonGia.Clear();
            }
        }

        private void display_ctpn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void display_ctpn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = display_ctpn.Rows[e.RowIndex];
                    txtMactpn.Text = row.Cells["ID_ChiTietPhieuNhap"].Value.ToString();
                    txtMactpn.Enabled = false;
                    txt_idpn.Text = row.Cells["ID_PhieuNhap"].Value.ToString();
                    txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                    txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                    txtMaThuoc.Text = row.Cells["ID_Thuoc"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private void suact_Click(object sender, EventArgs e)
        {
            try
            {
                int soLuong = int.Parse(txtSoLuong.Text);
                int idThuoc = int.Parse(txtMaThuoc.Text);
                decimal donGia = decimal.Parse(txtDonGia.Text);
                int idPhieuNhap = int.Parse(txt_idpn.Text);
                int idCTPN = int.Parse(txtMactpn.Text);
                ctpn.UpdateChiTietPhieuNhap(idCTPN, soLuong, idThuoc, idPhieuNhap,donGia);
                display_ctpn.DataSource = ctpn.GetAllCTPN();
                display_pn.DataSource = pn.GetAllPn();
                txtSoLuong.Clear();
                txtDonGia.Clear();
                txtMaThuoc.Clear();
                txtMactpn.Clear();
                txt_idpn.Clear();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Lỗi định dạng: Vui lòng nhập đúng dữ liệu cho các trường. " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoact_Click(object sender, EventArgs e)
        {
            try
            {
                int idctpn= int.Parse(txtMactpn.Text);
                int idpn = int.Parse(txt_idpn.Text);
                ctpn.DeleteChiTietPhieuNhap(idctpn,idpn);
                display_ctpn.DataSource = ctpn.GetAllCTPN();
                display_pn.DataSource = pn.GetAllPn();
                txtSoLuong.Clear();
                txtDonGia.Clear();
                txtMaThuoc.Clear();
                txtMactpn.Clear();
                txt_idpn.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá phiếu nhập: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int maPN = int.Parse(txt_tkpn.Text);
                display_pn.DataSource = pn.TkPN(maPN);
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int idctpn = int.Parse(txt_tkctpn.Text);
                display_ctpn.DataSource = ctpn.TkCTPN(idctpn);
                txtSoLuong.Clear();
                txtDonGia.Clear();
                txtMaThuoc.Clear();
                txtMactpn.Clear();
                txt_idpn.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
    }
}
