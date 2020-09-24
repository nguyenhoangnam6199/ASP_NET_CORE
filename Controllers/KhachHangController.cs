using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DoAn.Data;
using DoAn.Helpers;
using DoAn.Models;
using DoAn.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DoAn.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public KhachHangController(MyDbContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
         }
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(RegisterVM model)
        {

            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var khachHang = _mapper.Map<KhachHang>(model);
                        khachHang.MaNgauNhien = MyTools.GetRandom();
                        khachHang.MatKhau = model.MatKhau.ToSHA512Hash(khachHang.MaNgauNhien);
                        _context.Add(khachHang);
                        _context.SaveChanges();

                        //Add role for user
                        //default: customor
                        var userRole = new UserRole
                        {
                            RoleId = 4,
                            UserId = khachHang.MaKh
                        };
                        transaction.Commit();
                        return RedirectToAction("DangNhap");
                    }
                    catch
                    {
                        transaction.Rollback();
                        return View();
                    }
                }
            }
            return View();
        }

        #region LOGIN
        [HttpGet]
        public IActionResult DangNhap(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(LoginVM model, string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            string message = string.Empty;
            if (ModelState.IsValid)
            {
                var kh = _context.KhachHangs.SingleOrDefault(kh => kh.Email == model.Email);
                if (kh == null)
                {
                    ViewBag.message = "Tài khoản không tồn tại !";
                    return View();
                }
                if (!kh.DangHoatDong)
                {
                    ViewBag.message = "Tài khoản đang bị khóa";
                    return View();
                }
                if(kh.MatKhau!= model.MatKhau.ToSHA512Hash(kh.MaNgauNhien))
                {
                    ViewBag.message = "Sai thông tin đăng nhập !";
                    return View();
                }

                //set các claims
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, kh.HoTen),
                    new Claim(ClaimTypes.Email, kh.Email),
                    new Claim("MaNguoiDung",kh.MaKh.ToString())
                };

                var roles = _context.UserRoles.Where(r => r.UserId == kh.MaKh)
                    .Select(ur => ur.Role).ToList();

                foreach(var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                }

                var claimIdentity = new ClaimsIdentity(claims, "login");
                var claimPricipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync(claimPricipal);

                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    //nếu là admin, muốn chuyển tới trang nào đó mà ta thích thì chuyển cái redirect đến cái tương ứng
                    if(User.IsInRole("Quản trị"))
                    {
                        return Redirect("/admin/HangHoa");
                    }
                    return RedirectToAction(actionName: "Profile", controllerName: "KhachHang");
                }
            }
            ViewBag.message = message;
            return View();
        }

        #endregion

        [Authorize]
        public IActionResult Profile()
        {
            var user = User.Identities;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> DangXuat()
        {
           await HttpContext.SignOutAsync();
            return RedirectToAction("/");
        }

        public IActionResult HangDaMua()
        {
            return View();
        }
    }
}
