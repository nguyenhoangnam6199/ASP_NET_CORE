using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Buoi15_ASP_Dapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Buoi15_ASP_Dapper.Controllers
{
    public class LoaiController : Controller
    {
        private readonly string chuoiKetNoi;
        public LoaiController(IConfiguration config)
        {
            chuoiKetNoi = config.GetConnectionString("Data1");
        }

        //Hiển thị thông tin
        public async Task<IActionResult> Index()
        {
            using(var con = new SqlConnection(chuoiKetNoi))
            {
                var dsloai = await con.QueryAsync<Loai>("select *  from Loai");
                return View(dsloai.ToList());
            }
           
        }

        //Thêm thông tin
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loai loai)
        {
            using(var con = new SqlConnection(chuoiKetNoi))
            {
                var pa = new DynamicParameters();
                pa.Add("MaLoai", loai.MaLoai);
                pa.Add("TenLoai", loai.TenLoai);
                pa.Add("MoTa", loai.MoTa);
                pa.Add("Hinh", loai.Hinh);

                con.Execute("spThemLoai", pa, commandType: CommandType.StoredProcedure);
                return RedirectToAction("Index");
            }
        }

        //Sửa thông tin
        public IActionResult Edit(int id)
        {
            using(var con = new SqlConnection(chuoiKetNoi))
            {
                var edit = con.QueryFirst<Loai>("select * from Loai where MaLoai = @Ma"
                    , new { Ma = id });
                return View(edit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Loai loai)
        {
            using(var con = new SqlConnection(chuoiKetNoi))
            {
                var pa = new DynamicParameters();
                pa.Add("MaLoai", loai.MaLoai);
                pa.Add("TenLoai", loai.TenLoai);
                pa.Add("MoTa", loai.MoTa);
                pa.Add("Hinh", loai.Hinh);

                int rs = con.Execute("spSuaLoai", pa, commandType: CommandType.StoredProcedure);
                if (rs > 0)
                {
                    return RedirectToAction("Index");
                }
                else return RedirectToAction("Edit", new { id = loai.MaLoai });
            }
        }

        //Xóa thông tin
        public IActionResult Delete(int id)
        {
            using(var con = new SqlConnection(chuoiKetNoi))
            {
                var pa = new DynamicParameters();
                pa.Add("MaLoai", id);
                con.Execute("spXoaLoai", pa, commandType: CommandType.StoredProcedure);
                return RedirectToAction("Index");
            }
        }

        //Thông tin chi tiết
        public IActionResult Details(int id)
        {
            using(var con = new SqlConnection(chuoiKetNoi))
            {
                var detail = con.QueryFirst<Loai>("select * from Loai where MaLoai = @Ma"
                   , new { Ma = id });
                return View(detail);
            }
        }
    }
}
