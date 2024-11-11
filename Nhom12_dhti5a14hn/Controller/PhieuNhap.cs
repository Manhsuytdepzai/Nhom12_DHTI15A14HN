using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class PhieuNhap
    {
        public int ID_PhieuNhap { get; set; }
        public int? ID_NhaCungCap { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
    }
}
