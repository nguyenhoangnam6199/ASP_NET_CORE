using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi16_ASP_EFCore.Entities
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        [Display(Name = "Mã Loại")]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Tên Loại")]
        public string TenLoai { get; set; }
        [Display(Name = "Mô Tả")]
        public string MoTa { get; set; }
        [MaxLength(100)]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        public ICollection<HangHoa> HangHoas { get; set; }
        public Loai()
        {
            HangHoas = new HashSet<HangHoa>();
        }
    }
}
