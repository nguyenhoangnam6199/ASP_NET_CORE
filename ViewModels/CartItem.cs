using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.ViewModels
{
    public class CartItem
    {
        public Guid MaHangHoa { get; set; }
        public String TenHangHoa { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien => DonGia * SoLuong;
    }
}
