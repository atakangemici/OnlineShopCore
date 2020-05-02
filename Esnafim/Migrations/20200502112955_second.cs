using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Esnafim.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiparisDetaylari");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.CreateTable(
                name: "Sepet",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<int>(nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    musteri_id = table.Column<int>(nullable: false),
                    dukkan_id = table.Column<int>(nullable: false),
                    urun_id = table.Column<int>(nullable: false),
                    sepet_tutari = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<int>(nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    musteri_id = table.Column<int>(nullable: false),
                    dukkan_id = table.Column<int>(nullable: false),
                    urun_id = table.Column<int>(nullable: false),
                    siparis_tutari = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sepet");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<int>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    dukkan_id = table.Column<int>(nullable: false),
                    musteri_id = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    toplam_siparis_tutari = table.Column<double>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    updated_by = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDetaylari",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    adet_kg = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<int>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    fiyat = table.Column<double>(nullable: false),
                    siparis_id = table.Column<int>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    urun_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDetaylari", x => x.id);
                    table.ForeignKey(
                        name: "FK_SiparisDetaylari_Siparisler_siparis_id",
                        column: x => x.siparis_id,
                        principalTable: "Siparisler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetaylari_siparis_id",
                table: "SiparisDetaylari",
                column: "siparis_id");
        }
    }
}
