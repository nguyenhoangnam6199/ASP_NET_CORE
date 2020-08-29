using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Buoi7_ASP.Controllers
{
    public class Demo : Controller
    {
        //host/ABC
        [Route("ABC")]
        public int D1()
        {
            return new Random().Next();
        }

        [Route("[controller]/XYZ")]
        [Route("/XYZ")]
        public string D2()
        {
            return $"Chuỗi: {new Random().Next()}";
        }

        [Route("Say/{ten}")]    //  host/say/Nguyễn Hoàng Nam
        [Route("Hello-{ten}")]  //  host/Hello-Nguyễn Hoàng Nam
        public string Hello(string ten)
        {
            return $"Chào bạn {ten}";
        }

        [Route("{loai}/{hanghoa}.html")] // host/dien-thoai/iphone-7plus-132gb.html
        public string show(string loai, string hanghoa)
        {
            return $"{loai} ==> {hanghoa}";
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
