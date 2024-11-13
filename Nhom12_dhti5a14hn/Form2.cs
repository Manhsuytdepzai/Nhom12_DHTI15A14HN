using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    public partial class Form2 : Form
    {
        QuanLyThuoc thuoc = new QuanLyThuoc();
        public Form2()
        {
            InitializeComponent();
            display_qlt.DataSource = thuoc.GetAllThuoc();
        }

        private void LoadThuocData()
        {
            display_qlt.DataSource = thuoc.GetAllThuoc();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            
            txt_tenthuoc.Clear();
            txt_mancc.Clear();
            txt_loaithuoc.Clear();
            txt_gianhap.Clear();
            txt_giaban.Clear();
            dtp_nsx.Value = DateTime.Today;
            dtp_hsd.Value = DateTime.Today;
            txt_sl.Clear();
        }

        private void SearchThuoc()
        {
            string tenThuoc = txt_tktenthuoc.Text; 
            string loaiThuoc = txt_tkloaithuoc.Text; 

            display_qlt.DataSource = thuoc.SearchThuoc(tenThuoc, loaiThuoc);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(txt_tenthuoc.Text) ||
        string.IsNullOrEmpty(txt_mancc.Text) || string.IsNullOrEmpty(txt_loaithuoc.Text) ||
        string.IsNullOrEmpty(txt_gianhap.Text) || string.IsNullOrEmpty(txt_giaban.Text) ||
        string.IsNullOrEmpty(txt_sl.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            try
            {
                string maThuoc = txt_mathuoc.Text;
                string tenThuoc = txt_tenthuoc.Text;
                string maNhaCungCap = txt_mancc.Text;
                string loaiThuoc = txt_loaithuoc.Text;
                int giaNhap = int.Parse(txt_gianhap.Text);
                int giaBan = int.Parse(txt_giaban.Text);
                DateTime ngaySanXuat = dtp_nsx.Value;
                DateTime hanSuDung = dtp_hsd.Value;
                int soLuong = int.Parse(txt_sl.Text);

                thuoc.CreateQuanLyThuoc(maThuoc, tenThuoc, maNhaCungCap, loaiThuoc, giaNhap, giaBan, ngaySanXuat, hanSuDung, soLuong);

                MessageBox.Show("Thêm thuốc thành công!");
                ClearForm();
                LoadThuocData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void display_qlt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = display_qlt.Rows[e.RowIndex];
                txt_mathuoc.Text = row.Cells["MaThuoc"].Value.ToString();
                txt_tenthuoc.Text = row.Cells["TenThuoc"].Value.ToString();
                txt_mancc.Text = row.Cells["IDNhaCungCap"].Value.ToString();
                txt_loaithuoc.Text = row.Cells["LoaiThuoc"].Value.ToString();
                txt_gianhap.Text = row.Cells["GiaNhap"].Value.ToString();
                txt_giaban.Text = row.Cells["GiaBan"].Value.ToString();
                dtp_nsx.Value = (DateTime)row.Cells["NgaySanXuat"].Value;
                dtp_hsd.Value = (DateTime)row.Cells["HanSuDung"].Value;
                txt_sl.Text = row.Cells["SoLuong"].Value.ToString();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_mathuoc.Text) || string.IsNullOrEmpty(txt_tenthuoc.Text) ||
                string.IsNullOrEmpty(txt_mancc.Text) || string.IsNullOrEmpty(txt_loaithuoc.Text) ||
                string.IsNullOrEmpty(txt_gianhap.Text) || string.IsNullOrEmpty(txt_giaban.Text) ||
                string.IsNullOrEmpty(txt_sl.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                string maThuoc = txt_mathuoc.Text;
                string tenThuoc = txt_tenthuoc.Text;
                string maNhaCungCap = txt_mancc.Text;
                string loaiThuoc = txt_loaithuoc.Text;
                int giaNhap = int.Parse(txt_gianhap.Text);
                int giaBan = int.Parse(txt_giaban.Text);
                DateTime ngaySanXuat = dtp_nsx.Value;
                DateTime hanSuDung = dtp_hsd.Value;
                int soLuong = int.Parse(txt_sl.Text);

                // Gọi phương thức cập nhật thuốc
                thuoc.UpdateQuanLyThuoc(maThuoc, tenThuoc, maNhaCungCap, loaiThuoc, giaNhap, giaBan, ngaySanXuat, hanSuDung, soLuong);

                MessageBox.Show("Cập nhật thuốc thành công!");
                ClearForm();
                LoadThuocData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_mathuoc.Text))
            {
                MessageBox.Show("Vui lòng chọn mã thuốc để xóa!");
                return;
            }

            try
            {
                string maThuoc = txt_mathuoc.Text;

                // Gọi phương thức xóa thuốc
                thuoc.DeleteQuanLyThuoc(maThuoc);

                MessageBox.Show("Xóa thuốc thành công!");
                ClearForm();
                LoadThuocData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_TK_Click(object sender, EventArgs e)
        {
            SearchThuoc();
        }
    }
    
}

