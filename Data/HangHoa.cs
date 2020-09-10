using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Data
{
    public class HangHoa
    {
        [Display(Name ="Mã")]
        public Guid MaHangHoa { get; set; }
        [Display(Name = "Tên hàng hóa")]
        public string TenHangHoa { get; set; }
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }
        [Display(Name = "Giảm giá")]
        public byte GiamGia { get; set; }
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Chi tiết")]
        public string ChiTiet { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        

        public int? MaLoai { get; set; }
        [Display(Name = "Loại")]
        public Loai Loai { get; set; }

        public virtual ICollection<HangHoaTag> HangHoaTags { get; set; }

        public virtual ICollection<HinhPhu> HinhPhus { get; set; }

        public virtual ICollection<ReviewHangHoa> ReviewHangHoas { get; set; }
        [Display(Name = "Số sao bình chọn")]
        public double? DiemReview { get; set; }
    }

    public class ReviewHangHoa
    {
        public Guid Id { get; set; }
        public DateTime NgayReview { get; set; }
        public byte DiemReview { get; set; }
        public int TieuChi { get; set; }
        public Guid MaHangHoa { get; set; }

        [ForeignKey("TieuChi")]
        public Review Review { get; set; }
        [ForeignKey("MaHangHoa")]
        public HangHoa HangHoa { get; set; }
    }

    public class Review
    {
        public int Id { get; set; }
        public string Criteria { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<ReviewHangHoa> ReviewHangHoas { get; set; }
    }

    public class HinhPhu
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }

        public Guid MaHangHoa { get; set; }
        public HangHoa HangHoa { get; set; }
    }

    public class HangHoaTag
    {
        public string TagKey { get; set; }
        public Guid MaHangHoa { get; set; }

        public HangHoa HangHoa { get; set; }
        public Tag Tag { get; set; }
    }

    public class Tag
    {
        public string TagKey { get; set; }
        public string TagValue { get; set; }

        public virtual ICollection<HangHoaTag> HangHoaTags { get; set; }
    }
}
