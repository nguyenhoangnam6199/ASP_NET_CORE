using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi23_DemoReactAPI.Models
{
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }
        [MaxLength(100)]
        [Required]
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        [MaxLength(100)]
        public string Hinh { get; set; }
    }
}
