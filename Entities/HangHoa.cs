using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.Entities
{
    public partial class HangHoa
    {
        public HangHoa()
        {
            BanBe = new HashSet<BanBe>();
            ChiTietHd = new HashSet<ChiTietHd>();
            YeuThich = new HashSet<YeuThich>();
        }

        [Display(Name ="Mã")]
        public int MaHh { get; set; }
        [Display(Name = "Tên hàng hóa")]
        public string TenHh { get; set; }
        [Display(Name = "Loại")]
        public int MaLoai { get; set; }
        [Display(Name = "Đơn vị")]
        public string MoTaDonVi { get; set; }
        [Display(Name = "Đơn giá")]
        public double? DonGia { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Ngày sản xuất")]
        public DateTime NgaySx { get; set; }
        [Display(Name = "Giảm giá")]
        public double GiamGia { get; set; }
        [Display(Name = "Số lần xem")]
        public int SoLanXem { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "Nhà cung cấp")]
        public string MaNcc { get; set; }
        [Display(Name = "Loại")]
        public virtual Loai MaLoaiNavigation { get; set; }
        [Display(Name = "Nhà cung cấp")]
        public virtual NhaCungCap MaNccNavigation { get; set; }
        public virtual ICollection<BanBe> BanBe { get; set; }
        public virtual ICollection<ChiTietHd> ChiTietHd { get; set; }
        public virtual ICollection<YeuThich> YeuThich { get; set; }
    }
}
