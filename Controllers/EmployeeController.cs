using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi9_ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi9_ASP.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Employee emp)
        {
            if (emp is null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            return View();
        }

        [HttpPost]
        
        public IActionResult CheckEmployeeNo(string EmployeeNo)
        {
            var accounts = new List<string>()
            {
                "admin", "guest","abc"
            };
            if (accounts.Contains(EmployeeNo))
            {
                return Json("Mã này đã có !");
            }
            else return Json(true);
        }
    }
}
