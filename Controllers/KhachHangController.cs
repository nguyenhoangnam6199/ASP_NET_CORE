using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Buoi21_Identity.Models;
using Buoi21_Identity.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Buoi21_Identity.Controllers
{
    [Authorize]
    public class KhachHangController : Controller
    {
        private readonly eStore20Context _context;

        public KhachHangController(eStore20Context context)
        {
            _context = context;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kh);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login(string ReturnURL = null)
        {
            ViewBag.ReturnURL = ReturnURL;
            return View();
        }

        [HttpPost,AllowAnonymous]
        public async Task<IActionResult> Login(Login model, string ReturnURL = null)
        {
            ViewBag.ReturnURL = ReturnURL;
            var khachHang = _context.KhachHang.SingleOrDefault(kh => kh.MaKh == model.Username && kh.MatKhau == model.Password);
            if (khachHang != null)
            {
                //kiễm tra user theo Business Rule
                //đăng nhập thành công

                //khai báo các claims (đặc trưng cho user)
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, khachHang.HoTen),
                    new Claim(ClaimTypes.Email, khachHang.Email),
                    new Claim("MaKH", khachHang.MaKh),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Role, "Account")
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                var principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                if (Url.IsLocalUrl(ReturnURL))
                {
                    return Redirect(ReturnURL);
                }
                return RedirectToAction("Profile", "KhachHang");
            }
            ViewBag.Loi = "Sai thông tin đăng nhập";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "KhachHang");
        }

        [Authorize(Roles = "Account")]
        public IActionResult ThongKe()
        {
            return Content("Thống kê");
        }

        [Authorize(Roles = "Logistics")]
        public IActionResult DieuPhoiHang()
        {
            return Content("Vận chuyển");
        }

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
