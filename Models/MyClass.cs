using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi6_ASP.Models
{
    //Extension Method: Phương thức mở rộng là phương thức được thêm vào  lớp đã có mà ko cần kế thừa

    //Tên lớp định nghĩa method phải có chữ static
    //Tên method phải có chữ static
    //Tham số đầu tiên (để chỉ method này thuộc lớp nào) phải chứa từ khóa this

    public static class MyClass
    {
        public static int ToiTet(this DateTime date)
        {
            var tet = new DateTime(2021, 1, 1);
            return (tet - date).Days;
        }


        public static string Vietlotte(this string str, bool power)
        {
            int maxValue = power ? 55 : 45;
            Random rd = new Random();
            List<int> ds = new List<int>();
            for(int i=0; i<6; i++)
            {
                ds.Add(rd.Next(1, maxValue));
            }
            return string.Join(",", ds);
        }
    }
}
