using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi9_ASP.Models
{
    public class EmployeeInfo
    {
        [Display(Name ="Họ và tên")]
        [MinLength(5,ErrorMessage ="Tên ít nhất 5 kí tự")]
        public string FullName { get; set; }

        [Display(Name ="Tuổi")]
        [Required(ErrorMessage ="Không để trống !")]
        [Range(10, 60, ErrorMessage = "Tuổi phải từ 10 đến 60 !")]
        public int Age { get; set; }
    }
}
