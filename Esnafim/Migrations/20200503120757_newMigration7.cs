using Microsoft.EntityFrameworkCore.Migrations;

namespace Esnafim.Migrations
{
    public partial class newMigration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "odeme_tipi",
                table: "Siparis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "calisma_saatleri",
                table: "Dukkanlar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dukkan_telefon",
                table: "Dukkanlar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "odeme_tipi",
                table: "Siparis");

            migrationBuilder.DropColumn(
                name: "calisma_saatleri",
                table: "Dukkanlar");

            migrationBuilder.DropColumn(
                name: "dukkan_telefon",
                table: "Dukkanlar");
        }
    }
}
