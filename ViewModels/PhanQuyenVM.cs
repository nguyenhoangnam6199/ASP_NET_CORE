using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.ViewModels
{
    public class PhanQuyenVM
    {
        [Display(Name = "Mã")]
        public int MaKh { get; set; }
        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }

        [Display(Name ="Quản trị")]
        public bool QuanTri { get; set; }
        [Display(Name = "Bán hàng")]
        public bool BanHang { get; set; }
        [Display(Name = "Thủ kho")]
        public bool ThuKho { get; set; }
        [Display(Name = "Khách hàng")]
        public bool KhachHang { get; set; }
    }
}
