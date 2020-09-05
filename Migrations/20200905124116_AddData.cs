using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAn.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loai",
                columns: table => new
                {
                    MaLoai = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    MaLoaiCha = table.Column<int>(nullable: true),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai", x => x.MaLoai);
                    table.ForeignKey(
                        name: "FK_MaLoaiCha",
                        column: x => x.MaLoaiCha,
                        principalTable: "Loai",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Restrict,
                        onUpdate: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaLoaiCha",
                table: "Loai",
                column: "MaLoaiCha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loai");
        }
    }
}
