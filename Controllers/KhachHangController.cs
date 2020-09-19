using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoAn.Data;
using DoAn.Helpers;
using DoAn.Models;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                if (ModelState.IsValid)
                {
                    var khachHang = _mapper.Map<KhachHang>(model);
                    khachHang.MaNgauNhien = MyTools.GetRandom();
                    khachHang.MatKhau = model.MatKhau.ToSHA512Hash(khachHang.MaNgauNhien);
                    _context.Add(khachHang);
                    _context.SaveChanges();

                    return RedirectToAction("DangNhap");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}
