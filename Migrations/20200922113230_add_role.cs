using DoAn.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAn.Migrations
{
    public partial class add_role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Tạo user admin
            var randomKey = MyTools.GetRandom();
            var matKhau = "Admin@123";
            var sql = $@"
            DECLARE @MaNV int

            BEGIN TRY
            BEGIN TRANSACTION
            INSERT INTO KhachHang(HoTen, SoDienThoai, Email,MatKhau,DangHoatDong,MaNgauNhien) 
            VALUES(N'Quản trị hệ thống','120345145','admin@nhatnghe.com','{matKhau.ToSHA512Hash(randomKey)}',
            '1','{randomKey}')

            SET @MaNV = @@IDENTITY
            
            --SET QUYỀN
            INSERT INTO UserRole(RoleId, UserId) VALUES(1,@MaNV),(2,@MaNV),(3,@MaNV),(4,@MaNV)
            COMMIT TRANSACTION

            END TRY
            BEGIN CATCH 
                ROLLBACK TRANSACTION

            END CATCH

";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
