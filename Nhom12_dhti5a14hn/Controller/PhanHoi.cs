using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class PhanHoi
    {
        public int ID_PhanHoi { get; set; }
        public int? ID_DonHang { get; set; }
        public int? ID_KhachHang { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayPhanHoi { get; set; }
    }
}
