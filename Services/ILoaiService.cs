using Buoi15_ASP_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi15_ASP_Dapper.Services
{
    public interface ILoaiService
    {
        List<Loai> LayTatCa();
        Loai LayLoai(int maLoai);
        void CapNhat(Loai loai);
        void Them(Loai loai);
        void Xoa(int maLoai);
        List<Loai> Tim(string TuKhoa);
    }
}
