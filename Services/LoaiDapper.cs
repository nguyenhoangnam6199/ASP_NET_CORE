using Buoi14_ADONET.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi14_ADONET.Services
{
    public class LoaiDapper : ILoaiService
    {
        private string chuoiKetNoi;
        public LoaiDapper(IConfiguration config)
        {
            chuoiKetNoi = config.GetConnectionString("Database1");
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

                int rowEffect = con.Execute("spSuaLoai", pa, commandType: CommandType.StoredProcedure);

               
            }
            
        }

        public Loai LayLoai(int maLoai)
        {
            using (var con = new SqlConnection(chuoiKetNoi))
            {
                return con.QueryFirst<Loai>("select * from Loai where MaLoai=@Ma", new { Ma = maLoai});
               
            }
        }

        public List<Loai> LayTatCa()
        {
            using (var con = new SqlConnection(chuoiKetNoi))
            {
                return con.Query<Loai>("select * from Loai order by TenLoai").ToList();
                
            }
        }

        public void Them(Loai loai)
        {
            throw new NotImplementedException();
        }

        public List<Loai> Tim(string TuKhoa)
        {
            throw new NotImplementedException();
        }

        public void Xoa(int maLoai)
        {
            throw new NotImplementedException();
        }
    }
}
