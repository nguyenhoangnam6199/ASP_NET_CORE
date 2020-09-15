using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoAn.Data;
using DoAn.Helpers;
using DoAn.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace DoAn.Controllers
{
    public class GioHangController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public GioHangController(MyDbContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        public List<CartItem> Carts
        {
            get
            {
                var carts = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if(carts == null)
                {
                    carts = new List<CartItem>();
                }
                return carts;
            }
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCart(Guid id)
        {
            //lấy giỏ hàng hiện tại
            var myCart = Carts;
            //Kiểm tra hàng đã có trong giỏ
            var item = myCart.FirstOrDefault(item => item.MaHangHoa == id);
            if(item != null)
            {
                item.SoLuong += 1;
            }
            else
            {
                var hh = _context.HangHoas.FirstOrDefault(hh => hh.MaHangHoa == id);
                item = _mapper.Map<CartItem>(hh);
                item.SoLuong = 1;
                myCart.Add(item);

            }
            HttpContext.Session.Set("GioHang", myCart);
            return RedirectToAction("Index");
        }
    }
}
