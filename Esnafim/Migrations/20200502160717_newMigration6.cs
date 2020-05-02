using Microsoft.EntityFrameworkCore.Migrations;

namespace Esnafim.Migrations
{
    public partial class newMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "dukkan_adres",
                table: "Dukkanlar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "teslimat_suresi",
                table: "Dukkanlar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dukkan_adres",
                table: "Dukkanlar");

            migrationBuilder.DropColumn(
                name: "teslimat_suresi",
                table: "Dukkanlar");
        }
    }
}
