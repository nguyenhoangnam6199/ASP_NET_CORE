using System;
using System.Collections.Generic;

namespace Buoi22_WebAPI.ViewModels
{
    public partial class VHangHoa
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public int MaLoai { get; set; }
        public string MoTaDonVi { get; set; }
        public double? DonGia { get; set; }
        public string Hinh { get; set; }
        public DateTime NgaySx { get; set; }
        public double GiamGia { get; set; }
        public int SoLanXem { get; set; }
        public string MoTa { get; set; }
        public string MaNcc { get; set; }
        public string TenLoai { get; set; }
        public string TenNhaCungCap { get; set; }
    }
}
