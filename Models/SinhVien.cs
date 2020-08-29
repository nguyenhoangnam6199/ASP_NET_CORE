using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi9_ASP.Models
{
    public class SinhVien
    {
        [Display(Name ="Mã sinh viên")]
        public Guid MaSV { get; set; }

        [Display(Name ="Họ tên sinh viên")]
        [Required(ErrorMessage ="Họ tên sinh viên không được để trống ! ")]
        public string TenSV { get; set; }

        [Display(Name ="Ngày sinh")]
        [DataType(DataType.DateTime)]
        public DateTime NgaySinh { get; set; }

        [Display(Name ="Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống ! ")]
        [RegularExpression("0[3789][0-9]{8}", ErrorMessage ="Số điện thoại không đúng định dạng !")]
        public string SoDT { get; set; }

        [Display(Name ="Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng !")]
        public string Email { get; set; }

        [Display(Name = "Địa chỉ")] 
        [MinLength(3,ErrorMessage ="Địa chỉ không đúng định dạng !")]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [Display(Name = "Thông tin thêm")] 
        [DataType(DataType.MultilineText)] 
        public string Mota { get; set; }
    }
}
