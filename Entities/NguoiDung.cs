﻿using System;
using System.Collections.Generic;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.Entities
{
    public partial class NguoiDung
    {
        public string MaNd { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string Hinh { get; set; }
        public bool HieuLuc { get; set; }
        public int VaiTro { get; set; }
    }
}
