using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class DonHang
    {
        public int ID_DonHang { get; set; }
        public int? ID_KhachHang { get; set; }
        public DateTime NgayDatHang { get; set; }
        public decimal TongTien { get; set; }
    }
}
