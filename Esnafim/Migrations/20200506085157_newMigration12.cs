using Microsoft.EntityFrameworkCore.Migrations;

namespace Esnafim.Migrations
{
    public partial class newMigration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "adet_kg",
                table: "Urunler",
                newName: "kg");

            migrationBuilder.AddColumn<string>(
                name: "birim",
                table: "Urunler",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "adet_kg",
                table: "Sepet",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birim",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "adet_kg",
                table: "Sepet");

            migrationBuilder.RenameColumn(
                name: "kg",
                table: "Urunler",
                newName: "adet_kg");
        }
    }
}
