using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi15_ASP_Dapper.Models;
using Buoi15_ASP_Dapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Buoi15_ASP_Dapper.Controllers
{
    public class QuanLiLoaiController : Controller
    {
        private readonly ILoaiService temp;

        public QuanLiLoaiController(ILoaiService loai)
        {
            temp = loai;
        }

        //Xem bảng dữ liệu
        public IActionResult Index()
        {
            return View(temp.LayTatCa());
        }

        //Thêm dữ liệu
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loai loai)
        {
            try
            {
                temp.Them(loai);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Create", new { id = loai.MaLoai });
            }
        }

        //Sửa thông tin
        public IActionResult Edit(int id)
        {
            return View(temp.LayLoai(id));
        }

        [HttpPost]
        public IActionResult Edit(Loai loai)
        {
            try
            {
                temp.CapNhat(loai);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", new { id = loai.MaLoai });
            }
        }

        //Xóa thông tin
        public IActionResult Delete(int id)
        {
            temp.Xoa(id);
            return RedirectToAction("Index");
        }

        //Thông tin chi tiết
        public IActionResult Detail(int id)
        {
            return View(temp.LayLoai(id));
        }
    }
}
