using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn.Data;
using DoAn.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("admin")]
 //   [Authorize]
    public class QuanTriController : Controller
    {
        private readonly MyDbContext _context;
        public QuanTriController(MyDbContext ctx)
        {
            _context = ctx; 
        }
        public IActionResult Index()
        {
            //Cách khác để set quyền
            if(User.IsInRole("Quản trị"))
            {

            }
            return View();
        }

       //[Authorize(Roles = "Quản trị"), HttpGet]
        public IActionResult PhanQuyen()
        {
            var dsQuyen = _context.Roles.Select(p => p.RoleId).ToList();
            var data = _context.KhachHangs.Include(kh => kh.UserRoles)
                .Select(kh => new PhanQuyenVM
                {
                    MaKh = kh.MaKh,
                    HoTen = kh.HoTen,
                    QuanTri = kh.UserRoles.Any() && (kh.UserRoles.FirstOrDefault(ur => ur.RoleId == 1) != null),
                    BanHang = kh.UserRoles.Any() && (kh.UserRoles.FirstOrDefault(ur => ur.RoleId == 2) != null),
                    ThuKho = kh.UserRoles.Any() && (kh.UserRoles.FirstOrDefault(ur => ur.RoleId == 3) != null),
                    KhachHang = kh.UserRoles.Any() && (kh.UserRoles.FirstOrDefault(ur => ur.RoleId == 4) != null)
                });
            
            return View(data);
        }

        //[Authorize(Roles = "Quản trị"), HttpGet]
        [HttpPost]
        public IActionResult PhanQuyen(List<int> MaKh, List<bool> QuanTri)
        {
            return View();
        }
    }
}
