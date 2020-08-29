using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi7_ASP.Models
{
    public class HangHoa
    {
        [Display(Name ="Mã Hàng Hóa")]
        public Guid MaHh {get; set;}

        [Display(Name = "Tên Hàng Hóa")]
        public string TenHh { get; set; }

        [Display(Name = "Số lượng")]
        [Range(0, int.MaxValue)]
        public int Soluong { get; set; }

        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }


    }
}
