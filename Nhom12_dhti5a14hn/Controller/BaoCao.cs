using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom12_dhti5a14hn.Controller
{
    internal class BaoCao
    {
        public int ID_BaoCao { get; set; }
        public string TenBaoCao { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public int? ID_DonHang { get; set; }
    }
}
