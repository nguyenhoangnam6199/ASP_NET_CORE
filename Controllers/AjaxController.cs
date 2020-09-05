using Buoi17_18_19_EFCore_CRUD_AJAX.Entities;
using Buoi17_18_19_EFCore_CRUD_AJAX.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.Controllers
{
    public class AjaxController : Controller
    {
        private readonly eStore20Context _context;
        public const int ITEMS_PER_PAGE = 10;
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

        #region [JSON Search]
        [HttpGet]
        public IActionResult JsonSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JsonSearch(HangHoaJsonSearch model)
        {
            var data = _context.HangHoa.AsQueryable();
            if (!string.IsNullOrEmpty(model.TuKhoa))
            {
                data = data.Where(hh => hh.TenHh.Contains(model.TuKhoa));
            }
            if (model.GiaTu.HasValue)
            {
                data = data.Where(hh => hh.DonGia >= model.GiaTu.Value);
            }
            if (model.GiaDen.HasValue)
            {
                data = data.Where(hh => hh.DonGia <= model.GiaDen.Value);
            }

            var dshh = data.Select(hh => new
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                Hinh = hh.Hinh,
                DonGia = hh.DonGia.Value,
                Loai = hh.MaLoaiNavigation.TenLoai
            }).ToList();

            return Json(dshh);
        }
        #endregion

        #region [LoadMore]
        [HttpGet]
        public IActionResult LoadMore()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoadMore(int page = 1)
        {
            var data = _context.HangHoa.AsQueryable();
            var rs = data.Skip((page - 1) * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE)
                .Select(hh => new
                {
                    hh.MaHh,
                    hh.TenHh,
                    hh.Hinh,
                    DonGia = hh.DonGia.Value
                });

            var total = data.Count();
            var pageCount = Convert.ToInt32(Math.Ceiling(1.0 * total / ITEMS_PER_PAGE));

            return Json(new
            {
                data = rs,
                paging = new
                {
                    total = total,
                    totalPage = pageCount,
                    currentpage = page
                }
            });
        }
        #endregion
    }
}
