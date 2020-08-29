using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Buoi14_ADONET.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Buoi14_ADONET.Controllers
{
    public class QLLoaiController : Controller
    {
        //Dapper
        public string str1 = @"Data Source=DESKTOP-7KQC0UG\NAMPC;Initial Catalog=eStore20;Integrated Security=True";
       
        public async Task<IActionResult> Index()
        {
            using(var con = new SqlConnection(str1))
            {
                var ds = await con.QueryAsync<Loai>("select * from Loai order by TenLoai");
                return View(ds);
            }
           
        }

        public async Task<IActionResult> Edit(int id)
        {
            using (var con = new SqlConnection(str1))
            {
                var loai = await con.QueryFirstAsync<Loai>("select * from Loai where MaLoai=@Ma", new { Ma = id });
                return View(loai);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Loai loai)
        {
            using (var con = new SqlConnection(str1))
            {
                var pa = new DynamicParameters();
                pa.Add("MaLoai", loai.MaLoai);
                pa.Add("TenLoai", loai.TenLoai);
                pa.Add("MoTa", loai.MoTa);
                pa.Add("Hinh", loai.Hinh);

                int rowEffect = con.Execute("spSuaLoai",pa, commandType:CommandType.StoredProcedure);

                if (rowEffect > 0)
                {
                    return RedirectToAction("Index");
                }
                else return RedirectToAction("Edit",new { id = loai.MaLoai});
                //return Edit(loai.MaLoai)
            }
        }

        public IActionResult Delete(int id)
        {
            using (var con = new SqlConnection(str1))
            {
                var pa = new DynamicParameters();
                pa.Add("MaLoai",id);
                con.Execute("spXoaLoai", pa, commandType: CommandType.StoredProcedure);
                return RedirectToAction("Index");
            }
        }
    }
}
