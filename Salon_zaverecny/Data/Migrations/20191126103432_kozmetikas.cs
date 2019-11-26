using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salon_zaverecny.Data.Migrations
{
    public partial class kozmetikas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kozmetika",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meno = table.Column<string>(nullable: true),
                    Priezvisko = table.Column<string>(nullable: true),
                    Cislo = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Sluzba = table.Column<string>(nullable: true),
                    Potvrdenie = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kozmetika", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kozmetika");
        }
    }
}
