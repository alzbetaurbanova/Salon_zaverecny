using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salon_zaverecny.Data.Migrations
{
    public partial class masaz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Masaz",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Cislo",
                table: "Masaz",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Masaz",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Meno",
                table: "Masaz",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Potvrdenie",
                table: "Masaz",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Priezvisko",
                table: "Masaz",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sluzba",
                table: "Masaz",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Kadernictvo",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Cislo",
                table: "Kadernictvo",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Kadernictvo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Meno",
                table: "Kadernictvo",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Potvrdenie",
                table: "Kadernictvo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Priezvisko",
                table: "Kadernictvo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sluzba",
                table: "Kadernictvo",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Masaz",
                table: "Masaz",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kadernictvo",
                table: "Kadernictvo",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Masaz",
                table: "Masaz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kadernictvo",
                table: "Kadernictvo");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Masaz");

            migrationBuilder.DropColumn(
                name: "Cislo",
                table: "Masaz");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Masaz");

            migrationBuilder.DropColumn(
                name: "Meno",
                table: "Masaz");

            migrationBuilder.DropColumn(
                name: "Potvrdenie",
                table: "Masaz");

            migrationBuilder.DropColumn(
                name: "Priezvisko",
                table: "Masaz");

            migrationBuilder.DropColumn(
                name: "Sluzba",
                table: "Masaz");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Kadernictvo");

            migrationBuilder.DropColumn(
                name: "Cislo",
                table: "Kadernictvo");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Kadernictvo");

            migrationBuilder.DropColumn(
                name: "Meno",
                table: "Kadernictvo");

            migrationBuilder.DropColumn(
                name: "Potvrdenie",
                table: "Kadernictvo");

            migrationBuilder.DropColumn(
                name: "Priezvisko",
                table: "Kadernictvo");

            migrationBuilder.DropColumn(
                name: "Sluzba",
                table: "Kadernictvo");
        }
    }
}
