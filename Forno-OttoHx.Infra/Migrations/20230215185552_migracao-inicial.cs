using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forno_OttoHx.Infra.Migrations
{
    /// <inheritdoc />
    public partial class migracaoinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HoraInicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SegundosAquecimento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Potencia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forno", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forno");
        }
    }
}
