using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class ChiTietPhieuNhap
    {
        public int ID_ChiTietPhieuNhap { get; set; }
        public int? ID_PhieuNhap { get; set; }
        public int? ID_Thuoc { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}
