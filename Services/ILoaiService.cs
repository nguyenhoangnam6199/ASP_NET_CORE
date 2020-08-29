using Buoi14_ADONET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi14_ADONET.Services
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
