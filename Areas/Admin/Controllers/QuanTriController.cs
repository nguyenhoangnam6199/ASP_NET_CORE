using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn.Data;
using DoAn.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

      //  [Authorize(Roles = "Quản trị"), HttpGet]
        public IActionResult PhanQuyen()
        {
            var user = _context.KhachHangs.AsQueryable();

            var userRole = _context.UserRoles.AsQueryable();

            var viewModel = from kh in _context.Roles
                            join khq in _context.UserRoles
                            on kh.RoleId equals khq.RoleId
                            into mygroup
                            from p in mygroup.DefaultIfEmpty()
                            select new PhanQuyenVM
                            {
                                MaKh = p.UserId,
                                HoTen = p.User.HoTen,
                                BanHang = p.RoleId == 2,
                                QuanTri = p.RoleId == 1,
                                ThuKho = p.RoleId == 3,
                                KhachHang = p.RoleId == 4
                            };

            return Json(viewModel);
        }
    }
}
