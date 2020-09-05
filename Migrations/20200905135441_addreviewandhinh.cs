using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAn.Migrations
{
    public partial class addreviewandhinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DiemReview",
                table: "HangHoa",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HinhPhus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    MaHangHoa = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhPhus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HinhPhus_HangHoa_MaHangHoa",
                        column: x => x.MaHangHoa,
                        principalTable: "HangHoa",
                        principalColumn: "MaHangHoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Criteria = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewHangHoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NgayReview = table.Column<DateTime>(nullable: false),
                    DiemReview = table.Column<byte>(nullable: false),
                    TieuChi = table.Column<int>(nullable: false),
                    MaHangHoa = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewHangHoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewHangHoas_HangHoa_MaHangHoa",
                        column: x => x.MaHangHoa,
                        principalTable: "HangHoa",
                        principalColumn: "MaHangHoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewHangHoas_Reviews_TieuChi",
                        column: x => x.TieuChi,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HinhPhus_MaHangHoa",
                table: "HinhPhus",
                column: "MaHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewHangHoas_MaHangHoa",
                table: "ReviewHangHoas",
                column: "MaHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewHangHoas_TieuChi",
                table: "ReviewHangHoas",
                column: "TieuChi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HinhPhus");

            migrationBuilder.DropTable(
                name: "ReviewHangHoas");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropColumn(
                name: "DiemReview",
                table: "HangHoa");
        }
    }
}
