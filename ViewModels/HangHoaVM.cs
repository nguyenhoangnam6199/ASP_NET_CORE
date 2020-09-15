using DoAn.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.ViewModels
{
    public class HangHoaVM
    {
        [Display(Name = "Mã")]
        public Guid MaHangHoa { get; set; }
        [Display(Name = "Tên hàng hóa")]
        public string TenHangHoa { get; set; }
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }
        [Display(Name = "Giảm giá")]
        public byte GiamGia { get; set; }
        [Display(Name = "Giá bán")]
        public double GiaBan => DonGia * (100 - GiamGia) / 100.0;
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Loại")]
        public string TenLoai { get; set; }
    }
}
