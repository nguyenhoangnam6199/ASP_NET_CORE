using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi7_ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi7_ASP.Controllers
{
    public class HangHoaController : Controller
    {
        public static List<HangHoa> ds = new List<HangHoa>();
        public IActionResult Index()
        {
            return View(ds);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa hh)
        {
            hh.MaHh = Guid.NewGuid();
            ds.Add(hh);
            return RedirectToAction(actionName: "Index", controllerName: "HangHoa");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            //Tìm kiếm
            var hh = ds.SingleOrDefault(p => p.MaHh == Guid.Parse(id));
            if (hh != null)
            {
                return View(hh);
            }
            else return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(HangHoa hanghoa)
        {
            //Tìm kiếm
            var hh = ds.SingleOrDefault(p => p.MaHh == hanghoa.MaHh);
            if (hh != null)
            {
                hh.TenHh = hanghoa.TenHh;
                hh.Soluong = hanghoa.Soluong;
                hh.DonGia = hanghoa.DonGia;
                return RedirectToAction(actionName: "Index", controllerName: "HangHoa");
            }
            else return NotFound();
        }

        public IActionResult Delete(Guid id)
        {
            //Tìm kiếm
            var hh = ds.SingleOrDefault(p => p.MaHh == id);
            if (hh != null)
            {
                ds.Remove(hh);
                return RedirectToAction(actionName: "Index", controllerName: "HangHoa");
            }
            else return NotFound();
        }

        public IActionResult Detail(Guid id)
        {
            //Tìm kiếm
            var hh = ds.SingleOrDefault(p => p.MaHh == id);
            if (hh != null)
            {
                return View(hh);
                //return RedirectToAction(actionName: "Index", controllerName: "HangHoa");
            }
            else return NotFound();
        }

       


    }
}
