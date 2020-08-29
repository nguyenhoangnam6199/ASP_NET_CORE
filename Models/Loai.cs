using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi15_ASP_Dapper.Models
{
    public class Loai
    {
        [Display(Name = "Mã Loại")]
        public int MaLoai { get; set; }
        [Display(Name = "Tên Loại")]
        [Required(ErrorMessage = "Tên loại không được trống !")]
        public string TenLoai { get; set; }
        [Display(Name = "Mô Tả")]
        [Required(ErrorMessage = "Mô tả không được trống !")]
        public string MoTa { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
    }
}
