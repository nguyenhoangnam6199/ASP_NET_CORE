using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models
{
    public class RegisterVM
    {
        [MaxLength(100)]
        [Required]
        [Display(Name ="Họ Tên")]
        public string HoTen { get; set; }
        [MaxLength(20)]
        [Required]
        [Display(Name = "Số Điện Thoại")]
        public string SoDienThoai { get; set; }
        [MaxLength(100)]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }
        [Compare("MatKhau", ErrorMessage ="Mật khẩu không khớp")]
        [Display(Name = "Nhập lại mật khẩu")]
        public string NhapLaiMatKhau { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        
    }
}
