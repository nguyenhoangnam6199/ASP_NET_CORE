using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAn.Migrations
{
    public partial class addhanghoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    MaHangHoa = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    TenHangHoa = table.Column<string>(maxLength: 100, nullable: false),
                    DonGia = table.Column<double>(nullable: false),
                    GiamGia = table.Column<byte>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    Hinh = table.Column<string>(nullable: true),
                    ChiTiet = table.Column<string>(maxLength: 200, nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    MaLoai = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.MaHangHoa);
                    table.ForeignKey(
                        name: "FK_HangHoa_Loai_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "Loai",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.SetNull,
                        onUpdate: ReferentialAction.Cascade
                        );
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagKey = table.Column<string>(maxLength: 50, nullable: false),
                    TagValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagKey);
                });

            migrationBuilder.CreateTable(
                name: "HangHoaTag",
                columns: table => new
                {
                    TagKey = table.Column<string>(nullable: false),
                    MaHangHoa = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoaTag", x => new { x.TagKey, x.MaHangHoa });
                    table.ForeignKey(
                        name: "FK_HangHoaTag_HangHoa_MaHangHoa",
                        column: x => x.MaHangHoa,
                        principalTable: "HangHoa",
                        principalColumn: "MaHangHoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HangHoaTag_Tag_TagKey",
                        column: x => x.TagKey,
                        principalTable: "Tag",
                        principalColumn: "TagKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_TenHangHoa",
                table: "HangHoa",
                column: "TenHangHoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HangHoaTag_MaHangHoa",
                table: "HangHoaTag",
                column: "MaHangHoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoaTag");

            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
