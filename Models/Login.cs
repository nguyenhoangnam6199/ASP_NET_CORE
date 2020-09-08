using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi21_Identity.Models
{
    public class Login
    {

        [DisplayName("Tên đăng nhập")]
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
