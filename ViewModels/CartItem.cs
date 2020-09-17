using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.ViewModels
{
    public class CartItem
    {
        [Display(Name ="Mã")]
        public Guid MaHangHoa { get; set; }
        [Display(Name = "Hình")]
        public String Hinh { get; set; }
        [Display(Name = "Tên hàng hóa")]
        public String TenHangHoa { get; set; }
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
        [Display(Name = "Thành tiền")]
        public double ThanhTien => DonGia * SoLuong;
    }
}
