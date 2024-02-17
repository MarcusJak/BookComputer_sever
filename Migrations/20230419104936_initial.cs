using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication8.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dator_Hyrning",
                columns: table => new
                {
                    Dator_Hyrning_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dator_ID = table.Column<int>(type: "int", nullable: false),
                    Hyrnings_ID = table.Column<int>(type: "int", nullable: false),
                    anteckning = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dator_Hyrning", x => x.Dator_Hyrning_id);
                });

            migrationBuilder.CreateTable(
                name: "Datorer",
                columns: table => new
                {
                    Dator_ID = table.Column<int>(type: "int", nullable: false),
                    Typ = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Märke = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Modell = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Serienummer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PrisPerDag = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Datorer__C18FF85F2CAC74CE", x => x.Dator_ID);
                });

            migrationBuilder.CreateTable(
                name: "Hyrning",
                columns: table => new
                {
                    Hyrnings_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kund_ID = table.Column<int>(type: "int", nullable: true),
                    Startdatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Slutdatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Pris = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Paminelse = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hyrning__47E4174B2EAFED4F", x => x.Hyrnings_ID);
                });

            migrationBuilder.CreateTable(
                name: "Kunder",
                columns: table => new
                {
                    Kund_ID = table.Column<int>(type: "int", nullable: false),
                    Lösenord = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Företags_Namn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Adress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Telefonnummer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Epost = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kunder__7C0AD0F5EA6BAF3F", x => x.Kund_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dator_Hyrning");

            migrationBuilder.DropTable(
                name: "Datorer");

            migrationBuilder.DropTable(
                name: "Hyrning");

            migrationBuilder.DropTable(
                name: "Kunder");
        }
    }
}
