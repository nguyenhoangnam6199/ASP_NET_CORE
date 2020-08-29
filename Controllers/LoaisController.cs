using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi14_ADONET.Models;
using Buoi14_ADONET.Services;
using Microsoft.AspNetCore.Mvc;

namespace Buoi14_ADONET.Controllers
{
    public class LoaisController : Controller
    {
        private readonly ILoaiService Iloai;
        public LoaisController(ILoaiService loaiService)
        {
            Iloai = loaiService;
        }
        public IActionResult Index()
        {
            return View(Iloai.LayTatCa());
        }

        public IActionResult Edit(int id)
        {
            return View(Iloai.LayLoai(id));
        }

        [HttpPost]
        public IActionResult Edit(Loai loai)
        {
            try
            {
                Iloai.CapNhat(loai);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", new { id = loai.MaLoai });
            }
        }
    }
}
