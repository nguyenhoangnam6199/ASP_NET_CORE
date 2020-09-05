using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Data
{
    public class HangHoa
    {
        public Guid MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        public int SoLuong { get; set; }
        public string Hinh { get; set; }
        public string ChiTiet { get; set; }
        public string MoTa { get; set; }

        public int? MaLoai { get; set; }

        public Loai Loai { get; set; }

        public virtual ICollection<HangHoaTag> HangHoaTags { get; set; }

        public virtual ICollection<HinhPhu> HinhPhus { get; set; }

        public virtual ICollection<ReviewHangHoa> ReviewHangHoas { get; set; }

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
