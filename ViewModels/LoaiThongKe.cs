using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.ViewModels
{
    public class LoaiThongKe
    {
        [Display(Name ="Loại")]
        public string Loai { get; set; }
        [Display(Name = "Doanh thu")]
        public double DoanhThu { get; set; }
        [Display(Name = "Số HH")]
        public int SoHH { get; set; }
        [Display(Name = "Giá NN")]
        public double GiaNN { get; set; }
        [Display(Name = "Giá CN")]
        public double GiaCN { get; set; }
        [Display(Name = "Giá TB")]
        public double GiaTB { get; set; }
       
    }
}
