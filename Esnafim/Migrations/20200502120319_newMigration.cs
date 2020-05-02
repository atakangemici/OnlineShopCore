using Microsoft.EntityFrameworkCore.Migrations;

namespace Esnafim.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "urun_adi",
                table: "Sepet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "urun_fiyat",
                table: "Sepet",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "urun_adi",
                table: "Sepet");

            migrationBuilder.DropColumn(
                name: "urun_fiyat",
                table: "Sepet");
        }
    }
}
