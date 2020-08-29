using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using Buoi8_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Buoi8_ASP.Controllers
{
    public class SinhVIenController : Controller
    {
        public IActionResult DemoSync()
        {
            var demo = new Demo();
            var sw = new Stopwatch();
            sw.Start();
            demo.Test01();
            demo.Test02();
            demo.Test03();
            sw.Stop();
            return Content($"Chạy hết {sw.ElapsedMilliseconds} ms");
        }

        public async Task<IActionResult> DemoAsync()
        {
            var demo = new Demo();
            var sw = new Stopwatch();
            sw.Start();
            var x = demo.Test01Async();
            var y = demo.Test02Async();
            var z = demo.Test03Async();
            await x;  await y; await z;
            sw.Stop();
            return Content($"Chạy hết {sw.ElapsedMilliseconds} ms");
        }

        public IActionResult Index()
        {
            return View();
        }

        string textFile = "sinhvien.txt";
        string jsonFile = "sinhvien.json";

        //GetCurrentDirectory là lấy đúng đường dẫn cùng thư mục project tổng
        string TextFullPath => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", textFile);
        string JsonFullPath => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", jsonFile);

        string logFile => Path.Combine(Directory.GetCurrentDirectory(), "logFile.txt");

        [HttpPost]
        public IActionResult Index(SinhVien sinhVien, string GhiFile)
        {

           
            if(GhiFile == "Ghi file text")
            {
                var data = new string[]
                {
                    sinhVien.MaSinhVien,
                    sinhVien.HoTen,
                    sinhVien.DiemSo.ToString()
                };
                System.IO.File.WriteAllLines(TextFullPath, data);


            }
            else if(GhiFile == "Ghi file json")
            {
                //Chuyển object thành chuỗi json thì sử dụng SerializeObject
                var jsonString = JsonConvert.SerializeObject(sinhVien);
                // Ghi file Json
                System.IO.File.WriteAllText(JsonFullPath, jsonString);
            }
            return View("Index");
        }

        public IActionResult DocFile(string loai)
        {
            SinhVien sv = new SinhVien();
            try
            {
                
                if (loai == "text")
                {
                    var Textdata = System.IO.File.ReadAllLines(TextFullPath);
                    sv.MaSinhVien = Textdata[0];
                    sv.HoTen = Textdata[1];
                    if (double.TryParse(Textdata[2], out double tmp))
                    {
                        sv.DiemSo = tmp;
                    }

                    //sv.DiemSo = double.Parse(Textdata[2]);
                }
                else if (loai == "json")
                {
                    var Jsondata = System.IO.File.ReadAllText(JsonFullPath);
                    sv = JsonConvert.DeserializeObject<SinhVien>(Jsondata);
                }
            }
            catch (JsonReaderException ex)
            {
                using (var file = new StreamWriter(logFile, true))
                {
                    file.Write(ex.Message);
                }
            }
            catch(Exception ex)
            {
                using (var file = new StreamWriter(logFile, true))
                {
                    file.Write(ex.Message);
                }
            }
            
            return View("Index", sv);
        }
    }
}
