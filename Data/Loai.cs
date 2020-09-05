using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Data
{
    public class Loai
    {
        [Display(Name ="Mã loại")]
        public int MaLoai { get; set; }
        [Display(Name = "Tên loại")]
        public string TenLoai { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "Mã loại cha")]
        public int? MaLoaiCha { get; set; }

        public Loai LoaiCha { get; set; }

        public ICollection<HangHoa> HangHoas { get; set; }
    }
}
