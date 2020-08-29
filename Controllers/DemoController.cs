using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Buoi14_ADONET.Controllers
{
    public class DemoController : Controller
    {
        string chuoiKetNoi = @"Data Source=DESKTOP-7KQC0UG\NAMPC;Initial Catalog=eStore20;Integrated Security=True";
        public IActionResult GetData()
        {
            SqlConnection con = new SqlConnection(chuoiKetNoi);
            var sql = "select MaHH, TenHH, DonGia from HangHoa";

            //Đối với lệnh select ta sử dụng SqlDataAdapter và DataTable xong Fill(DataaTable) bằng
            //SqlDataAdapter
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, con);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            //Xử lí kết quả
            var sb = new StringBuilder();
            foreach (DataRow dr in dataTable.Rows)
            {
                //Thêm vô kết quả
                sb.AppendLine($"{dr["MaHH"]} - {dr["TenHH"]} - {dr["DonGia"]}");
            }
            return Content(sb.ToString());
        }

        public IActionResult ChangeData()
        {
            SqlConnection con = new SqlConnection(chuoiKetNoi);
            var sql = "insert into Loai(TenLoai,MoTa,Hinh)" +
                " values(N'Bánh kem Solice',N'Thơm ngon, béo ngậy', null)";

            //Đối với lệnh thay đổi dữ liệu ta sử dụng SqlCommand
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return Content($"{rs}");
        }

        public IActionResult DocJsonConfig()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("myappsettings.json");

            var config = builder.Build();

            var ten = config["Ten"];
            var web = config["KhoaHoc:Web"];
            var cisco = config["KhoaHoc:Cisco"];
            var conStr1 = config["ConnectionStrings:Database1"];

            return Json(true);
        }
    }
}
