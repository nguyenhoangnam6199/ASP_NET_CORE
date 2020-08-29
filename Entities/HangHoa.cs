using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi16_ASP_EFCore.Entities
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key] 
        [Display(Name ="Mã")]
        public int MaHH { get; set; }
        [Required] 
        [MaxLength(50)] 
        [Display(Name ="Tên Hàng Hóa")]
        public string TenHH { get; set; }
        [Display(Name ="Đơn Giá")]
        public double DonGia { get; set; }
        [Display(Name ="Số Lượng")]
        public int SoLuong { get; set; }
        [Display(Name ="Hình")]
        public string Hinh { get; set; }
        [Display(Name ="Mã Loại")]
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")] 
        public Loai Loai { get; set; }
    }
}
