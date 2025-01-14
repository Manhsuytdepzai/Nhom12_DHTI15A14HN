﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nhom12_dhti5a14hn
{
    public partial class Form2 : Form
    {
        private QuanLyThuoc thuoc = new QuanLyThuoc();

        public Form2()
        {
            InitializeComponent();
            display_qlt.DataSource = thuoc.GetAllThuoc();
            txt_giaban.Enabled = false;
            HighlightThuoc();
        }

        private void LoadThuocData()
        {
            display_qlt.DataSource = thuoc.GetAllThuoc();
            HighlightThuoc();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HighlightThuoc();
        }

        private void HighlightThuoc()
        {
            foreach (DataGridViewRow row in display_qlt.Rows)
            {
                if (row.Cells["SoLuong"].Value != null && int.TryParse(row.Cells["SoLuong"].Value.ToString(), out int soLuong) && soLuong == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (row.Cells["HanSuDung"].Value != null && DateTime.TryParse(row.Cells["HanSuDung"].Value.ToString(), out DateTime hanSuDung) && hanSuDung <= DateTime.Today)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void ClearForm()
        {
            txt_mathuoc.Clear();
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
            HighlightThuoc();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường dữ liệu
                if (string.IsNullOrEmpty(txt_tenthuoc.Text) ||
                    string.IsNullOrEmpty(txt_mancc.Text) ||
                    string.IsNullOrEmpty(txt_loaithuoc.Text) ||
                    string.IsNullOrEmpty(txt_gianhap.Text) ||
                    string.IsNullOrEmpty(txt_sl.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                string tenThuoc = txt_tenthuoc.Text;
                string maNhaCungCap = txt_mancc.Text;
                string loaiThuoc = txt_loaithuoc.Text;
                decimal giaNhap = decimal.Parse(txt_gianhap.Text);
                decimal giaBan = giaNhap * 1.15m;  // Tính giá bán = giá nhập + 15%
                DateTime ngaySanXuat = dtp_nsx.Value;
                DateTime hanSuDung = dtp_hsd.Value;
                int soLuong = int.Parse(txt_sl.Text);

                thuoc.CreateQuanLyThuoc(tenThuoc, maNhaCungCap, loaiThuoc, giaNhap, giaBan, ngaySanXuat, hanSuDung, soLuong);

                MessageBox.Show("Thêm thuốc thành công!");
                ClearForm();
                LoadThuocData();
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show("Lỗi định dạng dữ liệu: " + formatEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void display_qlt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = display_qlt.Rows[e.RowIndex];
                txt_mathuoc.Text = row.Cells["MaThuoc"].Value.ToString();
                txt_tenthuoc.Text = row.Cells["TenThuoc"].Value.ToString();
                txt_mancc.Text = row.Cells["ID_NhaCungCap"].Value.ToString();
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
                string.IsNullOrEmpty(txt_gianhap.Text) || string.IsNullOrEmpty(txt_sl.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                int maThuoc = int.Parse(txt_mathuoc.Text);
                string tenThuoc = txt_tenthuoc.Text;
                string maNhaCungCap = txt_mancc.Text;
                string loaiThuoc = txt_loaithuoc.Text;
                decimal giaNhap = decimal.Parse(txt_gianhap.Text);
                decimal giaBan = giaNhap * 1.15m;             // Giá bán = Giá nhập + 15%
                DateTime ngaySanXuat = dtp_nsx.Value;
                DateTime hanSuDung = dtp_hsd.Value;
                int soLuong = int.Parse(txt_sl.Text);

                thuoc.UpdateQuanLyThuoc(maThuoc, tenThuoc, maNhaCungCap, loaiThuoc, giaNhap, giaBan, ngaySanXuat, hanSuDung, soLuong);

                MessageBox.Show("Cập nhật thuốc thành công!");
                ClearForm();
                LoadThuocData();
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show("Lỗi định dạng dữ liệu: " + formatEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
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
                int maThuoc = int.Parse(txt_mathuoc.Text);

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

        private void reload_Click(object sender, EventArgs e)
        {
            ClearForm();
            display_qlt.DataSource = thuoc.GetAllThuoc();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            frm_Main fm = new frm_Main();
            fm.Show();
            this.Close();
        }
    }
}