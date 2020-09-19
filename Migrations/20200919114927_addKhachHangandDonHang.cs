using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAn.Migrations
{
    public partial class addKhachHangandDonHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKh = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    MatKhau = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    DangHoatDong = table.Column<bool>(nullable: false),
                    MaNgauNhien = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKh);
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaDh = table.Column<Guid>(nullable: false),
                    NgayDat = table.Column<DateTime>(nullable: false),
                    MaKh = table.Column<int>(nullable: true),
                    NguoiNhan = table.Column<string>(nullable: true),
                    DiaChiGiao = table.Column<string>(nullable: true),
                    TongTien = table.Column<double>(nullable: false),
                    TinhTrangDonHang = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaDh);
                    table.ForeignKey(
                        name: "FK_DonHang_KhachHang_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHang",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonHangChiTiet",
                columns: table => new
                {
                    MaDh = table.Column<Guid>(nullable: false),
                    MaHh = table.Column<Guid>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    DonGia = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangChiTiet", x => new { x.MaDh, x.MaHh });
                    table.ForeignKey(
                        name: "FK_DonHangChiTiet_DonHang_MaDh",
                        column: x => x.MaDh,
                        principalTable: "DonHang",
                        principalColumn: "MaDh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangChiTiet_HangHoa_MaHh",
                        column: x => x.MaHh,
                        principalTable: "HangHoa",
                        principalColumn: "MaHangHoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_MaKh",
                table: "DonHang",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangChiTiet_MaHh",
                table: "DonHangChiTiet",
                column: "MaHh");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_Email",
                table: "KhachHang",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHangChiTiet");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "KhachHang");
        }
    }
}
