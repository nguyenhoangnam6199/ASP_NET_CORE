using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.ViewModels
{
    public class HangHoaViewModel
    {
        [Display(Name = "Mã")]
        public int MaHh { get; set; }
        [Display(Name = "Tên hàng hóa")]
        public string TenHh { get; set; }
        [Display(Name = "Loại")]
        public string Loai { get; set; }
        [Display(Name = "Nhà cung cấp")]
        public string NhaCungCap { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }
    }
}
