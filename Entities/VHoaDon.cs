using System;
using System.Collections.Generic;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.Entities
{
    public partial class VHoaDon
    {
        public int MaCt { get; set; }
        public int MaHd { get; set; }
        public int MaHh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double GiamGia { get; set; }
        public string TenHh { get; set; }
        public string TenLoai { get; set; }
        public string TenNhaCungCap { get; set; }
    }
}
