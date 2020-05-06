using Microsoft.EntityFrameworkCore.Migrations;

namespace Esnafim.Migrations
{
    public partial class newMigration15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "kg",
                table: "Urunler",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "birim",
                table: "Sepet",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birim",
                table: "Sepet");

            migrationBuilder.AlterColumn<string>(
                name: "kg",
                table: "Urunler",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
