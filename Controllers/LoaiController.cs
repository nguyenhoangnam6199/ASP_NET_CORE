using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi14_ADONET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi14_ADONET.Controllers
{
    public class LoaiController : Controller
    {
        public static List<Loai> ds = new List<Loai>();
        public IActionResult Index()
        {
            return View(LoaiDataAccessLayer.getAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loai loai)
        {
            if (LoaiDataAccessLayer.Add(loai) == true)
            {
                return View();
            }
            else return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var loai = LoaiDataAccessLayer.GetLoai(id);
            return View(loai);
        }

        [HttpPost]
        public IActionResult Edit(Loai loai)
        {
            if (ModelState.IsValid)
            {
                LoaiDataAccessLayer.Edit(loai);
            }
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            //try
            //{
            //    LoaiDataAccessLayer.Delete(id);
            //    TempData["ThongBao"] = "Xóa thành công!";
            //}
            //catch (Exception ex)
            //{
            //    TempData["ThongBao"] = "Xóa không thành công!";
            //}

            //return RedirectToAction("Index");


            bool rs = LoaiDataAccessLayer.Delete(id);
            return Json(rs);
        }

    }
}
