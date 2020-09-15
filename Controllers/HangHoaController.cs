using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn.Data;
using DoAn.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace DoAn.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly MyDbContext context;
        public HangHoaController(MyDbContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index(int? MaLoai)
        {
            var data = context.HangHoas.AsQueryable();
            if (MaLoai.HasValue)
            {
                data = data.Where(hh => hh.MaLoai == MaLoai || hh.Loai.MaLoaiCha == MaLoai);

                //C2: Xác đinh danh sách loại cha
                //List<int> dsLoai = LayDanhSachLoai(MaLoai);
                //data = data.Where(hh => dsLoai.Contains(hh.MaLoai.Value));
            }

            var dshangHoa = data.Select(hh => new HangHoaVM
            {
                MaHangHoa = hh.MaHangHoa,
                TenHangHoa = hh.TenHangHoa,
                DonGia = hh.DonGia,
                GiamGia = hh.GiamGia,
                Hinh = hh.Hinh,
                MoTa = hh.MoTa,
                SoLuong = hh.SoLuong,
                TenLoai = hh.Loai.TenLoai
            }).ToList();
            return View(dshangHoa);
        }

        private List<int> LayDanhSachLoai(int? maLoai)
        {
            var danhsach = new List<int>();

            return danhsach;
        }

        public void DeQuyTimLoai(int maLoai, List<int> ds)
        {
            ds.Add(maLoai);
            var loaiCon = context.Loais.Where(lo => lo.MaLoaiCha == maLoai)
                .Select(lo=>lo.MaLoai)
                .ToList();
            while(loaiCon.Any())
            {
                var obj = loaiCon.First();
                loaiCon.Remove(obj);
                DeQuyTimLoai(obj, ds);
            }
        }
    }
}
