using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi6_ASP.Models
{
    public class HangHoa
    {
        //Field
        private string tenHh;
        private double donGia;

        //Sử dụng encapculation để tạo ra phương thức get, set cho các field
        public string TenHh {
            get => tenHh;
            set => tenHh = value;
        }
        public double DonGia {
            get => donGia;
            set => donGia = value;
        }

        //automatic Property
        public int SoLuong{ get; set; }

        //Property Read Only
        public bool ConHang
        {
            get { return SoLuong > 5; }
        }

        public bool DangCoHang => SoLuong > 5;

        public static int Dem { get; set; } = 0;

        public static string InDem() => $"{Dem}";

        #region [Hàm tạo-Constructor]
        public HangHoa()
        {
            Dem++;
        }
        public HangHoa(string ten, double gia, int soLuong)
        {
            Dem++;
            TenHh = ten;
            DonGia = gia;
            SoLuong = soLuong;
        }
        #endregion

        public string In()
        {
            return $"{TenHh} - {DonGia} = còn {SoLuong}";
        }

        //Ghi đè của hàm in
        public override string ToString()
        {
            //return base.ToString();
            return $"{TenHh} - {DonGia} = còn {SoLuong}";
        }

        
        

    }
}
