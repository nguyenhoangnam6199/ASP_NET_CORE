using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi3_ASP.Models
{
    public class HangHoa
    {
        public string TenHH { get; set; }

        public string Hinh { get; set; }

        public double DonGia { get; set; }

        public double GiamGia { get; set; }

        public double GiaBan => DonGia - (1 - GiamGia);


    }
}
