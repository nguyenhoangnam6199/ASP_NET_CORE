using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi17_18_19_EFCore_CRUD_AJAX.Entities;
using Buoi17_18_19_EFCore_CRUD_AJAX.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly eStore20Context _context;

        public ThongKeController(eStore20Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Thống kê
        public IActionResult LoaiThongKe()
        {
            var data = _context.ChiTietHd.GroupBy(cthd => cthd.MaHhNavigation.MaLoaiNavigation.TenLoai)
                .Select(g => new LoaiThongKe
                {
                    Loai = g.Key,
                    DoanhThu = g.Sum(cthd => cthd.SoLuong * cthd.DonGia * (1 - cthd.GiamGia)),
                    SoHH = g.Sum(cthd=>cthd.SoLuong),
                    GiaNN = g.Min(cthd => cthd.DonGia),
                    GiaCN = g.Max(cthd=>cthd.DonGia),
                    GiaTB = g.Average(cthd=>cthd.DonGia)
                }).ToList();

            return View(data);
        }

        public IActionResult ThangThongKe()
        {
            var data = _context.ChiTietHd.GroupBy(cthd => cthd.MaHdNavigation.NgayDat.Month)
                .Select(g => new ThangThongKe
                {
                    Thang = g.Key.ToString(),
                    DoanhThu = g.Sum(cthd => cthd.SoLuong * cthd.DonGia * (1 - cthd.GiamGia)),
                    SoHHDaBan = g.Sum(cthd => cthd.SoLuong),
                    GiaNN = g.Min(cthd => cthd.DonGia),
                    GiaCN = g.Max(ChiTietHd => ChiTietHd.DonGia),
                    GiaTB = g.Average(cthd => cthd.DonGia)
                });

            data = data.OrderBy(t => Convert.ToInt32(t.Thang));

            return View(data.ToList());
        }

        public IActionResult KhachHangThongKe()
        {
            var data = _context.ChiTietHd.GroupBy(cthd => new { 
                HoTen = cthd.MaHdNavigation.MaKhNavigation.HoTen
            })
                .Select(g => new KhachHangThongKe
                {
                    TenKh = g.Key.HoTen,
                    SoHhDaMua = g.Sum(p=>p.SoLuong),
                    TongTien = g.Sum(p=>p.SoLuong*p.DonGia*(1-p.GiamGia)),
                    GiaNN = g.Min(p=>p.DonGia),
                    GiaCN = g.Max(p=>p.DonGia),
                    GiaTB = g.Average(p=>p.DonGia)
                });
            data = data.OrderBy(t => t.SoHhDaMua);
            return View(data.ToList());
        }
    }
    #endregion
}
