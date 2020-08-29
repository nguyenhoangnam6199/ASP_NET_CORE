using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi9_ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi9_ASP.Controllers
{
    public class SinhVienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SinhVien sv)
        {
            if (sv is null)
            {
                throw new ArgumentNullException(nameof(sv));
            }

            return View();
        }
    }
}
