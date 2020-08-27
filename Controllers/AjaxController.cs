using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi17_18_19_EFCore_CRUD_AJAX.Entities;
using Buoi17_18_19_EFCore_CRUD_AJAX.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.Controllers
{
    public class AjaxController : Controller
    {
        private readonly eStore20Context _context;
        public AjaxController(eStore20Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ServerTime()
        {
            return Content(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"));
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View("SearchView");
        }

        [HttpPost]
        public IActionResult Search(string key)
        {
            var data = _context.HangHoa.AsQueryable();
            key = key.ToLower().Trim();
            if (!string.IsNullOrEmpty(key))
            {
                data = data.Where(hh => hh.TenHh.Contains(key));
            }
            var rs = data.Select(hh => new HangHoaTimKiem
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia.Value,
                GiamGia = hh.GiamGia,
                Loai = hh.MaLoaiNavigation.TenLoai,
                NgaySanXuat = hh.NgaySx
            });
            return PartialView(rs.ToList());
        }
    }
}
