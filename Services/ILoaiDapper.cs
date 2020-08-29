using Buoi15_ASP_Dapper.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi15_ASP_Dapper.Services
{
    public class ILoaiDapper : ILoaiService
    {
        private string chuoiKetNoi;

        public ILoaiDapper(IConfiguration config)
        {
            chuoiKetNoi = config.GetConnectionString("Data1");
        }
        public void CapNhat(Loai loai)
        {
            using (var con = new SqlConnection(chuoiKetNoi))
            {
                var pa = new Dapper.DynamicParameters();
                pa.Add("MaLoai", loai.MaLoai);
                pa.Add("TenLoai", loai.TenLoai);
                pa.Add("MoTa", loai.MoTa);
                pa.Add("Hinh", loai.Hinh);

                con.Execute("spSuaLoai", pa, commandType: CommandType.StoredProcedure);


            }
        }

        public Loai LayLoai(int maLoai)
        {
            using (var con = new SqlConnection(chuoiKetNoi))
            {
                return con.QueryFirst<Loai>("select * from Loai where MaLoai=@Ma", new { Ma = maLoai });

            }
        }

        public List<Loai> LayTatCa()
        {
            using (var con = new SqlConnection(chuoiKetNoi))
            {
                return con.Query<Loai>("select * from Loai order by MaLoai asc").ToList();

            }
        }

        public void Them(Loai loai)
        {
            using (var con = new SqlConnection(chuoiKetNoi))
            {
                var pa = new DynamicParameters();
                pa.Add("MaLoai", loai.MaLoai);
                pa.Add("TenLoai", loai.TenLoai);
                pa.Add("MoTa", loai.MoTa);
                pa.Add("Hinh", loai.Hinh);

                con.Execute("spThemLoai", pa, commandType: CommandType.StoredProcedure);
              
            }
        }

        public List<Loai> Tim(string TuKhoa)
        {
            //spTimLoai
            using (var con = new SqlConnection(chuoiKetNoi))
            {
                return con.Query<Loai>("select * from Loai where TenLoai like N'%'"+TuKhoa+"'%'").ToList();
            }
        }

        public void Xoa(int maLoai)
        {
            using(var con = new SqlConnection(chuoiKetNoi))
            {
                var pa = new Dapper.DynamicParameters();
                pa.Add("MaLoai", maLoai);
                con.Execute("spXoaLoai", pa, commandType: CommandType.StoredProcedure);
            }
      
        }
    }
}
