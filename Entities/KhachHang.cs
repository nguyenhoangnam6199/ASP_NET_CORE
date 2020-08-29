using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi16_ASP_EFCore.Entities
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key] 
        [MaxLength(20, ErrorMessage = "Tối đa 20 kí tự")] 
        [Display(Name ="Mã")]
        public string MaKH { get; set; }
        [Required] 
        [MaxLength(50, ErrorMessage = "Tối đa 50 kí tự")] 
        [Display(Name ="Tên Khách Hàng")]
        public string HoTen { get; set; }
        [MaxLength(50)]
        [Display(Name ="Số Điện Thoại")]
        public string DienThoai { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
    }
}
