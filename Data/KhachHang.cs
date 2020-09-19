using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Data
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public int MaKh { get; set; }
        [MaxLength(100)]
        [Required]
        public string HoTen { get; set; }
        [MaxLength(20)]
        [Required]
        public string SoDienThoai { get; set; }
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string DiaChi { get; set; }
        public bool DangHoatDong { get; set; }
        [MaxLength(10)]
        public string MaNgauNhien { get; set; }
    }

    public  class Role
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(50)]
        [Required]
        public string RoleName { get; set; }
        public bool IsSystem { get; set; }

    }
}
