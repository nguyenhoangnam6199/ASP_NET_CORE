using System;
using System.Collections.Generic;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.Entities
{
    public partial class Loai
    {
        public Loai()
        {
            HangHoa = new HashSet<HangHoa>();
        }

        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public string Hinh { get; set; }

        public virtual ICollection<HangHoa> HangHoa { get; set; }
    }
}
