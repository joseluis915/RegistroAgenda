using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroAgenda.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    ContactoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NickName = table.Column<string>(nullable: true),
                    NombreCompleto = table.Column<string>(nullable: true),
                    Telefono = table.Column<long>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.ContactoId);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContactoId = table.Column<int>(nullable: false),
                    TipoEvento = table.Column<string>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    Lugar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_Eventos_Contactos_ContactoId",
                        column: x => x.ContactoId,
                        principalTable: "Contactos",
                        principalColumn: "ContactoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_ContactoId",
                table: "Eventos",
                column: "ContactoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Contactos");
        }
    }
}
