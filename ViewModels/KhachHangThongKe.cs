using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.ViewModels
{
    public class KhachHangThongKe
    {
        [Display(Name ="Họ Tên")]
        public string TenKh { get; set; }
        [Display(Name = "Tổng số hàng")]
        public int SoHhDaMua { get; set; }
        [Display(Name = "Tổng tiền")]
        public double TongTien { get; set; }
        [Display(Name = "Giá SP thấp nhất")]
        public double GiaNN { get; set; }
        [Display(Name = "Giá SP cao nhất")]
        public double GiaCN { get; set; }
        [Display(Name = "Giá trung bình")]
        public double GiaTB { get; set; }
    }
}
