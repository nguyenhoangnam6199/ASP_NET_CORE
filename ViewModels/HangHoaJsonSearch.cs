using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.ViewModels
{
    public class HangHoaJsonSearch
    {
        [Display(Name ="Tên Hàng Hóa")]
        public string TuKhoa { get; set; }
        [Display(Name ="Giá Từ")]
        public double? GiaTu { get; set; }
        [Display(Name ="Giá Đến")]
        public double? GiaDen { get; set; }
    }
}
