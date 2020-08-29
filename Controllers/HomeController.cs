using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buoi8_ASP.Models;

namespace Buoi8_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Demo()
        {
            ViewBag.TenTrungTam = "Nhất Nghệ";
            ViewData["Email"] = "abc.com";
            ViewData["so dien thoai"] = 98994578947;
            return View();
        }

        public IActionResult Demo1()
        {
            ViewBag.ABC = "ABS XYZ";
            TempData["HoTen"] = "Nhat Nghe";

            return RedirectToAction(actionName:"Show");
        }

        public IActionResult Show()
        {
            var abc = ViewBag.ABC;
            var hoTen = TempData["HoTen"];
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
