using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Buoi9_ASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Buoi9_ASP.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private void  MoveUploadedFile(IFormFile myfile,  List<string> folder)
        {
            //folder.Add( Path.GetFileName(myfile.FileName));
            //cách 1
            var fullPath = Path.Combine(Directory.GetCurrentDirectory());
            for (int i = 0; i < folder.Count; i++)
            {
                fullPath = Path.Combine(fullPath, folder[i]);
            }
            //cách 2
            //var fullPath = Path.Combine(folder);

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            fullPath = Path.Combine(fullPath, Path.GetFileName(myfile.FileName));
            //Directory.CreateDirectory(path);
            using (var file = new FileStream(fullPath, FileMode.Create))
            {
                myfile.CopyTo(file);
            }
            
        }

        [HttpPost]
        public IActionResult SingleFile(IFormFile myfile)
        {
            //Directory.GetCurrentDirectory() lấy đường dẫn trực tiếp trong wwwroot
            //Directory.Exists(path);
            //Directory.CreateDirectory(path);
            //Cach 1
            //var uploadedFileName = Path.GetFileName(myfile.FileName);
            //var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", uploadedFileName);
            //if(myfile !=null && myfile.Length > 0)
            //{
            //    using (var file = new FileStream(fullPath, FileMode.Create))
            //    {
            //        myfile.CopyTo(file);
            //    }
            //}
            MoveUploadedFile(myfile, new List<string> { "wwwroot", "SingleFiles" });
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult MultipleFile(List<IFormFile> myfile)
        {
            foreach(var file in myfile)
            {
                MoveUploadedFile(file, new List<string> { "wwwroot", "Data1" });
            }
            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(EmployeeInfo emp)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("Lỗi","Hết Lỗi rồi !"); 
            }
            else
            {
                ModelState.AddModelError("Lỗi", "Vẫn còn lỗi rồi !");
            }
            return View();
        }
    }
}
