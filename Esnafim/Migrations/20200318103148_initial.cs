﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Esnafim.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EsnafUser",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<int>(nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    ad = table.Column<string>(nullable: true),
                    soyad = table.Column<string>(nullable: true),
                    adres = table.Column<string>(nullable: true),
                    telefon = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    sifre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsnafUser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<int>(nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    kategori_adi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MusteriUser",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<int>(nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    ad = table.Column<string>(nullable: true),
                    soyad = table.Column<string>(nullable: true),
                    adres = table.Column<string>(nullable: true),
                    telefon = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    sifre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriUser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sikayetler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<int>(nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    dukkan_id = table.Column<int>(nullable: false),
                    musteri_id = table.Column<int>(nullable: false),
                    mesaj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sikayetler", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
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
                    status = table.Column<string>(nullable: true),
                    toplam_siparis_tutari = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<int>(nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    urun_adi = table.Column<string>(nullable: true),
                    urun_kategori_id = table.Column<string>(nullable: true),
                    fiyat = table.Column<double>(nullable: false),
                    adet_kg = table.Column<string>(nullable: true),
                    KategoriId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.id);
                    table.ForeignKey(
                        name: "FK_Urunler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDetaylari",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<int>(nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    urun_id = table.Column<int>(nullable: false),
                    siparis_id = table.Column<int>(nullable: false),
                    fiyat = table.Column<double>(nullable: false),
                    adet_kg = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Dukkanlar",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<int>(nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    esnaf_user_id = table.Column<int>(nullable: false),
                    urun_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dukkanlar", x => x.id);
                    table.ForeignKey(
                        name: "FK_Dukkanlar_EsnafUser_esnaf_user_id",
                        column: x => x.esnaf_user_id,
                        principalTable: "EsnafUser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dukkanlar_Urunler_urun_id",
                        column: x => x.urun_id,
                        principalTable: "Urunler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dukkanlar_esnaf_user_id",
                table: "Dukkanlar",
                column: "esnaf_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Dukkanlar_urun_id",
                table: "Dukkanlar",
                column: "urun_id");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetaylari_siparis_id",
                table: "SiparisDetaylari",
                column: "siparis_id");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriId",
                table: "Urunler",
                column: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dukkanlar");

            migrationBuilder.DropTable(
                name: "MusteriUser");

            migrationBuilder.DropTable(
                name: "Sikayetler");

            migrationBuilder.DropTable(
                name: "SiparisDetaylari");

            migrationBuilder.DropTable(
                name: "EsnafUser");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
