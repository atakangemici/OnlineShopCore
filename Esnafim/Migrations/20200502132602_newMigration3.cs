using Microsoft.EntityFrameworkCore.Migrations;

namespace Esnafim.Migrations
{
    public partial class newMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "siparis_id",
                table: "Sepet",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "siparis_id",
                table: "Sepet");
        }
    }
}
