using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi9_ASP.Models
{
    public class Employee
    {
        public enum Gender
        {
            Nam,

            Nữ
        }

        [Display(Name ="ID")]
        public  Guid Id { get; set; }

        [Display(Name = "Mã nhân viên")]
        [Required(ErrorMessage ="Mã nhân viên không đúng định dạng !")]
        [StringLength(10,MinimumLength =5)]
        [Remote(action:"CheckEmployeeNo", controller:"Employee",ErrorMessage ="Mã đã tồn tại !")]
        public string EmployeeNo { get; set; }

        [Display(Name = "Tên nhân viên")]
        [Required(ErrorMessage = "Tên nhân viên không được trống !")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng !")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        [Phone]
        public string Phone { get; set; }

        [Url]
        public string Website { get; set; }

        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date)]
        [BirthDateCheck]
        public string NgaySinh { get; set; }

        [Display(Name = "Giới tính")]
        public Gender GioiTinh { get; set; }

        [Display(Name = "Lương")]
        [Range(0,double.MaxValue)]
        public double? Salary { get; set; } //Cho phép được trống (null)

        [Display(Name = "Bán thời gian ?")]
        public bool IsPartTime { get; set; }


        [Display(Name = "Số tài khoản")]
        [CreditCard]
        public string CreditCard { get; set; }

        [Display(Name = "Thông tin thêm")]
        [MaxLength(255)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
