using ASPCore.ADONETLab.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi14_ADONET.Models
{
    public class LoaiDataAccessLayer
    {
        public static List<Loai> getAll()
        {
            var ds = new List<Loai>();
            var dtLoai = DataProvider.SelectData("spLayTatCaLoai", CommandType.StoredProcedure, null);
            foreach(DataRow dr in dtLoai.Rows){
                ds.Add(new Loai
                {
                    MaLoai = Convert.ToInt32(dr["MaLoai"]),
                    TenLoai = dr["TenLoai"].ToString(),
                    MoTa = dr["MoTa"].ToString(),
                    Hinh = dr["Hinh"].ToString()
                });
            }
            return ds;
        }

        public static Loai GetLoai(int id)
        {
            var pa = new SqlParameter[1];
            pa[0] = new SqlParameter("MaLoai", id);
            DataTable dt = DataProvider.SelectData("spLayLoai", CommandType.StoredProcedure, pa);
            if (dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                return new Loai()
                {
                    MaLoai = Convert.ToInt32(dr["MaLoai"]),
                    TenLoai = dr["TenLoai"].ToString(),
                    MoTa = dr["MoTa"].ToString(),
                    Hinh = dr["Hinh"].ToString()
                };
            }
            else return null;
        }
        public static bool Add(Loai loai)
        {
            try
            {
                SqlParameter[] pa = new SqlParameter[4];
                pa[0] = new SqlParameter("MaLoai", SqlDbType.Int);
                pa[0].Direction = ParameterDirection.Output;
                pa[1] = new SqlParameter("TenLoai", loai.TenLoai);
                pa[2] = new SqlParameter("MoTa", loai.MoTa);
                pa[3] = new SqlParameter("Hinh", loai.Hinh);

                DataProvider.ExcuteNonQuery("spThemLoai", CommandType.StoredProcedure, pa);
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public static void Edit(Loai loai)
        {
            SqlParameter[] pa = new SqlParameter[4];
            pa[0] = new SqlParameter("MaLoai", loai.MaLoai);
            pa[1] = new SqlParameter("TenLoai", loai.TenLoai);
            pa[2] = new SqlParameter("MoTa", loai.MoTa);
            pa[3] = new SqlParameter("Hinh", loai.Hinh);

            DataProvider.ExcuteNonQuery("spSuaLoai", CommandType.StoredProcedure, pa);
        }

        public static bool Delete(int id)
        {
            try
            {
                SqlParameter[] pa = new SqlParameter[1];
                pa[0] = new SqlParameter("MaLoai", id);
                DataProvider.ExcuteNonQuery("spXoaLoai", CommandType.StoredProcedure, pa);
                return true;
            }
            catch
            {
                return false;
            }
           
        }
    }
}
