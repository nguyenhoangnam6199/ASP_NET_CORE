using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.ViewModels
{
    public class HangHoaTimKiem
    {
        [Display(Name ="Mã")]
        public int MaHh { get; set; }
        [Display(Name = "Tên hàng hóa")]
        public string TenHh { get; set; }
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }
        [Display(Name = "Giảm giá")]
        public double GiamGia { get; set; }
        [Display(Name = "Giá bán")]
        public double GiaBan => DonGia * (1 - GiamGia);
        [Display(Name = "Ngày sản xuất")]
        public DateTime NgaySanXuat { get; set; }
        [Display(Name = "Loại")]
        public string Loai { get; set; }
    }
}
